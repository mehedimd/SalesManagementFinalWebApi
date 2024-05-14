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
    public class UnitService: IUnitService
    {
        public IUnitOfWork _unitOfWork;

        public UnitService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateUnit(Unit unit)
        {
            if (unit != null)
            {
                await _unitOfWork.Units.Add(unit);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteUnit(int unitId)
        {
            if (unitId > 0)
            {
                var unit = await _unitOfWork.Units.GetById(unitId);
                if (unit != null)
                {
                    _unitOfWork.Units.Delete(unit);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Unit>> GetAllUnits()
        {
            var unitList = await _unitOfWork.Units.GetAll();
            return unitList;
        }

        public async Task<Unit> GetUnitById(int unitId)
        {
            if (unitId > 0)
            {
                var unit = await _unitOfWork.Units.GetById(unitId);
                if (unit != null)
                {
                    return unit;
                }
            }
            return null;
        }

        public async Task<bool> UpdateUnit(Unit unit)
        {
            if (unit != null)
            {
                var unitFind = await _unitOfWork.Units.GetById(unit.UnitId);
                if (unitFind != null)
                {
                    unitFind.UnitName = unit.UnitName;


                    _unitOfWork.Units.Update(unitFind);

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
