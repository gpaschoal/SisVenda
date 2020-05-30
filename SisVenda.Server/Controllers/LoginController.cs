using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SisVenda.Domain.Commands;
using SisVenda.Domain.Entities;
using SisVenda.Domain.Repositories;
using SisVenda.Domain.Responses;
using SisVenda.Server.Services;

namespace SisVenda.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public ActionResult<GenericCommandResult<LoginTokenResponse>> Authenticate([FromServices] IUsersRepository repository, [FromBody] LoginUsersCommand login)
        {
            login.Validate();
            if (login.Invalid)
                return new GenericCommandResult<LoginTokenResponse>(false, "Houve erro na validação", login.Notifications);

            Users user = repository.Login(login.Username, login.Password);
            if (user is null)
                return new GenericCommandResult<LoginTokenResponse>(false, "Usuário ou senha inválidos", new LoginTokenResponse());

            return new GenericCommandResult<LoginTokenResponse>(true, "Usuário válido!", new LoginTokenResponse(TokenService.GenerateToken(user)));
        }
    }
}
