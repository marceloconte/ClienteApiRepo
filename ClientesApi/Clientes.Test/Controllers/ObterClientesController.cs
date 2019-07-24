using ClientesAPI.Controllers;
using Xunit;

namespace Clientes.Test.Controllers
{
    public class ObterlientesControllerParaSerValidoPrecisa
    {
        private ObterClientesController _obterClientesController;
 
        public ObterlientesControllerParaSerValidoPrecisa()
        {
            _obterClientesController = new ObterClientesController();
          }

        [Fact]
        public void TerClientesAoObterTodos()
        {
            var clientes = _obterClientesController.Get();

            Assert.NotNull(clientes.Value);
        }

    
    }

}

