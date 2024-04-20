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
        private DateTime dataFim;
        public UserHomePage(int userId)
        {
            InitializeComponent();
            showEquipamento();
            VeDisponibilidade(dataFim);
            DesativaCampos();
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
                UserEquipmentList.Items.Add($"{E.Nome}, {E.Categoria}, {cidade}  - {(E.Disponivel ? "Disponivel" : "Não disponível")}");
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

            string query = "INSERT INTO Reserva (data_inicio, data_fim, duracao_aluguer, id_utilizador, id_equipamento) " +
                           "VALUES (@DataInicio, @DataFim, @DuracaoAluguer, @IdUtilizador, @IdEquipamento)";

            dataFim = DateTime.Now.AddHours(1);
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@DataInicio", DateTime.Now); 
            cmd.Parameters.AddWithValue("@DataFim", dataFim ); 
            cmd.Parameters.AddWithValue("@DuracaoAluguer", 10); 
            cmd.Parameters.AddWithValue("@IdUtilizador", selectedUserId);
            cmd.Parameters.AddWithValue("@IdEquipamento", equipamentos[equipamentoSelecionado].IdEquipamento);
            Equipamento E = equipamentos[equipamentoSelecionado];
            try
            {
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    E.Disponivel = false;
                    cmd = new SqlCommand("UPDATE Equipamento SET disponivel = 0 WHERE id_equipamento = @IdEquipamento", cn);
                    cmd.Parameters.AddWithValue("@IdEquipamento", E.IdEquipamento);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Equipamento reservado com sucesso");
                    UserHomePage u = new UserHomePage(selectedUserId);
                    u.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Falha a adicionar reserva!");
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

            DesativaCampos();
        }

        // Desativa os campos de inserir texto
        private void DesativaCampos()
        {
            txtNome.ReadOnly = true;
            txtCategoria.ReadOnly = true;
            txtLocalizacao.ReadOnly = true;
            txtDisponibilidade.ReadOnly = true;
        }
        private void VeDisponibilidade(DateTime dataFim)
        {
            if (!verifySGBDConnection())
                return;

            foreach (var equipamento in equipamentos)
            {
                SqlCommand cmd = new SqlCommand("SELECT data_fim FROM Reserva WHERE id_equipamento = @IdEquipamento", cn);
                cmd.Parameters.AddWithValue("@IdEquipamento", equipamento.IdEquipamento);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    dataFim = (DateTime)reader["data_fim"];
                    if (DateTime.Now > dataFim)
                    {
                        equipamento.Disponivel = true;

                        reader.Close();
                        cmd = new SqlCommand("UPDATE Equipamento SET disponivel = 1 WHERE id_equipamento = @IdEquipamento", cn);
                        cmd.Parameters.AddWithValue("@IdEquipamento", equipamento.IdEquipamento);
                        cmd.ExecuteNonQuery();
                    }
                }

                reader.Close();
            }
        }

    }

}
