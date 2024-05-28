using SalesManagement.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Infrastructure.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly DbContextClass _dbContext;
        public IProductRepository Products { get; }
        public ICategoryRepository Categories { get; }
        public IEmployeeRepository Employees { get; }
        public IOrderRepository Orders { get; }
        public IOrderItemsRepository OrderItems { get; }
        public IPharmacyRepository Pharmacies { get; }
        public ISalesAchivementRepository SalesAchivmants { get; }
        public ISalesTargetRepository SalesTargets { get; }
        public IUnitRepository Units { get; }
        public IUnitConversionRepository UnitConversions { get; }
        public IStockRepository Stocks { get; }
        public UnitOfWork(DbContextClass dbContext, IProductRepository productRepository, ICategoryRepository categories, IEmployeeRepository employees, IOrderRepository orders, IOrderItemsRepository orderItems,IPharmacyRepository pharmacies, ISalesAchivementRepository salesAchivmants, ISalesTargetRepository salesTargets, IUnitRepository units, IUnitConversionRepository unitConversions, IStockRepository stocks)
        {
            _dbContext = dbContext;
            Products = productRepository;
            Categories = categories;
            Employees = employees;
            Orders = orders;
            OrderItems = orderItems;
            Pharmacies = pharmacies;
            SalesAchivmants = salesAchivmants;
            SalesTargets = salesTargets;
            Units = units;
            UnitConversions = unitConversions;
            Stocks = stocks;
        }
        public int Save()
        {
            return _dbContext.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
    }
}
