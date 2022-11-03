using BusinessLogicClassLibrary.BusinessLogic;
using RepositoryClassLibrary.DataAccessLayer;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace UniversityStudentRegistrationSystem
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IStudentDAL, StudentDAL>();
            container.RegisterType<ISubjectDAL, SubjectDAL>();
            container.RegisterType<IUserBL, UserBL>();
            container.RegisterType<IStudentBL, StudentBL>();
            container.RegisterType<ISubjectBL, SubjectBL>();
            container.RegisterType<IUserDAL, UserDAL>();
            container.RegisterType<IResultBL, ResultBL>();
            container.RegisterType<IResultDAL, ResultDAL>();
            container.RegisterType<IValidations, Validations>();
            container.RegisterType<IRolesDAL, RolesDAL>();
            container.RegisterType<IRolesBL, RolesBL>();

            //container.RegisterType<ISqlDatabaseService, SqlDatabaseService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}