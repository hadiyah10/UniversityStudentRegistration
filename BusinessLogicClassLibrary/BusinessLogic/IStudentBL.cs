using RepositoryClassLibrary.Entities;
using RepositoryClassLibrary.Helper;
using RepositoryClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicClassLibrary.BusinessLogic
{
    public interface IStudentBL
    {
        Messages CreateStudent(Students Student);

        List<Results> GetStudentResultsByUserId(int id);
        List<FormattedModel> GetResultInFormat(int id);
        List<Students> GetStudentsSummary();

        List<Students> GetTopStudents();
    }
}
