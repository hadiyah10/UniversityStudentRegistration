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
/*        public bool isresultcreated(list<results> resultlist)
        {
            bool isresultcreated = false;

            list<sqlparameter> parameters = new list<sqlparameter>();

            foreach (var result in resultlist)
            {
                parameters.add(new sqlparameter("@subjectid", result.subjectid));
                parameters.add(new sqlparameter("@grade", result.grade));
                parameters.add(new sqlparameter("@studentid",))
                isresultcreated = databasehelper.insertupdatedata(createresultquery, parameters);
            }
            return isresultcreated;

        }*/

        public bool IsResultCreated(List<Results> resultList, int userId)
        {
            bool isResultCreated = false;

            foreach (var result in resultList)
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@SubjectId",result.SubjectId ));
                parameters.Add(new SqlParameter("@Grade", result.Grade));
                parameters.Add(new SqlParameter("@StudentId", userId));
                isResultCreated = DatabaseHelper.InsertUpdateData(CreateResultQuery, parameters);
            }

            return isResultCreated;

        }
    }
}
