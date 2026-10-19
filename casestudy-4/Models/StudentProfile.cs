using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace casestudy_4.Models
{
    public class StudentProfile
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [MaxLength(200, ErrorMessage = "Address cannot exceed 200 characters.")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Parent phone is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string ParentPhone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Emergency contact is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string EmergencyContact { get; set; } = string.Empty;

        // Foreign key to Student (One-to-One)
        [Required]
        public int StudentId { get; set; }

        // Navigation property
        public Student? Student { get; set; }
    }
}

