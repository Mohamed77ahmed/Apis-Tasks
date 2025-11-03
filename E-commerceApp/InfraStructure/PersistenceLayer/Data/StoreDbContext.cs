using DomainLayer.Models.ProductModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceLayer.Data
{
    public class StoreDbContext:DbContext
    {
       public DbSet<Product>products { get; set; }
       public DbSet<ProductBrand> productBrands { get; set; }
       public DbSet<ProductType> productTypes { get; set; }

        public StoreDbContext(DbContextOptions<StoreDbContext>options):base(options)
        { 

        }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
