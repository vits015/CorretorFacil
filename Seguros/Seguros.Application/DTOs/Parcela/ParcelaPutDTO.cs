using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Seguros.Application.DTOs.Parcela
{
    public class ParcelaPutDTO
    {
        [Required(ErrorMessage = "O ID é obrigatório.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Valor é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O Valor deve ser maior que zero.")]
        public double Valor { get; set; }
        
        public DateOnly? DataVencimento { get; set; }
    }
}
