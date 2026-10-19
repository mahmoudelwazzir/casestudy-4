using AutoMapper;
using casestudy_4.DTO.StudentDTO;
using casestudy_4.Models;

namespace casestudy_4.Mapping
{
    public class studentProfile : Profile
    {
        public studentProfile()
        {
            CreateMap<Student, CreateStudentDTO>().ReverseMap();
            CreateMap<Student, GetAllStudentDTO>().ReverseMap();
        }
    }
}
