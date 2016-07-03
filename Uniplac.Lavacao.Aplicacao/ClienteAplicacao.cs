using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniplac.Lavacao.Dominio;
using Uniplac.Lavacao.Dominio.Contratos;
using Uniplac.Lavacao.Framework;

namespace Uniplac.Lavacao.Aplicacao
{
    public class ClienteAplicacao : IClienteAplicacao
    {

        private IEmailServico _email;
        private IClienteRepositorio _repositorio;

        public ClienteAplicacao(IClienteRepositorio repositorio)
        {
            _repositorio = repositorio;
            _email = new EmailServico();
        }

        public ClienteAplicacao(IClienteRepositorio repositorio, IEmailServico email)
        {
            _repositorio = repositorio;
            _email = email;
        }
        public Cliente CriarCliente(Cliente cliente)
        {
            bool existe = ExisteCliente(cliente.Cpf);
            if (!existe)
            {
                    Cliente novoCliente = _repositorio.Adicionar(cliente);
                
                   bool sucesso = _email.Enviar(cliente.Email, "Conteúdo");

                    return novoCliente;
            }
            
            return null;
        }

        public Cliente AtualizarCliente(Cliente cliente)
        {
            Cliente novoCliente = _repositorio.Atualizar(cliente);

            bool sucesso = _email.Enviar(cliente.Email, "Conteúdo");

            return novoCliente;
        }

        public Cliente RetornarCliente(int id)
        {
            Cliente cliente = _repositorio.Buscar(id);
            return cliente;
        }

        public List<Cliente> RetornarTodosClientes()
        {
            List<Cliente> clientes = _repositorio.BuscarTodos();
            return clientes;
        }

        public void DeletarCliente(Cliente cliente)
        {
            _repositorio.Deletar(cliente);
        }

        public bool ExisteCliente(string cpf)
        {
            return false;
        }
    }
}
