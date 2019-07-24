using System.Collections.Generic;
using Clientes.Domain.Data.Entities;

namespace Clientes.Domain.Application.Services.Clientes
{
    public interface IObterClientesApplicationService
    {
        List<Cliente> ObterTodos();
    }
}