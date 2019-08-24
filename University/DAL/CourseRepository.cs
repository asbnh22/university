using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using University.DAL.Repository;
using University.DAL.DTO;

namespace University.DAL
{
    internal class CourseRepository : ICourseRepository
    {
        private readonly UniversityDBContext _context;

        public CourseRepository(UniversityDBContext context)
        {
            this._context = context;
        }

        public List<Course> GetCoursesWithStudents()
        {
            return _context.Courses.Include(c => c.Students).ToList();
        }

        public List<Course> GetCourses()
        {
            return _context.Courses.ToList();
        }

        public void Save()
        {

            _context.SaveChanges();

        }

        public bool Disposed { get; private set; }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.Disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.Disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
