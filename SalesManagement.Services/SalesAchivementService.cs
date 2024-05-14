using SalesManagement.Core.Interfaces;
using SalesManagement.Core.Models;
using SalesManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Services
{
    public class SalesAchivementService:ISalesAchivementService
    {
        public IUnitOfWork _unitOfWork;

        public SalesAchivementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateSalesAchivement(SalesAchivement salesAchivement)
        {
            if (salesAchivement != null)
            {
                await _unitOfWork.SalesAchivmants.Add(salesAchivement);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteSalesAchivement(int salesAchivementId)
        {
            if (salesAchivementId > 0)
            {
                var achivement = await _unitOfWork.SalesAchivmants.GetById(salesAchivementId);
                if (achivement != null)
                {
                    _unitOfWork.SalesAchivmants.Delete(achivement);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<SalesAchivement>> GetAllSalesAchivements()
        {
            var achivementList = await _unitOfWork.SalesAchivmants.GetAll();
            return achivementList;
        }

        public async Task<SalesAchivement> GetSalesAchivementById(int salesAchivementId)
        {
            if (salesAchivementId > 0)
            {
                var achivement = await _unitOfWork.SalesAchivmants.GetById(salesAchivementId);
                if (achivement != null)
                {
                    return achivement;
                }
            }
            return null;
        }

        public async Task<bool> UpdateSalesAchivement(SalesAchivement salesAchivement)
        {
            if (salesAchivement != null)
            {
                var achivementFind = await _unitOfWork.SalesAchivmants.GetById(salesAchivement.ID);
                if (achivementFind != null)
                {
                    achivementFind.SalesTargetsId = salesAchivement.SalesTargetsId;
                    achivementFind.Amount = salesAchivement.Amount;

                    _unitOfWork.SalesAchivmants.Update(achivementFind);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
    }
}
