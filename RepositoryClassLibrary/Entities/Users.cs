using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepositoryClassLibrary.Entities
{
    public class Users
    {
        public int UserId { get; set; } 
        public string Email  { get; set; }
        public string Password { get;set; }
        public Roles Role { get; set; }
        public Students Student { get; set; }   
    } 
}