using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Seguros.Application.DTOs.Pagamento
{
    public class PagamentoPostDTO
    {
        [Required(ErrorMessage = "O campo Tipo de Pagamento é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O Tipo de Pagamento deve ter, no máximo, 100 caracteres.")]
        public string TipoPagamento { get; set; }

        [Required(ErrorMessage = "O campo Valor Total é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O Valor Total deve ser maior que zero.")]
        public double ValorTotal { get; set; }

        [Required(ErrorMessage = "O campo Quantidade de Parcelas é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "A Quantidade de Parcelas deve ser maior que zero.")]
        public int QuantidadeParcelas { get; set; }
    }
}
