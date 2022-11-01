using RepositoryClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryClassLibrary.DataAccessLayer
{
    public interface IResultDAL
    {
        bool IsResultCreated(List<Results> listOfResults, int userId);  
    }
}
