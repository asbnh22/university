using System.Collections.Generic;

namespace University.DAL.DTO
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}