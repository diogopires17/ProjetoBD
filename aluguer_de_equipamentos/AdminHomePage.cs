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
            txtCategoria.ReadOnly = false;
            txtLocalizacao.ReadOnly = false;
            txtDisponivel.Enabled = true;
            txtFornecedor.ReadOnly = false;
            disponibilidade.Enabled = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DeleteFields();
            AdminHomePage adm = new AdminHomePage(selectedUserId);
            this.Hide();
            adm.Show();

        }


        private void LoadEquipments()
        {
            if (!VerifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT E.*, L.cidade FROM Equipamento E INNER JOIN localizacao L ON E.id_localizacao = L.id_localizacao", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            AdminList.Items.Clear();
            equipamentos.Clear();

            while (reader.Read())
            {
                Equipamento E = new Equipamento();
                E.Nome = (string)reader["nome"];
                E.Disponivel = (bool)reader["disponivel"];
                E.Categoria = (string)reader["categoria"];
                E.IdLocalizacao = (int)reader["id_localizacao"];
                E.IdEquipamento = (int)reader["id_equipamento"];
                E.IdLocalizacao = (int)reader["id_localizacao"];
                E.IdFornecedor = (int)reader["id_fornecedor"];
                E.Revisao = (DateTime)reader["revisao"];
                E.IdAdministrador = (int)reader["id_administrador"];
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


        // OUTRAS FUNÇÕES
        private void ShowEquipmentDetails()
        {
            if (equipamentoSelecionado < 0 || equipamentoSelecionado >= equipamentos.Count)
            {
                ClearFields();
                return;
            }
            
            Equipamento selectedEquipment = equipamentos[equipamentoSelecionado];
            DesativaCampos();
  

            SqlCommand cmd = new SqlCommand("SELECT * FROM Equipamento WHERE id_equipamento = @IdEquipamento", cn);
            cmd.Parameters.AddWithValue("@IdEquipamento", selectedEquipment.IdEquipamento);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtNome.Text = (string)reader["nome"];
                txtCategoria.Text = (string)reader["categoria"];
                txtLocalizacao.Text = selectedEquipment.IdLocalizacao.ToString();
                txtFornecedor.Text = selectedEquipment.IdFornecedor.ToString();
                txtDisponivel.Checked = selectedEquipment.Disponivel;
                disponibilidade.Value = selectedEquipment.Revisao;
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
            txtCategoria.Clear();
            txtLocalizacao.Clear();
            txtDisponivel.Checked = false;
            txtFornecedor.Clear();
            disponibilidade.Value = DateTime.Now;


        }
     
        private void EditFields()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE Equipamento SET nome = @Nome, categoria = @Categoria, disponivel = @Disponivel, id_localizacao = @IdLocalizacao, id_fornecedor = @IdFornecedor, revisao = @Revisao WHERE id_equipamento = @IdEquipamento"; cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@Categoria", txtCategoria.Text);
            cmd.Parameters.AddWithValue("@IdLocalizacao", txtLocalizacao.Text);
            cmd.Parameters.AddWithValue("@IdFornecedor", txtFornecedor.Text);
            cmd.Parameters.AddWithValue("@Revisao", disponibilidade.Value);
            cmd.Parameters.AddWithValue("@IdEquipamento", equipamentos[equipamentoSelecionado].IdEquipamento);
            cmd.Parameters.AddWithValue("@Disponivel", txtDisponivel.Checked);
            cmd.Connection = cn;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar equipamento: " + ex);
                return;
                
            }
            finally
            {
              MessageBox.Show("Equipamento editado com sucesso!");  
            }
        }
        private void AddEquipamento()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Equipamento (nome, categoria, disponivel, id_localizacao, id_fornecedor, revisao) VALUES (@Nome, @Categoria, @Disponivel, @IdLocalizacao, @IdFornecedor, @Revisao)"; cmd.Parameters.AddWithValue("@Nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@Categoria", txtCategoria.Text);
            cmd.Parameters.AddWithValue("@IdLocalizacao", txtLocalizacao.Text);
            cmd.Parameters.AddWithValue("@IdFornecedor", txtFornecedor.Text);
            cmd.Parameters.AddWithValue("@Revisao", disponibilidade.Value);
            cmd.Parameters.AddWithValue("@IdAdministrador", selectedUserId);
            cmd.Parameters.AddWithValue("@Disponivel", txtDisponivel.Checked);

            cmd.Connection = cn;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar equipamento: " + ex);
                return;
            }
            finally
            {
                MessageBox.Show("Equipamento adicionado com sucesso!");
            }
        }

        private void DeleteFields()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM Equipamento WHERE id_equipamento = @IdEquipamento";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@IdEquipamento", equipamentos[equipamentoSelecionado].IdEquipamento);
            cmd.Connection = cn;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao eliminar equipamento: " + ex);
                return;
            }
            finally
            {
                MessageBox.Show("Equipamento eliminado com sucesso!");
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
                    txtCategoria.ReadOnly = true;
                    txtLocalizacao.ReadOnly = true;
                    txtDisponivel.Enabled = false;
                    txtFornecedor.ReadOnly = true;
                    disponibilidade.Enabled = false;
                }
                else
                {
                    txtNome.ReadOnly = false;
                    txtCategoria.ReadOnly = false;
                    txtLocalizacao.ReadOnly = false;
                    txtDisponivel.Enabled = true;
                    txtFornecedor.ReadOnly = false;
                    disponibilidade.Enabled = true;
                }
            }
        }

    }
}
