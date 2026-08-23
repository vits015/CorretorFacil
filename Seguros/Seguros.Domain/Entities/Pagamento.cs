using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Domain.Entities
{
    public class Pagamento
    {
        public int Id { get; set; }
        public string TipoPagamento { get; set; }
        public double ValorTotal { get; set; }
        public int QuantidadeParcelas { get; set; }
        public ICollection<Parcela> Parcelas { get; set; }
    }
}
