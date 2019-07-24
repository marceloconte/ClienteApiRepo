using Clientes.Domain.Data.Entities;
using Clientes.Domain.Data.Mongo.Services;
using System.Collections.Generic;

namespace Clientes.Domain.Application.Services.Clientes
{
    public class ObterClientesApplicationService : IObterClientesApplicationService
    {
        private readonly IObterTodosClientes _obterTodosClientes;

        public ObterClientesApplicationService()
        {
            _obterTodosClientes = new ObterTodosClientes();
        }

        public List<Cliente> ObterTodos()
        {
            return _obterTodosClientes.ObterTodos();
        }
    }
}
