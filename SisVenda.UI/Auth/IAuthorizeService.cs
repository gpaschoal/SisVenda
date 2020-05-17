using System.Threading.Tasks;

namespace SisVenda.UI.Auth
{
    public interface IAuthorizeService
    {
        Task Login(string token);
        Task Logout();
    }
}