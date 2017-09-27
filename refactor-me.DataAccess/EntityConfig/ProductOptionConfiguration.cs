using refactor_me.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactor_me.DataAccess
{
    public class ProductOptionConfiguration : EntityTypeConfiguration<ProductOption>
    {
        public ProductOptionConfiguration()
        {
            ToTable("ProductOption");
            Ignore(p => p.IsValid);

            Property(p => p.Id)
               .IsRequired();

            Property(p => p.ProductId)
                .IsRequired();

            Property(p => p.Name)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(100);

            Property(p => p.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(500);

        }
    }
}
