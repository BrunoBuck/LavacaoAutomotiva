using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Uniplac.Lavacao.Dominio;
using Uniplac.Lavacao.Dominio.Contratos;
using Uniplac.Lavacao.Dados.Contexto;

namespace Uniplac.Lavacao.Dados.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private LavacaoContexto _contexto;

        public ClienteRepositorio()
        {
            _contexto = new LavacaoContexto();
        }

        public Cliente Adicionar(Cliente cliente)
        {
            var resultado = _contexto.Clientes.Add(cliente);
            _contexto.SaveChanges();
            return resultado;
        }

        public Cliente Atualizar(Cliente cliente)
        {
            var entry = _contexto.Entry<Cliente>(cliente);
            entry.State = EntityState.Modified;
            _contexto.SaveChanges();

            return cliente;
        }

        public Cliente Buscar(int id)
        {
            return _contexto.Clientes.Find(id);
        }

        public List<Cliente> BuscarTodos()
        {
            return _contexto.Clientes.ToList();
        }

        public void Deletar(Cliente cliente)
        {
            var entry = _contexto.Entry<Cliente>(cliente);
            entry.State = EntityState.Deleted;
            _contexto.SaveChanges();
        }
    }
}
