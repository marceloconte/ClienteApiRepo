using Clientes.Domain.Application.Services.Clientes;
using Clientes.Domain.Data.Entities;
using Clientes.Stubs;
using ClientesAPI.Controllers;
using System;
using Xunit;

namespace Clientes.Test.Controllers
{
    public class InserirClientesControllerParaSerValidoPrecisa 
    {
        private IExcluirClientesApplicationService _excluirClientesApplicationService;
        private InserirClientesController _inserirClientesController;

        public InserirClientesControllerParaSerValidoPrecisa()
        {
            _inserirClientesController = new InserirClientesController();

            //limpeza de cpfs utilizados para viabilizar novos testes
            _excluirClientesApplicationService = new ExcluirClientesApplicationService();
            _excluirClientesApplicationService.ExcluirPorCPF(new ClienteStub().ComDefaults().Build().CPF);
            _excluirClientesApplicationService.ExcluirPorCPF(new ClienteStub().ComCPFNovo().Build().CPF);
        }

        [Fact]
        public void TerCliente()
        {
            var cliente = default(Cliente);

            Exception ex = Assert.Throws<Exception>(() => _inserirClientesController.Post(cliente));

            Assert.Equal("Cliente não preenchido", ex.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void TerClienteComNomePreenchido(string nome)
        {
            var cliente = new ClienteStub().ComDefaults().ComNome(nome).Build();

            Exception ex = Assert.Throws<Exception>(() => _inserirClientesController.Post(cliente));

            Assert.Equal("Cliente com Nome não preenchido", ex.Message);
        }

        [Theory]
        [InlineData("Marcelo Conte Barbosa de Souza Alves Santa Cruz")]
        [InlineData("Marcelo Conte Barbosa de Souzas")]
        public void TerClienteComNomeComNoMaximo30Caracteres(string nome)
        {
            var cliente = new ClienteStub().ComDefaults().ComNome(nome).Build();

            Exception ex = Assert.Throws<Exception>(() => _inserirClientesController.Post(cliente));

            Assert.Equal("Cliente deve ter Nome com máximo de 30 caracteres", ex.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void TerClienteComCPFPreenchido(string cpf)
        {
            var cliente = new ClienteStub().ComDefaults().ComCPF(cpf).Build();

            Exception ex = Assert.Throws<Exception>(() => _inserirClientesController.Post(cliente));

            Assert.Equal("Cliente com CPF não preenchido", ex.Message);
        }

        [Theory]
        [InlineData("000.000.000-00")]
        [InlineData("123.156.789-01")]
        [InlineData("000.000.000.00")]
        [InlineData("123.156.789.01")]
        [InlineData("00000000000")]
        [InlineData("12315678901")]
        [InlineData("000000000-00")]
        [InlineData("123156789-01")]
        [InlineData("000-000-000.00")]
        [InlineData("123-156-789.01")]
        public void TerClienteComCPFValido(string cpf)
        {
            var cliente = new ClienteStub().ComDefaults().ComCPF(cpf).Build();

            Exception ex = Assert.Throws<Exception>(() => _inserirClientesController.Post(cliente));

            Assert.Equal("Cliente com CPF com formato inválido", ex.Message);
        }

        [Fact]
        public void TerClienteComDataNascimentoPreenchido()
        {
            var cliente = new ClienteStub().ComDefaults().ComDataNascimento(DateTime.MinValue).Build();

            Exception ex = Assert.Throws<Exception>(() => _inserirClientesController.Post(cliente));

            Assert.Equal("Cliente com Data de Nascimento não preenchido", ex.Message);
        }

        [Fact]
        public void TerClienteComEnderecoPreenchido()
        {
            var cliente = new ClienteStub().ComDefaults().ComEndereco(null).Build();

            Exception ex = Assert.Throws<Exception>(() => _inserirClientesController.Post(cliente));

            Assert.Equal("Cliente com Endereço não preenchido", ex.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void TerClienteComLogradouroPreenchido(string logradouro)
        {
            var cliente = new ClienteStub().ComDefaults().ComLogradouro(logradouro).Build();

            Exception ex = Assert.Throws<Exception>(() => _inserirClientesController.Post(cliente));

            Assert.Equal("Cliente com Logradouro no Endereço não preenchido", ex.Message);
        }

        [Theory]
        [InlineData("Rua conde de bonfim da lapa de são joão número 30, apto 9804")]
        [InlineData("Rua conde de bonfim da lapa de são joão número 30, perto do arco de teles")]
        public void TerClienteComLogradouroComNoMaximo50Caracteres(string logradouro)
        {
            var cliente = new ClienteStub().ComDefaults().ComLogradouro(logradouro).Build();

            Exception ex = Assert.Throws<Exception>(() => _inserirClientesController.Post(cliente));

            Assert.Equal("Cliente deve ter Logradouro no Endereço com máximo de 50 caracteres", ex.Message);
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void TerClienteComBairroPreenchido(string bairro)
        {
            var cliente = new ClienteStub().ComDefaults().ComBairro(bairro).Build();

            Exception ex = Assert.Throws<Exception>(() => _inserirClientesController.Post(cliente));

            Assert.Equal("Cliente com Bairro no Endereço não preenchido", ex.Message);
        }

        [Theory]
        [InlineData("Tijucaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        [InlineData("BotafogoooBotafogoooBotafogoooBotafogooo")]
        public void TerClienteComBairroComNoMaximo40Caracteres(string bairro)
        {
            var cliente = new ClienteStub().ComDefaults().ComBairro(bairro).Build();

            Exception ex = Assert.Throws<Exception>(() => _inserirClientesController.Post(cliente));

            Assert.Equal("Cliente deve ter Bairro no Endereço com máximo de 40 caracteres", ex.Message);
        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void TerClienteComCidadePreenchido(string cidade)
        {
            var cliente = new ClienteStub().ComDefaults().ComCidade(cidade).Build();

            Exception ex = Assert.Throws<Exception>(() => _inserirClientesController.Post(cliente));

            Assert.Equal("Cliente com Cidade no Endereço não preenchido", ex.Message);
        }

        [Theory]
        [InlineData("São Paulooooooooooooooooooooooooooooooooooooooooooooooooooo")]
        [InlineData("Rio de JaneiroRio de JaneiroRio de Janei")]
        public void TerClienteComCidadeComNoMaximo40Caracteres(string cidade)
        {
            var cliente = new ClienteStub().ComDefaults().ComCidade(cidade).Build();

            Exception ex = Assert.Throws<Exception>(() => _inserirClientesController.Post(cliente));

            Assert.Equal("Cliente deve ter Cidade no Endereço com máximo de 40 caracteres", ex.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void TerClienteComEstadoPreenchido(string estado)
        {
            var cliente = new ClienteStub().ComDefaults().ComEstado(estado).Build();

            Exception ex = Assert.Throws<Exception>(() => _inserirClientesController.Post(cliente));

            Assert.Equal("Cliente com Estado no Endereço não preenchido", ex.Message);
        }
                
        [Theory]
        [InlineData("RJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJJ")]
        [InlineData("SPPPPPPPPPSPPPPPPPPPSPPPPPPPPPSPPPPPPPPP")]
        public void TerClienteComEstadoComNoMaximo40Caracteres(string estado)
        {
            var cliente = new ClienteStub().ComDefaults().ComEstado(estado).Build();

            Exception ex = Assert.Throws<Exception>(() => _inserirClientesController.Post(cliente));

            Assert.Equal("Cliente deve ter Estado no Endereço com máximo de 40 caracteres", ex.Message);
        }

        [Fact]
        public void TerClientePreenchidoCorretamente()
        {
            var cliente = new ClienteStub().ComDefaults().Build();

            _inserirClientesController.Post(cliente);

        }

        [Fact]
        public void TerClienteComCPFInexistente()
        {

            var cliente = new ClienteStub().ComDefaults().ComCPFNovo().Build();

            _inserirClientesController.Post(cliente);

            var novocliente = new ClienteStub().ComDefaults().ComNome("Lucas").ComCPFNovo().Build();

            Exception ex = Assert.Throws<Exception>(() => _inserirClientesController.Post(novocliente));

            Assert.Equal("Já existe um cliente com esse CPF", ex.Message);
        }
    }

}

