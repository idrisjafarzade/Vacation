using Business.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using DataAccess.Abstract;
    
namespace Business.Concrete
{
    public class VacationManager : IVacationServices
    {
        private readonly IVacationDAL _vaction;
        public VacationManager(IVacationDAL vactionServices)
        {
            _vaction = vactionServices;
        }
        public void Create(Vacations services)
        {
            _vaction.Add(services);
        }
        public List<Vacations> GetAll()
        {
            return _vaction.GetAll();
        }
    
    }
}
