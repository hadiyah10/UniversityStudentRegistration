using RepositoryClassLibrary.Entities;
using RepositoryClassLibrary.DataAccessLayer;
using RepositoryClassLibrary.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RepositoryClassLibrary.SQLQueries;

namespace RepositoryClassLibrary.DataAccessLayer
{
    public class StudentDAL : IStudentDAL
    {
        DatabaseHelper DatabaseHelper;
        SqlQueries SqlQueries;
        public StudentDAL() { 
            this.DatabaseHelper = new DatabaseHelper();
            SqlQueries = new SqlQueries();
        }
        public bool CreateStudent(Students student)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            int userId = 0;
            string query = @"INSERT INTO Users(Email, Password)";
            query += "VALUES(@Email, @Password)";

            parameters.Add(new SqlParameter("@Email", student.Email));
            parameters.Add(new SqlParameter("@Password", student.Password));
            DatabaseHelper.InsertUpdateData(query, parameters);

            query = "SELECT UserId FROM Users WHERE Email=@Email";
            DataTable result = DatabaseHelper.GetDataWithConditions(query, parameters);
            userId = (int)result.Rows[0]["UserId"];

            query = @"INSERT INTO UserRoles(RoleId,UserId) VALUES(@RoleId,@UserId)";

            parameters.Add(new SqlParameter("@RoleId", (int)Roles.Student));
            parameters.Add(new SqlParameter("@UserId", userId));
            DatabaseHelper.InsertUpdateData(query, parameters);

            parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@NationalId", student.NationalId));
            parameters.Add(new SqlParameter("@FirstName", student.FirstName));
            parameters.Add(new SqlParameter("@Surname", student.Surname));
            parameters.Add(new SqlParameter("@PhoneNumber", student.PhoneNumber));
            parameters.Add(new SqlParameter("@DateOfBirth", student.DateOfBirth));
            parameters.Add(new SqlParameter("@GuardianName", student.GuardianName));
            parameters.Add(new SqlParameter("@Address", student.Address));
            parameters.Add(new SqlParameter("@StudentId", userId));
            parameters.Add(new SqlParameter("@Status", (int)Status.Waiting));
            return DatabaseHelper.InsertUpdateData(SqlQueries.CreateStudentsQuery(), parameters);
        }
        public List<Students> GetAllStudents()
        {
            List<Students> StudentList = null;
            Students Student;

            var dt = DatabaseHelper.GetData(SqlQueries.GetAllStudentsQuery());
            if (dt.Rows.Count > 0)
            {
                StudentList = new List<Students>();
                foreach (DataRow row in dt.Rows)
                {
                    Student = new Students();
                    Student.StudentId = (int)row["StudentId"];
                    Student.FirstName = row["FirstName"].ToString();
                    Student.Surname = row["Surname"].ToString();
                    Student.NationalId = row["NationalId"].ToString();
                    Student.Address = row["address"].ToString();
                    Student.PhoneNumber = row["PhoneNumber"].ToString();
                    Student.DateOfBirth = DateTime.Parse(row["DateOfBirth"].ToString());
                    Student.GuardianName = row["GuardianName"].ToString();
                    Student.Status = (int)row["Status"];
                    StudentList.Add(Student);
                }
            }
            return StudentList;
        }
        public void UpdateStatus(Students student, int status)
        {
            student.Status = status;
            Console.WriteLine("Update user status");
        }
        public List<Students> GetTopFifteenStudents()
        {
            //this method will usually return a list of top 15 student
            //this method will not return a new instance 
            return new List<Students>();
        }
        public List<Results> GetStudentResultsByUserId(int id)
        {
            List<Results> studentResults = null;
            string query=SqlQueries.GetResultsByStudentId;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@StudentId", id));
            DataTable result = DatabaseHelper.GetDataWithConditions(query, parameters);
            
            if (result.Rows.Count > 0)
            {
                studentResults = new List<Results>();
                for (int i=0;i<result.Rows.Count;i++)
                {
                    var studResult = new Results();
                    DataRow row = result.Rows[i];
                    studResult.ResultId = (int)row["ResultId"];
                    studResult.Grades =(Grades) Enum.Parse(typeof(Grades),row["Grade"].ToString());
                    Subjects subject = new Subjects();
                    subject.SubjectId = (int)row["SubjectId"];
                    subject.SubjectName = row["SubjectName"].ToString();
                    studResult.Subject = subject;
                    studentResults.Add(studResult);
                }
            }
            return studentResults;
        }
        public List<Students> GetStudentsSummary()
        {
            ResultDAL ResultDal = new ResultDAL();
            List<Students> StudentList = GetAllStudents();     
            List < Results > ResultList = ResultDal.GetAllResults();

            foreach(Students Student in StudentList)
            {           
                Student.Result = ResultList.FindAll(result => result.StudentId.Equals(Student.StudentId));
            }
            return StudentList;
        }

        public List<Students> GetTopStudents()
        {
            ResultDAL ResultDal = new ResultDAL();
            List<Students> StudentList = GetAllStudents();
            List<Results> ResultList = ResultDal.GetAllResults();
            
            foreach (Students Student in StudentList)
            {
                int TotalScore = 0;
                Student.Result = ResultList.FindAll(result => result.StudentId.Equals(Student.StudentId));
                foreach(var result in Student.Result) {
                   TotalScore = TotalScore +  (int)(Grades)Enum.Parse(typeof(Grades),result.Grade);
                }
                Student.TotalScore = TotalScore;
            }
            StudentList = StudentList.OrderByDescending(student => student.TotalScore).ToList() ;
            return StudentList;
        }

        public Students GetStudentBy(string queryParameter, object queryValue)
        {
            Students student = null;
            string query = string.Format($"{SqlQueries.GetStudentQuery} where {queryParameter} = @{queryParameter}"); 
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter($"@{queryParameter}", queryValue));
            DataTable result = DatabaseHelper.GetDataWithConditions(query, parameters);
            if (result.Rows.Count > 0)
            {
                student = new Students();
                DataRow row=result.Rows[0];
                student.StudentId = (int)row["StudentId"];
                student.NationalId = row["NationalId"].ToString();
                student.FirstName = row["FirstName"].ToString();
                student.Surname = row["Surname"].ToString();
                student.PhoneNumber = row["PhoneNumber"].ToString();
                student.DateOfBirth = DateTime.Parse(row["DateOfBirth"].ToString());
                student.GuardianName = row["GuardianName"].ToString();
                student.Address = row["Address"].ToString();
                student.Status = (int)row["Status"];
            }
            return student;    
        }
    }
}
