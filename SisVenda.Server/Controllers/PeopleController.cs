using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SisVenda.Domain.Commands;
using SisVenda.Domain.Entities;
using SisVenda.Domain.Handlers;
using SisVenda.Domain.Repositories;
using SisVenda.Domain.Responses;
using SisVenda.Shared.DTO.Filters;
using SisVenda.Shared.Extencoes;
using System.Collections.Generic;
using System.Linq;

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
            /* Calling Handle to create */
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpPut]
        [Authorize]
        public GenericCommandResult Update([FromBody] UpdatePeopleCommand command, [FromServices] PeopleHandler handler)
        {
            /* Calling Handle to Update */
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpDelete]
        [Authorize]
        public GenericCommandResult Delete([FromBody] DeletePeopleCommand command, [FromServices] PeopleHandler handler)
        {
            /* Calling Handle to Delete */
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("{id}")]
        [HttpGet]
        [Authorize]
        public PeopleResponse GetById([FromServices] IPeopleRepository repository, string id)
        {
            return new PeopleResponse(repository.GetById(id));
        }
        [Route("")]
        [HttpGet]
        [Authorize]
        public GenericPaginatorResponse<PeopleResponse> GetAll([FromServices] IPeopleRepository repository, [FromQuery] PeopleFilter filter)
        {
            /* Getting all filtered people from my repo */
            IEnumerable<People> filteredPeople = repository.GetAll(filter);

            /* Getting page, pagenumber and number of pages */
            (IQueryable<People> page, int pageNumber, int countsInThisPage, int pageCount) = filteredPeople.AsQueryable().Paginator(filter);

            /* Filtering data to my response */
            List<PeopleResponse> response = page.ToList().Select(x => new PeopleResponse(x)).ToList();

            /* Creating my Generic Response */
            return new GenericPaginatorResponse<PeopleResponse>(pageNumber, countsInThisPage, pageCount, response);
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