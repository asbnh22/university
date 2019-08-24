using System;
using System.Collections.Generic;
using University.DAL.DTO;

namespace University.DAL.Repository
{
    public interface IStudentRepository : IDisposable
    {
        List<Student> GetByCourseId(int courseId);
        void Insert(Student student);

        Student Find(int id);

        void Update(Student student);
        void Delete(Student student);
        void RemoveRange();
    }
}
