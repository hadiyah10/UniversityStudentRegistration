using RepositoryClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicClassLibrary.BusinessLogic
{
    public  interface IUserBL
    {
        bool IsUserAuthenticated(LoginModel LoginModel);
        int GetUserIdByEmailId(String email);
    }
}
