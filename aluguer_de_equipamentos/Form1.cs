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

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO MANUTENCAOEquipamento (id_equipamento, id_tecnico, descricao, data) VALUES (@idEquipamento, @id_tecnico, @descricao, @data)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@idEquipamento", equipamentos[equipamentoSelecionado].IdEquipamento);
            cmd.Parameters.AddWithValue("@id_tecnico", userID);
            cmd.Parameters.AddWithValue("@descricao", richTextBox1.Text);            
            cmd.Parameters.AddWithValue("@data", DateTime.Now);
            cmd.Connection = cn;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Manutenção efetuada com sucesso");

            // adiciona a nova data de revisao no equipamento
            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandText = "UPDATE Equipamento SET revisao = @revisao, id_tecnico = @Idtecnico WHERE id_equipamento = @idEquipamento";
            cmd2.Parameters.Clear();
            cmd2.Parameters.AddWithValue("@revisao", DateTime.Now.AddMonths(6));
            cmd2.Parameters.AddWithValue("@idEquipamento", equipamentos[equipamentoSelecionado].IdEquipamento);
            cmd2.Parameters.AddWithValue("@Idtecnico", userID);
            cmd2.Connection = cn;
            cmd2.ExecuteNonQuery();
            Login login = new Login();  
            login.Show();
            this.Hide();



        }


    }
}
