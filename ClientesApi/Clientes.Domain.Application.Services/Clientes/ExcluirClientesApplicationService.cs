using Clientes.Domain.Data.Entities;
using Clientes.Domain.Data.Mongo.Services;
using System.Collections.Generic;

namespace Clientes.Domain.Application.Services.Clientes
{
    public class ExcluirClientesApplicationService : IExcluirClientesApplicationService
    {
        private readonly IExcluirClientes _excluirClientes;

        public ExcluirClientesApplicationService()
        {
            _excluirClientes = new ExcluirClientes();
        }

        public void ExcluirPorCPF(string cpf)
        {
             _excluirClientes.ExcluirPorCPF(cpf);
        }
    }
}
