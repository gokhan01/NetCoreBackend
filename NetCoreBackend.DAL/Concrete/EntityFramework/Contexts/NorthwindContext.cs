using Microsoft.EntityFrameworkCore;
using NetCoreBackend.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreBackend.DAL.Concrete.EntityFramework.Contexts
{
    public class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-UR9FUC3;Database=Northwind;Integrated Security=True");
        }

        public DbSet<Product> Products { get; set; }
    }
}
