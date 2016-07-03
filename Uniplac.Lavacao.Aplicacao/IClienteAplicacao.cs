using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.Lavacao.Dominio;

namespace Uniplac.Lavacao.Aplicacao
{
    public interface IClienteAplicacao
    {
        bool ExisteCliente(string cpf);
        Cliente CriarCliente(Cliente cliente);
        Cliente AtualizarCliente(Cliente cliente);
        Cliente RetornarCliente(int id);
        List<Cliente> RetornarTodosClientes();
        void DeletarCliente(Cliente cliente);
    }
}
