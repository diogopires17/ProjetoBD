using Equipamentos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aluguer_de_equipamentos
{
    public partial class Transacao : Form
    {

        private SqlConnection cn;
        private int equipamentoSelecionado = 1;
        private List<Equipamento> equipamentos = new List<Equipamento>();
        private int selectedUserId;
        private DateTime dataFim;
        private int id_equipamento;

        public Transacao( int userId,int id_equipamento, int equipamentoSelecionado)
        {
            InitializeComponent();
            this.id_equipamento = id_equipamento;
            this.equipamentoSelecionado = equipamentoSelecionado;
            this.selectedUserId = userId;
        }

        private void Transacao_Load(object sender, EventArgs e)
        {
            cn = getSGBDConnection();
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
            if (!verifySGBDConnection())
                return;

            string query = "INSERT INTO Reserva (data_inicio, data_fim, duracao_aluguer, id_utilizador, id_equipamento) " +
                           "VALUES (@DataInicio, @DataFim, @DuracaoAluguer, @IdUtilizador, @IdEquipamento)";

            dataFim = DateTime.Now.AddHours(1);
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@DataInicio", DateTime.Now);
            cmd.Parameters.AddWithValue("@DataFim", dataFim);
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
    }
}

