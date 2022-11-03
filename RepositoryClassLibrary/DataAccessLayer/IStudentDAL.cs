using RepositoryClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryClassLibrary.DataAccessLayer
{
    public interface IStudentDAL
    {
        bool CreateStudent(Students student);

        List<Results> GetStudentResultsByUserId(int id);

        List<Students> GetAllStudents();

        List<Students> GetStudentsSummary();

        List<Students> GetTopStudents();

        void UpdateStatus(Students student, int Status);

        Students GetStudentBy(string queryParameter, object queryValue);


    }
}
