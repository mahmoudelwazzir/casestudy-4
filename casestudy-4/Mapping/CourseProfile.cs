using AutoMapper;
using casestudy_4.DTO.CourseDTO;
using casestudy_4.Models;

namespace casestudy_4.Mapping
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, GetAllCourseDTO>().ReverseMap();
        }
    }
}
