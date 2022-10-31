using RepositoryClassLibrary.Entities;
using RepositoryClassLibrary.Helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryClassLibrary.DataAccessLayer
{
    public class ResultDAL : IResultDAL
    {
        private const string CreateResultQuery = @"Insert into Results 
        ([SubjectId], [Grade], [StudentId])
        Values (@SubjectId, @Grade, @StudentId)";

        DatabaseHelper DatabaseHelper; 
        public ResultDAL()
        {
            this.DatabaseHelper = new DatabaseHelper();
        }
        public bool IsResultCreated(List<Results> resultList)
        {
            bool isResultCreated = false;

            List<SqlParameter> parameters = new List<SqlParameter>();
       
            foreach (var result in resultList)
            {
                parameters.Add(new SqlParameter("@SubjectId", result.SubjectId));
                parameters.Add(new SqlParameter("@Grade", result.Grade));
                parameters.Add(new SqlParameter("@StudentId", result.StudentId));
                isResultCreated = DatabaseHelper.InsertUpdateData(CreateResultQuery, parameters);
            }
            return isResultCreated;

        }
    }
}
