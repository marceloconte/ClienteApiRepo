using Clientes.Domain.Data.Mongo.Repositories;

namespace Clientes.Domain.Data.Mongo.Services
{
    public class ExcluirClientes : IExcluirClientes
    {
        private readonly IClientesRepository _ClientesRepository;

        public ExcluirClientes()
        {
            _ClientesRepository = new ClientesRepository();
        }

        public void ExcluirPorCPF(string cpf)
        {

            _ClientesRepository.ExcluirPorCPF(cpf);
        }


    }
}
