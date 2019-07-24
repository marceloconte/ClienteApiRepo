using Clientes.Domain.Data.Entities;
using Clientes.Domain.Data.Mongo.Repositories;
using System.Collections.Generic;

namespace Clientes.Domain.Data.Mongo.Services
{
    public class ObterTodosClientes : IObterTodosClientes
    {
        private readonly IClientesRepository _clientesRepository;

        public ObterTodosClientes()
        {
            _clientesRepository = new ClientesRepository();
        }

        public List<Cliente> ObterTodos()
        {
            return _clientesRepository.ObterTodos();
        }
    }
}
