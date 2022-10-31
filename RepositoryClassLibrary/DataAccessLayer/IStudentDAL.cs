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
        Results GetStudentResultsByUserId(int id);
        List<Students> GetAllStudents();
        void UpdateStatus(Students student, int Status);  
        List<Students> GetTopFifteenStudents();
     
    }
}
