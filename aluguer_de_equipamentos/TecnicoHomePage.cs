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
            }
        }

        private void loadEquipmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("dbo.GetEquipamentos", cn)
            {
                CommandType = CommandType.StoredProcedure
            };

            SqlDataReader reader = cmd.ExecuteReader();
            tecnicoListBox.Items.Clear();

            while (reader.Read())
            {
                needsManutencao = false;
                Equipamento E = new Equipamento
                {
                    Nome = (string)reader["nome"],
                    Disponivel = (bool)reader["disponivel"],
                    Categoria = (string)reader["categoria"],
                    IdLocalizacao = (int)reader["id_localizacao"],
                    IdEquipamento = (int)reader["id_equipamento"],
                    Preco = (int)reader["preco"],
                    Revisao = (DateTime)reader["revisao"]
                };
                string cidade = (string)reader["cidade"];
                if (E.Revisao < DateTime.Now)
                {
                    needsManutencao = true;
                }

                equipamentos.Add(E);
                tecnicoListBox.Items.Add($"{E.Preco}, {E.Nome}, {E.Categoria}, {cidade} MANUTENCAO?: {needsManutencao}");
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

            SqlCommand cmd = new SqlCommand("SELECT L.cidade FROM Equipamento E INNER JOIN localizacao L ON E.id_localizacao = L.id_localizacao WHERE E.id_equipamento = @IdEquipamento", cn);
            cmd.Parameters.AddWithValue("@IdEquipamento", E.IdEquipamento);
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
            if (E.Revisao < DateTime.Now)
            {
                needsManutencao = true;
            }
            txtManutencao.BackColor = needsManutencao ? Color.Red : Color.Green;
            txtManutencao.Text = needsManutencao ? "Precisa de manutenção" : "Não precisa de manutenção";

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

        private void button2_Click(object sender, EventArgs e)
        {
           this.Hide();
           Gerir gt = new Gerir(userID);
           gt.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Gerir gt = new Gerir(userID);
            gt.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            EfetuarManutencao ef = new EfetuarManutencao(userID, equipamentoSelecionado);
            ef.Show();
            this.Hide();
        }
    }
}
