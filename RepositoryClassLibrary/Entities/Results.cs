using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepositoryClassLibrary.Entities
{
    public class Results
    {
        public int ResultId { get;  set; }
        public string Grade { get; set; }
        public Grades Grades { get; set; }
        public int StudentId { get; set; }
        public Subjects Subject { get; set; }
    }
}