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
    public partial class FormAdicionarLavacao : Form
    {
        private ILavacaoAplicacao _lavacaoAplicacao;
        private bool edicao;
        private LavacaoAutomotiva _lavacao;
        private IClienteAplicacao _clienteAplicacao;

        public FormAdicionarLavacao(ILavacaoRepositorio repositorio)
        {
            InitializeComponent();
            edicao = false;
            _lavacaoAplicacao = new LavacaoAplicacao(repositorio);
            _clienteAplicacao = new ClienteAplicacao(new ClienteRepositorio());

            AtualizarClientes();
            AtualizarTipos();
            AtualizarValor();
        }

        public FormAdicionarLavacao(ILavacaoRepositorio repositorio, LavacaoAutomotiva lavacao)
        {
            InitializeComponent();
            btnAdicionar.Text = "Salvar";
            edicao = true;
            _lavacaoAplicacao = new LavacaoAplicacao(repositorio);
            _clienteAplicacao = new ClienteAplicacao(new ClienteRepositorio());
            AtualizarClientes();
            AtualizarTipos();
            AtualizarValor();
            _lavacao = lavacao;
            cmbCliente.Text = _lavacao.Cliente.ToString();
            txtId.Text = _lavacao.Id.ToString();
            cmbTipo.Text = _lavacao.Tipo.ToString();

            
        }

        private void AtualizarValor()
        {
            LavacaoAutomotiva lavacao = new LavacaoAutomotiva();
            double valor = lavacao.AtribuirValor((TipoLavacao)Enum.Parse(typeof(TipoLavacao), cmbTipo.Text));
            lblMostraValor.Text = string.Format("R$ {0},00", valor);
        }

        private void AtualizarTipos()
        {
            cmbTipo.DataSource = Enum.GetNames(typeof(TipoLavacao));
        }

        private void AtualizarClientes()
        {
            List<Cliente> clientes = _clienteAplicacao.RetornarTodosClientes();
            cmbCliente.DataSource = clientes;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (!edicao)
            {
                Cliente cliente = (Cliente)cmbCliente.SelectedItem;
                LavacaoAutomotiva lavacao = new LavacaoAutomotiva((TipoLavacao)Enum.Parse(typeof(TipoLavacao), cmbTipo.Text), dataHora.Value, false, cliente);
                _lavacaoAplicacao.CriarLavacao(lavacao);
            }
            else
            {
                Cliente cliente = (Cliente)cmbCliente.SelectedItem;
                LavacaoAutomotiva lavacao = _lavacaoAplicacao.RetornarLavacao(_lavacao.Id);
                lavacao.Cliente = cliente;
                lavacao.Id = int.Parse(txtId.Text);
                lavacao.Tipo = (TipoLavacao)Enum.Parse(typeof(TipoLavacao), cmbTipo.Text);
                lavacao.DataHora = dataHora.Value;
                lavacao.Valor = lavacao.AtribuirValor(lavacao.Tipo);
                _lavacaoAplicacao.AtualizarLavacao(lavacao);
            }
            Close();
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarValor();
        }
    }
}
