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
    public class UnitMeasurementController : ControllerBase
    {

        [Route("")]
        [HttpPost]
        [Authorize]
        public GenericCommandResult<UnitMeasurementResponse> Create([FromBody] CreateUnitMeasurementCommand command, [FromServices] UnitMeasurementHandler handler)
        {
            /* Calling Handle to create */
            return (GenericCommandResult<UnitMeasurementResponse>)handler.Handle(command);
        }

        [Route("")]
        [HttpPut]
        [Authorize]
        public GenericCommandResult<UnitMeasurementResponse> Update([FromBody] UpdateUnitMeasurementCommand command, [FromServices] UnitMeasurementHandler handler)
        {
            /* Calling Handle to Update */
            return (GenericCommandResult<UnitMeasurementResponse>)handler.Handle(command);
        }

        [Route("")]
        [HttpDelete]
        [Authorize]
        public GenericCommandResult<UnitMeasurementResponse> Delete([FromBody] DeleteUnitMeasurementCommand command, [FromServices] UnitMeasurementHandler handler)
        {
            /* Calling Handle to Delete */
            return (GenericCommandResult<UnitMeasurementResponse>)handler.Handle(command);
        }

        [Route("{id}")]
        [HttpGet]
        [Authorize]
        public UnitMeasurementResponse GetById([FromServices] IUnitMeasurementRepository repository, string id)
        {
            return new UnitMeasurementResponse(repository.GetById(id));
        }
        [Route("Get")]
        [HttpPost]
        [Authorize]
        public GenericPaginatorResponse<UnitMeasurementResponse> GetAll([FromServices] IUnitMeasurementRepository repository, [FromBody] UnitMeasurementFilter filter)
        {
            /* Getting all filtered people from my repo */
            IEnumerable<UnitMeasurement> filteredUnitMeasurement = repository.GetAll(filter);

            /* Getting page, pagenumber and number of pages */
            (IQueryable<UnitMeasurement> page, int pageNumber, int countsInThisPage, int pageCount) = filteredUnitMeasurement.AsQueryable().Paginator(filter);

            /* Filtering data to my response */
            List<UnitMeasurementResponse> response = page.ToList().Select(x => new UnitMeasurementResponse(x)).ToList();

            /* Creating my Generic Response */
            return new GenericPaginatorResponse<UnitMeasurementResponse>(pageNumber, countsInThisPage, pageCount, response);
        }
    }
}
