using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Seguros.Application.DTOs.Seguradora
{
    public class SeguradoraPutDTO
    {
        [Required(ErrorMessage = "O ID é obrigatório.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O Nome deve ter, no máximo, 100 caracteres.")]
        public string Nome { get; set; }
    }
}
