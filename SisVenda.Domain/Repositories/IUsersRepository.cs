using SisVenda.Domain.Entities;

namespace SisVenda.Domain.Repositories
{
    public interface IUsersRepository
    {
        Users Login(string username, string password);
    }
}
