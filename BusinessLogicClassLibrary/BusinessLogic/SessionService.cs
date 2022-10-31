using RepositoryClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessLogicClassLibrary.BusinessLogic
{ 
    public class SessionService : ISessionService
    {
        public void CreateSession(Users User)
        {
            Console.WriteLine("Creating session");
        }
        public void DestroySession(Users User)
        {
            Console.WriteLine("Destroying session");
        }
        public bool IsUserLoggedIn(Users User)
        {
            bool isUserLoggedIn = false;
            Console.WriteLine("Verifing if user is logged in.");
            return isUserLoggedIn;
        }
    }
} 