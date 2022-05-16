using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using Business.Status;
using Entities.DTOs;
using AutoMapper;
using System.Linq;
using Business.Enums;
using Nager.Date;

namespace Business.Concrete
{
    public class VacationApplyManager : IVacationApplyServices
    {
        private readonly IVacationApplyDAL _vacationApply;
        private readonly IMapper _mapper;
        public VacationApplyManager(IVacationApplyDAL vacationApply, IMapper mapper)
        {
            _vacationApply = vacationApply;
            _mapper = mapper;
        }
        public void Create(VacationApplyDto vacationApplyDto)
        {
            var m = _vacationApply.GetAll();
            var aa = m.LastOrDefault();
            string [] arr=  aa.VacationApplyNumber.Split("-");

            if (m.Count() == 0 || arr[1] != DateTime.Now.ToString("yy"))
            {
                vacationApplyDto.ApplyNumber=1;
            }
            else 
            {
                vacationApplyDto.ApplyNumber = aa.ApplyNumber + 1;
            }

            var DM = "0000";
            var FF=DM.Substring(0 ,DM.Length-vacationApplyDto.ApplyNumber.ToString().Length)+vacationApplyDto.ApplyNumber.ToString();
            vacationApplyDto.VacationApplyNumber = "Q" + "-" + DateTime.Now.ToString("yy-MM") + "-" + FF;
            
            int a = vacationApplyDto.StartTime.Year;
            int b = vacationApplyDto.EndTime.Year;
            int c = vacationApplyDto.StartTime.Month;
            int d = vacationApplyDto.EndTime.Month;
            int e = vacationApplyDto.StartTime.Day;
            int f = vacationApplyDto.EndTime.Day;

            if (a > b || c > d)
            {
                throw new Exception("duzgun tarix secin");
            }
            if (c == d && e > f)
            {
                throw new Exception();
            }
            
            if (vacationApplyDto.EndTime.DayOfWeek==DayOfWeek.Saturday)
            {
                throw new Exception();
            }
            else if (vacationApplyDto.EndTime.DayOfWeek ==DayOfWeek.Sunday)
            {
                throw new Exception();
            }

            var result = _mapper.Map<VacationApply>(vacationApplyDto);
            result.Status = VacationStatus.Yeni.ToString();
            _vacationApply.Add(result);
        }

        public void UpdateVacationStatus(int? Id)
        {
            var existVacation = _vacationApply.Get(x => x.Id == Id);
            if (existVacation == null)
            {
                throw new Exception();
            }
            existVacation.Status = VacationStatus.TesdiqEdildi.ToString();
            _vacationApply.Update(existVacation);
        }
        
    }
}
