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
    public class ProductsController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        [Authorize]
        public GenericCommandResult<ProductsResponse> Create([FromBody] ProductsCreateCommand command, [FromServices] ProductsHandler handler)
        {
            /* Calling Handle to create */
            return (GenericCommandResult<ProductsResponse>)handler.Handle(command);
        }

        [Route("")]
        [HttpPut]
        [Authorize]
        public GenericCommandResult<ProductsResponse> Update([FromBody] ProductsUpdateCommand command, [FromServices] ProductsHandler handler)
        {
            /* Calling Handle to Update */
            return (GenericCommandResult<ProductsResponse>)handler.Handle(command);
        }

        [Route("")]
        [HttpDelete]
        [Authorize]
        public GenericCommandResult<ProductsResponse> Delete([FromBody] ProductsDeleteCommand command, [FromServices] ProductsHandler handler)
        {
            /* Calling Handle to Delete */
            return (GenericCommandResult<ProductsResponse>)handler.Handle(command);
        }

        [Route("{id}")]
        [HttpGet]
        [Authorize]
        public ProductsResponse GetById([FromServices] IProductsRepository repository, string id)
        {
            return new ProductsResponse(repository.GetById(id));
        }

        [Route("Get")]
        [HttpPost]
        [Authorize]
        public GenericPaginatorResponse<ProductsResponse> GetAll([FromServices] IProductsRepository repository, [FromBody] ProductsFilter filter)
        {
            /* Getting all filtered people from my repo */
            IEnumerable<Products> filteredPeople = repository.GetAll(filter);

            /* Getting page, pagenumber and number of pages */
            (IQueryable<Products> page, int pageNumber, int countsInThisPage, int pageCount) = filteredPeople.AsQueryable().Paginator(filter);

            /* Filtering data to my response */
            List<ProductsResponse> response = page.ToList().Select(x => new ProductsResponse(x)).ToList();

            /* Creating my Generic Response */
            return new GenericPaginatorResponse<ProductsResponse>(pageNumber, countsInThisPage, pageCount, response);
        }
    }
}
