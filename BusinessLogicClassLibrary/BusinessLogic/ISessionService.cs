using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryClassLibrary.Entities;

namespace BusinessLogicClassLibrary.BusinessLogic
{
    interface ISessionService
    {   
        void CreateSession(Users User);
        bool IsUserLoggedIn(Users User);
        void DestroySession(Users User);
    }
}