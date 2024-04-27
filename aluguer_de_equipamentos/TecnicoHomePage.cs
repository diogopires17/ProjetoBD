using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Equipamentos;


namespace aluguer_de_equipamentos
{


    public partial class TecnicoHomePage : Form
    {
        private bool needsManutencao = false;
        private int userID;
        private SqlConnection cn;
        private List<Equipamento> equipamentos = UserHomePage.equipamentos;
        private int equipamentoSelecionado = 1;
        public TecnicoHomePage(int userID)
        {
            InitializeComponent();
            this.userID = userID;
        }

        private void TecnicoHomePage_Load(object sender, EventArgs e)
        {

                cn = getSGBDConnection();
                loadEquipmentsToolStripMenuItem_Click(sender, e);
        }

        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection(Globals.strConn);
        }

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }
        private void button1_Click(object sender, EventArgs e)
        {
                EfetuarManutencao ef = new EfetuarManutencao(userID, equipamentoSelecionado);
                ef.Show();
                this.Hide();

        }
        private void tecnicoListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            equipamentoSelecionado = tecnicoListBox.SelectedIndex;
            if (tecnicoListBox.SelectedIndex >= 0)
            {
                equipamentoSelecionado = tecnicoListBox.SelectedIndex;
                Equipamento E = equipamentos[equipamentoSelecionado];
                showEquipamento();
                if (needsManutencao)
                {
                    button1.Enabled = true;
                }
                else 
                {
                    button1.Enabled = false;
                }
            }

        }

        private void loadEquipmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT E.*, L.cidade FROM Equipamento E INNER JOIN localizacao L ON E.id_localizacao = L.id_localizacao", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            tecnicoListBox.Items.Clear();

            while (reader.Read())
            {
                needsManutencao = false;
                Equipamento E = new Equipamento();
                E.Nome = (string)reader["nome"];
                E.Disponivel = (bool)reader["disponivel"];
                E.Categoria = (string)reader["categoria"];
                E.IdLocalizacao = (int)reader["id_localizacao"];
                E.IdEquipamento = (int)reader["id_equipamento"];
                E.Preco = (int)reader["preco"];
                string cidade = (string)reader["cidade"];
                E.Revisao = (DateTime)reader["revisao"];
                if (E.Revisao < DateTime.Now)
                {
                    needsManutencao = true;
                }

                equipamentos.Add(E);
                tecnicoListBox.Items.Add($" {E.Preco}, {E.Nome}, {E.Categoria}, {cidade} MANUTENCAO?: {needsManutencao}");
            }
            reader.Close();

        }

        public void showEquipamento()
        {
            if (tecnicoListBox.Items.Count == 0 || tecnicoListBox.SelectedIndex < 0)
            {
                return;
            }
            needsManutencao = false;
            int selectedIndex = tecnicoListBox.SelectedIndex;

            Equipamento E = equipamentos[selectedIndex];

            string cidade = "";
            SqlCommand cmd = new SqlCommand("SELECT L.cidade FROM Equipamento E INNER JOIN localizacao L ON E.id_localizacao = L.id_localizacao WHERE E.Nome = @Nome AND E.Categoria = @Categoria", cn);
            cmd.Parameters.AddWithValue("@Nome", E.Nome);
            cmd.Parameters.AddWithValue("@Categoria", E.Categoria);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                cidade = (string)reader["cidade"];
            }
            reader.Close();

            txtNome.Text = E.Nome;
            txtCategoria.Text = E.Categoria;
            txtLocalizacao.Text = cidade;
            txtDisponibilidade.Text = E.Disponivel ? "Disponivel" : "Não disponivel";
            if(E.Revisao < DateTime.Now)
            {
               needsManutencao = true;
            }
            if (needsManutencao)
            {
                txtManutencao.BackColor = Color.Red;
            }
            else
            {
                txtManutencao.BackColor = Color.Green;  

            }
            txtManutencao.Text = needsManutencao ? "Precisa de manutenção" : "Não precisa de manutenção";
            
            button1.Enabled = E.Disponivel;

            DesativaCampos();
        }

        private void DesativaCampos()
        {
            txtNome.ReadOnly = true;
            txtCategoria.ReadOnly = true;
            txtLocalizacao.ReadOnly = true;
            txtDisponibilidade.ReadOnly = true;
            txtManutencao.ReadOnly = true;
        }



    }
}
