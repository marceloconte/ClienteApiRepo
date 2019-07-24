using Clientes.Domain.Data.Entities;

namespace Clientes.Domain.Application.Services.Clientes
{
    public interface IInserirClientesApplicationService
    {
        void Inserir(Cliente cliente);
    }
}