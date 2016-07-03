using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniplac.Lavacao.Framework
{
    public interface IEmailServico
    {
        bool Enviar(string email, string conteudo);
    }
}
