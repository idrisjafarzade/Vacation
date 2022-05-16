using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Vacation.Areas.AdminPanel.ViewModels;
using Vacation.ViewModels;

namespace Vacation.Area.Controllers
{
    [Area("AdminPanel")]
    public class EmployeeController: Controller
    {
        private readonly IEmployeeServices _employeeservices;
        private readonly IVacationServices _vacationServices;
        public EmployeeController(IEmployeeServices employeeservices, IVacationServices vacationServices)
        {
            _employeeservices = employeeservices;
            _vacationServices = vacationServices;

        }
        public IActionResult Index()
        {
            return Content("success");
        }
        public IActionResult Create()
        {
           var model=_vacationServices.GetAll();
            
            
            return View(model);
        }
        //[HttpPost]
       // [ValidateAntiForgeryToken]
        //public IActionResult Create( Entities.Concrete.Employee employee)
        //{
        //    var model = _vacationServices.GetAll();
        //    _employeeservices.Create(employee);
        //    return Redirect(nameof(Index));
        //}
    }
}
