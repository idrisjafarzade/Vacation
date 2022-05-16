using Entities.Concrete;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Vacation.ViewModels
{
    public class VacationsWM
    {
        [Required(ErrorMessage ="{0} yazilmalidr")]
        [Display(Name ="Ad")]
        public string Name { get; set; }
       public  List<VacationApply> Vacations { get; set; }   
    }
}
