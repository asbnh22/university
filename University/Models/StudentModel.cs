using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.Models
{
    public class StudentModel
    {
        public int Id { get; set; }

        [MaxLength(20)]
        [Required(ErrorMessage = "Имя студента не может быть пустым")]
        public string FirstName { get; set; }

        [MaxLength(20)]
        [Required(ErrorMessage = "Фамилия студента не может быть пустой")]
        public string LastName { get; set; }

        public int? CourseId { get; set; }

       // [ForeignKey("CourseId")]
        public virtual CourseModel Course { get; set; }
    }
}
