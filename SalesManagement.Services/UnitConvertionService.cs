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
    public class UnitConvertionService : IUnitConvertionService
    {
        public IUnitOfWork _unitOfWork;

        public UnitConvertionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateUnitConvertion(UnitConvertion unitConvertion)
        {
            if (unitConvertion != null)
            {
                await _unitOfWork.UnitConversions.Add(unitConvertion);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteUnitConvertion(int convertionId)
        {
            if (convertionId > 0)
            {
                var unitConversion = await _unitOfWork.UnitConversions.GetById(convertionId);
                if (unitConversion != null)
                {
                    _unitOfWork.UnitConversions.Delete(unitConversion);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<UnitConvertion>> GetAllUnitConvertions()
        {
            var conversionList = await _unitOfWork.UnitConversions.GetAll();
            return conversionList;
        }

        public async Task<UnitConvertion> GetUnitConvertionById(int convertionId)
        {
            if (convertionId > 0)
            {
                var unitConvertion = await _unitOfWork.UnitConversions.GetById(convertionId);
                if (unitConvertion != null)
                {
                    return unitConvertion;
                }
            }
            return null;
        }

        public object GetUnitConvertions()
        {
           return this._unitOfWork.UnitConversions.GetUnitConvertions();
        }

        public async Task<bool> UpdateUnitConvertion(UnitConvertion unitConvertion)
        {
            if (   unitConvertion  != null)
            {
                var convertionFind = await _unitOfWork.UnitConversions.GetById(unitConvertion.UnitConvertionId);
                if (convertionFind != null)
                {
                    convertionFind.UnitId = unitConvertion.UnitId;
                    convertionFind.ProductId = unitConvertion.ProductId;
                    convertionFind.Quantity = unitConvertion.Quantity;


                    _unitOfWork.UnitConversions.Update(convertionFind);

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
