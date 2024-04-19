namespace aluguer_de_equipamentos
{
    partial class UserHomePage
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
            this.UserEquipmentList = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Nome = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtCategoria = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDisponibilidade = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLocalizacao = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UserEquipmentList
            // 
            this.UserEquipmentList.FormattingEnabled = true;
            this.UserEquipmentList.Location = new System.Drawing.Point(1, 0);
            this.UserEquipmentList.Name = "UserEquipmentList";
            this.UserEquipmentList.Size = new System.Drawing.Size(383, 563);
            this.UserEquipmentList.TabIndex = 0;
            this.UserEquipmentList.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial Black", 15F);
            this.button1.Location = new System.Drawing.Point(845, 484);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 79);
            this.button1.TabIndex = 1;
            this.button1.Text = "Alugar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Nome
            // 
            this.Nome.AutoSize = true;
            this.Nome.Font = new System.Drawing.Font("Arial Black", 15F);
            this.Nome.Location = new System.Drawing.Point(412, 18);
            this.Nome.Name = "Nome";
            this.Nome.Size = new System.Drawing.Size(75, 28);
            this.Nome.TabIndex = 2;
            this.Nome.Text = "Nome";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(417, 49);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(310, 20);
            this.txtNome.TabIndex = 3;
            // 
            // txtCategoria
            // 
            this.txtCategoria.Location = new System.Drawing.Point(417, 118);
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.Size = new System.Drawing.Size(310, 20);
            this.txtCategoria.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 15F);
            this.label2.Location = new System.Drawing.Point(412, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 28);
            this.label2.TabIndex = 4;
            this.label2.Text = "Categoria";
            // 
            // txtDisponibilidade
            // 
            this.txtDisponibilidade.Location = new System.Drawing.Point(417, 184);
            this.txtDisponibilidade.Name = "txtDisponibilidade";
            this.txtDisponibilidade.Size = new System.Drawing.Size(310, 20);
            this.txtDisponibilidade.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Black", 15F);
            this.label3.Location = new System.Drawing.Point(414, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 28);
            this.label3.TabIndex = 6;
            this.label3.Text = "Disponíbilidade\r\n";
            // 
            // txtLocalizacao
            // 
            this.txtLocalizacao.Location = new System.Drawing.Point(417, 257);
            this.txtLocalizacao.Name = "txtLocalizacao";
            this.txtLocalizacao.Size = new System.Drawing.Size(310, 20);
            this.txtLocalizacao.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Black", 15F);
            this.label4.Location = new System.Drawing.Point(414, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 28);
            this.label4.TabIndex = 8;
            this.label4.Text = "Localização";
            // 
            // UserHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 568);
            this.Controls.Add(this.txtLocalizacao);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDisponibilidade);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCategoria);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.Nome);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.UserEquipmentList);
            this.Name = "UserHomePage";
            this.Text = "UserHomePage";
            this.Load += new System.EventHandler(this.UserHomePage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox UserEquipmentList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label Nome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDisponibilidade;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLocalizacao;
        private System.Windows.Forms.Label label4;
    }
}