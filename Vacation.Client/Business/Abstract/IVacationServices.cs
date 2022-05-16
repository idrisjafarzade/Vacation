using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IVacationServices 
    {
        //public void CreateVacation(VacationApply services);

        List<Vacations> GetAll();

    }
}
