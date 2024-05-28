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
    public class StockService : IStockService
    {
        public IUnitOfWork _unitOfWork;

        public StockService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateStock(Stock stock)
        {
            if (stock != null)
            {
                await _unitOfWork.Stocks.Add(stock);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteStock(int stockId)
        {
            if (stockId > 0)
            {
                var stock = await _unitOfWork.Stocks.GetById(stockId);
                if (stock != null)
                {
                    _unitOfWork.Stocks.Delete(stock);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Stock>> GetAllStocks()
        {
            var stockList = await _unitOfWork.Stocks.GetAll();
            return stockList;
        }

        public async Task<Stock> GetStockById(int stockId)
        {
            if (stockId > 0)
            {
                var stock = await _unitOfWork.Stocks.GetById(stockId);
                if (stock != null)
                {
                    return stock;
                }
            }
            return null;
        }

        public async Task<bool> UpdateStock(Stock stock)
        {
            if (stock != null)
            {
                var stockFind = await _unitOfWork.Stocks.GetById(stock.StockId);
                if (stockFind != null)
                {
                    stockFind.ProductId = stock.ProductId;
                    stockFind.Quantity = stock.Quantity;

                    _unitOfWork.Stocks.Update(stockFind);

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
