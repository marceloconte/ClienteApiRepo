using Clientes.Domain.Data.Entities;
using Clientes.Domain.Data.Mongo.Services;
using Clientes.Framework;
using System;

namespace Clientes.Domain.Application.Services.Clientes
{
    public class InserirClientesApplicationService : IInserirClientesApplicationService
    {
        private readonly IInserirClientes _inserirClientes;

        public InserirClientesApplicationService()
        {
            _inserirClientes = new InserirClientes();
        }

        public void Inserir(Cliente cliente)
        {
            if (cliente.IsNull()) throw new Exception("Cliente não preenchido");

            if (cliente.Nome.IsEmpty()) throw new Exception("Cliente com Nome não preenchido");
            if (cliente.Nome.HasLenghtMoreThan(30)) throw new Exception("Cliente deve ter Nome com máximo de 30 caracteres");
            if (cliente.CPF.IsEmpty()) throw new Exception("Cliente com CPF não preenchido");
            if (cliente.CPF.IsNotCPFValid()) throw new Exception("Cliente com CPF com formato inválido");
            if (cliente.DataNascimento.IsEmpty()) throw new Exception("Cliente com Data de Nascimento não preenchido");

            if (cliente.Endereco.IsNull()) throw new Exception("Cliente com Endereço não preenchido");
            if (cliente.Endereco.Logradouro.IsEmpty()) throw new Exception("Cliente com Logradouro no Endereço não preenchido");
            if (cliente.Endereco.Logradouro.HasLenghtMoreThan(50)) throw new Exception("Cliente deve ter Logradouro no Endereço com máximo de 50 caracteres");
            if (cliente.Endereco.Bairro.IsEmpty()) throw new Exception("Cliente com Bairro no Endereço não preenchido");
            if (cliente.Endereco.Bairro.HasLenghtMoreThan(40)) throw new Exception("Cliente deve ter Bairro no Endereço com máximo de 40 caracteres");
            if (cliente.Endereco.Cidade.IsEmpty()) throw new Exception("Cliente com Cidade no Endereço não preenchido");
            if (cliente.Endereco.Cidade.HasLenghtMoreThan(40)) throw new Exception("Cliente deve ter Cidade no Endereço com máximo de 40 caracteres");
            if (cliente.Endereco.Estado.IsEmpty()) throw new Exception("Cliente com Estado no Endereço não preenchido");
            if (cliente.Endereco.Estado.HasLenghtMoreThan(40)) throw new Exception("Cliente deve ter Estado no Endereço com máximo de 40 caracteres");

            _inserirClientes.Inserir(cliente);
        }
    }
}
