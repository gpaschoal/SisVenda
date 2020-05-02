using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisVenda.Domain.Entities;
using SisVenda.Infra.SeedData;

namespace SisVenda.Infra.Maps
{
    public class UsuariosMap : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            //builder.HasMany(x => x.IdPerfilUsuario).
            builder.HasData(SDUsuarios.Usuarios());
        }
    }
}
