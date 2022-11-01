using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepositoryClassLibrary.Entities
{
    public class Results
    {
        public int ResultId { get; private set; }
        public int SubjectId { get; set; } 
        public char Grade { get; set; }
       // public int StudentId { get; set; }
    }
}