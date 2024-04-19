using Contacts;
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
        private int  equipamnetoSelecionado = 1 ;
        private List<Equipamento> equipamentos = new List<Equipamento>(); 

        public UserHomePage()
        {
            InitializeComponent();
            showEquipamento();
        }
        private void UserHomePage_Load(object sender, EventArgs e)
        {
            cn = getSGBDConnection();
            loadEquipmentsToolStripMenuItem_Click(sender, e);
        }

        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection("data source= DIOGOPIRES\\SQLEXPRESS;integrated security=true;initial catalog=aluguer_equipamentos");
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
            equipamnetoSelecionado = UserEquipmentList.SelectedIndex;
            showEquipamento();
        }
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
                string cidade = (string)reader["cidade"]; 
                equipamentos.Add(E);
                UserEquipmentList.Items.Add($"{E.Nome},  {E.Categoria}, {cidade}  - {(E.Disponivel ? "Disponivel" : "Não disponível")}");
            }

            cn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }



        // OUTRAS FUNÇÕES
        private void  showEquipamento()
        {
            if(UserEquipmentList.Items.Count == 0 | UserEquipmentList.SelectedIndex < 0)
            {
                return;
            }
            Equipamento E = equipamentos[equipamnetoSelecionado];
            txtNome.Text = E.Nome;
            txtCategoria.Text = E.Categoria;
            txtLocalizacao.Text = E.IdLocalizacao.ToString();
            txtDisponibilidade.Text = E.Disponivel ? "Disponivel" : "Não disponivel";

            

            desativaCampos();

        }

        private void desativaCampos()
        {
            txtNome.ReadOnly = true;
            txtCategoria.ReadOnly = true;
            txtLocalizacao.ReadOnly = true;
            txtDisponibilidade.ReadOnly = true;
        }

    }
}
