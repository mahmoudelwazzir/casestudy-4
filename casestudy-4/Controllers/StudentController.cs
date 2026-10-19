using AutoMapper;
using casestudy_4.DTO.StudentDTO;
using casestudy_4.Models;
using casestudy_4.Repo.Reposatory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace casestudy_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public StudentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> CreateStudent(CreateStudentDTO dto)
        {
            var studentdto = _mapper.Map<Student>(dto);
            await _unitOfWork.Students.AddAsync(studentdto);
            return Created();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudent()
        {
            var student = await _unitOfWork.Students.GetAllAsync();
            var studentdto =  _mapper.Map<IEnumerable<GetAllStudentDTO>>(student);
            return Ok(studentdto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _unitOfWork.Students.GetByIdAsync(id);
            if(student == null) { return NotFound(""); }
            var studentdto = _mapper.Map<GetAllStudentDTO>(student);
            return Ok(studentdto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, CreateStudentDTO dto)
        {
            var student = await _unitOfWork.Students.GetByIdAsync(id);
            if (student == null) { return NotFound(); }
            _mapper.Map(dto, student);
            await _unitOfWork.Students.UpdateAsync(student);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _unitOfWork.Students.GetByIdAsync(id);
            if( student == null) { return NotFound(); }
            await _unitOfWork.Students.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
        [HttpGet("search")]
        public async Task<IActionResult> GetStudentByname(string name)
        {
            var student = await _unitOfWork.Students.GetStudentByNameAsync(name);
            var studentdto = _mapper.Map<IEnumerable<GetAllStudentDTO>>(student);
            return Ok(studentdto);
        }
        [HttpGet("filter")]
        public async Task<IActionResult> FilterByGender(string gender)
        {
            var student = await _unitOfWork.Students.FilterByGenderAsync(gender);
            var studentdto = _mapper.Map<IEnumerable<GetAllStudentDTO>>(student);
            return Ok(studentdto);
        }
        [HttpGet("pagination")]
        public async Task<IActionResult> GetStudentsWithPagination(int pageNumber, int pageSize)
        {
            var student = await _unitOfWork.Students.GetStudentsWithPaginationAsync(pageNumber, pageSize);
            var studentdto = _mapper.Map<IEnumerable<GetAllStudentDTO>>(student);
            return Ok(studentdto);
        }
    }
}
