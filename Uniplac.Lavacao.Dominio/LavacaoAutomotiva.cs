using System;
using Uniplac.Lavacao.Dominio.Exceptions;

namespace Uniplac.Lavacao.Dominio
{
    public class LavacaoAutomotiva
    {
        public int Id { get; set; }
        public TipoLavacao Tipo { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime DataHora { get; set; }
        public bool Finalizada { get; set; }
        public double Valor { get; set; }

        public LavacaoAutomotiva()
        {

        }

        public LavacaoAutomotiva(TipoLavacao tipo, DateTime dataHora, bool finalizada, Cliente cliente)
        {
            if (dataHora > DateTime.Now)
                throw new BusinessException("A Data/Hora é inválida");

            if (finalizada)
                throw new BusinessException("Uma Lavação não pode ser criada com o status de Finalizada");

            Valor = AtribuirValor(tipo);
            Tipo = tipo;
            DataHora = dataHora;
            Finalizada = finalizada;
            Cliente = cliente;
        }

        public double AtribuirValor(TipoLavacao tipo)
        {
            if (tipo == TipoLavacao.Basica)
                return 25.0;
            else
                return 100.0;
        }

        public string StatusLavacao()
        {
            return Finalizada ? "Finalizada" : "Aberta";
        }

        public override string ToString()
        {
            return string.Format("{0} - R$ {1} - {2} - {3} - {4}", Tipo, Valor, StatusLavacao(), Cliente.Nome, Cliente.Carro.Modelo);
        }
    }
}