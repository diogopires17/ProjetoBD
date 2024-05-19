using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aluguer_de_equipamentos
{
    public partial class SignUpButton : Form
    {
        public int userId;  

        public SignUpButton()
        {
            InitializeComponent();
        }

        private SqlConnection cn;

        private void Form1_Load(object sender, EventArgs e)
        {
            cn = getSGBDConnection();
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int cc;
            if (!int.TryParse(SignUpCC.Text, out cc))
            {
                MessageBox.Show("CC inválido");

            }
            
            string nome = SignUpNome.Text;
            string email = SignUpEmail.Text;
            int telefone;
            
            if (!int.TryParse(SignUpTelefone.Text, out telefone))
            {
               
                MessageBox.Show("Telefone inválido");
            }

            string endereco = SignUpEndereco.Text;
            DateTime dataNascimento = SignUpDataNasc.Value;
            string password = SignUpPassword.Text;

            if (!verifySGBDConnection())
                return;
            if (nome.Equals(""))
            {
                MessageBox.Show("Nome não pode estar vazio");   
            }
            else if (email.Equals(""))
            {
                MessageBox.Show("Email não pode estar vazio");
            }
            else if (password.Equals(""))
            {
                MessageBox.Show("Password não pode estar vazia");
            }
            else if (cc.Equals(""))
            {
                MessageBox.Show("CC não pode estar vazio");
            }
            else if (telefone.Equals(""))
            {
                MessageBox.Show("Telefone não pode estar vazio");
            }
            else if (endereco.Equals(""))
            {
                MessageBox.Show("Endereço não pode estar vazio");
            }
            else if (dataNascimento.Equals(""))
            {
                MessageBox.Show("Data de Nascimento não pode estar vazia");
            }
            else
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "insert into Utilizador(cc, nome, email, telefone, endereco, data_nascimento, pass) values(@cc, @nome, @email, @telefone, @endereco, @dataNascimento, @pass)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@cc", cc);
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@telefone", telefone);
                cmd.Parameters.AddWithValue("@endereco", endereco);
                cmd.Parameters.AddWithValue("@dataNascimento", dataNascimento);
                cmd.Parameters.AddWithValue("@pass", password);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Utilizador registado com sucesso");
                Login login = new Login();
                userId = login.GetUserId(email, password);
                UserHomePage userHome = new UserHomePage(userId);   
                userHome.Show();
                this.Hide();


            }
        }


        private void openLogin_Click(object sender, EventArgs e)
        {
            cn.Open();
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }

}
