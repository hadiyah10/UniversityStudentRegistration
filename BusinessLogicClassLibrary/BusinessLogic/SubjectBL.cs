using RepositoryClassLibrary.Entities;
using RepositoryClassLibrary.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicClassLibrary.BusinessLogic
{
    public class SubjectBL : ISubjectBL
    {
        public ISubjectDAL SubjectDal;
        public SubjectBL(ISubjectDAL subjectDAL)
        {
            SubjectDal = subjectDAL;
        }
        public List<Subjects> GetSubjects()
        {
            return this.SubjectDal.GetSubjects();
        }
    }
}
