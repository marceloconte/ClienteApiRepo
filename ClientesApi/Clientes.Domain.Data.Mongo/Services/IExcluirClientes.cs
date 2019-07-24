namespace Clientes.Domain.Data.Mongo.Services
{
    public interface IExcluirClientes
    {
        void ExcluirPorCPF(string cpf);
    }
}