using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniplac.Lavacao.Framework
{
    public class EmailServico : IEmailServico
    {
        public bool Enviar(string email, string conteudo)
        {
            return true;
        }
    }
}
