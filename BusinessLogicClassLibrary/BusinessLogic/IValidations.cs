using RepositoryClassLibrary.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicClassLibrary.BusinessLogic
{
    public interface IValidations
    {
        Messages ValidateEmailDuplication(string email);
        Messages ValidateNationalIdDuplication(string nationalId);
        Messages ValidatePhoneDuplication(string phoneNumber); 
    }
}
