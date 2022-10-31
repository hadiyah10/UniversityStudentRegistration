using System.Web.Mvc;

namespace Student_Registration.Controllers
{
    public class HomeController : Controller

    {
        public HomeController()
        { }

        public ActionResult HomePage()
        {
            if (this.Session["user"] != null) {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
           
        }
    }
}