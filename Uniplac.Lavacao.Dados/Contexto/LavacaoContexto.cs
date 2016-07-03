using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.Lavacao.Dominio;

namespace Uniplac.Lavacao.Dados.Contexto
{
    public class LavacaoContexto : DbContext
    {
        public LavacaoContexto(): base("LavacaoDB")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<LavacaoAutomotiva> Lavacoes { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
