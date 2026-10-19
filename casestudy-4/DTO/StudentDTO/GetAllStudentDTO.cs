using System.ComponentModel.DataAnnotations;

namespace casestudy_4.DTO.StudentDTO
{
    public class GetAllStudentDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; } = string.Empty;
    }
}
