using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisVenda.Domain.Entities;

namespace SisVenda.Infra.Maps
{
    public class ItensVendaMap : IEntityTypeConfiguration<SalesItems>
    {
        public void Configure(EntityTypeBuilder<SalesItems> builder)
        {
            //builder.ToTable("ItensVenda");
            builder.HasKey(x => new { x.IdSales, x.Id });
        }
    }
}
