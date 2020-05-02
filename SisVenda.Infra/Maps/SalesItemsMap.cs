using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisVenda.Domain.Entities;

namespace SisVenda.Infra.Maps
{
    public class SalesItemsMap : IEntityTypeConfiguration<SalesItems>
    {
        public void Configure(EntityTypeBuilder<SalesItems> builder)
        {
            builder.ToTable("SalesItems");
            builder.HasKey(x => new { x.SalesId, x.Id });
            builder.HasOne(x => x.Product).WithMany(x => x.SalesItems).HasForeignKey(x => x.ProductsId);
        }
    }
}
