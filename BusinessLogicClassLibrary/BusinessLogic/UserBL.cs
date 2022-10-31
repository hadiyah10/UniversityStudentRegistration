using RepositoryClassLibrary.Model;
using RepositoryClassLibrary.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicClassLibrary.BusinessLogic
{
    public class UserBL : IUserBL
    {
        public IUserDAL UserDal;
        public UserBL(IUserDAL userDAL)
        {
            UserDal = userDAL;
        }  
        public bool IsUserAuthenticated(LoginModel loginModel)
        {
            return this.UserDal.IsUserAuthenticated(loginModel);
        }
        public int GetUserIdByEmailId(string email)
        {
            return this.UserDal.GetUserIdByEmailId(email);
        }
    }
}
