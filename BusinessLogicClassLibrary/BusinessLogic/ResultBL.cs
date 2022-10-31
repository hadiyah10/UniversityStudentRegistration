using RepositoryClassLibrary.Model;
using RepositoryClassLibrary.Entities;
using RepositoryClassLibrary.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            bool IsResultCreated = false;
            foreach(Results result in resultList)
            { 
                IsResultCreated = this.ResultDAL.IsResultCreated(resultList);
            }
            return IsResultCreated; 
        }
    }
}
