using SalesManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Services.Interfaces
{
    public interface IUnitConvertionService
    {
        Task<bool> CreateUnitConvertion(UnitConvertion unitConvertion);

        Task<IEnumerable<UnitConvertion>> GetAllUnitConvertions();

        Task<UnitConvertion> GetUnitConvertionById(int unitConvertionId);

        Task<bool> UpdateUnitConvertion(UnitConvertion unitConvertion);

        Task<bool> DeleteUnitConvertion(int unitConvertionId);
        object GetUnitConvertions();
    }
}
