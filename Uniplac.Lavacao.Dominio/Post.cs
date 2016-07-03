using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.Lavacao.Dominio.Exceptions;
using Uniplac.Lavacao.Framework.Helpers;

namespace Uniplac.Lavacao.Dominio
{
    public class Post
    {
        public long PostId { get; set; }

        public string PostMensagem { get; set; }

        public DateTime PostData { get; set; }

        public string MostrarDataPost
        {
            get
            {
                return DataHoraHelper.ToDateString(PostData);
            }
        }

        public void Validacao()
        {
            if (string.IsNullOrEmpty(PostMensagem))
                throw new PostMessageException("A mensagem do post está vazia.");
            if (PostMensagem.Length > 140)
                throw new PostMessageException("O número de caracteres não pode ser maior que 140.");
            if (PostData > DateTime.Now)
                throw new PostMessageException("A data do Post não pode ser maior que a data atual.");
        }
    }
}
