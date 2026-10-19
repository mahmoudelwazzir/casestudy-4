using System.ComponentModel.DataAnnotations;

namespace casestudy_4.DTO.CourseDTO
{
    public class GetAllCourseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int CreditHours { get; set; }
        public int TeacherId { get; set; }
    }
}
