using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Vacation.ViewModels;

namespace Vacation.Controllers
{
    public class VacationController:Controller
    {
        private readonly IEmployeeServices _employeeservices;
        private readonly IEmployeeDAL _employeeDAL;
        private readonly UserManager<Employee> _userManager;
        private readonly IVacationServices _vacationServices;
        private readonly IVacationApplyServices _vacationApplyServices;
        private readonly AppDbContext _appDbContext;                                    
        public VacationController(IEmployeeServices employeeservices, IEmployeeDAL employeeDAL,
            UserManager<Employee> userManager, IVacationServices vacationServices,
            IVacationApplyServices vacationApplyServices, AppDbContext appDbContext)
        {
            _employeeDAL= employeeDAL;
            _employeeservices = employeeservices;
            _userManager = userManager;
            _vacationServices = vacationServices;
            _vacationApplyServices = vacationApplyServices;
            _appDbContext = appDbContext;
        }
        public IActionResult GetAllData()
        {
            var employeeView = _employeeservices.GetAll();
            EmpolyeeVM model = new();
           
            model.Employees=employeeView;
            return View(model);
        }
       
        public async Task<IActionResult> VacationApply()
        {
            Employee user = await _userManager.FindByNameAsync(User.Identity.Name);
            VacationApplyDto vacationApplyDto=new ();
            vacationApplyDto.Employees = _employeeDAL.GetAll(x => x.UserName != user.UserName).ToList();
            vacationApplyDto.Vacations = _vacationServices.GetAll();

            return View(vacationApplyDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VacationApply(VacationApplyDto vacationApplyDto)
        {
            Employee user = await _userManager.FindByNameAsync(User.Identity.Name);

            vacationApplyDto.Employees = _employeeDAL.GetAll(x => x.UserName != user.UserName).ToList();
            vacationApplyDto.Vacations = _vacationServices.GetAll();
            vacationApplyDto.EmployeeSubstitute= user.FullName ;
            _vacationApplyServices.Create(vacationApplyDto);
            return RedirectToAction(nameof(VacationsList));
        }

        

        public IActionResult VacationsList()
        {

           using(AppDbContext context =new ())
            {
                var Vacations = context.VacationsApply.Include(x => x.Vacation).Include(x => x.Employee).ToList();
                VacationsWM vacationsVM= new ();
                vacationsVM.Vacations = Vacations;
                return View(vacationsVM); 
           }

        }

        public IActionResult UpdateStatus(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
           _vacationApplyServices.UpdateVacationStatus(id);
            return RedirectToAction(nameof(VacationsList));
        }
    }
}
