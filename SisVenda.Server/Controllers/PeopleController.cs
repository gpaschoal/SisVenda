using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SisVenda.Domain.Commands;
using SisVenda.Domain.Entities;
using SisVenda.Domain.Handlers;
using SisVenda.Domain.Repositories;
using System.Collections.Generic;

namespace SisVenda.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        [Authorize]
        public GenericCommandResult Create([FromBody] CreatePeopleCommand command, [FromServices] PeopleHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpPut]
        [Authorize]
        public GenericCommandResult Update([FromBody] UpdatePeopleCommand command, [FromServices] PeopleHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpDelete]
        [Authorize]
        public GenericCommandResult Delete([FromBody] DeletePeopleCommand command, [FromServices] PeopleHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("{id}")]
        [HttpGet]
        [Authorize]
        public People GetById([FromServices] IPeopleRepository repository, string id)
        {
            return repository.GetById(id);
        }
        [Route("")]
        [HttpGet]
        [Authorize]
        public IEnumerable<People> GetAll([FromServices] IPeopleRepository repository)
        {
            return repository.GetAll();
        }

        [Route("customer")]
        [HttpGet]
        [Authorize]
        public IEnumerable<People> GetAllCustomer([FromServices] IPeopleRepository repository)
        {
            return repository.GetCustomer();
        }

        [Route("supplier")]
        [HttpGet]
        [Authorize]
        public IEnumerable<People> GetSupplier([FromServices] IPeopleRepository repository)
        {
            return repository.GetSupplier();
        }
    }
}