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
    public partial class LoginAdmin : Form
    {
        public String email;
        public String password;

        public LoginAdmin()
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

        private void voltar_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
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
                cmd.CommandText = "SELECT * FROM Administrador WHERE email = @email AND pass = @password";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Connection = cn;
                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int userId = GetUserId(email, password);
                            if (userId == -1)
                            {
                                MessageBox.Show("Login falhado");
                                return;
                            }
                            else if (email.StartsWith("admin"))
                            {
                                AdminHomePage adminHomePage = new AdminHomePage(userId);
                                adminHomePage.Show();
                                this.Hide();
                                MessageBox.Show("Login efetuado com  sucesso!");
                            }
                            else
                            {
                                MessageBox.Show("Ocorreu um erro!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Credenciais erradas");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                    return;
                }
            }
        }


        // OUTRAS FUNÇÕES
        public int GetUserId(string email, string password)
        {
            int userId = -1;

            using (SqlConnection cn = getSGBDConnection())
            {
                cn.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT id_administrador FROM Administrador WHERE email = @email and pass = @pass", cn))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@pass", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userId = reader.GetInt32(reader.GetOrdinal("id_administrador"));
                        }
                        else
                        {
                            MessageBox.Show("Nenhum admin encontrado com as credenciais fornecidas");
                        }
                    }
                }
            }

            return userId;
        }

        private void LoginAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
