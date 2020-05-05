using Microsoft.EntityFrameworkCore;
using SisVenda.Domain.Entities;
using SisVenda.Domain.Repositories;
using SisVenda.Infra.Contexts;
using System.Linq;

namespace SisVenda.Infra.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly SisVendaContext _context;

        public UsersRepository(SisVendaContext context)
        {
            _context = context;
        }

        public Users Login(string username, string password)
        {
            return _context.Users.AsNoTracking().FirstOrDefault(x => x.User.ToLower() == username.ToLower() && x.Password == password);
        }
    }
}
