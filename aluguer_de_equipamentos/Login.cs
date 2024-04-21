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



        private void SignupTitle_Click(object sender, EventArgs e)
        {

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
             email = LoginEmail.Text;
             password = LoginPassword.Text;

            if (!verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand();

            if (email.Equals(""))
            {
                MessageBox.Show("Insira o email");
                return;
            }
            else if (password.Equals(""))
            {
                MessageBox.Show("Insira a  password");
                return;
            }
            else
            {
                cmd.CommandText = "SELECT * FROM Utilizador WHERE email = @email AND pass = @password";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Connection = cn;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show ( "" +  ex);
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
                    MessageBox.Show("Login efetuado com  sucesso!");


                    UserHomePage userHomePage = new UserHomePage(userId);
                    userHomePage.Show();
                    this.Hide();
                }else if (email.StartsWith("admin"))
                {
                    MessageBox.Show("Login efetuado com  sucesso!");
                    AdminHomePage adminHomePage = new AdminHomePage(userId);
                    adminHomePage.Show();
                    this.Hide();
                }
            }


        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        // OUTRAS FUNÇÕES
        public int GetUserId(string email, string password)
        {
            int userId = -1;

            using (SqlConnection cn = getSGBDConnection())
            {
                cn.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT id_utilizador FROM Utilizador WHERE email = @email and pass = @pass", cn))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@pass", password);

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
    }
}
