using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace aluguer_de_equipamentos
{
    public partial class Gerir : Form
    {
        private int tecnicoID;
        private SqlConnection cn;
        private List<ManutencaoRecord> manutencoes;

        public Gerir(int tecnicoID)
        {
            InitializeComponent();
            this.tecnicoID = tecnicoID;
            cn = getSGBDConnection(); // Initialize the connection here
            LoadManutencoes();
        }

        private void GestaoTecnic_Load(object sender, EventArgs e)
        {
            // Initialize the connection here
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

        private void LoadManutencoes()
        {
            try
            {
                if (!verifySGBDConnection())
                {
                    MessageBox.Show("Unable to connect to the database.");
                    return;
                }

                SqlCommand cmd = new SqlCommand("sp_GetManutencoesByTecnico", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@id_tecnico", tecnicoID);

                SqlDataReader reader = cmd.ExecuteReader();
                manutencoesListBox.Items.Clear();
                manutencoes = new List<ManutencaoRecord>();

                if (!reader.HasRows)
                {
                    MessageBox.Show("No maintenance records found for this technician.");
                }

                while (reader.Read())
                {
                    int idManutencao = reader["id_manutencao"] != DBNull.Value ? (int)reader["id_manutencao"] : 0;
                    string manutencaoDesc = reader["descricao"] != DBNull.Value ? (string)reader["descricao"] : "No description";
                    int idEquipamento = reader["id_equipamento"] != DBNull.Value ? (int)reader["id_equipamento"] : 0;
                    string equipamentoNome = reader["nome_equipamento"] != DBNull.Value ? (string)reader["nome_equipamento"] : "No name";
                    DateTime data = reader["data"] != DBNull.Value ? (DateTime)reader["data"] : DateTime.MinValue;

                    ManutencaoRecord record = new ManutencaoRecord
                    {
                        IdManutencao = idManutencao,
                        Descricao = manutencaoDesc,
                        IdEquipamento = idEquipamento,
                        NomeEquipamento = equipamentoNome,
                        Data = data
                    };

                    manutencoes.Add(record);
                    manutencoesListBox.Items.Add($"{data.ToShortDateString()} - {equipamentoNome}: {manutencaoDesc}");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading maintenance records: " + ex.Message);
            }
        }

        private void manutencoesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            showManutencaoDetails();
        }

        public void showManutencaoDetails()
        {
            if (manutencoesListBox.Items.Count == 0 || manutencoesListBox.SelectedIndex < 0)
            {
                return;
            }

            int selectedIndex = manutencoesListBox.SelectedIndex;
            ManutencaoRecord selectedRecord = manutencoes[selectedIndex];

            // Update the UI elements with the parsed values
            txtData.Text = selectedRecord.Data.ToShortDateString();
            txtEquipamento.Text = selectedRecord.NomeEquipamento;
            txtDescricao.Text = selectedRecord.Descricao;

            // Update hidden fields or labels with IDs
            lblIdManutencao.Text = selectedRecord.IdManutencao.ToString();
            lblIdEquipamento.Text = selectedRecord.IdEquipamento.ToString();
        }

        private void Atualizar_Click(object sender, EventArgs e)
        {
            if (lblIdManutencao.Text == "" || lblIdEquipamento.Text == "")
            {
                MessageBox.Show("Please select a maintenance record to update.");
                return;
            }

            int idManutencao = int.Parse(lblIdManutencao.Text);
            string descricao = txtDescricao.Text;
            int idEquipamento = int.Parse(lblIdEquipamento.Text);
            int idTecnico = tecnicoID; // Assuming idTecnico is the current technician
            DateTime data = DateTime.Parse(txtData.Text);

            UpdateManutencao(idManutencao, descricao, idEquipamento, idTecnico, data);
            LoadManutencoes(); // Refresh the list
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            if (lblIdManutencao.Text == "")
            {
                MessageBox.Show("Please select a maintenance record to delete.");
                return;
            }

            int idManutencao = int.Parse(lblIdManutencao.Text);

            DeleteManutencao(idManutencao);
            LoadManutencoes(); // Refresh the list
        }

        private void UpdateManutencao(int idManutencao, string descricao, int idEquipamento, int idTecnico, DateTime data)
        {
            if (!verifySGBDConnection())
            {
                MessageBox.Show("Unable to connect to the database.");
                return;
            }

            try
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateManutencao", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@id_manutencao", idManutencao);
                cmd.Parameters.AddWithValue("@descricao", descricao);
                cmd.Parameters.AddWithValue("@id_equipamento", idEquipamento);
                cmd.Parameters.AddWithValue("@id_tecnico", idTecnico);
                cmd.Parameters.AddWithValue("@data", data);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating the maintenance record: " + ex.Message);
            }
        }

        private void DeleteManutencao(int idManutencao)
        {
            if (!verifySGBDConnection())
            {
                MessageBox.Show("Unable to connect to the database.");
                return;
            }

            try
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteManutencao", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@id_manutencao", idManutencao);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while deleting the maintenance record: " + ex.Message);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            TecnicoHomePage tecnicoHomePage = new TecnicoHomePage(tecnicoID);
            tecnicoHomePage.Show();
            this.Hide();
        }
    }

    public class ManutencaoRecord
    {
        public int IdManutencao { get; set; }
        public string Descricao { get; set; }
        public int IdEquipamento { get; set; }
        public string NomeEquipamento { get; set; }
        public DateTime Data { get; set; }
    }
}
