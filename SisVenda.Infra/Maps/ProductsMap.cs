using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisVenda.Domain.Entities;

namespace SisVenda.Infra.Maps
{
    public class ProductsMap : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.ToTable("Products");
            builder.HasOne(x => x.UnitMeasurement).WithMany(x => x.Products).HasForeignKey(x => x.UnitMeasurementId);
        }
    }
}
