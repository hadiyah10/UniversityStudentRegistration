using BusinessLogicClassLibrary.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityStudentRegistrationSystem.Controllers
{
    public class AdminController : Controller
    {
        private IResultBL ResultBL; 
        private IStudentBL StudentBL;
        public AdminController(IResultBL resultBL, IStudentBL studentBL)
        {
            ResultBL = resultBL;
            StudentBL = studentBL;
        }
        public ActionResult Panel()
        {
            return View(); 
        }

        [HttpGet]
        public JsonResult GetStudentsSummary()
        {
            var response = this.StudentBL.GetStudentsSummary();
            return Json(new { result = response }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult TopStudents()
        {
            return View();
        }


        [HttpGet]
        public JsonResult GetTopStudents()
        {
            var response = this.StudentBL.GetTopStudents();
            return Json(new { result = response }, JsonRequestBehavior.AllowGet);
        }

    }
}