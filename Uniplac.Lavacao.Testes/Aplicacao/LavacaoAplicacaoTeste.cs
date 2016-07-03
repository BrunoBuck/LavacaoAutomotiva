using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uniplac.Lavacao.Dominio;
using Uniplac.Lavacao.Dominio.Contratos;
using Moq;
using Uniplac.Lavacao.Framework;
using Uniplac.Lavacao.Aplicacao;
using System.Collections.Generic;

namespace Uniplac.Lavacao.Testes.Aplicacao
{
    [TestClass]
    public class LavacaoAplicacaoTeste
    {
        [TestMethod]
        public void CriarLavacaoAplicacaoTeste()
        {
            LavacaoAutomotiva lavacao = new LavacaoAutomotiva(TipoLavacao.Basica, DateTime.Now, false, new Cliente("Bruno", "10044560931", "brunob_schmidt@hotmail.com",
                                                new DateTime(1996, 07, 22), new Carro("Gol", "Volkswagen", "LXD-9484")));


            var repositorioFake = new Mock<ILavacaoRepositorio>();
            repositorioFake.Setup(x => x.Adicionar(lavacao)).Returns(new LavacaoAutomotiva());

            var emailFake = new Mock<IEmailServico>();
            emailFake.Setup(x => x.Enviar("brunob_schmidt@hotmail.com", string.Empty)).Returns(true);

            ILavacaoAplicacao servico = new LavacaoAplicacao(repositorioFake.Object, emailFake.Object);
            LavacaoAutomotiva novaLavacao = servico.CriarLavacao(lavacao);

            repositorioFake.Verify(x => x.Adicionar(lavacao));
            emailFake.Verify(x => x.Enviar(lavacao.Cliente.Email, "Conteúdo"));
        }

        [TestMethod]
        public void RetornaLavacaoAplicacaoTeste()
        {
            var repositorioFake = new Mock<ILavacaoRepositorio>();

            repositorioFake.Setup(x => x.Buscar(1)).Returns(new LavacaoAutomotiva());

            ILavacaoAplicacao servico = new LavacaoAplicacao(repositorioFake.Object);
            LavacaoAutomotiva lavacao = servico.RetornarLavacao(1);

            repositorioFake.Verify(x => x.Buscar(1));
        }

        [TestMethod]
        public void RetornaTodasLavacoesAplicacaoTeste()
        {
            var repositorioFake = new Mock<ILavacaoRepositorio>();
            repositorioFake.Setup(x => x.BuscarTodas()).Returns(new List<LavacaoAutomotiva>());

            ILavacaoAplicacao servico = new LavacaoAplicacao(repositorioFake.Object);
            List<LavacaoAutomotiva> lavacoes = servico.RetornarTodasLavacoes();

            repositorioFake.Verify(x => x.BuscarTodas());
        }

        [TestMethod]
        public void DeletarLavacaoAplicacaoTeste()
        {
            LavacaoAutomotiva lavacao = new LavacaoAutomotiva(TipoLavacao.Basica, DateTime.Now, false, new Cliente("Bruno", "10044560931", "brunob_schmidt@hotmail.com",
                                                new DateTime(1996, 07, 22), new Carro("Gol", "Volkswagen", "LXD-9484")));

            var repositorioFake = new Mock<ILavacaoRepositorio>();
            repositorioFake.Setup(x => x.Deletar(lavacao));

            ILavacaoAplicacao servico = new LavacaoAplicacao(repositorioFake.Object);
            servico.DeletarLavacao(lavacao);

            repositorioFake.Verify(x => x.Deletar(lavacao));
        }

        [TestMethod]
        public void AtualizaLavacaoAplicacaoTeste()
        {
            LavacaoAutomotiva lavacao = new LavacaoAutomotiva(TipoLavacao.Basica, DateTime.Now, false, new Cliente("Bruno", "10044560931", "brunob_schmidt@hotmail.com",
                                                new DateTime(1996, 07, 22), new Carro("Gol", "Volkswagen", "LXD-9484")));

            var repositorioFake = new Mock<ILavacaoRepositorio>();
            repositorioFake.Setup(x => x.Atualizar(lavacao)).Returns(new LavacaoAutomotiva());
            
            ILavacaoAplicacao servico = new LavacaoAplicacao(repositorioFake.Object);
            LavacaoAutomotiva novaLavacao = servico.AtualizarLavacao(lavacao);

            repositorioFake.Verify(x => x.Atualizar(lavacao));
        }
    }
}
