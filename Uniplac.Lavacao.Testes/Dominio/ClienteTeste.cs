using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uniplac.Lavacao.Dominio;
using Uniplac.Lavacao.Dominio.Exceptions;

namespace Uniplac.Lavacao.Testes.Dominio
{
    [TestClass]
    public class ClienteTeste
    {
        [TestMethod]
        public void Criar_Cliente_Valido_Teste()
        {
            Cliente cliente = new Cliente("Bruno", "10044560931", "brunob_schmidt@hotmail.com",
                                                new DateTime(1996, 07, 22), new Carro("Gol", "Volkswagen", "LXD-9484"));
            Assert.AreEqual("Bruno - Gol - LXD-9484", cliente.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void Criar_Cliente_Nome_Invalido_Teste()
        {
            Cliente cliente = new Cliente(string.Empty, "10044560931", "brunob_schmidt@hotmail.com",
                                                new DateTime(1996, 07, 22), new Carro("Gol", "Volkswagen", "LXD-9484"));
        }

        [TestMethod]
        public void Criar_Cliente_Cpf_Valido_Teste()
        {
            Cliente cliente = new Cliente("Bruno", "10044560931", "brunob_schmidt@hotmail.com",
                                                new DateTime(1996, 07, 22), new Carro("Gol", "Volkswagen", "LXD-9484"));
            Assert.AreEqual("Bruno - Gol - LXD-9484", cliente.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void Criar_Cliente_Cpf_Invalido_Teste()
        {
            Cliente cliente = new Cliente("Bruno", "10044560932", "brunob_schmidt@hotmail.com",
                                                new DateTime(1996, 07, 22), new Carro("Gol", "Volkswagen", "LXD-9484"));
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void Criar_Cliente_Cpf_Vazio_Teste()
        {
            Cliente cliente = new Cliente("Bruno", "", "brunob_schmidt@hotmail.com",
                                                new DateTime(1996, 07, 22), new Carro("Gol", "Volkswagen", "LXD-9484"));
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void Criar_Cliente_Email_Invalido_Sem_PontoCom_Teste()
        {
            Cliente cliente = new Cliente("Bruno", "10044560931", "brunob_schmidt@hotmailcom",
                                                new DateTime(1996, 07, 22), new Carro("Gol", "Volkswagen", "LXD-9484"));
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void Criar_Cliente_Email_Invalido_PontoCom_Incompleto_Teste()
        {
            Cliente cliente = new Cliente("Bruno", "10044560931", "brunob_schmidt@hotmail.c",
                                                new DateTime(1996, 07, 22), new Carro("Gol", "Volkswagen", "LXD-9484"));
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void Criar_Cliente_Email_Invalido_Sem_NomeDeEndereco__Teste()
        {
            Cliente cliente = new Cliente("Bruno", "10044560931", "@hotmail.com",
                                                new DateTime(1996, 07, 22), new Carro("Gol", "Volkswagen", "LXD-9484"));
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void Criar_Cliente_Email_Invalido_Dominio_Teste()
        {
            Cliente cliente = new Cliente("Bruno", "10044560931", "brunob_schmidt@hotmail.commmmm",
                                                new DateTime(1996, 07, 22), new Carro("Gol", "Volkswagen", "LXD-9484"));
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void Criar_Cliente_Email_Vazio_Teste()
        {
            Cliente cliente = new Cliente("Bruno", "10044560931", "",
                                                new DateTime(1996, 07, 22), new Carro("Gol", "Volkswagen", "LXD-9484"));
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void Criar_Cliente_Menor_Idade_Teste()
        {
            Cliente cliente = new Cliente("Bruno", "10044560931", "brunob_schmidt@hotmail.com",
                                                new DateTime(2000, 07, 22), new Carro("Gol", "Volkswagen", "LXD-9484"));
        }

        [TestMethod]
        public void Criar_Cliente_Maior_Idade_Valido_Proximo_Menor_Teste()
        {
            Cliente cliente = new Cliente("Bruno", "10044560931", "brunob_schmidt@hotmail.com",
                                                new DateTime(1998, 04, 11), new Carro("Gol", "Volkswagen", "LXD-9484"));
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void Criar_Cliente_Carro_Sem_Modelo()
        {
            Cliente cliente = new Cliente("Bruno", "10044560931", "brunob_schmidt@hotmail.com",
                                                new DateTime(2000, 07, 22), new Carro("", "Volkswagen", "LXD-9484"));
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void Criar_Cliente_Carro_Sem_Marca()
        {
            Cliente cliente = new Cliente("Bruno", "10044560931", "brunob_schmidt@hotmail.com",
                                                new DateTime(2000, 07, 22), new Carro("Gol", "", "LXD-9484"));
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void Criar_Cliente_Carro_Sem_Placa()
        {
            Cliente cliente = new Cliente("Bruno", "10044560931", "brunob_schmidt@hotmail.com",
                                                new DateTime(2000, 07, 22), new Carro("Gol", "Volkswagen", ""));
        }
    }
}
