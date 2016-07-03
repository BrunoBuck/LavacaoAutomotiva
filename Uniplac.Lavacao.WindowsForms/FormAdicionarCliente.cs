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
using Uniplac.Lavacao.Dominio;
using Uniplac.Lavacao.Dominio.Contratos;

namespace Uniplac.Lavacao.WindowsForms
{
    public partial class FormAdicionarCliente : Form
    {
        private IClienteAplicacao _clienteAplicacao;
        private bool edicao;
        private Cliente _cliente;

        public FormAdicionarCliente(IClienteRepositorio repositorio)
        {
            InitializeComponent();
            edicao = false;
            _clienteAplicacao = new ClienteAplicacao(repositorio);
        }

        public FormAdicionarCliente(IClienteRepositorio repositorio, Cliente cliente)
        {
            InitializeComponent();
            _clienteAplicacao = new ClienteAplicacao(repositorio);
            edicao = true;
            _cliente = cliente;
            btnAdicionar.Text = "Atualizar";
            txtId.Text = cliente.Id.ToString();
            txtNome.Text = cliente.Nome;
            txtCpf.Text = cliente.Cpf;
            txtEmail.Text = cliente.Email;
            dtDataNascimento.Value = cliente.DataNascimento;
            txtModelo.Text = cliente.Carro.Modelo;
            txtMarca.Text = cliente.Carro.Marca;
            txtPlaca.Text = cliente.Carro.Placa;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (!edicao)
            {
                Cliente cliente = new Cliente(txtNome.Text, txtCpf.Text, txtEmail.Text, dtDataNascimento.Value.Date, new Carro(txtModelo.Text, txtMarca.Text, txtPlaca.Text));
                _clienteAplicacao.CriarCliente(cliente);
            }
            else
            {
                Cliente cliente = _clienteAplicacao.RetornarCliente(_cliente.Id);
                cliente.Id = int.Parse(txtId.Text);
                cliente.Nome = txtNome.Text;
                cliente.Cpf = txtCpf.Text;
                cliente.Email = txtEmail.Text;
                cliente.DataNascimento = dtDataNascimento.Value;
                cliente.Carro.Modelo = txtModelo.Text;
                cliente.Carro.Marca = txtMarca.Text;
                cliente.Carro.Placa = txtPlaca.Text;
                _clienteAplicacao.AtualizarCliente(cliente);
            }
            Close();
        }
    }
}
