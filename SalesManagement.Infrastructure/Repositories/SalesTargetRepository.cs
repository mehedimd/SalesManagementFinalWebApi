﻿using SalesManagement.Core.Models;
using SalesManagement.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Infrastructure.Repositories
{
    public class SalesTargetRepository:GenericRepository<SalesTarget>,ISalesTargetRepository
    {
        public SalesTargetRepository(DbContextClass dbContext) : base(dbContext)
        {
            
        }
    }
}
