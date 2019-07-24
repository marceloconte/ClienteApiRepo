using System.Collections.Generic;
using Clientes.Domain.Application.Services.Clientes;
using Clientes.Domain.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ClientesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObterClientesController : ControllerBase
    {
        private IObterClientesApplicationService _obterClientesApplicationService;

        public ObterClientesController()
        {
            _obterClientesApplicationService = new ObterClientesApplicationService();
        }

        [HttpGet]
        public ActionResult<IList<Cliente>> Get()
        {
            return _obterClientesApplicationService.ObterTodos();
        }
    }
}
