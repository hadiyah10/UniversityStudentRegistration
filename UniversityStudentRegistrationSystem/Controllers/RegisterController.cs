using RepositoryClassLibrary.Entities;
using RepositoryClassLibrary.Model;
using BusinessLogicClassLibrary.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Student_Registration.Controllers
{
    public class RegisterController : Controller
    {
        private IStudentBL _studentBL;
        private ISubjectBL _subjectBL;
        private IResultBL ResultBL;

        public RegisterController() { }
       public RegisterController(IStudentBL student , ISubjectBL subject, IResultBL resultBL)
        {
            _studentBL = student;
            _subjectBL = subject;
            ResultBL = resultBL;
        }

        public ActionResult Index()
        {
            return View(); 
        }


        [HttpPost]
       public JsonResult CreateStudent(Students Student)
        {
            var response = this._studentBL.CreateStudent(Student);
            return Json(new { result = response });

        }
        public ActionResult ResultDetails()
        {
            if (this.Session["user"] != null)
            {
                //verify if user has results
                if(this._studentBL.GetStudentResultsByUserId((int)this.Session["user"]) == null) {
                    //redirect to input results
                    return View();
                }
                else
                {
                    //redirect to display results
                    return View();

                }
               
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }


        [HttpGet]
        public JsonResult GetSubjects()
        {
            var response = this._subjectBL.GetSubjects();
            return Json(new { result = response }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CreateResult(Results[] resultList)
        {

            var response = this.ResultBL.IsResultCreated(resultList.ToList());
            return Json(new { result = response });

        }
    }
}