using SalesManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Services.Interfaces
{
    public interface ISalesAchivementService
    {
        Task<bool> CreateSalesAchivement(SalesAchivement salesAchivement);

        Task<IEnumerable<SalesAchivement>> GetAllSalesAchivements();

        Task<SalesAchivement> GetSalesAchivementById(int salesAchivementId);

        Task<bool> UpdateSalesAchivement(SalesAchivement salesAchivement);

        Task<bool> DeleteSalesAchivement(int salesAchivementId);
    }
}
