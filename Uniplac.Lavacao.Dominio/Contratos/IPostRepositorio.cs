using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniplac.Lavacao.Dominio.Contratos
{
    public interface IPostRepositorio
    {
        Post CriarOuAtualizar(Post post);
        Post Retornar(long id);
        IEnumerable<Post> RetornarTodos();
        void Deletar(Post post);
    }
}
