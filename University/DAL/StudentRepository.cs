using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DAL.Repository;
using University.DAL.DTO;

namespace University.DAL
{
    public class StudentRepository : IStudentRepository, IDisposable
    {
        private readonly UniversityDBContext _context;

        public StudentRepository(UniversityDBContext context)
        {
            this._context = context;
        }

        public List<Student> GetByCourseId(int courseId)
        {
            return _context.Students.Where(student => student.CourseId == courseId).ToList();
        }

        public void Insert(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public Student Find(int id)
        {
           return _context.Students.Find(id);
        }


        public void Update(Student student)
        {
            _context.Update(student);
            _context.SaveChanges();
        }

        public void Delete(Student student)
        {
            _context.Students.Remove(student);
            _context.SaveChanges();
        }

        public void RemoveRange()
        {
            _context.Students.RemoveRange(_context.Students);
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
