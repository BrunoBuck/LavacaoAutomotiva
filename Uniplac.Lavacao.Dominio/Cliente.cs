using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.Lavacao.Dominio.Exceptions;
using Uniplac.Lavacao.Framework.Helpers;

namespace Uniplac.Lavacao.Dominio
{
    public class Cliente
    {
        public Cliente()
        {

        }
        public Cliente(string nome, string cpf, string email, DateTime dataNascimento, Carro carro)
        {
            if (string.IsNullOrEmpty(nome.Trim()))
                throw new BusinessException("O Nome é inválido.");

            if (!CpfHelper.ValidarCPF(cpf))
                throw new BusinessException("O CPF é inválido.");

            if (!EmailHelper.ValidarEmail(email))
                throw new BusinessException("O Email é inválido.");

            if (!ValidarIdade(dataNascimento))
                throw new BusinessException("A Data de Nascimento é inválida.");

            Nome = nome;
            Cpf = cpf;
            Email = email;
            DataNascimento = dataNascimento;
            Carro = carro;
        }

        public int Id { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public Carro Carro { get; set; }
        public string Nome { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1} - {2}", Nome, Carro.Modelo, Carro.Placa);
        }

        public static bool ValidarIdade(DateTime dataNascimento)
        {
            return DateTime.Today.AddYears(-18) >= dataNascimento;
        }
    }
}
