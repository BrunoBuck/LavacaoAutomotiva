namespace Uniplac.Lavacao.WindowsForms
{
    partial class FormLavacaoPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.dgvAberta = new System.Windows.Forms.DataGridView();
            this.txtBuscaPlacaAberto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRemoverFinalizada = new System.Windows.Forms.Button();
            this.dgvFinalizada = new System.Windows.Forms.DataGridView();
            this.txtBuscaPlacaFinalizada = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReabrir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAberta)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinalizada)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRemover);
            this.groupBox1.Controls.Add(this.btnFinalizar);
            this.groupBox1.Controls.Add(this.btnEditar);
            this.groupBox1.Controls.Add(this.btnAdicionar);
            this.groupBox1.Controls.Add(this.dgvAberta);
            this.groupBox1.Controls.Add(this.txtBuscaPlacaAberto);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(579, 286);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lavações Em Aberto";
            // 
            // btnRemover
            // 
            this.btnRemover.Location = new System.Drawing.Point(444, 249);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(128, 23);
            this.btnRemover.TabIndex = 6;
            this.btnRemover.Text = "Remover Lavação";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Location = new System.Drawing.Point(298, 249);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(128, 23);
            this.btnFinalizar.TabIndex = 5;
            this.btnFinalizar.Text = "Finalizar Lavação";
            this.btnFinalizar.UseVisualStyleBackColor = true;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(152, 249);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(128, 23);
            this.btnEditar.TabIndex = 4;
            this.btnEditar.Text = "Editar Lavação";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(5, 249);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(129, 23);
            this.btnAdicionar.TabIndex = 3;
            this.btnAdicionar.Text = "Adicionar Lavação";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // dgvAberta
            // 
            this.dgvAberta.AllowUserToAddRows = false;
            this.dgvAberta.AllowUserToDeleteRows = false;
            this.dgvAberta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvAberta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAberta.Location = new System.Drawing.Point(6, 64);
            this.dgvAberta.Name = "dgvAberta";
            this.dgvAberta.ReadOnly = true;
            this.dgvAberta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAberta.Size = new System.Drawing.Size(567, 172);
            this.dgvAberta.TabIndex = 2;
            // 
            // txtBuscaPlacaAberto
            // 
            this.txtBuscaPlacaAberto.Location = new System.Drawing.Point(125, 25);
            this.txtBuscaPlacaAberto.Name = "txtBuscaPlacaAberto";
            this.txtBuscaPlacaAberto.Size = new System.Drawing.Size(150, 22);
            this.txtBuscaPlacaAberto.TabIndex = 1;
            this.txtBuscaPlacaAberto.TextChanged += new System.EventHandler(this.txtBuscaPlacaAberto_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pesquisar por Placa:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnReabrir);
            this.groupBox2.Controls.Add(this.btnRemoverFinalizada);
            this.groupBox2.Controls.Add(this.dgvFinalizada);
            this.groupBox2.Controls.Add(this.txtBuscaPlacaFinalizada);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(13, 305);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(579, 286);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lavações Finalizadas";
            // 
            // btnRemoverFinalizada
            // 
            this.btnRemoverFinalizada.Location = new System.Drawing.Point(444, 249);
            this.btnRemoverFinalizada.Name = "btnRemoverFinalizada";
            this.btnRemoverFinalizada.Size = new System.Drawing.Size(128, 23);
            this.btnRemoverFinalizada.TabIndex = 6;
            this.btnRemoverFinalizada.Text = "Remover Lavação";
            this.btnRemoverFinalizada.UseVisualStyleBackColor = true;
            this.btnRemoverFinalizada.Click += new System.EventHandler(this.btnRemoverFinalizada_Click);
            // 
            // dgvFinalizada
            // 
            this.dgvFinalizada.AllowUserToAddRows = false;
            this.dgvFinalizada.AllowUserToDeleteRows = false;
            this.dgvFinalizada.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvFinalizada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFinalizada.Location = new System.Drawing.Point(6, 64);
            this.dgvFinalizada.Name = "dgvFinalizada";
            this.dgvFinalizada.ReadOnly = true;
            this.dgvFinalizada.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFinalizada.Size = new System.Drawing.Size(567, 172);
            this.dgvFinalizada.TabIndex = 2;
            // 
            // txtBuscaPlacaFinalizada
            // 
            this.txtBuscaPlacaFinalizada.Location = new System.Drawing.Point(125, 25);
            this.txtBuscaPlacaFinalizada.Name = "txtBuscaPlacaFinalizada";
            this.txtBuscaPlacaFinalizada.Size = new System.Drawing.Size(150, 22);
            this.txtBuscaPlacaFinalizada.TabIndex = 1;
            this.txtBuscaPlacaFinalizada.TextChanged += new System.EventHandler(this.txtBuscaPlacaFinalizada_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Pesquisar por Placa:";
            // 
            // btnReabrir
            // 
            this.btnReabrir.Location = new System.Drawing.Point(297, 249);
            this.btnReabrir.Name = "btnReabrir";
            this.btnReabrir.Size = new System.Drawing.Size(129, 23);
            this.btnReabrir.TabIndex = 7;
            this.btnReabrir.Text = "Reabrir Lavação";
            this.btnReabrir.UseVisualStyleBackColor = true;
            this.btnReabrir.Click += new System.EventHandler(this.btnReabrir_Click);
            // 
            // FormLavacaoPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(604, 599);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormLavacaoPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulário de Lavação";
            this.Load += new System.EventHandler(this.FormLavacaoPrincipal_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAberta)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinalizada)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscaPlacaAberto;
        private System.Windows.Forms.DataGridView dgvAberta;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRemoverFinalizada;
        private System.Windows.Forms.DataGridView dgvFinalizada;
        private System.Windows.Forms.TextBox txtBuscaPlacaFinalizada;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReabrir;
    }
}