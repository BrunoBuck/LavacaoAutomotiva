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
    public partial class FormLavacaoPrincipal : Form
    {
        private List<LavacaoAutomotiva> _lavacoes;
        private ILavacaoRepositorio _repositorio = new LavacaoRepositorio();
        private ILavacaoAplicacao _servico;
        public FormLavacaoPrincipal()
        {
            InitializeComponent();
            _servico = new LavacaoAplicacao(_repositorio);
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            FormAdicionarLavacao formAddLavacao = new FormAdicionarLavacao(_repositorio);
            formAddLavacao.ShowDialog();
            AtualizarForm();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FormAdicionarLavacao formAddLavacao = new FormAdicionarLavacao(_repositorio, (LavacaoAutomotiva)dgvAberta.SelectedRows[0].DataBoundItem);
            formAddLavacao.ShowDialog();
            AtualizarForm();
        }
        

        private void FormLavacaoPrincipal_Load(object sender, EventArgs e)
        {
            AtualizarForm();
        }

        private void AtualizarForm()
        {
            _lavacoes = _servico.RetornarTodasLavacoes();

            dgvAberta.DataSource = null;
            dgvFinalizada.DataSource = null;

            dgvAberta.DataSource = _lavacoes.Where(c => c.Finalizada == false).ToList();
            dgvFinalizada.DataSource = _lavacoes.Where(c => c.Finalizada == true).ToList();

            dgvAberta.Refresh();
            dgvFinalizada.Refresh();
        }

        private void txtBuscaPlacaAberto_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBuscaPlacaAberto.Text))
            {
                dgvAberta.DataSource = _lavacoes.Where(c => c.Finalizada == false && c.Cliente.Carro.Placa.StartsWith(txtBuscaPlacaAberto.Text)).ToList();
                dgvAberta.Refresh();
            }
            else
            {
                dgvAberta.DataSource = _lavacoes.Where(c => c.Finalizada == false).ToList();
                dgvAberta.Refresh();
            }
        }

        private void txtBuscaPlacaFinalizada_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBuscaPlacaFinalizada.Text))
            {
                dgvFinalizada.DataSource = _lavacoes.Where(c => c.Finalizada == true && c.Cliente.Carro.Placa.StartsWith(txtBuscaPlacaFinalizada.Text)).ToList();
                dgvFinalizada.Refresh();
            }
            else
            {
                dgvFinalizada.DataSource = _lavacoes.Where(c => c.Finalizada == true).ToList();
                dgvFinalizada.Refresh();
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            LavacaoAutomotiva lavacao = (LavacaoAutomotiva)dgvAberta.SelectedRows[0].DataBoundItem;
            _servico.DeletarLavacao(lavacao);
            AtualizarForm();
        }

        private void btnRemoverFinalizada_Click(object sender, EventArgs e)
        {
            LavacaoAutomotiva lavacao = (LavacaoAutomotiva)dgvFinalizada.SelectedRows[0].DataBoundItem;
            _servico.DeletarLavacao(lavacao);
            AtualizarForm();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            LavacaoAutomotiva lavacao = (LavacaoAutomotiva)dgvAberta.SelectedRows[0].DataBoundItem;
            lavacao.Finalizada = true;
            _servico.AtualizarLavacao(lavacao);
            AtualizarForm();
        }

        private void btnReabrir_Click(object sender, EventArgs e)
        {
            LavacaoAutomotiva lavacao = (LavacaoAutomotiva)dgvFinalizada.SelectedRows[0].DataBoundItem;
            lavacao.Finalizada = false;
            _servico.AtualizarLavacao(lavacao);
            AtualizarForm();
        }
    }
}
