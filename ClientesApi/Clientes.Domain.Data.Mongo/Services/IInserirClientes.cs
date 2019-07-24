using Clientes.Domain.Data.Entities;
using System.Collections.Generic;

namespace Clientes.Domain.Data.Mongo.Services
{
    public interface IInserirClientes
    {
        void Inserir(List<Cliente> clientes);
        void Inserir(Cliente clientes);
    }
}