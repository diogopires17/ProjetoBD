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
        public UserHomePage()
        {
            InitializeComponent();
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

        private SqlConnection cn;

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

        }
        private void loadEquipmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM Equipamento", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            UserEquipmentList.Items.Clear();

            while (reader.Read())
            {
                Equipamento E = new Equipamento();
                E.Nome = (string)reader["nome"];
                E.Disponivel = (bool)reader["disponivel"];
                E.Categoria = (string)reader["categoria"];
                UserEquipmentList.Items.Add($"{E.Nome},  {E.Categoria} - {(E.Disponivel ? "Disponivel" : "Não disponível")}");

            }

            cn.Close();
        }


    }
}
