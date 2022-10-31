using RepositoryClassLibrary.Entities;
using RepositoryClassLibrary.DataAccessLayer;
using RepositoryClassLibrary.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryClassLibrary.DataAccessLayer { 
    public class SubjectDAL : ISubjectDAL
    {
        public const string GetSubjectsQuery = @"SELECT [SubjectId], [SubjectName] FROM [dbo].[Subjects]";
        DatabaseHelper DatabaseHelper;
        public List<Subjects> GetSubjects()
        {
            DatabaseHelper = new DatabaseHelper();
            List<Subjects> SubjectList = new List<Subjects>();
            Subjects subject;
            DataTable dt = DatabaseHelper.GetDataFromQuery(GetSubjectsQuery);
            foreach (DataRow row in dt.Rows)
            {
                subject = new Subjects();
                subject.SubjectId = int.Parse(row["SubjectId"].ToString());
                subject.SubjectName= row["SubjectName"].ToString();

                SubjectList.Add(subject);
            }
            return SubjectList;
        }
    }

}
