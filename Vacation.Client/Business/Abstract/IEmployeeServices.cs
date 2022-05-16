using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEmployeeServices 
    {
         Task<EmployeeDto> Registr(EmployeeDto employeeDto);
         Task<SignInResult>Login(LoginDto loginDto);
        List<Employee> GetAll();
    }
}
