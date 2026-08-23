using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Domain.Entities
{
    public class Sinistro
    {
        public int ID { get; set; }
        public int SeguroID { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public string NumeroSinistro { get; set; }
        //public string Arquivo { get; set; }
    }
}
