using Equipamentos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace aluguer_de_equipamentos
{
    public partial class AdminHomePage : Form
    {
        private SqlConnection cn;
        private int equipamentoSelecionado = -1;
        private List<Equipamento> equipamentos = new List<Equipamento>();
        private int selectedUserId;

        public AdminHomePage(int adminID)
        {
            InitializeComponent();
            this.selectedUserId = adminID;
            LoadEquipments();
            ShowEquipmentDetails();
            AdminList.SelectedIndexChanged += AdminList_SelectedIndexChanged;
        }

        private void AdminHomePage_Load(object sender, EventArgs e)
        {
            cn = getSGBDConnection();
            fazerGrafico();
        }

        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection(Globals.strConn);
        }

        private bool VerifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditFields();
            AdminHomePage adm = new AdminHomePage(selectedUserId);
            this.Hide();
            adm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddEquipamento();
            AdminHomePage adm = new AdminHomePage(selectedUserId);
            this.Hide();
            adm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClearFields();
            txtNome.ReadOnly = false;
            comboBox1.Enabled = true;
            txtLocalizacao.ReadOnly = false;
            txtDisponivel.Enabled = true;
            txtFornecedor.ReadOnly = false;
            disponibilidade.Enabled = true;
            txtPreco.ReadOnly = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DeleteFields();
            AdminHomePage adm = new AdminHomePage(selectedUserId);
            this.Hide();
            adm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fazerGrafico();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            fazerGrafico();
        }

        private void LoadEquipments()
        {
            if (!VerifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("GetEquipamentos", cn)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlDataReader reader = cmd.ExecuteReader();
            AdminList.Items.Clear();
            equipamentos.Clear();

            while (reader.Read())
            {
                Equipamento E = new Equipamento
                {
                    Nome = (string)reader["nome"],
                    Disponivel = (bool)reader["disponivel"],
                    Categoria = (string)reader["categoria"],
                    IdLocalizacao = (int)reader["id_localizacao"],
                    IdEquipamento = (int)reader["id_equipamento"],
                    IdFornecedor = (int)reader["id_fornecedor"],
                    Revisao = (DateTime)reader["revisao"],
                    IdAdministrador = (int)reader["id_administrador"]
                };

                equipamentos.Add(E);
                AdminList.Items.Add($"{E.Nome}, {E.Categoria}, {E.IdLocalizacao}  - {(E.Disponivel ? "Disponivel" : "Não disponível")}");
            }
            reader.Close();
        }

        private void AdminList_SelectedIndexChanged(object sender, EventArgs e)
        {
            equipamentoSelecionado = AdminList.SelectedIndex;
            ShowEquipmentDetails();
        }

        private void ShowEquipmentDetails()
        {
            if (equipamentoSelecionado < 0 || equipamentoSelecionado >= equipamentos.Count)
            {
                ClearFields();
                return;
            }

            Equipamento selectedEquipment = equipamentos[equipamentoSelecionado];
            DesativaCampos();

            SqlCommand cmd = new SqlCommand("GetEquipamentoById", cn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@IdEquipamento", selectedEquipment.IdEquipamento);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtNome.Text = (string)reader["nome"];
                comboBox1.Text = (string)reader["categoria"];
                txtLocalizacao.Text = selectedEquipment.IdLocalizacao.ToString();
                txtFornecedor.Text = selectedEquipment.IdFornecedor.ToString();
                txtDisponivel.Checked = selectedEquipment.Disponivel;
                disponibilidade.Value = selectedEquipment.Revisao;
                txtPreco.Text = reader["preco"].ToString();
                txtTecnico.Text = reader["id_tecnico"].ToString();
            }
            else
            {
                MessageBox.Show("Equipamento não encontrado.");
            }

            reader.Close();
        }

        private void ClearFields()
        {
            txtNome.Clear();
            comboBox1.SelectedIndex = -1;
            txtLocalizacao.Clear();
            txtDisponivel.Checked = false;
            txtFornecedor.Clear();
            disponibilidade.Value = DateTime.Now;
            txtTecnico.Clear();
            txtPreco.Clear();
        }

        private void EditFields()
        {
            using (SqlCommand cmd = new SqlCommand("UpdateEquipamento", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdEquipamento", equipamentos[equipamentoSelecionado].IdEquipamento);
                cmd.Parameters.AddWithValue("@Nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@Categoria", comboBox1.Text);
                cmd.Parameters.AddWithValue("@IdLocalizacao", txtLocalizacao.Text);
                cmd.Parameters.AddWithValue("@IdFornecedor", txtFornecedor.Text);
                cmd.Parameters.AddWithValue("@Revisao", disponibilidade.Value);
                cmd.Parameters.AddWithValue("@Disponivel", txtDisponivel.Checked);
                cmd.Parameters.AddWithValue("@Preco", txtPreco.Text);
                cmd.Parameters.AddWithValue("@IdTecnico", int.Parse(txtTecnico.Text));

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Equipamento editado com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao editar equipamento: " + ex);
                }
            }
        }

        private void AddEquipamento()
        {
            using (SqlCommand cmd = new SqlCommand("AddEquipamento", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@Categoria", comboBox1.Text);
                cmd.Parameters.AddWithValue("@IdLocalizacao", txtLocalizacao.Text);
                cmd.Parameters.AddWithValue("@IdFornecedor", txtFornecedor.Text);
                cmd.Parameters.AddWithValue("@Revisao", disponibilidade.Value);
                cmd.Parameters.AddWithValue("@IdAdministrador", selectedUserId);
                cmd.Parameters.AddWithValue("@Disponivel", txtDisponivel.Checked);
                cmd.Parameters.AddWithValue("@Preco", txtPreco.Text);
                cmd.Parameters.AddWithValue("@IdTecnico", int.Parse(txtTecnico.Text));

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Equipamento adicionado com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao adicionar equipamento: " + ex.Message);
                }
            }
        }

        private void DeleteFields()
        {
            using (SqlCommand cmd = new SqlCommand("DeleteEquipamento", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdEquipamento", equipamentos[equipamentoSelecionado].IdEquipamento);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Equipamento eliminado com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao eliminar equipamento: " + ex.Message);
                }
            }
        }

        private void DesativaCampos()
        {
            if (equipamentoSelecionado >= 0 && equipamentoSelecionado < equipamentos.Count)
            {
                Equipamento selectedEquipment = equipamentos[equipamentoSelecionado];
                if (selectedEquipment.IdAdministrador != selectedUserId)
                {
                    txtNome.ReadOnly = true;
                    comboBox1.Enabled = false;
                    txtLocalizacao.ReadOnly = true;
                    txtDisponivel.Enabled = false;
                    txtFornecedor.ReadOnly = true;
                    disponibilidade.Enabled = false;
                    txtPreco.ReadOnly = true;
                    button1.Enabled = false;
                    button4.Enabled = false;
                    button3.Enabled = false;
                    button2.Enabled = false;
                }
                else
                {
                    txtNome.ReadOnly = false;
                    comboBox1.Enabled = true;
                    txtLocalizacao.ReadOnly = false;
                    txtDisponivel.Enabled = true;
                    txtFornecedor.ReadOnly = false;
                    disponibilidade.Enabled = true;
                    txtPreco.ReadOnly = false;
                    button1.Enabled = true;
                    button4.Enabled = true;
                    button3.Enabled = true;
                    button2.Enabled = true;
                }
            }
        }

        private void fazerGrafico()
        {
            SqlCommand cmd = new SqlCommand(@"
                SELECT e.id_equipamento, e.nome AS EquipmentName, AVG(af.classificacao) AS AvgRating 
                FROM Equipamento e 
                LEFT JOIN Reserva r ON e.id_equipamento = r.id_equipamento 
                LEFT JOIN AvaliacaoFeedback af ON r.id_reserva = af.id_reserva 
                GROUP BY e.id_equipamento, e.nome", cn);

            SqlDataReader reader = cmd.ExecuteReader();

            List<int> equipamentos = new List<int>();
            List<double?> medias = new List<double?>(); // Use nullable double

            while (reader.Read())
            {
                equipamentos.Add((int)reader["id_equipamento"]);

                if (reader["AvgRating"] != DBNull.Value)
                {
                    string avgRatingString = reader["AvgRating"].ToString();
                    double avgRatingValue;

                    if (double.TryParse(avgRatingString, out avgRatingValue))
                    {
                        medias.Add(avgRatingValue);
                    }
                    else
                    {
                        medias.Add(null);
                    }
                }
                else
                {
                    medias.Add(null);
                }
            }

            reader.Close();

            avaliacoes.Series["Avaliações"].Points.Clear();

            for (int i = 0; i < equipamentos.Count; i++)
            {
                double? avgRating = medias[i];

                if (avgRating != null)
                {
                    avaliacoes.Series["Avaliações"].Points.AddXY(equipamentos[i], avgRating.Value);
                }
            }

            SqlCommand cmd2 = new SqlCommand(@"
                SELECT e.id_equipamento, e.nome AS EquipmentName, COUNT(r.id_equipamento) AS TotalReservations 
                FROM Equipamento e 
                LEFT JOIN Reserva r ON e.id_equipamento = r.id_equipamento 
                GROUP BY e.id_equipamento, e.nome", cn);

            SqlDataReader reader2 = cmd2.ExecuteReader();
            if (reader2.Read())
            {
                List<int> equipamentos2 = new List<int>();
                List<int> totalReservations = new List<int>();

                while (reader2.Read())
                {
                    equipamentos2.Add((int)reader2["id_equipamento"]);
                    totalReservations.Add((int)reader2["TotalReservations"]);
                }

                reader2.Close();

                maisAlugados.Series["alugados"].Points.Clear();

                for (int i = 0; i < equipamentos2.Count; i++)
                {
                    maisAlugados.Series["alugados"].Points.AddXY(equipamentos2[i], totalReservations[i]);
                }
                maisAlugados.Series["alugados"].IsValueShownAsLabel = true;
            }

            SqlCommand cmd3 = new SqlCommand(@"
                SELECT t.id_tecnico, t.nome AS TechnicianName, COUNT(m.id_tecnico) AS TotalMaintenance 
                FROM TecnicoManutencao t 
                LEFT JOIN ManutencaoEquipamento m ON t.id_tecnico = m.id_tecnico 
                GROUP BY t.id_tecnico, t.nome", cn);

            SqlDataReader reader3 = cmd3.ExecuteReader();

            List<int> technicianIDs = new List<int>();
            List<int> totalMaintenanceCounts = new List<int>();

            while (reader3.Read())
            {
                technicianIDs.Add((int)reader3["id_tecnico"]);
                totalMaintenanceCounts.Add((int)reader3["TotalMaintenance"]);
            }

            reader3.Close();

            manutencoes.Series["Manutenções"].Points.Clear();

            for (int i = 0; i < technicianIDs.Count; i++)
            {
                manutencoes.Series["Manutenções"].Points.AddXY(technicianIDs[i], totalMaintenanceCounts[i]);
            }

            SqlCommand cmd4 = new SqlCommand(@"
                SELECT l.id_localizacao, l.cidade AS LocationName, COUNT(e.id_localizacao) AS TotalEquipments 
                FROM Localizacao l 
                LEFT JOIN Equipamento e ON l.id_localizacao = e.id_localizacao 
                GROUP BY l.id_localizacao, l.cidade", cn);

            SqlDataReader reader4 = cmd4.ExecuteReader();

            List<int> locationIDs = new List<int>();
            List<int> totalEquipmentCounts = new List<int>();

            while (reader4.Read())
            {
                locationIDs.Add((int)reader4["id_localizacao"]);
                totalEquipmentCounts.Add((int)reader4["TotalEquipments"]);
            }

            reader4.Close();

            equipa.Series["Equipamentos"].Points.Clear();

            for (int i = 0; i < locationIDs.Count; i++)
            {
                equipa.Series["Equipamentos"].Points.AddXY(locationIDs[i], totalEquipmentCounts[i]);
            }
        }
    }
}
