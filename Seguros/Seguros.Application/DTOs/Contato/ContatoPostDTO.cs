using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Seguros.Application.DTOs.Contato
{
    public class ContatoPostDTO
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O Nome deve ter, no máximo, 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        [MaxLength(100, ErrorMessage = "A Descrição deve ter, no máximo, 100 caracteres.")]
        public string Descricao { get; set; }        
        public int? ClienteId { get; set; }
        public int? SeguradoraId { get; set; }
    }
}
