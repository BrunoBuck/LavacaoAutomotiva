using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uniplac.Lavacao.Dados.Contexto;
using Uniplac.Lavacao.Dominio.Contratos;
using System.Data.Entity;
using Uniplac.Lavacao.Testes.Base;
using Uniplac.Lavacao.Dados.Repositorios;
using Uniplac.Lavacao.Dominio;
using System.Collections.Generic;

namespace Uniplac.Lavacao.Testes.Dados
{
    [TestClass]
    public class LavacaoDadosTeste
    {
        private LavacaoContexto _contexto;
        private ILavacaoRepositorio _repositorio;

        [TestInitialize]
        public void Initialize()
        {
            Database.SetInitializer(new CriarNovoBancoLavacao<LavacaoContexto>());

            _contexto = new LavacaoContexto();
            _repositorio = new LavacaoRepositorio();

            _contexto.Database.Initialize(true);
        }

        [TestMethod]
        public void CriarLavacaoRepositorioTeste()
        {
            LavacaoAutomotiva lavacao = new LavacaoAutomotiva(TipoLavacao.Basica, DateTime.Now, false, new Cliente("Bruno", "10044560931", "brunob_schmidt@hotmail.com",
                                                new DateTime(1996, 07, 22), new Carro("Gol", "Volkswagen", "LXD-9484")));

            _repositorio.Adicionar(lavacao);

            LavacaoAutomotiva novaLavacao = _repositorio.Buscar(lavacao.Id);

            Assert.IsTrue(novaLavacao.Id > 0);
            Assert.AreEqual(lavacao.Tipo, novaLavacao.Tipo);
            Assert.AreEqual(lavacao.DataHora, novaLavacao.DataHora);
            Assert.AreEqual(lavacao.Cliente.Nome, novaLavacao.Cliente.Nome);
            Assert.AreEqual(lavacao.Cliente.Carro.Modelo, novaLavacao.Cliente.Carro.Modelo);
        }

        [TestMethod]
        public void RetornarLavacaoRepositorioTest()
        {
            LavacaoAutomotiva lavacao = _repositorio.Buscar(1);

            Assert.IsNotNull(lavacao);
        }

        [TestMethod]
        public void RetornaTodasAsLavacoesRepositorioTest()
        {
            List<LavacaoAutomotiva> lavacoes = _repositorio.BuscarTodas();

            Assert.AreEqual(10, lavacoes.Count);
        }

        [TestMethod]
        public void AtualizaLavacaoRepositorioTeste()
        {
            LavacaoAutomotiva lavacao = _repositorio.Buscar(1);

            lavacao.Finalizada = true;
            lavacao.Cliente.Carro.Modelo = "Golf";

            _repositorio.Atualizar(lavacao);

            LavacaoAutomotiva lavacaoAtualizada = _repositorio.Buscar(1);
            Assert.AreEqual(true, lavacaoAtualizada.Finalizada);
            Assert.AreEqual("Golf", lavacaoAtualizada.Cliente.Carro.Modelo);
        }

        [TestMethod]
        public void DeletarLavacaoRepositorioTeste()
        {
            LavacaoAutomotiva lavacao = _repositorio.Buscar(1);

            _repositorio.Deletar(lavacao);

            LavacaoAutomotiva lavacaoDeletada = _repositorio.Buscar(1);
            Assert.IsNull(lavacaoDeletada);
        }
    }
}
