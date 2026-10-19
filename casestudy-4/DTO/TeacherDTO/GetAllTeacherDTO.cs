using System.ComponentModel.DataAnnotations;

namespace casestudy_4.DTO.TeacherDTO
{
    public class GetAllTeacherDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime HireDate { get; set; }
    }
}
