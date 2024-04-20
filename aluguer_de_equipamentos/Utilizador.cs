using System;

namespace Contacts
{
    [Serializable()]
    public class Equipamento
    {
        public int IdEquipamento { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public bool Disponivel { get; set; }
        public int IdLocalizacao { get; set; }
        public int IdFornecedor { get; set; }
        public int IdAdministrador { get; set; }
        public DateTime Revisao { get; set; }

        public Equipamento()
        {
        }

        public Equipamento(string nome, string categoria, bool disponivel, int idLocalizacao, int idFornecedor, int idAdministrador, DateTime revisao)
        {
            Nome = nome;
            Categoria = categoria;
            Disponivel = disponivel;
            IdLocalizacao = idLocalizacao;
            IdFornecedor = idFornecedor;
            IdAdministrador = idAdministrador;
            Revisao = revisao;
        }

        public override string ToString()
        {
            return Nome; 
        }
    }
}
