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
        public bool IsResultCreated(List<Results> resultList)
        {
            bool isResultCreated = false;
            int userId = (int)HttpContext.Current.Session["user"];
          /*
            for (int i = 0; i < resultList.Count; i++)
            {
                var result = resultList[i];
                for (int j = i + 1; j < resultList.Count; j++)
                {
                    if (result.SubjectId == resultList[j].SubjectId)
                    {
                        return new Response(false, "Same subjects were entered twice!");
                    }
                }
            }*/

            isResultCreated = this.ResultDAL.IsResultCreated(resultList, userId);
            
            return isResultCreated;                       
        }
    }
}
