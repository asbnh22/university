using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DAL.Repository;
using University.DAL.DTO;

namespace University.DAL
{
    internal class CourseRepository : ICourseRepository, IDisposable
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

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
