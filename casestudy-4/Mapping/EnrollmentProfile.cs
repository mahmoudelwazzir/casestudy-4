using AutoMapper;
using casestudy_4.DTO.EnrollmentDTO;
using casestudy_4.Models;

namespace casestudy_4.Mapping
{
    public class EnrollmentProfile : Profile
    {
        public EnrollmentProfile()
        {
            CreateMap<Enrollment, CreateAllEnrollmentDTO>().ReverseMap();
            CreateMap<Enrollment, GetAllEnrollmentDTO>().ReverseMap();
        }
    }
}
