using System.Collections.Generic;
using Clientes.Domain.Data.Entities;

namespace Clientes.Domain.Data.Mongo.Repositories
{
    internal interface IClientesRepository
    {
        void Inserir(Cliente obj);
        void Inserir(List<Cliente> list);
        void ExcluirPorCPF(string cpf);
        List<Cliente> ObterTodos();
    }
}