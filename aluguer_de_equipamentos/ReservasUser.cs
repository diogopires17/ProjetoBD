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


            string query = "SELECT h.*, e.nome AS EquipamentoNome FROM HistoricoAluguer h " +
                           "JOIN Reserva r ON h.id_reserva = r.id_reserva " +
                           "JOIN Utilizador u ON r.id_utilizador = u.id_utilizador " +
                           "JOIN Equipamento e ON r.id_equipamento = e.id_equipamento " +
                           "WHERE u.id_utilizador = @IdUtilizador";

            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.AddWithValue("@IdUtilizador", userID);

                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dataAluguer = (DateTime)reader["data_aluguer"];
                            string equipamentoNome = reader["EquipamentoNome"].ToString();
                            idReserva = (int)reader["id_reserva"];
                            if (dataAluguer > DateTime.Now.AddDays(-2))
                                txtReservas.Items.Add(idReserva + ", " + equipamentoNome + " - " + dataAluguer);
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


        private void button1_Click(object sender, EventArgs e)
        {
            Feedback feedback = new Feedback(userID);
            this.Hide();
            feedback.Show();
        }

        private void txtReservas_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            int selectedReservaId = int.Parse(selectedItem.Split(',')[0]);  // Assuming the format is "ID, Name - Date"

            string deleteQuery = "DELETE FROM Reserva WHERE id_reserva = @IdReserva";

            if (!verifySGBDConnection())
            {
                MessageBox.Show("Database connection is not available.");
                return;
            }

            using (SqlCommand cmd = new SqlCommand(deleteQuery, cn))
            {
                cmd.Parameters.AddWithValue("@IdReserva", selectedReservaId);

                try
                {
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Reservation and all related transactions deleted successfully.");
                        txtReservas.Items.RemoveAt(txtReservas.SelectedIndex);  // Remove the item from the list
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


        private void button2_Click(object sender, EventArgs e)
        {

            deleteReserva();

        }
    }
}
