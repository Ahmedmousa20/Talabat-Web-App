using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Talabat.DAL.Data.Config;
using Talabat.DAL.Entities;

namespace Talabat.DAL.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options):base(options)
        {

        }

        public DbSet<Product> Products { set; get; }
        public DbSet<ProductBrand> ProductBrands { set; get; }
        public DbSet<ProductType> ProductTypes { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //بتاع كل كلاس fluent api هنا بنادى كود ال
            //modelBuilder.ApplyConfiguration(new ProductConfiguration());
            //modelBuilder.ApplyConfiguration(new OrderConfiguration());  

            //entities بتاع كل ال fluent api دى بنادى بيها كود ال
            //IEntityTypeConfiguration ال impelement عن طريف انو بجيب كل الكلاسيس الي بت fluent api وبيعرف الكلاسيس بتاعه كود ال
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
