using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisVenda.Domain.Entities;

namespace SisVenda.Infra.Maps
{
    class ProductsProfileMap : IEntityTypeConfiguration<ProductsProfile>
    {
        public void Configure(EntityTypeBuilder<ProductsProfile> builder)
        {
            builder.HasIndex(x => new { x.BarCode, x.DtDeleted }).IsUnique();
        }
    }
}
