using Equipamentos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aluguer_de_equipamentos
{
    public partial class UserHomePage : Form
    {
        private SqlConnection cn;
        private int  equipamentoSelecionado = 1 ;
        public static List<Equipamento> equipamentos { get; set; } = new List<Equipamento>(); 
        private int selectedUserId;
        private DateTime dataFim;
        private int duracaoReserva;
        private int nr_reserva;
        private int desconto;
        private int idReserva;
        private DateTime dataInicio;
        public UserHomePage(int userId)
        {
            InitializeComponent();
            showEquipamento();
            VeDisponibilidade(dataFim);
            DesativaCampos();
            UserEquipmentList.SelectedIndexChanged += listBox1_SelectedIndexChanged;
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
            if (UserEquipmentList.SelectedIndex >= 0)
            {
                equipamentoSelecionado = UserEquipmentList.SelectedIndex;
                showEquipamento();
            }

        }

        // carrega os equipamentos para a lista
        private void loadEquipmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;


            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.EquipmentView", cn);
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
                UserEquipmentList.Items.Add($"{E.Preco}€, {E.Nome}, {E.Categoria}, {cidade}  - {(E.Disponivel ? "Disponivel" : "Não disponível")}");
            }
            reader.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UserEquipmentList.SelectedIndex >= 0)
            {
                equipamentoSelecionado = UserEquipmentList.SelectedIndex;
                if (has10())
                {
                    Random random = new Random();
                    desconto = random.Next(0, 1000);
                    MessageBox.Show("Parabéns a sua reserva é par! Ganhou um código de desconto: " + desconto);
                }
                // le duracao da reserva da database
                if (equipamentoSelecionado >= 0 && equipamentoSelecionado < equipamentos.Count) // Check that equipamentoSelecionado is a valid index
                {
                    using (SqlCommand cmdres1 = new SqlCommand("SELECT id_reserva FROM Reserva WHERE id_equipamento = @IdEquipamento", cn))
                    {
                        Equipamento equipamento = equipamentos[equipamentoSelecionado];
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
                    Transacao trans = new Transacao(selectedUserId, equipamentos[equipamentoSelecionado].IdEquipamento, equipamentoSelecionado, equipamentos, desconto, idReserva);
                    this.Hide();
                    trans.Show();
                }
                else
                {
                    MessageBox.Show("Invalid selection.");
                }
            }
            else
            {
                MessageBox.Show("No item selected");
            }
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
            // checks if the user has 10 reservations
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Reserva WHERE id_utilizador = @IdUtilizador", cn))
            {
                cmd.Parameters.AddWithValue("@IdUtilizador", selectedUserId);
                int count = (int)cmd.ExecuteScalar();
                return count % 2 == 0;
            }

        }


        private void VeDisponibilidade(DateTime dataFim)
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("sp_CheckAndUpdateAvailability", cn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.ExecuteNonQuery();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Feedback feedback = new Feedback(selectedUserId);
            this.Hide();
            feedback.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ReservasUser userReservas = new ReservasUser(selectedUserId);
            this.Hide();
            userReservas.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }
    }

}
