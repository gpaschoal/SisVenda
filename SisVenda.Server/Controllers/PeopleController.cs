using Microsoft.AspNetCore.Mvc;
using SisVenda.Domain.Commands;
using SisVenda.Domain.Handlers;
using SisVenda.Infra.Contexts;

namespace SisVenda.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly SisVendaContext context;
        public PeopleController(SisVendaContext context)
        {
            this.context = context;
        }

        [Route("")]
        [HttpPost]
        public GenericCommandResult Create([FromBody] CreatePeopleCommand command, [FromServices] PeopleHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpPut]
        public GenericCommandResult Update([FromBody] UpdatePeopleCommand command, [FromServices] PeopleHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpDelete]
        public GenericCommandResult Delete([FromBody] DeletePeopleCommand command, [FromServices] PeopleHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}