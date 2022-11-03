using RepositoryClassLibrary.Model;
using RepositoryClassLibrary.Entities;
using RepositoryClassLibrary.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Reflection;

namespace BusinessLogicClassLibrary.BusinessLogic
{
    public class ResultBL : IResultBL
    {
        IResultDAL ResultDAL;
        public ResultBL(IResultDAL resultDAL)
        {
            ResultDAL = resultDAL;
        }
        public List<Results> GetAllResults()
        {
            return this.ResultDAL.GetAllResults();   
        }
        public bool IsResultCreated(List<Results> resultList)
        {
            bool isResultCreated = false;
            int userId = (int)HttpContext.Current.Session["userId"]; 
            /*var duplicateSubjects = false;
              for (int i = 0; i < model.Results.Count; i++)
              {
                  var duplicate=model.Results.Count(result => result.Subject.SubjectId == model.Results[i].Subject.SubjectId);
                  if (duplicate > 1)
                  {
                      duplicateSubjects=true;
                      break;
                  }
              }
              if (duplicateSubjects)
              {
                  return new Response(false, "Same subjects were entered twice!");
              }
              }*/
            isResultCreated = this.ResultDAL.IsResultCreated(resultList, userId);
            return isResultCreated;                       
        }
    }
}
