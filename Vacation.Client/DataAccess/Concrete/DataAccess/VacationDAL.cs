using Core.DataAccess.Base;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.DataAccess
{
    public class VacationDAL : EFRepositoryBase<Vacations, AppDbContext>, IVacationDAL
    {
    }
}
