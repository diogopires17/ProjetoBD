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
    public partial class Login : Form
    {
        public String email;
        public String password;

        public Login()
        {
            InitializeComponent();
            cn = getSGBDConnection();
        }

        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection(Globals.strConn);
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

        private void button1_Click(object sender, EventArgs e)
        {
            LoginAdmin logAdmin = new LoginAdmin();
            logAdmin.Show();
            this.Hide();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            email = textBox1.Text;
            password = LoginPassword.Text;

            if (!verifySGBDConnection())
                return;

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Insira o email");
                return;
            }
            else if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Insira a password");
                return;
            }

            int userId = GetUserId(email, password);

            if (userId == -1)
            {
                MessageBox.Show("Login falhado");
                return;
            }
            else if (!email.StartsWith("admin"))
            {
                MessageBox.Show("Login efetuado com sucesso!");
                UserHomePage userHomePage = new UserHomePage(userId);
                userHomePage.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Ocorreu um erro!");
                return;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
        }

        public int GetUserId(string email, string password)
        {
            int userId = -1;

            using (SqlConnection cn = getSGBDConnection())
            {
                cn.Open();

                using (SqlCommand cmd = new SqlCommand("dbo.LoginUser", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userId = reader.GetInt32(reader.GetOrdinal("id_utilizador"));
                        }
                        else
                        {
                            MessageBox.Show("Nenhum utilizador encontrado com as credenciais fornecidas");
                        }
                    }
                }
            }

            return userId;
        }

        private void createAccountButton_Click(object sender, EventArgs e)
        {
            SignUpButton signupForm = new SignUpButton();
            signupForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TecnicoLogin tec = new TecnicoLogin();
            tec.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}