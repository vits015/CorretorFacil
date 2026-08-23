using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Application.DTOs.Pagamento
{
    public class PagamentoGetDTO
    {
        public int Id { get; set; }
        public string TipoPagamento { get; set; }
        public double ValorTotal { get; set; }
        public int QuantidadeParcelas { get; set; }
    }
}
