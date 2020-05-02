using Microsoft.AspNetCore.Mvc;
using SisVenda.Infra.Contexts;
using System.Threading.Tasks;

namespace SisVenda.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly SisVendaContext context;
        public PessoasController(SisVendaContext context)
        {
            this.context = context;
        }
       
    }
}