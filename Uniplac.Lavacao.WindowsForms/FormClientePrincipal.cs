using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Uniplac.Lavacao.Aplicacao;
using Uniplac.Lavacao.Dados.Repositorios;
using Uniplac.Lavacao.Dominio;
using Uniplac.Lavacao.Dominio.Contratos;

namespace Uniplac.Lavacao.WindowsForms
{
    public partial class FormClientePrincipal : Form
    {
        private List<Cliente> _clientes;
        private IClienteRepositorio _repositorio = new ClienteRepositorio();
        private IClienteAplicacao _servico;

        public FormClientePrincipal()
        {
            InitializeComponent();
            _servico = new ClienteAplicacao(_repositorio);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormAdicionarCliente formAddCliente = new FormAdicionarCliente(_repositorio);
            formAddCliente.ShowDialog();
            AtualizarForm();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            FormAdicionarCliente formAddCliente = new FormAdicionarCliente(_repositorio, (Cliente)dgvClientes.SelectedRows[0].DataBoundItem);
            formAddCliente.ShowDialog();
            AtualizarForm();
        }

        private void FormClientePrincipal_Load(object sender, EventArgs e)
        {
            AtualizarForm();
        }

        private void AtualizarForm()
        {
            _clientes = _servico.RetornarTodosClientes();            

            dgvClientes.DataSource = null;
            dgvClientes.DataSource = _clientes;
            dgvClientes.Refresh();
        }
        
        private void txtBuscaNome_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBuscaNome.Text))
            {
                dgvClientes.DataSource = _clientes.Where(c => c.Nome.StartsWith(txtBuscaNome.Text)).ToList();
                dgvClientes.Refresh();
            }
            else
            {
                dgvClientes.DataSource = _clientes;
                dgvClientes.Refresh();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = (Cliente)dgvClientes.SelectedRows[0].DataBoundItem;
                _servico.DeletarCliente(cliente);
                AtualizarForm();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Não pode deletar Clientes que já efetuaram lavações.");
            }
            
        }
        
    }
}
