using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisVenda.Domain.Entities;

namespace SisVenda.Infra.Maps
{
    public class PrecosProdutoMap : IEntityTypeConfiguration<ProductPrices>
    {
        public void Configure(EntityTypeBuilder<ProductPrices> builder)
        {
            //builder.HasKey(x => new { x.IdProduto, x.IdPrecoProduto });
        }
    }
}
