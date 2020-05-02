using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisVenda.Domain.Entities;

namespace SisVenda.Infra.Maps
{
    class SalesMap : IEntityTypeConfiguration<Sales>
    {
        public void Configure(EntityTypeBuilder<Sales> builder)
        {
            builder.ToTable("Sales");
            builder.HasOne(x => x.People).WithMany(x => x.Sales).HasForeignKey(x => x.PeopleId);
        }
    }
}
