using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisVenda.Domain.Entities;

namespace SisVenda.Infra.Maps
{
    public class PurchasesItemsMap : IEntityTypeConfiguration<PurchasesItems>
    {
        public void Configure(EntityTypeBuilder<PurchasesItems> builder)
        {
            builder.ToTable("PurchasesItems");
            builder.HasKey(x => new { x.PurchasesId, x.Id });
            builder.HasOne(x => x.Product).WithMany(x => x.PurchasesItems).HasForeignKey(x => x.ProductsId);
        }
    }
}
