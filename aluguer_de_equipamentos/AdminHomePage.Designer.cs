namespace aluguer_de_equipamentos
{
    partial class AdminHomePage
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtPreco = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDisponivel = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.disponibilidade = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFornecedor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLocalizacao = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCategoria = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.Nome = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.AdminList = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.avaliacoes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.txtTecnico = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.maisAlugados = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.manutencoes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avaliacoes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maisAlugados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.manutencoes)).BeginInit();
            this.SuspendLayout();
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabPage1);
            this.tab.Controls.Add(this.tabPage2);
            this.tab.Location = new System.Drawing.Point(0, 2);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(1294, 824);
            this.tab.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtTecnico);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txtPreco);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtDisponivel);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.disponibilidade);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtFornecedor);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtLocalizacao);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtCategoria);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtNome);
            this.tabPage1.Controls.Add(this.Nome);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.AdminList);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1089, 741);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "InserirDados";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtPreco
            // 
            this.txtPreco.Location = new System.Drawing.Point(409, 498);
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.Size = new System.Drawing.Size(310, 20);
            this.txtPreco.TabIndex = 50;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Black", 15F);
            this.label5.Location = new System.Drawing.Point(408, 467);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 28);
            this.label5.TabIndex = 49;
            this.label5.Text = "Preço";
            // 
            // txtDisponivel
            // 
            this.txtDisponivel.AutoSize = true;
            this.txtDisponivel.Location = new System.Drawing.Point(411, 204);
            this.txtDisponivel.Name = "txtDisponivel";
            this.txtDisponivel.Size = new System.Drawing.Size(81, 17);
            this.txtDisponivel.TabIndex = 48;
            this.txtDisponivel.Text = "Disponivel?";
            this.txtDisponivel.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Arial Black", 15F);
            this.button4.Location = new System.Drawing.Point(837, 328);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(130, 79);
            this.button4.TabIndex = 47;
            this.button4.Text = "Delete ";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Arial Black", 15F);
            this.button3.Location = new System.Drawing.Point(607, 656);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(130, 79);
            this.button3.TabIndex = 46;
            this.button3.Text = "Limpar campos";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Arial Black", 15F);
            this.button2.Location = new System.Drawing.Point(411, 656);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 79);
            this.button2.TabIndex = 45;
            this.button2.Text = "Adicionar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // disponibilidade
            // 
            this.disponibilidade.Location = new System.Drawing.Point(413, 419);
            this.disponibilidade.Name = "disponibilidade";
            this.disponibilidade.Size = new System.Drawing.Size(310, 20);
            this.disponibilidade.TabIndex = 44;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Black", 15F);
            this.label6.Location = new System.Drawing.Point(406, 379);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 28);
            this.label6.TabIndex = 43;
            this.label6.Text = "Revisão";
            // 
            // txtFornecedor
            // 
            this.txtFornecedor.Location = new System.Drawing.Point(411, 337);
            this.txtFornecedor.Name = "txtFornecedor";
            this.txtFornecedor.Size = new System.Drawing.Size(310, 20);
            this.txtFornecedor.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 15F);
            this.label1.Location = new System.Drawing.Point(408, 311);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 28);
            this.label1.TabIndex = 41;
            this.label1.Text = "ID_Fornecedor";
            // 
            // txtLocalizacao
            // 
            this.txtLocalizacao.Location = new System.Drawing.Point(409, 260);
            this.txtLocalizacao.Name = "txtLocalizacao";
            this.txtLocalizacao.Size = new System.Drawing.Size(310, 20);
            this.txtLocalizacao.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Black", 15F);
            this.label4.Location = new System.Drawing.Point(406, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 28);
            this.label4.TabIndex = 39;
            this.label4.Text = "ID_Localização";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Black", 15F);
            this.label3.Location = new System.Drawing.Point(406, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 28);
            this.label3.TabIndex = 38;
            this.label3.Text = "Disponíbilidade\r\n";
            // 
            // txtCategoria
            // 
            this.txtCategoria.Location = new System.Drawing.Point(409, 121);
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.Size = new System.Drawing.Size(310, 20);
            this.txtCategoria.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 15F);
            this.label2.Location = new System.Drawing.Point(404, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 28);
            this.label2.TabIndex = 36;
            this.label2.Text = "Categoria";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(409, 52);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(310, 20);
            this.txtNome.TabIndex = 35;
            // 
            // Nome
            // 
            this.Nome.AutoSize = true;
            this.Nome.Font = new System.Drawing.Font("Arial Black", 15F);
            this.Nome.Location = new System.Drawing.Point(404, 21);
            this.Nome.Name = "Nome";
            this.Nome.Size = new System.Drawing.Size(75, 28);
            this.Nome.TabIndex = 34;
            this.Nome.Text = "Nome";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial Black", 15F);
            this.button1.Location = new System.Drawing.Point(837, 656);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 79);
            this.button1.TabIndex = 33;
            this.button1.Text = "Editar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // AdminList
            // 
            this.AdminList.FormattingEnabled = true;
            this.AdminList.Items.AddRange(new object[] {
            "Teste"});
            this.AdminList.Location = new System.Drawing.Point(0, 3);
            this.AdminList.Name = "AdminList";
            this.AdminList.Size = new System.Drawing.Size(383, 563);
            this.AdminList.TabIndex = 32;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.manutencoes);
            this.tabPage2.Controls.Add(this.maisAlugados);
            this.tabPage2.Controls.Add(this.button5);
            this.tabPage2.Controls.Add(this.avaliacoes);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1286, 798);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Ver Gráficos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1072, 706);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(208, 86);
            this.button5.TabIndex = 1;
            this.button5.Text = "Carregar";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // avaliacoes
            // 
            chartArea3.Name = "ChartArea1";
            this.avaliacoes.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.avaliacoes.Legends.Add(legend3);
            this.avaliacoes.Location = new System.Drawing.Point(23, 21);
            this.avaliacoes.Name = "avaliacoes";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Avaliações";
            this.avaliacoes.Series.Add(series3);
            this.avaliacoes.Size = new System.Drawing.Size(522, 407);
            this.avaliacoes.TabIndex = 0;
            this.avaliacoes.Text = "chart1";
            title3.Name = "Title1";
            title3.Text = "Avaliação média de equipamento";
            this.avaliacoes.Titles.Add(title3);
            // 
            // txtTecnico
            // 
            this.txtTecnico.Location = new System.Drawing.Point(413, 584);
            this.txtTecnico.Name = "txtTecnico";
            this.txtTecnico.Size = new System.Drawing.Size(310, 20);
            this.txtTecnico.TabIndex = 52;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Black", 15F);
            this.label7.Location = new System.Drawing.Point(412, 553);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(197, 28);
            this.label7.TabIndex = 51;
            this.label7.Text = "Primeiro Técnico";
            // 
            // maisAlugados
            // 
            chartArea2.Name = "ChartArea1";
            this.maisAlugados.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.maisAlugados.Legends.Add(legend2);
            this.maisAlugados.Location = new System.Drawing.Point(758, 21);
            this.maisAlugados.Name = "maisAlugados";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "alugados";
            this.maisAlugados.Series.Add(series2);
            this.maisAlugados.Size = new System.Drawing.Size(461, 403);
            this.maisAlugados.TabIndex = 2;
            this.maisAlugados.Text = "alugados";
            title2.Name = "Title1";
            title2.Text = "Equipamentos mais alugados";
            this.maisAlugados.Titles.Add(title2);
            // 
            // manutencoes
            // 
            chartArea1.Name = "ChartArea1";
            this.manutencoes.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.manutencoes.Legends.Add(legend1);
            this.manutencoes.Location = new System.Drawing.Point(478, 457);
            this.manutencoes.Name = "manutencoes";
            this.manutencoes.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series1.Legend = "Legend1";
            series1.Name = "Manutenções";
            this.manutencoes.Series.Add(series1);
            this.manutencoes.Size = new System.Drawing.Size(460, 300);
            this.manutencoes.TabIndex = 3;
            this.manutencoes.Text = "chart1";
            title1.Name = "Title1";
            title1.Text = "Técnicos com mais manutenções";
            this.manutencoes.Titles.Add(title1);
            // 
            // AdminHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1289, 865);
            this.Controls.Add(this.tab);
            this.Name = "AdminHomePage";
            this.Text = "AdminHomePage";
            this.tab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.avaliacoes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maisAlugados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.manutencoes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtPreco;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox txtDisponivel;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker disponibilidade;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFornecedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLocalizacao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label Nome;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox AdminList;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataVisualization.Charting.Chart avaliacoes;
        private System.Windows.Forms.TextBox txtTecnico;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataVisualization.Charting.Chart maisAlugados;
        private System.Windows.Forms.DataVisualization.Charting.Chart manutencoes;
    }
}