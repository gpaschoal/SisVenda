using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisVenda.Domain.Entities;

namespace SisVenda.Infra.Maps
{
    public class ItensCompraMap : IEntityTypeConfiguration<PurchasesItems>
    {
        public void Configure(EntityTypeBuilder<PurchasesItems> builder)
        {
            //builder.ToTable("ItensCompra");
            builder.HasKey(x => new { x.IdPurchase, x.Id });
        }
    }
}
