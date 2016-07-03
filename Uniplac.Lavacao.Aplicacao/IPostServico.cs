using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.Lavacao.Dominio;

namespace Uniplac.Lavacao.Aplicacao
{
    public interface IPostServico
    {
        Post CriarOuAtualizar(Post post);
        Post Retornar(long id);
        IEnumerable<Post> RetornarTodos();
        void Deletar(Post post);
    }
}
