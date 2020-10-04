using SisVenda.Domain.Entities;
using SisVenda.Domain.Repositories;

namespace SisVenda.Domain.Tests.Repositories
{
    public class UsersRepositoryFake : IUsersRepository
    {
        public Users Login(string username, string password)
        {
            return null;
        }
    }
}
