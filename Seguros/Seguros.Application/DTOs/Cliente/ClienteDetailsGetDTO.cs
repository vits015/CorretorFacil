using Seguros.Application.DTOs.Contato;
using Seguros.Application.DTOs.Endereco;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Application.DTOs.Cliente
{
    public class ClienteDetailsGetDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public string EstadoCivil { get; set; }
        public string Sexo { get; set; }
        public string Profissao { get; set; }
        public List<EnderecoGetDTO> Enderecos { get; set; }
        public List<ContatoGetDTO> Contatos { get; set; }
    }
}
