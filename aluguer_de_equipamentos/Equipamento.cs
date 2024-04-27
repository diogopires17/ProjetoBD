using System;

namespace Equipamentos
{
    [Serializable()]
    public class Equipamento
    {
        private int _idEquipamento;
        private string _nome;
        private string _categoria;
        private bool _disponivel;
        private int _idLocalizacao;
        private int _idFornecedor;
        private int _idAdministrador;
        private DateTime _revisao;
        private int preco;
        private int _idTecnico;

        public int IdEquipamento
        {
            get { return _idEquipamento; }
            set { _idEquipamento = value; }
        }

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public string Categoria
        {
            get { return _categoria; }
            set { _categoria = value; }
        }

        public bool Disponivel
        {
            get { return _disponivel; }
            set { _disponivel = value; }
        }

        public int IdLocalizacao
        {
            get { return _idLocalizacao; }
            set { _idLocalizacao = value; }
        }

        public int IdFornecedor
        {
            get { return _idFornecedor; }
            set { _idFornecedor = value; }
        }

        public int IdAdministrador
        {
            get { return _idAdministrador; }
            set { _idAdministrador = value; }
        }

        public DateTime Revisao
        {
            get { return _revisao; }
            set { _revisao = value; }
        }
        public int Preco
        {
            get { return preco; }
            set { preco = value; }
        }
        public int IdTecnico
        {
            get { return _idTecnico; }
            set { _idTecnico = value; }
        }

        public Equipamento(string nome = null, string categoria = null, bool disponivel = true, int idLocalizacao = 0, int idFornecedor = 0, int idAdministrador = 0, DateTime revisao = default(DateTime) , string cidade = null, int preco = 0, int idTecnico = 0 )
        {
            Nome = nome;
            Categoria = categoria;
            Disponivel = disponivel;
            IdLocalizacao = idLocalizacao;
            IdFornecedor = idFornecedor;
            IdAdministrador = idAdministrador;
            Revisao = revisao;
            Preco = preco;
            IdTecnico = idTecnico;
        }


    }
}
