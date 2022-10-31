using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;

namespace RepositoryClassLibrary.Entities
{
    public class Grades
    {
        public int GradeId { get; private set; } 
        public char GradeName { get; set; }
        public int GradeScore { get; set; }
    }  
}