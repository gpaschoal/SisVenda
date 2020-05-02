using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisVenda.Domain.Entities;

namespace SisVenda.Infra.Maps
{
    public class LossesMap : IEntityTypeConfiguration<Losses>
    {
        public void Configure(EntityTypeBuilder<Losses> builder)
        {
            builder.ToTable("Losses");
            builder.HasOne(x => x.Product).WithMany(x => x.Losses).HasForeignKey(x => x.ProductId);
        }
    }
}
