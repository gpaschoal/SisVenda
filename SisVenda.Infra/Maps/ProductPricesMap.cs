using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisVenda.Domain.Entities;

namespace SisVenda.Infra.Maps
{
    public class ProductPricesMap : IEntityTypeConfiguration<ProductsPrices>
    {
        public void Configure(EntityTypeBuilder<ProductsPrices> builder)
        {
            builder.ToTable("ProductPrices");
            builder.HasOne(x => x.Product).WithMany(x => x.ProductsPrices).HasForeignKey(x => x.ProductId);
        }
    }
}
