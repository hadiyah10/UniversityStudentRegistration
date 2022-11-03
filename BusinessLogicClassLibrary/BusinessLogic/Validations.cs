using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryClassLibrary.DataAccessLayer;
using RepositoryClassLibrary.Entities;
using RepositoryClassLibrary.Helper;

namespace BusinessLogicClassLibrary.BusinessLogic
{
    public class Validations : IValidations
    {
        private readonly IStudentDAL StudentDAL;
        private readonly IUserDAL UserDAL;  
        public Validations(IStudentDAL studentDAL, IUserDAL userDAL)
        {
            StudentDAL = studentDAL;
            UserDAL = userDAL;
        }

        public Messages ValidateNationalIdDuplication(string nationalId)
        {
            if (string.IsNullOrEmpty(nationalId))
            {
                return new Messages(false, "National Id is required!");
            }
            bool exist = true;
            string mssg = "National Id available";
            Students stud = StudentDAL.GetStudentBy("NationalId", nationalId);
            if (stud != null)
            {
                exist = false;
                mssg = "National Id already registered!";
            }
            return new Messages(exist,mssg);
        }

        public Messages ValidateEmailDuplication(string email)
        {
            if( string.IsNullOrEmpty(email) )
            {
                return new Messages(false, "Email Address is required!");
            }
            int response=UserDAL.GetUserIdByEmailId(email);
            if (response == 0)
                return new Messages(true,"Email Address is available");
            else
            {
                return new Messages(false, "Email Address is already registered!");
            }
        }

        public Messages ValidatePhoneDuplication(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                return new Messages(false, "Phone Number is required!");
            }
            bool exist = true;
            string mssg = "Phone Number available";
            Students stud = StudentDAL.GetStudentBy("PhoneNumber", phoneNumber);
            if (stud != null)
            {
                exist = false;
                mssg = "Phone Number already registered!";
            }
            return new Messages(exist, mssg);
        }
    }
}
