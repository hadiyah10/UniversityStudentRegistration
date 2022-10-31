using RepositoryClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicClassLibrary.BusinessLogic
{
    public interface IStudentBL
    {
        bool CreateStudent(Students Student);
        Results GetStudentResultsByUserId(int userId);
    }
}
