using refactor_me.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactor_me.DataAccess
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            ToTable("Product");
            Ignore(p => p.IsValid);

            Property(p => p.Id)
               .IsRequired();

            Property(p => p.Name)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(100);

            Property(p => p.Description)
                .HasColumnType("nvarchar")
                .HasMaxLength(500);

            Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal")
                .HasPrecision(18, 2);

            Property(p => p.DeliveryPrice)
               .IsRequired()
               .HasColumnType("decimal")
               .HasPrecision(18, 2);

            HasMany<ProductOption>(p => p.ProductOption)
                .WithRequired(po => po.Product)
                .WillCascadeOnDelete();
        }
    }
}
