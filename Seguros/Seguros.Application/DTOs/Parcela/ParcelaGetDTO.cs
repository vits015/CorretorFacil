using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Application.DTOs.Parcela
{
    public class ParcelaGetDTO
    {
        public int Id { get; set; }
        public double Valor { get; set; }
        public DateOnly? DataVencimento { get; set; }
        public int PagamentoID { get; set; }
    }
}
