using System;

namespace Contacts
{
    [Serializable()]
    public class Utilizador
    {
        private int _idUtilizador;
        private int _cc;
        private string _nome;
        private string _email;
        private string _telefone;
        private string _endereco;
        private DateTime _dataNascimento;

        public int IdUtilizador
        {
            get { return _idUtilizador; }
            set { _idUtilizador = value; }
        }

        public int Cc
        {
            get { return _cc; }
            set { _cc = value; }
        }

        public string Nome
        {
            get { return _nome; }
            set
            {
              
                _nome = value;
            }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Telefone
        {
            get { return _telefone; }
            set { _telefone = value; }
        }

        public string Endereco
        {
            get { return _endereco; }
            set { _endereco = value; }
        }

        public DateTime DataNascimento
        {
            get { return _dataNascimento; }
            set { _dataNascimento = value; }
        }

        public Utilizador() : base()
        {
        }

        public Utilizador(int cc, string nome, string email, DateTime dataNascimento) : base()
        {
            this.Cc = cc;
            this.Nome = nome;
            this.Email = email;
            this.DataNascimento = dataNascimento;
        }
    }
}