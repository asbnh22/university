using System;
using System.Collections.Generic;
using University.DAL.DTO;

namespace University.DAL.Repository
{
    public interface ICourseRepository : IDisposable
    {
        List<Course> GetCoursesWithStudents();
        List<Course> GetCourses();
    }
}
