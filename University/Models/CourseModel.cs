using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.Models
{
    public class CourseModel
    {
        public int Id { get; set; }

        [Column("CourseName")]
        [MaxLength(20)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<StudentModel> Students { get; set; }
    }
}
