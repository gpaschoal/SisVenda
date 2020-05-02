using Microsoft.AspNetCore.Mvc;
using SisVenda.Infra.Contexts;
using System.Threading.Tasks;

namespace SisVenda.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly Context context;
        public PessoasController(Context context)
        {
            this.context = context;
        }
        [HttpGet]
        //public async Task<ActionResult<DTOPessoas>> GetAll([FromQuery] PessoaFilter pessoaFilter)
        //{
        //    PessoasServices ps = new PessoasServices(context);
        //    return await ps.FindAll(pessoaFilter).ConfigureAwait(true);
        //}

        //[HttpGet("{id}")]
        ////[Authorize]
        //public async Task<ActionResult<Pessoas>> GetById(string id)
        //{
        //    PessoasServices ps = new PessoasServices(context);

        //    if (!Guid.TryParse(id, out Guid guid)) NotFound();

        //    //Pessoas pessoa = await ps.FindByID(guid).ConfigureAwait(true);
        //    //if (pessoa is null) return NotFound();
        //    return Ok(new Pessoas());
        //}

        //[HttpPost]
        ////[Authorize]
        //public async Task<ActionResult<Guid>> Add([FromBody] Pessoas pview)
        //{
        //    //PessoasContrato contrato = new PessoasContrato(pview);
        //    //if (!contrato.ContractValidation()) return BadRequest(contrato.Notifications);

        //    //PessoasServices ps = new PessoasServices(context);
        //    //Guid pessoa = await ps.Add(pview).ConfigureAwait(true);

        //    return null; // pessoa;
        //}

        //[HttpPut]
        ////[Authorize]
        //public async Task<ActionResult<bool>> Edit([FromBody] Pessoas pview)
        //{
        //    //PessoasContrato contrato = new PessoasContrato(pview);
        //    //if (!contrato.ContractValidation()) return BadRequest(contrato.Notifications);

        //    //PessoasServices ps = new PessoasServices(context);
        //    //await ps.Edit(pview).ConfigureAwait(true);
        //    return true;
        //}

        [HttpDelete]
        //[Authorize]
        public async Task Delete(string id)
        {
            //PessoasServices ps = new PessoasServices(context);
            //if (Guid.TryParse(id, out Guid guid))
            //    await ps.Delete(guid).ConfigureAwait(true);
        }
    }
}