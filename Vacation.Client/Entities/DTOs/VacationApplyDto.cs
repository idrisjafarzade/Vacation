using Core.Entities.IDTOs;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class VacationApplyDto: IDTO
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string VacationApplyNumber { get; set; }

        public int ApplyNumber { get; set; }
        public string EmployeeSubstitute { get; set; }
        public string EmployeeId { get; set; }
        public List<Employee> Employees { get; set; }
        public int VacationId { get; set; } 
        public List<Vacations> Vacations { get; set; }
    }
}
