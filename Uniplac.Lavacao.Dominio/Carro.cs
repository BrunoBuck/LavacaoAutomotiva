using Uniplac.Lavacao.Dominio.Exceptions;

namespace Uniplac.Lavacao.Dominio
{
    public class Carro
    {
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Placa { get; set; }

        public Carro()
        {

        }

        public Carro(string modelo, string marca, string placa)
        {
            if (string.IsNullOrEmpty(modelo.Trim()))
                throw new BusinessException("O Modelo do Carro é inválido.");

            if (string.IsNullOrEmpty(marca.Trim()))
                throw new BusinessException("A Marca do Carro é inválida.");

            if (string.IsNullOrEmpty(placa.Trim()))
                throw new BusinessException("A Placa do Carro é inválida.");

            Modelo = modelo;
            Marca = marca;
            Placa = placa;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} - {2}", Modelo, Marca, Placa);
        }
    }
}