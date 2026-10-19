using AutoMapper;
using casestudy_4.DTO.CourseDTO;
using casestudy_4.Models;
using casestudy_4.Repo.Reposatory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace casestudy_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        public CourseController(IUnitOfWork unitofwork, IMapper mapper)
        {
            _unitofwork = unitofwork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCourse()
        {
            var course = await _unitofwork.Courses.GetAllAsync();
            var coursedto = _mapper.Map<IEnumerable<GetAllCourseDTO>>(course);
            return Ok(coursedto);
        }
        //sdgfdsgfdsgfdsgd
        [HttpPost]
        public async Task<IActionResult> CreateCourse(CreateCourseDTO dto)
        {
            var course = _mapper.Map<Course>(dto);
            await _unitofwork.Courses.AddAsync(course);
            await _unitofwork.SaveAsync();
            return Ok(course);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, CreateCourseDTO dto)
        {
            var course = await _unitofwork.Courses.GetByIdAsync(id);
            if(course == null)
            {
                return NotFound();
            }
            _mapper.Map(dto, course);
            await _unitofwork.Courses.UpdateAsync(course);
            await _unitofwork.SaveAsync();
            return Ok(course);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var  course = await _unitofwork.Courses.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            await _unitofwork.Courses.DeleteAsync(id);
            await _unitofwork.SaveAsync();
            return Ok(course);
        }
        [HttpGet("search")]
        public async Task<IActionResult> SearchByTitle(string title)
        {
            var courses = await _unitofwork.Courses.GetCourseByTitelAsync(title);
            return Ok(courses);
        }
        [HttpGet("FilterByCreditHours")]
        public async Task<IActionResult> FilterCourseByCreditHours(int creditHours)
        {
            var courses = await _unitofwork.Courses.FilterCourse(creditHours);
            return Ok(courses);
        }

    }
}
