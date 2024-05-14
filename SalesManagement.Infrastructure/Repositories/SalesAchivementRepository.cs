﻿using SalesManagement.Core.Models;
using SalesManagement.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Infrastructure.Repositories
{
    internal class SalesAchivementRepository:GenericRepository<SalesAchivement>,ISalesAchivementRepository
    {
        public SalesAchivementRepository(DbContextClass dbContext) : base(dbContext)
        {
            
        }
    }
}
