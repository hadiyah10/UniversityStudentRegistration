using RepositoryClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryClassLibrary.DataAccessLayer
{
    public interface IRolesDAL
    {
        List<Roles> GetAllRoles(int userId);
    }
}
