using Seguros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Seguros.Application.DTOs.Cliente
{
    public class ClientePostDTO
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [MaxLength(200, ErrorMessage = "O nome deve ter, no máximo, 200 caracteres.")]
        public string Nome { get; set; }        
        [MaxLength(11, ErrorMessage = "O CPF deve ter, no máximo, 11 caracteres.")]
        public string CPF { get; set; }
        [MaxLength(14, ErrorMessage = "O CNPJ deve ter, no máximo, 14 caracteres.")]
        public string CNPJ { get; set; }
        public string EstadoCivil { get; set; }
        public string Sexo { get; set; }
        public string Profissao { get; set; }
    }
}
