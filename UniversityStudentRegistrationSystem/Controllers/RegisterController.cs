using RepositoryClassLibrary.Entities;
using RepositoryClassLibrary.Model;
using BusinessLogicClassLibrary.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using UniversityStudentRegistrationSystem.Models;

namespace Student_Registration.Controllers
{
    public class RegisterController : Controller
    {
        private IStudentBL StudentBL;
        private ISubjectBL SubjectBL;
        private IResultBL ResultBL;


        public RegisterController() { }
        public RegisterController(IStudentBL student, ISubjectBL subject, IResultBL resultBL)
        {
            StudentBL = student;
            SubjectBL = subject;
            ResultBL = resultBL;
        }

        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public JsonResult CreateStudent(Students Student)
        {
            var response = this.StudentBL.CreateStudent(Student);
            return Json(response);

        }
        public ActionResult ResultDetails()
        {
            int? userId = this.Session.GetUserId();

            if (userId != null)
            {
                if (this.StudentBL.GetStudentResultsByUserId(userId.Value)==null)
                {
                    return View();
                }
                else
                {
                    return Redirect("/Result/DisplayResults");
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
            var response = this.SubjectBL.GetSubjects();
            return Json(new { result = response }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CreateResult(ResultModel resultModel)
        {
            var response = this.ResultBL.IsResultCreated(resultModel.Results);
            return Json(new { result = response });
        }
    }
}