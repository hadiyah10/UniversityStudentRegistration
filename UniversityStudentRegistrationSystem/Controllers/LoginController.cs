using RepositoryClassLibrary.Model;
using BusinessLogicClassLibrary.BusinessLogic;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using RepositoryClassLibrary.Entities;
using System.Linq;

namespace Student_Registration.Controllers
{
    public static class SessionExtensions
    {
        public static int? GetUserId(this HttpSessionStateBase session)
        {
            return (int?)session["userId"];
        }
        public static void SignIn(this HttpSessionStateBase session, int userId)
        {
            session["userId"] = userId;
        }
        public static void SetRoles(this HttpSessionStateBase session, List<Roles> roles)
        {
            string rolesStr = "";
            foreach (Roles role in roles)
            {
                rolesStr += role.ToString();
                rolesStr += ",";
            }
            rolesStr.Remove(rolesStr.Length - 1);
            session["roles"] = rolesStr;
        }
        public static void SignOut(this HttpSessionStateBase session)
        {
            session["userId"] = false;
            session["roles"]=false;
        }
    }
    public class LoginController : Controller 
    {
        private readonly IUserBL UserBL; 
        private readonly IRolesBL RoleBL;

        public LoginController(IUserBL userBL, IRolesBL rolesBL)
        {
            UserBL = userBL;
            RoleBL = rolesBL;
        }
        public ActionResult Login()
        { 
            return View();
        }
        public ActionResult Logout()
        {
            Session.SignOut();
            return RedirectToAction("Login", "Login");
        }
        [HttpPost]
        public JsonResult Authentication(LoginModel loginModel)
        {
            var isUserAuthenticated = this.UserBL.IsUserAuthenticated(loginModel);
            var role = new List<Roles>();
            if (isUserAuthenticated)
            {
                int userId = this.UserBL.GetUserIdByEmailId(loginModel.Email);
                role = this.RoleBL.GetUserRoles(userId);
                Session.SetRoles(role);
                Session.SignIn(userId);
            }
            string urlSend = "";
            if (role.Contains(Roles.Admin))
            {
                urlSend ="/Admin/Panel";
            }
            else
            {
                urlSend = "/Home/HomePage";
            }           
            return Json(new
            {
                result = isUserAuthenticated,
                url = urlSend
            }); 
        }
    }
}