using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.Lavacao.Dados.Contexto;
using Uniplac.Lavacao.Dominio;

namespace Uniplac.Lavacao.Testes.Base
{
    public class CriarNovoBancoLavacao<T> : DropCreateDatabaseAlways<LavacaoContexto>
    {
        protected override void Seed(LavacaoContexto contexto)
        {
            for (int i = 0; i < 10; i++)
            {
                Cliente cliente = new Cliente("Cliente_" + i, "10044560931",
                    "cliente" + i + "@teste.com", DateTime.Today.AddYears(-18 - i),
                    new Carro("Modelo " + i, "Marca " + i, "Placa " + i));

                LavacaoAutomotiva lavacao = new LavacaoAutomotiva(TipoLavacao.Basica, DateTime.Now, false, cliente);

                contexto.Lavacoes.Add(lavacao);
                contexto.Clientes.Add(cliente);
            }

            contexto.SaveChanges();

            base.Seed(contexto);
        }
    }
}
