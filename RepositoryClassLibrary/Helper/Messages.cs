using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages;

namespace RepositoryClassLibrary.Helper
{
    public class Messages
    {
        public bool Flag { get; set; }
        public string Message { get; set; }

        public Messages()
        { }

        public Messages(bool flag, string message)
        {
            Flag = flag;
            Message = message;
        }
    }
}
