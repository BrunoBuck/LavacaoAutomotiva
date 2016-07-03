using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uniplac.Lavacao.Dominio;
using Uniplac.Lavacao.Dominio.Exceptions;

namespace Uniplac.Lavacao.Testes.Dominio
{
    [TestClass]
    public class LavacaoTeste
    {
        [TestMethod]
        public void Criar_Lavacao_Valida_Teste()
        {
            LavacaoAutomotiva lavacao = new LavacaoAutomotiva(TipoLavacao.Basica, DateTime.Now, false, new Cliente("Bruno", "10044560931", "brunob_schmidt@hotmail.com",
                                                new DateTime(1996, 07, 22), new Carro("Gol", "Volkswagen", "LXD-9484")) );
            Assert.AreEqual("Basica - R$ 25 - Aberta - Bruno - Gol", lavacao.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void Criar_Lavacao_Data_Invalida_Teste()
        {
            LavacaoAutomotiva lavacao = new LavacaoAutomotiva(TipoLavacao.Basica, DateTime.Now.AddDays(2), false, new Cliente("Bruno", "10044560931", "brunob_schmidt@hotmail.com",
                                                new DateTime(1996, 07, 22), new Carro("Gol", "Volkswagen", "LXD-9484")));
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void Criar_Lavacao_Status_Finalizado_Teste()
        {
            LavacaoAutomotiva lavacao = new LavacaoAutomotiva(TipoLavacao.Basica, DateTime.Now, true, new Cliente("Bruno", "10044560931", "brunob_schmidt@hotmail.com",
                                                new DateTime(1996, 07, 22), new Carro("Gol", "Volkswagen", "LXD-9484")));
        }
    }
}
