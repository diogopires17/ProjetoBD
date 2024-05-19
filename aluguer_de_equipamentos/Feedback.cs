using Equipamentos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace aluguer_de_equipamentos
{
    public partial class Feedback : Form
    {
        private SqlConnection cn;
        private int userID;
        private DateTime dataAluguer;
        private int idReserva;

        public Feedback(int userID)
        {
            InitializeComponent();
            this.userID = userID;
            cn = getSGBDConnection();
            carrega_reservas();
        }

        private void FeedaBack_Load(object sender, EventArgs e) { }

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
            try
            {
                if (txtReservas.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a reservation first.");
                    return;
                }

                // Extract the reservation ID from the selected item
                string selectedItem = txtReservas.SelectedItem.ToString();
                idReserva = int.Parse(selectedItem.Split(',')[0]);

                insereFeedback();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir feedback: " + ex.Message);
            }
        }

        private void carrega_reservas()
        {
            if (!verifySGBDConnection())
                return;

            string query = "GetHistoricoAluguer";

            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUtilizador", userID);

                HashSet<int> seenReservaIds = new HashSet<int>();

                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int reservaId = (int)reader["id_reserva"];

                            if (!seenReservaIds.Contains(reservaId))
                            {
                                seenReservaIds.Add(reservaId);
                                dataAluguer = (DateTime)reader["data_aluguer"];
                                string equipamentoNome = reader["EquipamentoNome"].ToString();
                                txtReservas.Items.Add($"{reservaId}, {equipamentoNome} - {dataAluguer}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading reservations: " + ex.Message);
                }
            }
        }

        private void insereFeedback()
        {
            if (!verifySGBDConnection())
                return;

            MessageBox.Show("Inserting feedback...");

            string query = "InsertAvaliacaoFeedback";

            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdReserva", idReserva);
                cmd.Parameters.AddWithValue("@Classificacao", txtClassificacao.Value);
                cmd.Parameters.AddWithValue("@IdUtilizador", userID);
                cmd.Parameters.AddWithValue("@DataAvaliacao", DateTime.Now);
                cmd.Parameters.AddWithValue("@Comentario", txtComentario.Text);

                try
                {
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Feedback inserido com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("No feedback was inserted. Please check the values.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inserting feedback: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserHomePage userHomePage = new UserHomePage(userID);
            userHomePage.Show();
        }
    }
}
