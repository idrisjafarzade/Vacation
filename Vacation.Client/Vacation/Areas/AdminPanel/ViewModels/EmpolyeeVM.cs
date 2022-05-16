using Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Vacation.Areas.AdminPanel.ViewModels
{
    public class EmpolyeeVM
    {
        public Employee employee { get; set; }
        public List<Entities.Concrete.Vacations> Vacation { get; set; }
        public SelectList VacationName { get; set; }
    }
}
