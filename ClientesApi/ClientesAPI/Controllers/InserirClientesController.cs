using Clientes.Domain.Application.Services.Clientes;
using Clientes.Domain.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ClientesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InserirClientesController : ControllerBase
    {
        private IInserirClientesApplicationService _inserirClientesApplicationService;

        public InserirClientesController()
        {
            _inserirClientesApplicationService = new InserirClientesApplicationService();
        }

        [HttpPost]
        public void Post([FromBody]Cliente cliente)
        {
            _inserirClientesApplicationService.Inserir(cliente);

        }
    }
}
