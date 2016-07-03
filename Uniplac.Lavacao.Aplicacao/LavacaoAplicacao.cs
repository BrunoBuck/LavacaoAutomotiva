using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.Lavacao.Dominio;
using Uniplac.Lavacao.Dominio.Contratos;
using Uniplac.Lavacao.Framework;

namespace Uniplac.Lavacao.Aplicacao
{
    public class LavacaoAplicacao : ILavacaoAplicacao
    {
        private IPostServico _post;
        private IEmailServico _email;
        private ILavacaoRepositorio _repositorio;

        public LavacaoAplicacao(ILavacaoRepositorio repositorio)
        {
            _repositorio = repositorio;
            _email = new EmailServico();
            _post = new PostServico();
        }

        public LavacaoAplicacao(ILavacaoRepositorio repositorio, IEmailServico email)
        {
            _repositorio = repositorio;
            _email = email;
            _post = new PostServico();
        }

        public LavacaoAutomotiva AtualizarLavacao(LavacaoAutomotiva lavacao)
        {
            LavacaoAutomotiva novaLavacao = _repositorio.Atualizar(lavacao);

            if (lavacao.Finalizada == true)
            {
                Post post = new Post();

                post.PostData = DateTime.Now;
                post.PostMensagem = string.Format("O {0} do/da cliente {1} terminou de ser lavado!", novaLavacao.Cliente.Carro.Modelo, novaLavacao.Cliente.Nome);

                post = _post.CriarOuAtualizar(post);

            }

            return novaLavacao;
        }

        public LavacaoAutomotiva CriarLavacao(LavacaoAutomotiva lavacao)
        {
            LavacaoAutomotiva novaLavacao = _repositorio.Adicionar(lavacao);

            bool sucessoEmail = _email.Enviar(lavacao.Cliente.Email, "Conteúdo");

            Post post = new Post();
            post.PostData = DateTime.Now;
            post.PostMensagem = string.Format("O {0} do/da cliente {1} entrou na fila para ser lavado!", lavacao.Cliente.Carro.Modelo, lavacao.Cliente.Nome);

            post = _post.CriarOuAtualizar(post);

            return novaLavacao;
        }

        public void DeletarLavacao(LavacaoAutomotiva lavacao)
        {
            _repositorio.Deletar(lavacao);
        }

        public LavacaoAutomotiva RetornarLavacao(int id)
        {
            LavacaoAutomotiva lavacao = _repositorio.Buscar(id);
            return lavacao;
        }

        public List<LavacaoAutomotiva> RetornarTodasLavacoes()
        {
            List<LavacaoAutomotiva> lavacoes = _repositorio.BuscarTodas();
            return lavacoes;
        }
    }
}
