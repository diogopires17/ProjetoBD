﻿namespace aluguer_de_equipamentos
{
    partial class Transacao
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDesconto = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 18.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(50, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Valor";
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(56, 103);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(302, 20);
            this.txtValor.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 18.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(50, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(323, 36);
            this.label2.TabIndex = 2;
            this.label2.Text = "Método de pagamento";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial Black", 18F);
            this.button1.Location = new System.Drawing.Point(776, 434);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 98);
            this.button1.TabIndex = 4;
            this.button1.Text = "Pagar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Black", 18.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(50, 276);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 36);
            this.label3.TabIndex = 5;
            this.label3.Text = "Desconto";
            // 
            // txtDesconto
            // 
            this.txtDesconto.Location = new System.Drawing.Point(56, 345);
            this.txtDesconto.Name = "txtDesconto";
            this.txtDesconto.Size = new System.Drawing.Size(302, 20);
            this.txtDesconto.TabIndex = 6;
            this.txtDesconto.TextChanged += new System.EventHandler(this.txtDesconto_TextChanged);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Arial Black", 18F);
            this.button2.Location = new System.Drawing.Point(776, 300);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(145, 98);
            this.button2.TabIndex = 7;
            this.button2.Text = "Aplicar desconto";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "MBWay",
            "PayPal",
            "VISA"});
            this.comboBox1.Location = new System.Drawing.Point(56, 210);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(302, 21);
            this.comboBox1.TabIndex = 9;
            // 
            // Transacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 544);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtDesconto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.label1);
            this.Name = "Transacao";
            this.Text = "Transacao";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDesconto;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}