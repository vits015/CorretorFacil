using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Seguros.Application.DTOs.Sinistro
{
    public class SinistroPutDTO
    {
        [Required(ErrorMessage = "O ID é obrigatório.")]
        public int ID { get; set; }

        [Required(ErrorMessage = "O campo Seguro ID é obrigatório.")]
        public int SeguroID { get; set; }

        [Required(ErrorMessage = "O campo Data de Ocorrência é obrigatório.")]
        public DateTime DataOcorrencia { get; set; }

        [Required(ErrorMessage = "O campo Número do Sinistro é obrigatório.")]
        [MaxLength(20, ErrorMessage = "O Número do Sinistro deve ter, no máximo, 20 caracteres.")]
        public string NumeroSinistro { get; set; }
    }
}
