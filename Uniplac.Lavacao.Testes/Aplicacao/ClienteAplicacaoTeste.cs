using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uniplac.Lavacao.Dominio;
using Moq;
using Uniplac.Lavacao.Dominio.Contratos;
using Uniplac.Lavacao.Framework;
using Uniplac.Lavacao.Aplicacao;
using System.Collections.Generic;

namespace Uniplac.Lavacao.Testes.Aplicacao
{
    [TestClass]
    public class ClienteAplicacaoTeste
    {
        [TestMethod]
        public void CriarClienteAplicacaoTeste()
        {
            Cliente cliente = new Cliente("Bruno", "10044560931", "brunob_schmidt@hotmail.com",
                                          new DateTime(1996, 07, 22),
                                          new Carro("Gol", "Volkswagen", "LXD-9484"));

            var repositorioFake = new Mock<IClienteRepositorio>();
            repositorioFake.Setup(x => x.Adicionar(cliente)).Returns(new Cliente());

            var emailFake = new Mock<IEmailServico>();
            emailFake.Setup(x => x.Enviar("brunob_schmidt@hotmail.com", string.Empty)).Returns(true);

            IClienteAplicacao servico = new ClienteAplicacao(repositorioFake.Object, emailFake.Object);
            Cliente novoCliente = servico.CriarCliente(cliente);

            repositorioFake.Verify(x => x.Adicionar(cliente));
            emailFake.Verify(x => x.Enviar(cliente.Email, "Conteúdo"));
        }

        [TestMethod]
        public void RetornaClienteAplicacaoTeste()
        {
            var repositorioFake = new Mock<IClienteRepositorio>();
            repositorioFake.Setup(x => x.Buscar(1)).Returns(new Cliente());

            IClienteAplicacao servico = new ClienteAplicacao(repositorioFake.Object);
            Cliente cliente = servico.RetornarCliente(1);

            repositorioFake.Verify(x => x.Buscar(1));
        }

        [TestMethod]
        public void RetornaTodosClientesAplicacaoTeste()
        {
            var repositorioFake = new Mock<IClienteRepositorio>();
            repositorioFake.Setup(x => x.BuscarTodos()).Returns(new List<Cliente>());

            IClienteAplicacao servico = new ClienteAplicacao(repositorioFake.Object);
            List<Cliente> clientes = servico.RetornarTodosClientes();

            repositorioFake.Verify(x => x.BuscarTodos());
        }

        [TestMethod]
        public void DeletarClienteAplicacaoTeste()
        {
            Cliente cliente = new Cliente("Bruno", "10044560931", "brunob_schmidt@hotmail.com",
                                          new DateTime(1996, 07, 22),
                                          new Carro("Gol", "Volkswagen", "LXD-9484"));

            var repositorioFake = new Mock<IClienteRepositorio>();
            repositorioFake.Setup(x => x.Deletar(cliente));

            IClienteAplicacao servico = new ClienteAplicacao(repositorioFake.Object);
            servico.DeletarCliente(cliente);

            repositorioFake.Verify(x => x.Deletar(cliente));
        }

        [TestMethod]
        public void AtualizaClienteAplicacaoTeste()
        {
            Cliente cliente = new Cliente("Bruno", "10044560931", "brunob_schmidt@hotmail.com",
                                          new DateTime(1996, 07, 22),
                                          new Carro("Gol", "Volkswagen", "LXD-9484"));

            var repositorioFake = new Mock<IClienteRepositorio>();
            repositorioFake.Setup(x => x.Atualizar(cliente)).Returns(new Cliente());

            var emailFake = new Mock<IEmailServico>();
            emailFake.Setup(x => x.Enviar("brunob_schmidt@hotmail.com", string.Empty)).Returns(true);

            IClienteAplicacao servico = new ClienteAplicacao(repositorioFake.Object, emailFake.Object);
            Cliente novoCliente = servico.AtualizarCliente(cliente);

            repositorioFake.Verify(x => x.Atualizar(cliente));
            emailFake.Verify(x => x.Enviar(cliente.Email, "Conteúdo"));
        }
    }
}
