using System.Collections.Generic;
using Clientes.Domain.Data.Entities;

namespace Clientes.Domain.Data.Mongo.Services
{
    public interface IObterTodosClientes
    {
        List<Cliente> ObterTodos();
    }
}