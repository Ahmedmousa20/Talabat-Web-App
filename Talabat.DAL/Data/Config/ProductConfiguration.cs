using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.DAL.Entities;

namespace Talabat.DAL.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        //Entity ويبقا شكلها وحش وكبير لا انا هعمل لكل OnModelCreating ف ال fluent api فكره الكلاس دا انلى بدل م بروح اكتر كود ال
        // بتاعتو Configurations بتاعتو او ال fluent api  كلاس فيه كود ال
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(P => P.Name).IsRequired();
            builder.Property(P => P.Description).IsRequired();
            //.HasColumnType("decimal(18,2)") --  دى معناها ان الرقم هيكون مكون من 18 رقم منهم 2 بعد العلامه فراكشن يعني
            builder.Property(P => P.Price).HasColumnType("decimal(18,2)"); 
            builder.Property(P => P.PictureUrl).IsRequired();

            //اكتر على العلاقه constrains دا لو عايز احط 
            //builder.HasOne(P => P.ProductType).WithMany()
            //    .HasForeignKey(P=>P.ProductTypeId).IsRequired(true);
        }
    }
}
