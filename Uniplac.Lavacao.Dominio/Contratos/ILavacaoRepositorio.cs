using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniplac.Lavacao.Dominio.Contratos
{
    public interface ILavacaoRepositorio
    {
        LavacaoAutomotiva Adicionar(LavacaoAutomotiva lavacao);
        LavacaoAutomotiva Buscar(int id);
        List<LavacaoAutomotiva> BuscarTodas();
        LavacaoAutomotiva Atualizar(LavacaoAutomotiva lavacao);
        void Deletar(LavacaoAutomotiva lavacao);
    }
}
