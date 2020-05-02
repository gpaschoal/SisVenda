using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisVenda.Domain.Entities;

namespace SisVenda.Infra.Maps
{
    public class PercasMap : IEntityTypeConfiguration<Losses>
    {
        public void Configure(EntityTypeBuilder<Losses> builder)
        {
            //builder.HasKey(x => new { x.IdPerca });
        }
    }
}
