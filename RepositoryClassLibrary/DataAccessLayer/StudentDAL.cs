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

namespace RepositoryClassLibrary.DataAccessLayer
{
    public class StudentDAL : IStudentDAL
    {

        private const string CreateStudentQuery = @"Insert into Students
        ([NationalId],[FirstName],[Surname], [PhoneNumber], [DateOfBirth], [GuardianName], [Address], [StudentId], [Status])
        values (@NationalId, @FirstName, @Surname, @PhoneNumber, @DateOfBirth, @GuardianName, @Address, @StudentId , @Status)";

        private const string GetStudentsQuery = @"Select [NationalId],[FirstName],[Surname], [PhoneNumber], [DateOfBirth], [GuardianName], [Address] from Students";

        DatabaseHelper DatabaseHelper;
        public StudentDAL() { 
            this.DatabaseHelper = new DatabaseHelper();
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
            return DatabaseHelper.InsertUpdateData(CreateStudentQuery, parameters);
        }
        public List<Students> GetAllStudents()
        {
            List<Students> StudentList = null;
            Students Student;

            var dt = DatabaseHelper.GetData(GetStudentsQuery);
            if (dt.Rows.Count > 0)
            {
                StudentList = new List<Students>();
                foreach (DataRow row in dt.Rows)
                {
                    Student = new Students();
                    Student.FirstName = row["FirstName"].ToString();
                    Student.Surname = row["Surname"].ToString();
                    Student.NationalId = row["NationalId"].ToString();
                    Student.Address = row["address"].ToString();
                    Student.PhoneNumber = row["PhoneNumber"].ToString();
                    Student.DateOfBirth = DateTime.Parse(row["DateOfBirth"].ToString());
                    Student.GuardianName = row["GuardianName"].ToString();
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
        public Results GetStudentResultsByUserId(int id)
        {
            return null;
        }
    }
}
