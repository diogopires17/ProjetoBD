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
        public Login()
        {
            InitializeComponent();
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
            string email = LoginEmail.Text;
            string password = LoginPassword.Text;

            if (!verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand();

            if (email.Equals(""))
            {
                MessageBox.Show("Please insert your email");
                return;
            }
            else if (password.Equals(""))
            {
                MessageBox.Show("Please insert your password");
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
                    MessageBox.Show("Failed to login");
                    return;
                }
                finally
                {
                    cn.Close();
                }
                MessageBox.Show("Login successful");
            }


        }
    }
}
