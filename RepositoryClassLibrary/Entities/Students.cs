using System;
using System.Collections.Generic;


namespace RepositoryClassLibrary.Entities
{
    public class Students 
    { 
        public int StudentId { get;  set; }
        public string NationalId { get; set; }
        public string FirstName { get; set; }
        public string Surname  { get; set; }
        public string Email { get; set; }
        public string Password { get; set;  } 
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; } 
        public string GuardianName { get; set; }
        public int Status { get; set; }
        public List<Results> Result { get; set; }
        public string Address { get; set; } 
        public int TotalScore { get; set; } 

        public Students()
        {
            Result = new List<Results>();
        }
    }
}