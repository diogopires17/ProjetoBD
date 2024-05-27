using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Equipamentos;


namespace aluguer_de_equipamentos
{

    public partial class EfetuarManutencao : Form
    {
        private int userID;
        private List<Equipamento> equipamentos = UserHomePage.equipamentos;
        private int equipamentoSelecionado;
        private SqlConnection cn;

        public EfetuarManutencao(int userID, int equipamento)
        {
            InitializeComponent();
            this.userID = userID;
            this.equipamentoSelecionado = equipamento;
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


        private void EfetuarManutencao_Load(object sender, EventArgs e)
        {
            txtEquipamento.Text = "id:" + " " +  equipamentos[equipamentoSelecionado].IdEquipamento.ToString() + " " +  "Nome:" + " " +  equipamentos[equipamentoSelecionado].Nome;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            EfetuaManutencao();
        }

        private void EfetuaManutencao()
        {
            if (!verifySGBDConnection())
                return;

            // Call stored procedure to insert maintenance
            SqlCommand cmd = new SqlCommand("dbo.InsertMaintenance", cn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@id_equipamento", equipamentos[equipamentoSelecionado].IdEquipamento);
            cmd.Parameters.AddWithValue("@id_tecnico", userID);
            cmd.Parameters.AddWithValue("@descricao", richTextBox1.Text);
            cmd.Parameters.AddWithValue("@data", DateTime.Now);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Manutenção efetuada com sucesso");

            // Call stored procedure to update equipment revision
            SqlCommand cmd2 = new SqlCommand("dbo.UpdateEquipmentRevision", cn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd2.Parameters.AddWithValue("@id_equipamento", equipamentos[equipamentoSelecionado].IdEquipamento);
            cmd2.Parameters.AddWithValue("@revisao", DateTime.Now.AddMonths(6));
            cmd2.Parameters.AddWithValue("@id_tecnico", userID);
            cmd2.ExecuteNonQuery();

           TecnicoHomePage tecnicoHomePage = new TecnicoHomePage(userID);
            tecnicoHomePage.Show();
            this.Hide();
        }



    }
}
