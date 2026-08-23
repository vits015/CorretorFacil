using Seguros.Application.DTOs.Cliente;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Application.DTOs.Endereco
{
    public class EnderecoGetDTO
    {
        public int Id { get; set; }                
        public string Logradouro { get; set; }
        public string CEP { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Complemento { get; set; }
        public string Nome { get; set; }
        public int ClienteID { get; set; }
    }
}
