using SalesManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Services.Interfaces
{
    public interface IStockService
    {
        Task<bool> CreateStock(Stock stock);

        Task<IEnumerable<Stock>> GetAllStocks();

        Task<Stock> GetStockById(int stockId);

        Task<bool> UpdateStock(Stock stock);

        Task<bool> DeleteStock(int stockId);
    }
}
