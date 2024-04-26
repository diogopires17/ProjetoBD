using Equipamentos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aluguer_de_equipamentos
{
    public partial class Feedback : Form
    {
        private SqlConnection cn;
        private Equipamento equipamento;
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

        private void FeedaBack_Load(object sender, EventArgs e)
        {
   


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
            try
            {
                insereFeedback();
                MessageBox.Show("Feedback inserido com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir feedback");
            }
        }

        // seleciona as reservas do historico
        private void carrega_reservas()
        {
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

        // insere o feedback    
            private void insereFeedback()
            {
                if (!verifySGBDConnection())
                    return;
                string query = "INSERT INTO AvaliacaoFeedback (id_reserva, classificacao, id_utilizador, data_avaliacao, comentario) VALUES (@IdReserva, @Classificacao, @IdUtilizador, @DataAvaliacao, @Comentario)";
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@IdUtilizador", userID);
                    cmd.Parameters.AddWithValue("@DataAvaliacao", DateTime.Now);
                    cmd.Parameters.AddWithValue("@IdReserva", idReserva);
                    cmd.Parameters.AddWithValue("@Classificacao", txtClassificacao.Value);
                    cmd.Parameters.AddWithValue("@Comentario", txtComentario.Text);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Feedback inserido com sucesso!");
                    }
                    catch (Exception ex)
                    {
                        // Handle exception
                        Console.WriteLine(ex.Message);
                    }
                }


            }


    }
}
