using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Seguros.Application.DTOs.Endereco
{
    public class EnderecoPostDTO
    {        
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "O campo CEP é obrigatório.")]
        [MaxLength(8, ErrorMessage = "O CEP deve ter, no máximo, 8 caracteres.")]
        public string CEP { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Complemento { get; set; }
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo Cliente ID é obrigatório.")]
        public int ClienteId { get; set; }
    }
}
