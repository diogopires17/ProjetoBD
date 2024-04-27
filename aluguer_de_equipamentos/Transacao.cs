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
        private List<Equipamento> equipamentos = new List<Equipamento>();
        private int selectedUserId;
        private DateTime dataFim;
        private int id_equipamento;
        private int duracao_reserva;
        private int desconto;
        private int equipamentoSelecionado;
        private int idReserva;

        public Transacao(int userId, int id_equipamento, int equipamentoSelecionado, List<Equipamento> equips, int desconto, int idReserva)
        {
            InitializeComponent();
            this.id_equipamento = id_equipamento;
            this.equipamentoSelecionado = equipamentoSelecionado;
            MessageBox.Show("Equipamento selecionado: " + equipamentoSelecionado);
            this.selectedUserId = userId;
            this.equipamentos = equips;
            this.desconto = desconto;
            this.idReserva = idReserva;
            loadContents();



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
        private void loadContents()

        {
            txtValor.ReadOnly = true;
            // Check that equipamentoSelecionado is within the valid range
            if (equipamentoSelecionado < 0 || equipamentoSelecionado >= equipamentos.Count)
            {
                MessageBox.Show("teste Invalid selection.");
                return;
            }

            txtValor.Text = equipamentos[equipamentoSelecionado].Preco.ToString();
            button2.Enabled = false;

        }



        // Button1_Click method
        private void button1_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            // Insert into the Reserva table first
            string query1 = "INSERT INTO Reserva (data_inicio, data_fim, duracao_aluguer, id_utilizador, id_equipamento, desconto) " +
                           "OUTPUT INSERTED.id_reserva " +
                           "VALUES (@DataInicio, @DataFim, @DuracaoAluguer, @IdUtilizador, @IdEquipamento, @Desconto)";

            dataFim = DateTime.Now.AddMinutes(1);
            using (SqlCommand cmd = new SqlCommand(query1, cn))
            {
                cmd.Parameters.AddWithValue("@DataInicio", DateTime.Now);
                cmd.Parameters.AddWithValue("@DataFim", dataFim);
                cmd.Parameters.AddWithValue("@DuracaoAluguer", 1);
                cmd.Parameters.AddWithValue("@IdUtilizador", selectedUserId);
                cmd.Parameters.AddWithValue("@IdEquipamento", equipamentos[equipamentoSelecionado].IdEquipamento);
                cmd.Parameters.AddWithValue("@Desconto", desconto);

                // Execute the command and get the inserted id_reserva value
                idReserva = (int)cmd.ExecuteScalar();
            }

            Equipamento E = equipamentos[equipamentoSelecionado];
            E.Disponivel = false;
            SqlCommand cmdUpdate = new SqlCommand("UPDATE Equipamento SET disponivel = 0 WHERE id_equipamento = @IdEquipamento", cn);
            cmdUpdate.Parameters.AddWithValue("@IdEquipamento", E.IdEquipamento);
            cmdUpdate.ExecuteNonQuery();

            // Now insert into the Transacao table with the inserted id_reserva value
            string query = "INSERT INTO Transacao (valor, MetodoPagamento, id_reserva) VALUES (@Valor, @MetodoPagamento, @IdReserva)";

            using (SqlCommand cmd1 = new SqlCommand(query, cn))
            {
                cmd1.Parameters.AddWithValue("@Valor", equipamentos[equipamentoSelecionado].Preco);
                cmd1.Parameters.AddWithValue("@MetodoPagamento", comboBox1.SelectedItem.ToString());
                cmd1.Parameters.AddWithValue("@IdReserva", idReserva);

                cmd1.ExecuteNonQuery();
            }

            MessageBox.Show("Equipamento reservado com sucesso");
            UserHomePage u = new UserHomePage(selectedUserId);
            u.Show();
            this.Hide();
            // termina a aplicação
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtDesconto.Text == desconto.ToString())
            {
                MessageBox.Show("Desconto aplicado com sucesso.");
                equipamentos[equipamentoSelecionado].Preco -= (int)(equipamentos[equipamentoSelecionado].Preco * 0.30);
                MessageBox.Show("Preço atualizado: " + equipamentos[equipamentoSelecionado].Preco);
                txtValor.Text = equipamentos[equipamentoSelecionado].Preco.ToString();
            }
            else
            {
                MessageBox.Show("Código de desconto inválido.");
            }

            // refresh the form
            this.Refresh();
        }

        private void txtDesconto_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }


    }
}

