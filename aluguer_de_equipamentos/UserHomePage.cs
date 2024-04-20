using Contacts;
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

namespace aluguer_de_equipamentos
{
    public partial class UserHomePage : Form
    {
        private SqlConnection cn;
        private int  equipamentoSelecionado = 1 ;
        private List<Equipamento> equipamentos = new List<Equipamento>(); 
        private int selectedUserId; 

        public UserHomePage(int userId)
        {
            InitializeComponent();
            showEquipamento();
            this.selectedUserId = userId; 
        }
        private void UserHomePage_Load(object sender, EventArgs e)
        {
            cn = getSGBDConnection();
            loadEquipmentsToolStripMenuItem_Click(sender, e);
        }

        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection("data source= DIOGOPIRES\\SQLEXPRESS;integrated security=true;initial catalog=aluguer_equipamentos");
        }

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            equipamentoSelecionado = UserEquipmentList.SelectedIndex;
            showEquipamento();
        }

        // carrega os equipamentos para a lista
        private void loadEquipmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT E.*, L.cidade FROM Equipamento E INNER JOIN localizacao L ON E.id_localizacao = L.id_localizacao", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            UserEquipmentList.Items.Clear();

            while (reader.Read())
            {
                Equipamento E = new Equipamento();
                E.Nome = (string)reader["nome"];
                E.Disponivel = (bool)reader["disponivel"];
                E.Categoria = (string)reader["categoria"];
                E.IdLocalizacao = (int)reader["id_localizacao"];
                E.IdEquipamento = (int)reader["id_equipamento"];    
                string cidade = (string)reader["cidade"]; 
                equipamentos.Add(E);
                UserEquipmentList.Items.Add($"{E.Nome}, {E.IdEquipamento}.  {E.Categoria}, {cidade}  - {(E.Disponivel ? "Disponivel" : "Não disponível")}");
            }
            reader.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UserEquipmentList.SelectedIndex < 0 || selectedUserId < 0) 
            {
                MessageBox.Show("Please select a user and an equipment.");
                return;
            }


            if (!verifySGBDConnection())
                return;
            MessageBox.Show("Selected user: " + selectedUserId);

            string query = "INSERT INTO Reserva (data_inicio, data_fim, duracao_aluguer, id_utilizador, id_equipamento) " +
                           "VALUES (@DataInicio, @DataFim, @DuracaoAluguer, @IdUtilizador, @IdEquipamento)";

            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@DataInicio", DateTime.Now); 
            cmd.Parameters.AddWithValue("@DataFim", DBNull.Value); 
            cmd.Parameters.AddWithValue("@DuracaoAluguer", DBNull.Value); 
            cmd.Parameters.AddWithValue("@IdUtilizador", selectedUserId);
            cmd.Parameters.AddWithValue("@IdEquipamento", equipamentos[equipamentoSelecionado].IdEquipamento);

            try
            {
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Equipment added to the user successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to add equipment to the user.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        // OUTRAS FUNÇÕES
        // Mostra o equipamento selecionado
        private void showEquipamento()
        {
            if (UserEquipmentList.Items.Count == 0 || UserEquipmentList.SelectedIndex < 0)
            {
                return;
            }

            int selectedIndex = UserEquipmentList.SelectedIndex;

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
            button1.Enabled = E.Disponivel;

            desativaCampos();
        }

        // Desativa os campos de inserir texto
        private void desativaCampos()
        {
            txtNome.ReadOnly = true;
            txtCategoria.ReadOnly = true;
            txtLocalizacao.ReadOnly = true;
            txtDisponibilidade.ReadOnly = true;
        }


    }

}
