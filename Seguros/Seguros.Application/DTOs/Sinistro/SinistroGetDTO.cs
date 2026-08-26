using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Application.DTOs.Sinistro
{
    public class SinistroGetDTO
    {
        public int ID { get; set; }
        public int ApoliceId { get; set; }
        public DateOnly DataOcorrencia { get; set; }
        public string NumeroSinistro { get; set; }
    }
}
