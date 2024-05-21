namespace aluguer_de_equipamentos
{
    partial class TecnicoHomePage
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
            this.txtLocalizacao = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDisponibilidade = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCategoria = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.Nome = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tecnicoListBox = new System.Windows.Forms.ListBox();
            this.txtManutencao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Técnico = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtLocalizacao
            // 
            this.txtLocalizacao.BackColor = System.Drawing.Color.White;
            this.txtLocalizacao.Location = new System.Drawing.Point(699, 488);
            this.txtLocalizacao.Name = "txtLocalizacao";
            this.txtLocalizacao.Size = new System.Drawing.Size(609, 20);
            this.txtLocalizacao.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(969, 457);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 30);
            this.label4.TabIndex = 16;
            this.label4.Text = "Localização";
            // 
            // txtDisponibilidade
            // 
            this.txtDisponibilidade.BackColor = System.Drawing.Color.White;
            this.txtDisponibilidade.Location = new System.Drawing.Point(699, 400);
            this.txtDisponibilidade.Name = "txtDisponibilidade";
            this.txtDisponibilidade.Size = new System.Drawing.Size(609, 20);
            this.txtDisponibilidade.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(955, 369);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 30);
            this.label3.TabIndex = 14;
            this.label3.Text = "Disponíbilidade\r\n";
            // 
            // txtCategoria
            // 
            this.txtCategoria.BackColor = System.Drawing.Color.White;
            this.txtCategoria.Location = new System.Drawing.Point(699, 327);
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.Size = new System.Drawing.Size(609, 20);
            this.txtCategoria.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(969, 283);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 30);
            this.label2.TabIndex = 12;
            this.label2.Text = "Categoria";
            // 
            // txtNome
            // 
            this.txtNome.BackColor = System.Drawing.Color.White;
            this.txtNome.Location = new System.Drawing.Point(699, 241);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(609, 20);
            this.txtNome.TabIndex = 11;
            // 
            // Nome
            // 
            this.Nome.AutoSize = true;
            this.Nome.Font = new System.Drawing.Font("Segoe UI Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nome.Location = new System.Drawing.Point(981, 198);
            this.Nome.Name = "Nome";
            this.Nome.Size = new System.Drawing.Size(75, 30);
            this.Nome.TabIndex = 10;
            this.Nome.Text = "Nome";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Segoe UI Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1439, 646);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(255, 76);
            this.button1.TabIndex = 18;
            this.button1.Text = "Efetuar manutencao";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tecnicoListBox
            // 
            this.tecnicoListBox.BackColor = System.Drawing.Color.Beige;
            this.tecnicoListBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.tecnicoListBox.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tecnicoListBox.FormattingEnabled = true;
            this.tecnicoListBox.ItemHeight = 15;
            this.tecnicoListBox.Location = new System.Drawing.Point(0, 0);
            this.tecnicoListBox.Name = "tecnicoListBox";
            this.tecnicoListBox.Size = new System.Drawing.Size(522, 734);
            this.tecnicoListBox.TabIndex = 19;
            this.tecnicoListBox.SelectedIndexChanged += new System.EventHandler(this.tecnicoListBox_SelectedIndexChanged);
            // 
            // txtManutencao
            // 
            this.txtManutencao.BackColor = System.Drawing.Color.White;
            this.txtManutencao.Location = new System.Drawing.Point(701, 586);
            this.txtManutencao.Name = "txtManutencao";
            this.txtManutencao.Size = new System.Drawing.Size(607, 20);
            this.txtManutencao.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(938, 543);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 30);
            this.label1.TabIndex = 21;
            this.label1.Text = "Precisa Manutenção?";
            // 
            // Técnico
            // 
            this.Técnico.AutoSize = true;
            this.Técnico.Font = new System.Drawing.Font("Segoe UI Black", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Técnico.Location = new System.Drawing.Point(917, 56);
            this.Técnico.Name = "Técnico";
            this.Técnico.Size = new System.Drawing.Size(209, 65);
            this.Técnico.TabIndex = 22;
            this.Técnico.Text = "Técnico";
            // 
            // TecnicoHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1706, 734);
            this.Controls.Add(this.Técnico);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtManutencao);
            this.Controls.Add(this.tecnicoListBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtLocalizacao);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDisponibilidade);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCategoria);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.Nome);
            this.Name = "TecnicoHomePage";
            this.Text = "Tecnico Manutencao";
            this.Load += new System.EventHandler(this.TecnicoHomePage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtLocalizacao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDisponibilidade;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label Nome;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox tecnicoListBox;
        private System.Windows.Forms.TextBox txtManutencao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Técnico;
    }
}