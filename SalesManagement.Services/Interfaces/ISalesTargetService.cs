using SalesManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Services.Interfaces
{
    public interface ISalesTargetService
    {
        Task<bool> CreateSalesTarget(SalesTarget salesTarget);

        Task<IEnumerable<SalesTarget>> GetAllSalesTargets();

        Task<SalesTarget> GetSalesTargetById(int salesTargetId);

        Task<bool> UpdateSalesTarget(SalesTarget salesTarget);

        Task<bool> DeleteSalesTarget(int salesTargetId);
    }
}
