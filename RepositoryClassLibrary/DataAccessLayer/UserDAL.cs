using RepositoryClassLibrary.Entities;
using RepositoryClassLibrary.Helper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using RepositoryClassLibrary.Model;
using System.Reflection;
using System.Collections;
using System.Data;
using System.Security.Cryptography;
using BCrypt.Net;
using RepositoryClassLibrary.SQLQueries;

namespace RepositoryClassLibrary.DataAccessLayer
{
    public class UserDAL : IUserDAL
    {
        public const string AuthenticationQuery = @"select Password from Users where Email = @Email ";

        public const string GetUserByEmailQuery = @"SELECT UserId FROM Users WHERE Email=@Email";
       
        DatabaseHelper _databaseHelper;
     
        public UserDAL()
        {
            this._databaseHelper = new DatabaseHelper();
        }
        public bool IsUserAuthenticated(LoginModel LoginModel)
        {
            
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Email", LoginModel.Email));

            var dt = _databaseHelper.GetDataWithConditions(AuthenticationQuery, parameters);
            if (dt.Rows.Count > 0) 
            { 
                string hashedPassword = dt.Rows[0]["Password"].ToString();
                return BCrypt.Net.BCrypt.Verify(LoginModel.Password, hashedPassword);
            }
            return false;
        }

        public int GetUserIdByEmailId(String email)
        {
            int userId=0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Email", email));
            DataTable result = _databaseHelper.GetDataWithConditions(GetUserByEmailQuery, parameters);
            if (result.Rows.Count > 0)
                userId = (int)result.Rows[0]["UserId"];
            return userId;
        }

        
    }
}