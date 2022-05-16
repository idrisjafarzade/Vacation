using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class VacationApply:IEntity
    {
        public int Id { get; set; } 
        public string VacationApplyNumber { get; set; }
        public int ApplyNumber { get; set; }    
        public string Status { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string EmployeeSubstitute { get; set; }
        public int VacationId { get; set; }
        public Vacations Vacation { get; set; }
        public string EmployeeId  { get; set; }
        public Employee Employee { get; set; }

    }
}
