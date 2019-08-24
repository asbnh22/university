using System;
using System.Collections.Generic;
using University.DAL.DTO;

namespace University.DAL.Repository
{
    public interface IStudentRepository : IDisposable
    {
        Student Find(int id);
        void Insert(Student student);
        void Update(Student student);
        void Delete(Student student);
    }
}
