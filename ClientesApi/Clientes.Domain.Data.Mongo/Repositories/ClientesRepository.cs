using System.Collections.Generic;
using Clientes.Domain.Data.Entities;

namespace Clientes.Domain.Data.Mongo.Repositories
{
    internal sealed class ClientesRepository : RepositoryBase<Cliente>, IClientesRepository
    {
        public List<Cliente> ObterTodos()
        {
            return GetAll();
        }

        public void Inserir(Cliente obj)
        {
            if(Exist(p => p.CPF == obj.CPF)) throw new System.Exception("Já existe um cliente com esse CPF");
            
            Insert(obj);
        }

        public void ExcluirPorCPF(string cpf)
        {
            if (Exist(p => p.CPF == cpf)) Remove(p => p.CPF == cpf);
        }

        public void Inserir(List<Cliente> list)
        {
            Insert(list);
        }

    }

}
