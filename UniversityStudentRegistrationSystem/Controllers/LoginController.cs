using RepositoryClassLibrary.Model;
using RepositoryClassLibrary.Entities;
using BusinessLogicClassLibrary.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Student_Registration.Controllers
{
    public class LoginController : Controller 
    {
        private readonly IUserBL UserBL;
       
        public LoginController() {
            this.UserBL = UserBL;
        }
        public LoginController(IUserBL userBL)
        {
            UserBL = userBL;
        }

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Authentication(LoginModel loginModel)
        {
            var isUserAuthenticated = false;
            isUserAuthenticated = this.UserBL.IsUserAuthenticated(loginModel);
            if (isUserAuthenticated)
            {
                int userId = this.UserBL.GetUserIdByEmailId(loginModel.Email);
                this.Session["user"] = userId;
            }
           
            return Json(new
            {
                result = isUserAuthenticated,
                url = Url.Action("HomePage", "Home")
            }); 

        }
    }
}