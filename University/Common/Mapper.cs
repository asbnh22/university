using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DAL.DTO;
using University.Models;

namespace University.Common
{
    public static class Mapper
    {
        public static Student ToDomain(StudentModel entity)
        {
            return new Student
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                CourseId = entity.CourseId.Value
            };
        }

        public static StudentModel ToView(Student entity)
        {
            return new StudentModel
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                CourseId = entity.CourseId
            };
        }


        public static Course ToDomain(CourseModel entity)
        {
            return new Course
            {
                Id = entity.Id,
                Name = entity.Name,
                Students = entity.Students.Select(ToDomain).ToList()
            };
        }

        public static CourseModel ToView(Course entity)
        {
            return new CourseModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Students = entity.Students.Select(ToView).ToList()
            };
        }
    }
}
