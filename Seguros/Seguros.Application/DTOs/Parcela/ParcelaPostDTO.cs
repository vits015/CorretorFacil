using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Seguros.Application.DTOs.Parcela
{
    public class ParcelaPostDTO
    {
        [Required(ErrorMessage = "O campo Valor é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O Valor deve ser maior que zero.")]
        public double Valor { get; set; }        
        public DateOnly? DataVencimento { get; set; }

        [Required(ErrorMessage = "O campo Pagamento ID é obrigatório.")]
        public int PagamentoID { get; set; }
    }
}
