    using Core.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class Employee: IdentityUser,IEntity
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public bool IsDeleted { get; set; }=false;
        public bool IsSuccess { get; set; }
        public int VacationsId { get; set; }
        public List<Vacations> Vacations { get; set; }
        public int EmployeeId { get; set; } 
        public List<Employee> Employees { get; set; }

    }
}
