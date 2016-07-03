using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uniplac.Lavacao.WindowsForms
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
                Hide();
                FormLavacaoPrincipal formLavacao = new FormLavacaoPrincipal();
                formLavacao.ShowDialog();
                Show();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
                Hide();
                FormClientePrincipal formCliente = new FormClientePrincipal();
                formCliente.ShowDialog();
                Show();
        }
    }
}
