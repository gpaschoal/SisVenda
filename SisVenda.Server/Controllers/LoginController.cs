using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SisVenda.Domain.Repositories;
using SisVenda.Domain.Commands;
using System;
using SisVenda.Domain.Entities;
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
        public ActionResult<dynamic> Authenticate([FromServices] IUsersRepository repository, [FromBody] LoginUsersCommand login)
        {
            login.Validate();
            if (login.Invalid)
                return new GenericCommandResult(false, "Houve erro na validação", login.Notifications);

            Users user = repository.Login(login.Username, login.Password);
            if (user is null)
                return new GenericCommandResult(false, "Usuário ou senha inválidos", new object());

            return new { token = TokenService.GenerateToken(user) };
        }
    }
}
