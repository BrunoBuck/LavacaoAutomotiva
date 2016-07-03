using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.Lavacao.Dominio;

namespace Uniplac.Lavacao.Aplicacao
{
    public interface ILavacaoAplicacao
    {
        LavacaoAutomotiva CriarLavacao(LavacaoAutomotiva lavacao);
        LavacaoAutomotiva AtualizarLavacao(LavacaoAutomotiva lavacao);
        LavacaoAutomotiva RetornarLavacao(int id);
        List<LavacaoAutomotiva> RetornarTodasLavacoes();
        void DeletarLavacao(LavacaoAutomotiva lavacao);
    }
}
