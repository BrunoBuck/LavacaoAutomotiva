using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniplac.Lavacao.Dominio.Exceptions
{
    public class PostMessageException : Exception
    {
        public PostMessageException(string message) : base(message) { }
    }
}
