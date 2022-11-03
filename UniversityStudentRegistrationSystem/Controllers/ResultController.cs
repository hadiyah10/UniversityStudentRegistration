using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicClassLibrary.BusinessLogic;
using Student_Registration.Controllers;

namespace UniversityStudentRegistrationSystem.Controllers
{
    public class ResultController : Controller
    {
        private readonly IStudentBL StudentBL;
        public ResultController(IStudentBL studentBL)
        {
            StudentBL = studentBL;
        }

        public ActionResult DisplayResults()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetResults()
        {
            int? userId = this.Session.GetUserId();
            var results=StudentBL.GetResultInFormat((int)userId);
            return Json(results, JsonRequestBehavior.AllowGet);
        }
    }
}