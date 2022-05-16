using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Vacation.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Employee> _userManager;
        private readonly SignInManager<Employee> _signInManager;
        private readonly IEmployeeServices _employeeservices;

        public AccountController(UserManager<Employee> userManager, SignInManager<Employee> signInManager, IEmployeeServices employeeservices)
        {
            _employeeservices = employeeservices;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Registr()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registr(EmployeeDto employee)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(" ", "");
                return View(employee);
            }
            _employeeservices.Registr(employee);
            if (employee.IsSuccess == false)
            {
                ModelState.AddModelError("UserName ", "Bu Adda user var");
                return View(employee);
            }
            return RedirectToAction(nameof(Login));
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(" ", "Required");
                return View(loginDto);
            }

            var result = await _employeeservices.Login(loginDto);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(" ", "Required");
                return View(loginDto);
            }

            return RedirectToAction("VacationApply", "Vacation");
        }
    }
}
