

using Core.DataAccess.Base;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace DataAccess.Concrete.DataAccess
{
    public class VacationApplyDAL : EFRepositoryBase<VacationApply, AppDbContext>, IVacationApplyDAL
    {
    }
}
