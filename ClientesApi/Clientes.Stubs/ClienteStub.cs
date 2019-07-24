using Clientes.Domain.Data.Entities;
using Clientes.Framework.Stubs;
using System;

namespace Clientes.Stubs
{
    public class ClienteStub : IStub<Cliente>
    {
        private Cliente _clienteStubbing;

        public ClienteStub()
        {
            _clienteStubbing = new Cliente();
        }

        public ClienteStub ComDefaults()
        {
            _clienteStubbing = new Cliente
            {
                Nome = "Marcelo Conte Barbosa",
                CPF = "557.218.574-47",
                DataNascimento = new DateTime(1979, 10, 20),
                Endereco = new Endereco()
                {
                    Logradouro = "Rua Franciscana",
                    Bairro = "Tijuca",
                    Cidade = "Rio de Janeiro",
                    Estado = "RJ"
                }
            };

            return this;
        }

        public ClienteStub ComNome(string value)
        {
            _clienteStubbing.Nome = value;

            return this;
        }

        public ClienteStub ComCPF(string value)
        {
            _clienteStubbing.CPF = value;

            return this;
        }
        
        public ClienteStub ComCPFNovo()
        {
            _clienteStubbing.CPF = "661.271.870-60";

            return this;
        }

        public ClienteStub ComDataNascimento(DateTime value)
        {
            _clienteStubbing.DataNascimento = value;

            return this;
        }

        public ClienteStub ComEndereco(Endereco value)
        {
            _clienteStubbing.Endereco = value;

            return this;
        }

        public ClienteStub ComLogradouro(string value)
        {
            _clienteStubbing.Endereco.Logradouro = value;

            return this;
        }

        public ClienteStub ComBairro(string value)
        {
            _clienteStubbing.Endereco.Bairro = value;

            return this;
        }

        public ClienteStub ComCidade(string value)
        {
            _clienteStubbing.Endereco.Cidade = value;

            return this;
        }

        public ClienteStub ComEstado(string value)
        {
            _clienteStubbing.Endereco.Estado = value;

            return this;
        }

        public Cliente Build()
        {
            return _clienteStubbing;
        }

    }
}
