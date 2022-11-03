using RepositoryClassLibrary.DataAccessLayer;
using RepositoryClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicClassLibrary.BusinessLogic
{
    public class RolesBL : IRolesBL
    {
        private readonly IRolesDAL RolesDAL;
        public RolesBL(IRolesDAL rolesDAL)
        {
            RolesDAL = rolesDAL;
        }

        public List<Roles> GetUserRoles(int userId)
        {
            return this.RolesDAL.GetAllRoles(userId);
        }
    }
}
