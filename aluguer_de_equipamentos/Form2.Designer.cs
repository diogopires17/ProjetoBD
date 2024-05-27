namespace aluguer_de_equipamentos
{
    partial class Gerir
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
            this.manutencoesListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEquipamento = new System.Windows.Forms.TextBox();
            this.txtData = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.RichTextBox();
            this.Nome = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Descrição = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.Atualizar = new System.Windows.Forms.Button();
            this.Eliminar = new System.Windows.Forms.Button();
            this.lblIdManutencao = new System.Windows.Forms.Label();
            this.lblIdEquipamento = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // manutencoesListBox
            // 
            this.manutencoesListBox.BackColor = System.Drawing.Color.Beige;
            this.manutencoesListBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.manutencoesListBox.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manutencoesListBox.FormattingEnabled = true;
            this.manutencoesListBox.ItemHeight = 15;
            this.manutencoesListBox.Location = new System.Drawing.Point(0, 0);
            this.manutencoesListBox.Name = "manutencoesListBox";
            this.manutencoesListBox.Size = new System.Drawing.Size(522, 670);
            this.manutencoesListBox.TabIndex = 20;
            this.manutencoesListBox.SelectedIndexChanged += new System.EventHandler(this.manutencoesListBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(634, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(496, 65);
            this.label1.TabIndex = 21;
            this.label1.Text = "Gerir Equipamentos";
            // 
            // txtEquipamento
            // 
            this.txtEquipamento.BackColor = System.Drawing.Color.White;
            this.txtEquipamento.Font = new System.Drawing.Font("Segoe UI Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEquipamento.Location = new System.Drawing.Point(613, 227);
            this.txtEquipamento.Name = "txtEquipamento";
            this.txtEquipamento.Size = new System.Drawing.Size(609, 22);
            this.txtEquipamento.TabIndex = 22;
            this.txtEquipamento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtData
            // 
            this.txtData.BackColor = System.Drawing.Color.White;
            this.txtData.Font = new System.Drawing.Font("Segoe UI Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtData.Location = new System.Drawing.Point(613, 334);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(609, 22);
            this.txtData.TabIndex = 23;
            this.txtData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(613, 427);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(644, 96);
            this.txtDescricao.TabIndex = 24;
            this.txtDescricao.Text = "";
            // 
            // Nome
            // 
            this.Nome.AutoSize = true;
            this.Nome.Font = new System.Drawing.Font("Segoe UI Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nome.Location = new System.Drawing.Point(871, 181);
            this.Nome.Name = "Nome";
            this.Nome.Size = new System.Drawing.Size(75, 30);
            this.Nome.TabIndex = 25;
            this.Nome.Text = "Nome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(884, 301);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 30);
            this.label2.TabIndex = 26;
            this.label2.Text = "Data";
            // 
            // Descrição
            // 
            this.Descrição.AutoSize = true;
            this.Descrição.Font = new System.Drawing.Font("Segoe UI Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Descrição.Location = new System.Drawing.Point(871, 394);
            this.Descrição.Name = "Descrição";
            this.Descrição.Size = new System.Drawing.Size(111, 30);
            this.Descrição.TabIndex = 27;
            this.Descrição.Text = "Descrição";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Segoe UI Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(541, 582);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(255, 76);
            this.button2.TabIndex = 28;
            this.button2.Text = "Voltar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // Atualizar
            // 
            this.Atualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Atualizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Atualizar.Font = new System.Drawing.Font("Segoe UI Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Atualizar.Location = new System.Drawing.Point(827, 582);
            this.Atualizar.Name = "Atualizar";
            this.Atualizar.Size = new System.Drawing.Size(255, 76);
            this.Atualizar.TabIndex = 29;
            this.Atualizar.Text = "Atualizar";
            this.Atualizar.UseVisualStyleBackColor = false;
            this.Atualizar.Click += new System.EventHandler(this.Atualizar_Click);
            // 
            // Eliminar
            // 
            this.Eliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Eliminar.Font = new System.Drawing.Font("Segoe UI Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Eliminar.Location = new System.Drawing.Point(1126, 582);
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Size = new System.Drawing.Size(255, 76);
            this.Eliminar.TabIndex = 30;
            this.Eliminar.Text = "Eliminar";
            this.Eliminar.UseVisualStyleBackColor = false;
            this.Eliminar.Click += new System.EventHandler(this.Eliminar_Click);
            // 
            // lblIdManutencao
            // 
            this.lblIdManutencao.AutoSize = true;
            this.lblIdManutencao.Location = new System.Drawing.Point(30, 370);
            this.lblIdManutencao.Name = "lblIdManutencao";
            this.lblIdManutencao.Size = new System.Drawing.Size(0, 17);
            this.lblIdManutencao.TabIndex = 31;
            this.lblIdManutencao.Visible = false;
            // 
            // lblIdEquipamento
            // 
            this.lblIdEquipamento.AutoSize = true;
            this.lblIdEquipamento.Location = new System.Drawing.Point(30, 390);
            this.lblIdEquipamento.Name = "lblIdEquipamento";
            this.lblIdEquipamento.Size = new System.Drawing.Size(0, 17);
            this.lblIdEquipamento.TabIndex = 32;
            this.lblIdEquipamento.Visible = false;
            // 
            // Gerir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1472, 670);
            this.Controls.Add(this.lblIdEquipamento);
            this.Controls.Add(this.lblIdManutencao);
            this.Controls.Add(this.Eliminar);
            this.Controls.Add(this.Atualizar);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Descrição);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Nome);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.txtEquipamento);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.manutencoesListBox);
            this.Name = "Gerir";
            this.Text = "Gerir";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ListBox manutencoesListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEquipamento;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.RichTextBox txtDescricao;
        private System.Windows.Forms.Label Nome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Descrição;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Atualizar;
        private System.Windows.Forms.Button Eliminar;
        private System.Windows.Forms.Label lblIdManutencao;
        private System.Windows.Forms.Label lblIdEquipamento;
    }
}
