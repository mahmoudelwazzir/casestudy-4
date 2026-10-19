using System.ComponentModel.DataAnnotations;

namespace casestudy_4.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Course title is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Course title must be between 3 and 100 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Credit hours is required.")]
        [Range(1, 6, ErrorMessage = "Credit hours must be between 1 and 6.")]
        public int CreditHours { get; set; }

        [Required(ErrorMessage = "TeacherId is required.")]
        public int TeacherId { get; set; }

        // Navigation properties
        public Teacher? Teacher { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}

