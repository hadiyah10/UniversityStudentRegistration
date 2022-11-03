using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryClassLibrary.Entities;

namespace BusinessLogicClassLibrary.BusinessLogic
{
    public interface IRolesBL
    {
        List<Roles> GetUserRoles(int userId);
    }
}
