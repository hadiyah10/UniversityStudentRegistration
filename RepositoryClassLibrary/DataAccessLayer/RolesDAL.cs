using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using RepositoryClassLibrary.SQLQueries;
using RepositoryClassLibrary.Helper;
using RepositoryClassLibrary.Entities;

namespace RepositoryClassLibrary.DataAccessLayer
{
    public class RolesDAL : IRolesDAL
    {
        private readonly DatabaseHelper DatabaseHelper=new DatabaseHelper();

        public List<Roles> GetAllRoles(int userId)
        {
            List<Roles> roles = new List<Roles>();
            string query = SqlQueries.GetAllRoles;
            var parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@UserId", userId));
            DataTable result = DatabaseHelper.GetDataWithConditions(query, parameters);

            if (result.Rows.Count > 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    int roleId = (int)row["RoleId"];
                    roles.Add((Roles)roleId);
                }
            }
            return roles;
        }
    }
}
