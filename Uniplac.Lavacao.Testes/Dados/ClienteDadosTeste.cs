using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uniplac.Lavacao.Dados.Contexto;
using Uniplac.Lavacao.Dominio.Contratos;
using System.Data.Entity;
using Uniplac.Lavacao.Testes.Base;
using Uniplac.Lavacao.Dados.Repositorios;
using Uniplac.Lavacao.Dominio;
using System.Collections.Generic;
using Uniplac.Lavacao.Dominio.Exceptions;

namespace Uniplac.Lavacao.Testes.Dados
{
    [TestClass]
    public class ClienteDadosTeste
    {

        private LavacaoContexto _contexto;
        private IClienteRepositorio _repositorio;

        [TestInitialize]
        public void Initialize()
        {
            Database.SetInitializer(new CriarNovoBancoLavacao<LavacaoContexto>());

            _contexto = new LavacaoContexto();
            _repositorio = new ClienteRepositorio();

            _contexto.Database.Initialize(true);
        }

        [TestMethod]
        public void CriarClienteRepositorioTeste()
        {
            Cliente cliente = new Cliente("Bruno", "10044560931", "brunob_schmidt@hotmail.com",
                                          new DateTime(1996, 07, 22),
                                          new Carro("Gol", "Volkswagen", "LXD-9484"));
            
            _repositorio.Adicionar(cliente);
            
            Cliente novoCliente = _contexto.Clientes.Find(cliente.Id);
            
            Assert.IsTrue(novoCliente.Id > 0);
            Assert.AreEqual(cliente.Cpf, novoCliente.Cpf);
            Assert.AreEqual(cliente.Nome, novoCliente.Nome);
            Assert.AreEqual(cliente.Carro.Modelo, novoCliente.Carro.Modelo);
        }

        [TestMethod]
        public void RetornarClienteRepositorioTest()
        {
            Cliente cliente = _repositorio.Buscar(1);
            
            Assert.IsNotNull(cliente);
        }

        [TestMethod]
        public void RetornaTodosOsClientesRepositorioTest()
        {
            List<Cliente> clientes = _repositorio.BuscarTodos();

            Assert.AreEqual(10, clientes.Count);
        }

        [TestMethod]
        public void AtualizaClienteRepositorioTeste()
        {
            Cliente cliente = _contexto.Clientes.Find(1);

            cliente.Nome = "Bruno";
            cliente.Cpf = "10044560931";
            cliente.DataNascimento = new DateTime(1996, 07, 22);
            cliente.Carro.Modelo = "Golf";

            _repositorio.Atualizar(cliente);
            
            Cliente clienteAtualizado = _contexto.Clientes.Find(1);
            Assert.AreEqual("Bruno", clienteAtualizado.Nome);
            Assert.AreEqual("10044560931", clienteAtualizado.Cpf);
            Assert.AreEqual(new DateTime(1996, 07, 22), clienteAtualizado.DataNascimento);
            Assert.AreEqual("Golf", clienteAtualizado.Carro.Modelo);
        }

        [TestMethod]
        public void DeletarClienteRepositorioTeste()
        {
            Cliente cliente = new Cliente("Bruno", "10044560931", "brunob_schmidt@hotmail.com",
                                          new DateTime(1996, 07, 22),
                                          new Carro("Gol", "Volkswagen", "LXD-9484"));

            Cliente clienteCriado = _repositorio.Adicionar(cliente);

            _repositorio.Deletar(clienteCriado);
            
            Cliente clienteDeletado = _contexto.Clientes.Find(cliente.Id);
            Assert.IsNull(clienteDeletado);
        }
    }
}
