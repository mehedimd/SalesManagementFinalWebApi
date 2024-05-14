using SalesManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Services.Interfaces
{
    public interface IUnitService
    {
        Task<bool> CreateUnit(Unit unit);

        Task<IEnumerable<Unit>> GetAllUnits();

        Task<Unit> GetUnitById(int unitId);

        Task<bool> UpdateUnit(Unit unit);

        Task<bool> DeleteUnit(int unitId);
    }
}
