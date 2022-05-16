using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.DataAccess;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;

namespace Business.DependencyResolver
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EmployeeDal>().As<IEmployeeDAL>();
            builder.RegisterType<EmpolyeeManager>().As<IEmployeeServices>();
            builder.RegisterType<VacationManager>().As<IVacationServices>();
            builder.RegisterType<VacationDAL>().As<IVacationDAL>();
            builder.RegisterType<VacationApplyManager>().As<IVacationApplyServices>();
            builder.RegisterType<VacationApplyDAL>().As<IVacationApplyDAL>();
            builder.RegisterType<UserManager<Employee>>().SingleInstance();
            builder.RegisterType<SignInManager<Employee>>().SingleInstance();
            builder.RegisterType<AppDbContext>().SingleInstance();
        }
    }
}
