using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class ProductsProfileController : Controller
    {
        [Route("")]
        [HttpPost]
        [Authorize]
        public GenericCommandResult<ProductsProfileResponse> Create([FromBody] ProductsProfileCreateCommand command, [FromServices] ProductsProfileHandler handler)
        {
            /* Calling Handle to create */
            return (GenericCommandResult<ProductsProfileResponse>)handler.Handle(command);
        }

        [Route("")]
        [HttpPut]
        [Authorize]
        public GenericCommandResult<ProductsProfileResponse> Update([FromBody] ProductsProfileUpdateCommand command, [FromServices] ProductsProfileHandler handler)
        {
            /* Calling Handle to Update */
            return (GenericCommandResult<ProductsProfileResponse>)handler.Handle(command);
        }

        [Route("")]
        [HttpDelete]
        [Authorize]
        public GenericCommandResult<ProductsProfileResponse> Delete([FromBody] ProductsProfileDeleteCommand command, [FromServices] ProductsProfileHandler handler)
        {
            /* Calling Handle to Delete */
            return (GenericCommandResult<ProductsProfileResponse>)handler.Handle(command);
        }

        [Route("{id}")]
        [HttpGet]
        [Authorize]
        public ProductsProfileResponse GetById([FromServices] IProductsProfileRepository repository, string id)
        {
            return new ProductsProfileResponse(repository.GetById(id));
        }
        [Route("Get")]
        [HttpPost]
        [Authorize]
        public GenericPaginatorResponse<ProductsProfileResponse> GetAll([FromServices] IProductsProfileRepository repository, [FromBody] ProductsProfileFilter filter)
        {
            /* Getting all filtered ProductsProfile from my repo */
            IEnumerable<ProductsProfile> filteredProductsProfile = repository.GetAll(filter);

            /* Getting page, pagenumber and number of pages */
            (IQueryable<ProductsProfile> page, int pageNumber, int countsInThisPage, int pageCount) = filteredProductsProfile.AsQueryable().Paginator(filter);

            /* Filtering data to my response */
            List<ProductsProfileResponse> response = page.Include(x => x.Products).Include(x => x.UnitMeasurement).Select(x => new ProductsProfileResponse(x)).ToList();

            /* Creating my Generic Response */
            return new GenericPaginatorResponse<ProductsProfileResponse>(pageNumber, countsInThisPage, pageCount, response);
        }
    }
}
