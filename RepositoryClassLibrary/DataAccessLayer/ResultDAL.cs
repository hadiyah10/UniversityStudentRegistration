using RepositoryClassLibrary.Entities;
using RepositoryClassLibrary.Helper;
using RepositoryClassLibrary.SQLQueries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RepositoryClassLibrary.DataAccessLayer
{
    public class ResultDAL : IResultDAL
    {
        DatabaseHelper DatabaseHelper;
        SqlQueries SqlQueries;
        public ResultDAL()
        {
            this.DatabaseHelper = new DatabaseHelper();
            SqlQueries = new SqlQueries();
        }

        public List<Results> GetAllResults()
        {
            List<Results> ResultList = new List<Results>();
            DataTable dt = DatabaseHelper.GetData(SqlQueries.GetAllResultsQuery());
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Results Result = new Results();
                    Result.StudentId = (int)row["StudentId"];
                    Result.ResultId = (int)row["ResultId"];
                    Result.Grade = row["Grade"].ToString();
                    Result.Grades = (Grades)Enum.Parse(typeof(Grades), Result.Grade);
                    Subjects subject = new Subjects();
                    subject.SubjectId = (int)row["SubjectId"];
                    subject.SubjectName = row["SubjectName"].ToString();
                    Result.Subject = subject;
                    ResultList.Add(Result);
                }
            }
            return ResultList;
        }

        public bool IsResultCreated(List<Results> resultList, int userId)
        {
            bool isResultCreated = false;
            foreach (var result in resultList)
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@SubjectId",result.Subject.SubjectId ));
                parameters.Add(new SqlParameter("@Grade", result.Grades.ToString()));
                parameters.Add(new SqlParameter("@StudentId", userId));
                isResultCreated = DatabaseHelper.InsertUpdateData(SqlQueries.GetCreateResultQuery(), parameters);
            }
            return isResultCreated;
        }

        private int GetPointFromGrade(string Grade) {
            int value =0;
            switch (Grade) {
                case "A":
                    value = 10;
                    break;
                case "B":
                    value = 8;
                    break;
                case "C":
                    value = 6;
                    break;
                case "D":
                    value = 4;
                    break;
                case "E":
                    value = 2;
                    break;
                case "F":
                    value = 0;
                    break;
                default:
                    break;
            }

            return value;
        }
    }
}
