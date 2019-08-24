using System;
using System.Collections.Generic;
using System.Linq;
using University.DAL.Repository;
using University.DAL.DTO;

namespace University.DAL
{
    public class StudentRepository : IStudentRepository
    {
        private readonly UniversityDBContext _context;

        public StudentRepository(UniversityDBContext context)
        {
            this._context = context;
        }

        public Student Find(int id)
        {
            return _context.Students.Find(id);
        }

        public void Insert(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
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

        public bool Disposed { get; set; }

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
