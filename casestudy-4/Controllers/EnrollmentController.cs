using AutoMapper;
using Azure.Core;
using casestudy_4.Data;
using casestudy_4.DTO.EnrollmentDTO;
using casestudy_4.Models;
using casestudy_4.Repo.Reposatory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace casestudy_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitofWork;
        private readonly IMapper _mapper;
        public EnrollmentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitofWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> CreateEnrollmentSudent(CreateAllEnrollmentDTO dto)
        {
            var student = await _unitofWork.Students.GetByIdAsync(dto.StudentId);
            if (student == null)
            {
                return NotFound($"Student with ID {dto.StudentId} not found.");
            }
            var course = await _unitofWork.Courses.GetByIdAsync(dto.CourseId);
            if(course == null)
            {
                return NotFound($"Course with ID {dto.CourseId} not found.");
            }
            var enrollment = await _unitofWork.Enrollments.GetAllAsync();
            var isAlreadyEnrolled = enrollment.Any(e => e.StudentId == dto.StudentId && e.CourseId == dto.CourseId);
            if (isAlreadyEnrolled)
            {
                return BadRequest("Student is already enrolled in this course.");
            }
            var newEnrollment = _mapper.Map<Enrollment>(dto);
            if(newEnrollment.EnrollmentDate == default)
            {
                newEnrollment.EnrollmentDate = DateTime.UtcNow;
            }
            await _unitofWork.Enrollments.AddAsync(newEnrollment);
            await _unitofWork.SaveAsync();
            return Ok(newEnrollment);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnrollment(int id)
        {
            var enrollment = await _unitofWork.Enrollments.GetByIdAsync(id);
            if(enrollment == null)
            {
                return NotFound($"Enrollment with ID {id} not found.");
            }
            await _unitofWork.Enrollments.DeleteAsync(id);
            await _unitofWork.SaveAsync();
            return Ok();
        }
    }
}
    