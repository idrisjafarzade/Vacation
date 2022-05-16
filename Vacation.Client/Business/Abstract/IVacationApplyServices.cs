using Entities.DTOs;

namespace Business.Abstract
{
    public interface IVacationApplyServices
    {
        void UpdateVacationStatus(int? Id);
        void Create(VacationApplyDto vacationApplyDto);
    }
}
