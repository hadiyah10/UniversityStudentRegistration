using RepositoryClassLibrary.Model;
using BusinessLogicClassLibrary.BusinessLogic;
using System.Web;
using System.Web.Mvc;

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

        public static void SignOut(this HttpSessionStateBase session)
        {
            session["userId"] = false;
        }
    }

    public class LoginController : Controller 
    {
        private readonly IUserBL UserBL;

        public LoginController(IUserBL userBL)
        {
            UserBL = userBL;
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
            if (isUserAuthenticated)
            {
                int userId = this.UserBL.GetUserIdByEmailId(loginModel.Email);
                Session.SignIn(userId);
            }
           
            return Json(new
            {
                result = isUserAuthenticated,
                url = Url.Action("HomePage", "Home")
            }); 

        }
    }
}