using System.ComponentModel.DataAnnotations;

namespace casestudy_4.DTO.CourseDTO
{
    public class CreateCourseDTO
    {
        [Required(ErrorMessage = "Course title is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Course title must be between 3 and 100 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Credit hours is required.")]
        [Range(1, 6, ErrorMessage = "Credit hours must be between 1 and 6.")]
        public int CreditHours { get; set; }
    }
}
