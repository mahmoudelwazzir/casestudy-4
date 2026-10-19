using AutoMapper;
using casestudy_4.DTO.TeacherDTO;
using casestudy_4.Models;

namespace casestudy_4.Mapping
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<Teacher, GetAllTeacherDTO>().ReverseMap();
        }
    }
}
