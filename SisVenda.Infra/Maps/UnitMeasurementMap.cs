using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisVenda.Domain.Entities;

namespace SisVenda.Infra.Maps
{
    class UnitMeasurementMap : IEntityTypeConfiguration<UnitMeasurement>
    {
        public void Configure(EntityTypeBuilder<UnitMeasurement> builder)
        {
            //builder.HasOne(x=> x.p)
        }
    }
}
