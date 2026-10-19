using casestudy_4.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace casestudy_4.DTO.EnrollmentDTO
{
    public class CreateAllEnrollmentDTO
    {

        [Required(ErrorMessage = "StudentId is required.")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "CourseId is required.")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "EnrollmentDate is required.")]
        public DateTime EnrollmentDate { get; set; }

        [Range(0, 100, ErrorMessage = "Grade must be between 0 and 100.")]
        [Column(TypeName = "decimal(5,2)")]
        public decimal? Grade { get; set; }
    }
}
