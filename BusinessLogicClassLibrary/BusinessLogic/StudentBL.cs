using RepositoryClassLibrary.Model;
using RepositoryClassLibrary.Entities;
using RepositoryClassLibrary.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using RepositoryClassLibrary.Helper;

namespace BusinessLogicClassLibrary.BusinessLogic
{
    public class StudentBL : IStudentBL
    {
        private readonly IStudentDAL StudentDAL;
        private readonly IValidations Validations;
        public StudentBL(IStudentDAL studentDAL, IValidations validations) 
        {
            StudentDAL = studentDAL;
            Validations = validations;
        }
        public Messages CreateStudent(Students student)
        {
            var isStudentCreated = false;
            var validateEmail = Validations.ValidateEmailDuplication(student.Email);
            if (!validateEmail.Flag)
                return validateEmail;
            var validatePhone = Validations.ValidatePhoneDuplication(student.PhoneNumber);
            if (!validatePhone.Flag)
                return validatePhone;
            var validateNationalID = Validations.ValidateNationalIdDuplication(student.NationalId);
            if (!validateNationalID.Flag)
                return validateNationalID;
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(student.Password);
            student.Password = hashedPassword;
            isStudentCreated = this.StudentDAL.CreateStudent(student);
            return new Messages(isStudentCreated,"");
        }
        
        public List<FormattedModel> GetResultInFormat(int id)
        {
            var formattedResult = new List<FormattedModel>();
            var allResults = GetStudentResultsByUserId(id);
            for (int i = 0; i < allResults.Count; i++)
            {
                var result = new FormattedModel();
                result.SubjectName = allResults[i].Subject.SubjectName;
                result.Grade = allResults[i].Grades.ToString();
                formattedResult.Add(result);
            }
            return formattedResult;
        }
        public List<Results> GetStudentResultsByUserId(int id)
        {
           return this.StudentDAL.GetStudentResultsByUserId(id);
        }

        public List<Students> GetStudentsSummary()
        {
            return this.StudentDAL.GetStudentsSummary();
        }

        public List<Students> GetTopStudents() { 
            return this.StudentDAL.GetTopStudents();
        }
    }
}
