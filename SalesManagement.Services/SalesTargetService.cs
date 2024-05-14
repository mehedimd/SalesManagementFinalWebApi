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
    public class SalesTargetService : ISalesTargetService
    {
        public IUnitOfWork _unitOfWork;

        public SalesTargetService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateSalesTarget(SalesTarget salesTarget)
        {
            if (salesTarget != null)
            {
                await _unitOfWork.SalesTargets.Add(salesTarget);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteSalesTarget(int salesTargetId)
        {
            if (salesTargetId > 0)
            {
                var target = await _unitOfWork.SalesTargets.GetById(salesTargetId);
                if (target != null)
                {
                    _unitOfWork.SalesTargets.Delete(target);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<SalesTarget>> GetAllSalesTargets()
        {
            var targetList = await _unitOfWork.SalesTargets.GetAll();
            return targetList;
        }

        public async Task<SalesTarget> GetSalesTargetById(int salesTargetId)
        {
            if (salesTargetId > 0)
            {
                var target = await _unitOfWork.SalesTargets.GetById(salesTargetId);
                if (target != null)
                {
                    return target;
                }
            }
            return null;
        }

        public async Task<bool> UpdateSalesTarget(SalesTarget salesTarget)
        {
            if (salesTarget != null)
            {
                var targetFind = await _unitOfWork.SalesTargets.GetById(salesTarget.SalesTargetId);
                if (targetFind != null)
                {
                    targetFind.TargetTaka = salesTarget.TargetTaka;
                    targetFind.EmployeeId = salesTarget.EmployeeId;
                    targetFind.ClosingDate = salesTarget.ClosingDate;


                    _unitOfWork.SalesTargets.Update(targetFind);

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
