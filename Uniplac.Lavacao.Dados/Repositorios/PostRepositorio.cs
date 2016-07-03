using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.Lavacao.Dados.Contexto;
using Uniplac.Lavacao.Dominio;
using Uniplac.Lavacao.Dominio.Contratos;

namespace Uniplac.Lavacao.Dados.Repositorios
{
    public class PostRepositorio : IPostRepositorio
    {
        private LavacaoContexto _contexto = new LavacaoContexto();

        public Post CriarOuAtualizar(Post post)
        {
            Post postAdicionado = _contexto.Posts.Add(post);
            _contexto.SaveChanges();
            return postAdicionado;
        }

        public Post Retornar(long id)
        {
            return _contexto.Posts.Find(id);
        }

        public IEnumerable<Post> RetornarTodos()
        {
            return _contexto.Posts.ToList();
        }

        public void Deletar(Post post)
        {
            _contexto.Posts.Remove(post);
            _contexto.SaveChanges();
        }
    }
}
