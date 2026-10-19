using AutoMapper;
using casestudy_4.DTO.StudentDTO;
using casestudy_4.DTO.TeacherDTO;
using casestudy_4.Models;
using casestudy_4.Repo.Reposatory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace casestudy_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TeacherController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTeacher()
        {
            var teacher = await _unitOfWork.Teachers.GetAllAsync();
            var teacherdto = _mapper.Map<IEnumerable<GetAllTeacherDTO>>(teacher);
            return Ok(teacherdto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTeacher(CreateTeacherDTO dto)
        {
            var teacher = _mapper.Map<Teacher>(dto);
            await _unitOfWork.Teachers.AddAsync(teacher);
            await _unitOfWork.SaveAsync();
            return Ok(teacher);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacher(int id, CreateTeacherDTO dto)
        {
            var teacher = await _unitOfWork.Teachers.GetByIdAsync(id);
            if(teacher == null)
            {
                return NotFound();
            }
            _mapper.Map(dto, teacher);
            await _unitOfWork.Teachers.UpdateAsync(teacher);
            await _unitOfWork.SaveAsync();
            return Ok(teacher);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var teacher = await _unitOfWork.Teachers.GetByIdAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            await _unitOfWork.Teachers.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
            return Ok();
        }

    }
}
