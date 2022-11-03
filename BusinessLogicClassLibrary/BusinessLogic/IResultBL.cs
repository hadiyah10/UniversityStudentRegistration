using RepositoryClassLibrary.Entities;
using System.Collections.Generic;

namespace BusinessLogicClassLibrary.BusinessLogic
{
    public interface IResultBL
    {
        bool IsResultCreated(List<Results> results);
        List<Results> GetAllResults();
    }
}
