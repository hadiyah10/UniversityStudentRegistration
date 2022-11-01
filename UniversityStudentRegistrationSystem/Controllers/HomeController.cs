using System.Web.Mvc;

namespace Student_Registration.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult HomePage()
        {
            if (this.Session.GetUserId() != null)
            {
                return View();
            }

            return RedirectToAction("Login", "Login");
        }
    }
}