using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata;
using SalesManagement.Core.Models;

namespace SalesManagement.Infrastructure
{
    //public class DbContextFactory : IDesignTimeDbContextFactory<DbContextClass>
    //{
    //    public DbContextClass CreateDbContext(string[] args)
    //    {
    //        var optionsBuilder = new DbContextOptionsBuilder<DbContextClass>();
    //        optionsBuilder.UseSqlServer("Server=.;Database = SalesManagmentFinalDB; User Id=sa;Password=123; TrustServerCertificate = true; Trusted_Connection = true;MultipleActiveResultSets=True;");
    //        return new DbContextClass(optionsBuilder.Options);
    //    }
    //}
    public partial class DbContextClass : IdentityDbContext<ApplicationUser>
    {
        public DbContextClass()
        {

        }
        public DbContextClass(DbContextOptions<DbContextClass> contextOptions) : base(contextOptions)
        {

        }

        public DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderItems> OrderItems { get; set; } = null!;
        public virtual DbSet<Pharmacy> Pharmacies { get; set; } = null!;
        public virtual DbSet<SalesAchivement> SalesAchivements { get; set; } = null!;
        public virtual DbSet<SalesTarget> SalesTargets { get; set; } = null!;
        public virtual DbSet<Unit> Units { get; set; } = null!;
        public virtual DbSet<UnitConvertion> UnitConvertions { get; set; } = null!;
        public virtual DbSet<Stock> Stocks { get; set; } = null!;
        public virtual DbSet<PharmacyRoute> PharmacyRoute { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database = SalesManagmentFinalDB; User Id=sa;Password=123; TrustServerCertificate = true; Trusted_Connection = true;MultipleActiveResultSets=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // for user role
            List<IdentityRole> identityRoles = new List<IdentityRole>(){
                        new IdentityRole(){ Name = "manager", NormalizedName = "manager"},
                        new IdentityRole(){ Name = "sr", NormalizedName = "sr"},
                        new IdentityRole(){ Name = "rider", NormalizedName = "rider"}

                    };
            builder.Entity<IdentityRole>().HasData(identityRoles);

        }

    }
}
