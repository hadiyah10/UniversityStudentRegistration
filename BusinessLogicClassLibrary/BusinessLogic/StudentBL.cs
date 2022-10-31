using RepositoryClassLibrary.Model;
using RepositoryClassLibrary.Entities;
using RepositoryClassLibrary.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace BusinessLogicClassLibrary.BusinessLogic
{
    public class StudentBL : IStudentBL
    {
        private readonly IStudentDAL StudentDAL;
        public StudentBL(IStudentDAL studentDAL) 
        {
            StudentDAL = studentDAL;
        }
        public bool CreateStudent(Students student)
        {
            var isStudentCreated = false;
            //put error message 
            if (IsNIDUnique(student.NationalId)) {
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(student.Password);
                student.Password = hashedPassword;
                isStudentCreated = this.StudentDAL.CreateStudent(student);
            }
            return isStudentCreated;
        }
        private bool ValidateEmailDuplication(string email)
        {
            var student = this.StudentDAL.GetAllStudents().FirstOrDefault(s => s.Email.Equals(email));
            if (student == null)
            {
                return true;
            }
            return false;
        } 
        private bool IsNIDUnique(string nationalId)
        {
            var student = this.StudentDAL.GetAllStudents();
               if (student != null)
            {
                var stud = student.FirstOrDefault(s => s.NationalId.Equals(nationalId));
                if (stud == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
               return true;
        }

        private bool ValidatePhoneDuplication(string phoneNumber)
        {
            var student = this.StudentDAL.GetAllStudents().FirstOrDefault(s => s.PhoneNumber.Equals(phoneNumber));
            return student != null;
        }
        public Results GetStudentResultsByUserId(int userId)
        {
            return this.StudentDAL.GetStudentResultsByUserId(userId);
        }
    }
}
