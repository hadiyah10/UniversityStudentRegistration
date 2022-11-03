using BusinessLogicClassLibrary.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using RepositoryClassLibrary.Helper;

namespace UniversityStudentRegistrationSystem.Controllers
{
    public class ValidationsController : Controller
    {
        private readonly IValidations Validations;

        public ValidationsController(IValidations validations)
        {
            Validations = validations;
        }
        public JsonResult IsEmailAvailable(string email)
        {
            Messages result=Validations.ValidateEmailDuplication(email);
            return Json(result);
        }

        public JsonResult IsPhoneNumberAvailable(string phoneNumber)
        {
            Messages result = Validations.ValidatePhoneDuplication(phoneNumber);
            return Json(result);
        }

        public JsonResult ValidateNationalIdDuplication(string nationalId)
        {
            Messages result = Validations.ValidatePhoneDuplication(nationalId);
            return Json(result);
        }

    }
}