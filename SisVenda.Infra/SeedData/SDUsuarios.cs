using SisVenda.Domain.Entities;
using System.Collections.Generic;

namespace SisVenda.Infra.SeedData
{
    public static class SDUsuarios
    {
        public static List<Users> Usuarios()
        {
            return new List<Users> { new Users("Administrador", "123", "admin") };
        }
    }
}
