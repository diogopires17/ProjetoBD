using Equipamentos;
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
        private int duracaoReserva;
        private int nr_reserva;
        private int desconto;
        public UserHomePage(int userId)
        {
            InitializeComponent();
            showEquipamento();
            VeDisponibilidade(dataFim);
            DesativaCampos();
            this.selectedUserId = userId;
            Timer timer = new Timer();
            timer.Interval = 60000; // 60 seconds
            timer.Tick += (s, e) => VeDisponibilidade(dataFim);
            timer.Start();


        }
        private void UserHomePage_Load(object sender, EventArgs e)
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
                E.Preco = (int)reader["preco"];
                string cidade = (string)reader["cidade"]; 

                equipamentos.Add(E);
                UserEquipmentList.Items.Add($"PREÇO : {E.Preco}, {E.Nome}, {E.Categoria}, {cidade}  - {(E.Disponivel ? "Disponivel" : "Não disponível")}");
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
            // gera codigo de desconto se o user tiver 10 reservas
            if (has10())
            {
                Random random = new Random();
                desconto = random.Next(0, 1000);
                MessageBox.Show("Parabéns! Ganhou um código de desconto: " + desconto);

            }

            // le duracao da reserva da database
            Transacao trans = new Transacao(selectedUserId, equipamentos[equipamentoSelecionado].IdEquipamento, equipamentoSelecionado, equipamentos, desconto );
            this.Hide();
            trans.Show();

        }

        // OUTRAS FUNÇÕES
        // Mostra o equipamento selecionado
        public  void showEquipamento()
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
        private bool has10()
        {
            nr_reserva = 0; 
            foreach (var equipamento in equipamentos)
            {
                if (equipamento.IdEquipamento == selectedUserId)
                {
                    nr_reserva++;
                    MessageBox.Show("nr_reserva: " + nr_reserva);
                }
            }
            if (nr_reserva >= 10)
            {
                return true;
            }
            return false;
        }


        private void VeDisponibilidade(DateTime dataFim)
        {
            if (!verifySGBDConnection())
                return;

            foreach (var equipamento in equipamentos)
            {
                bool disponivel = false;
                DateTime dataFimReserva = DateTime.MinValue;
                using (SqlCommand cmd = new SqlCommand("SELECT data_fim FROM Reserva WHERE id_equipamento = @IdEquipamento", cn))
                {
                    cmd.Parameters.AddWithValue("@IdEquipamento", equipamento.IdEquipamento);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            dataFimReserva = (DateTime)reader["data_fim"];
                            disponivel = DateTime.Now > dataFimReserva;
                        }
                    }
                }

                if (disponivel)
                {
                    equipamento.Disponivel = true;

                    // Atualiza a disponibilidade do equipamento
                    using (SqlCommand cmdeq = new SqlCommand("UPDATE Equipamento SET disponivel = 1 WHERE id_equipamento = @IdEquipamento", cn))
                    {
                        cmdeq.Parameters.AddWithValue("@IdEquipamento", equipamento.IdEquipamento);
                        cmdeq.ExecuteNonQuery();
                    }

                    // le o id da reserva
                    int idReserva = 0;
                    using (SqlCommand cmdres1 = new SqlCommand("SELECT id_reserva FROM Reserva WHERE id_equipamento = @IdEquipamento", cn))
                    {
                        cmdres1.Parameters.AddWithValue("@IdEquipamento", equipamento.IdEquipamento);
                        using (SqlDataReader reader1 = cmdres1.ExecuteReader())
                        {
                            if (reader1.Read())
                            {
                                idReserva = (int)reader1["id_reserva"];
                                //duracaoReserva = (int)reader1["duracao_aluguer"];
                            }
                        }
                    }

                    // Adiciona a reserva a historico   
                    using (SqlCommand cmdres2 = new SqlCommand("INSERT INTO HistoricoAluguer (data_aluguer, id_equipamento, id_reserva) " +
                                                                         "VALUES (@DataInicio, @IdEquipamento, @IdReserva)", cn))
                    {
                        cmdres2.Parameters.AddWithValue("@DataInicio", DateTime.Now);
                        cmdres2.Parameters.AddWithValue("@IdEquipamento", equipamento.IdEquipamento);
                        cmdres2.Parameters.AddWithValue("@IdReserva", idReserva);
                        cmdres2.ExecuteNonQuery();
                    }
                }
            }
        }
    }

}
