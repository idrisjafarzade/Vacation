using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class EmpolyeeManager : IEmployeeServices
    {
        private readonly IEmployeeDAL _employee;
        private readonly IMapper _mapper;
        private readonly UserManager<Employee> _userManager;
        private readonly SignInManager<Employee> _signInManager;
        public EmpolyeeManager(IEmployeeDAL employee , IMapper mapper
            , UserManager<Employee> userManager, SignInManager<Employee> signInManager)
        {
            _employee = employee;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public void Create(Employee employees)
        {
            _employee.Add(employees);
        }

        public List<Employee> GetAll()
        {
            return _employee.GetAll();
        }

        public async Task<EmployeeDto> Registr(EmployeeDto employeeDto)
        {
            try
            {
                var existUser = _employee.Get(x => x.UserName == employeeDto.UserName);
                if (existUser != null)
                {
                    throw new System.Exception();
                }

                var user = new Employee
                {
                    UserName = employeeDto.UserName,
                    Email = employeeDto.Email,
                    FullName=employeeDto.FullName,
                    Position=employeeDto.Position,
                };
                 employeeDto.IsSuccess = true;
                var result = await _userManager.CreateAsync(user, employeeDto.Password);
                return (employeeDto);
            }
            catch (System.Exception e)
            {

                throw e.InnerException;
            }

        }

        public async Task<SignInResult> Login(LoginDto loginDto)
        {
            var x = _employee.GetAll(x => x.UserName == loginDto.UserName).FirstOrDefault();
            if (x == null)
            {
                 throw new System.Exception();
            }
            var result = await _signInManager.PasswordSignInAsync(x.UserName,loginDto.Password,false,false);
            if (!result.Succeeded)
            {
                throw new System.Exception();
                //loginDto.IsPasswordValid=false;
            }
            return (result);
        }
    }
}
