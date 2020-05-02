using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisVenda.Domain.Entities;

namespace SisVenda.Infra.Maps
{
    class PurchasesMap : IEntityTypeConfiguration<Purchases>
    {
        public void Configure(EntityTypeBuilder<Purchases> builder)
        {
            builder.ToTable("Purchases");
            builder.HasOne(x => x.People).WithMany(x => x.Purchases).HasForeignKey(x => x.PeopleId);
        }
    }
}
