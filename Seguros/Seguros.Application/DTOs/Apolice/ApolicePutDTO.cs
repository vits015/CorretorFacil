using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Application.DTOs.Apolice
{
    public class ApolicePutDTO
    {
        public int Id { get; set; }
        public int ClienteID { get; set; }
        public DateTime VigenciaInicio { get; set; }
        public DateTime VigenciaFim { get; set; }
        public int SeguradoraID { get; set; }
        public int TipoSeguroID { get; set; }
        public int SituacaoID { get; set; }
        public int PagamentoID { get; set; }
        public double PremioLiquido { get; set; }
        public double Comissao { get; set; }        
    }
}
