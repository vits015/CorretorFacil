using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Seguros.Domain.Entities
{
    public class Parcela
    {
        public int Id { get; set; }
        public double Valor { get; set; }
        public DateOnly? DataVencimento { get; set; }
        public int PagamentoID { get; set; }
        //public Blob Arquivo { get; set; }
    }
}
