using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public string EstadoCivil { get; set; }
        public string Sexo { get; set; }
        public string Profissao { get; set; }
        public bool Excluido { get; set; } = false;
        public ICollection<Endereco> Enderecos { get; set; }    
        public ICollection<Contato> Contatos { get; set; }
        public ICollection<Apolice> Apolices { get; set; }
    }
}
