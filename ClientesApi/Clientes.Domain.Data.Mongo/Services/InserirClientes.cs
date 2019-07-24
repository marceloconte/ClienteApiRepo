using Clientes.Domain.Data.Entities;
using Clientes.Domain.Data.Mongo.Repositories;
using System.Collections.Generic;

namespace Clientes.Domain.Data.Mongo.Services
{
    public class InserirClientes : IInserirClientes
    {
        private readonly IClientesRepository _ClientesRepository;

        public InserirClientes()
        {
            _ClientesRepository = new ClientesRepository();
        }

        public void Inserir(Cliente Cliente)
        {
            _ClientesRepository.Inserir(Cliente);
        }

        public void Inserir(List<Cliente> Clientes)
        {
            _ClientesRepository.Inserir(Clientes);
        }
    }
}
