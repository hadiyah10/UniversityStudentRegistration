using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryClassLibrary.Entities;
using RepositoryClassLibrary.Model;

namespace RepositoryClassLibrary.DataAccessLayer
{
    public interface IUserDAL
    {
        bool IsUserAuthenticated(LoginModel loginModel);
        int GetUserIdByEmailId(String email);
      
    }
}
