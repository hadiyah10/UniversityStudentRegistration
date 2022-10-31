using RepositoryClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicClassLibrary.BusinessLogic
{
    public interface ISubjectBL
    {
        List<Subjects> GetSubjects();
    }
}
