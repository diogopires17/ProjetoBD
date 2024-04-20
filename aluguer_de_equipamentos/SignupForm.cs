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
    public partial class SignUpButton : Form
    {
        private int equipamentoSelecionado = 0;

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
                
                while (reader.Read())
                {
                    Equipamento E = new Equipamento();
                    E.Nome = (string)reader["nome"];
                    E.Disponivel = (bool)reader["disponivel"];
                    E.Categoria = (string)reader["categoria"];
                    E.IdLocalizacao = (int)reader["id_localizacao"];
                    E.IdEquipamento = (int)reader["id_equipamento"];
                    string cidade = (string)reader["cidade"];
                    userSelecionado = E.IdEquipamento;
                }
                    UserHomePage userHomePage = new UserHomePage();

            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void SignUpNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void SignUpNome_TextChanged_1(object sender, EventArgs e)
        {

        }
    }

}
