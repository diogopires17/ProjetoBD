using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Equipamentos;

namespace aluguer_de_equipamentos
{
    public partial class ReservasUser : Form
    {
        private SqlConnection cn;
        private Equipamento equipamento;
        private int userID;
        private DateTime dataAluguer;
        private int idReserva;

        public ReservasUser(int userID)
        {
            InitializeComponent();
            this.userID = userID;
            carrega_reservas();
        }

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }

        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection(Globals.strConn);
        }

        private void carrega_reservas()
        {
            txtReservas.Items.Clear();

            if (!verifySGBDConnection())
                return;

            string spName = "GetHistoricoAluguer";

            using (SqlCommand cmd = new SqlCommand(spName, cn))
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
                                if (dataAluguer > DateTime.Now.AddDays(-2))
                                {
                                    txtReservas.Items.Add($"{reservaId}, {equipamentoNome} - {dataAluguer}");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void ShowReservaDetails()
        {
            if (txtReservas.SelectedIndex == -1)
                return;

            // Extracting the reservation details from the selected item
            string selectedItem = txtReservas.SelectedItem.ToString();
            int selectedReservaId = int.Parse(selectedItem.Split(',')[0]);

            string spName = "GetReservaDetails";

            using (SqlCommand cmd = new SqlCommand(spName, cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdReserva", selectedReservaId);

                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtEquipamento.Text = reader["EquipamentoNome"].ToString();
                            txtData.Text = reader["data_aluguer"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading reservation details: " + ex.Message);
                }
            }
        }

        private void deleteReserva()
        {
            if (txtReservas.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a reservation to delete.");
                return;
            }

            // Confirm deletion
            if (MessageBox.Show("Tem a certeza que deseja cancelar a reserva?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            // Extracting the reservation ID from the selected item
            string selectedItem = txtReservas.SelectedItem.ToString();
            int selectedReservaId = int.Parse(selectedItem.Split(',')[0]);

            string spName = "DeleteReserva";

            if (!verifySGBDConnection())
            {
                MessageBox.Show("Database connection is not available.");
                return;
            }

            using (SqlCommand cmd = new SqlCommand(spName, cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdReserva", selectedReservaId);

                try
                {
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Reserva cancelada!");
                        txtReservas.Items.RemoveAt(txtReservas.SelectedIndex);  // Remove the item from the list
                        ClearReservaDetails();
                    }
                    else
                    {
                        MessageBox.Show("No reservation was deleted. Please check the reservation ID.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting reservation: " + ex.Message);
                }
            }
        }

        private void ClearReservaDetails()
        {
            txtEquipamento.Clear();
            txtData.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Feedback feedback = new Feedback(userID);
            this.Hide();
            feedback.Show();
        }

        private void txtReservas_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowReservaDetails();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            deleteReserva();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserHomePage userHomePage = new UserHomePage(userID);
            userHomePage.Show();
        }
    }
}
