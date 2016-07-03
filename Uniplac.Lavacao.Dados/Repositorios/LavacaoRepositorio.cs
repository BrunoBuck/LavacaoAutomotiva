using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.Lavacao.Dados.Contexto;
using Uniplac.Lavacao.Dominio;
using Uniplac.Lavacao.Dominio.Contratos;

namespace Uniplac.Lavacao.Dados.Repositorios
{
    public class LavacaoRepositorio : ILavacaoRepositorio
    {
        private LavacaoContexto _contexto;

        public LavacaoRepositorio()
        {
            _contexto = new LavacaoContexto();
        }

        public LavacaoAutomotiva Adicionar(LavacaoAutomotiva lavacao)
        {
            var resultado = _contexto.Lavacoes.Add(lavacao);
            _contexto.SaveChanges();
            return resultado;
        }

        public LavacaoAutomotiva Atualizar(LavacaoAutomotiva lavacao)
        {
            var entry = _contexto.Entry<LavacaoAutomotiva>(lavacao);
            entry.State = EntityState.Modified;
            _contexto.SaveChanges();

            return lavacao;
        }

        public LavacaoAutomotiva Buscar(int id)
        {
            LavacaoAutomotiva lavacao = _contexto.Lavacoes.Find(id);

            if(lavacao != null)
            _contexto.Entry(lavacao).Reference(i => i.Cliente).Load();

            return lavacao;
        }

        public List<LavacaoAutomotiva> BuscarTodas()
        {
            List<LavacaoAutomotiva> lavacoes = _contexto.Lavacoes.ToList();

            foreach (var lavacao in lavacoes)
            {
                _contexto.Entry(lavacao).Reference(i => i.Cliente).Load();
            }

            return _contexto.Lavacoes.ToList();
        }

        public void Deletar(LavacaoAutomotiva lavacao)
        {
            var entry = _contexto.Entry<LavacaoAutomotiva>(lavacao);
            entry.State = EntityState.Deleted;
            _contexto.SaveChanges();
        }
    }
}
