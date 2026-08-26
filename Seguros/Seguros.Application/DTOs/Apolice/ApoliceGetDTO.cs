using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Application.DTOs.Apolice
{
    public class ApoliceGetDTO
    {        
        public int Id { get; set; }
        public int ClienteID { get; set; }
        public DateOnly VigenciaInicio { get; set; }
        public DateOnly VigenciaFim { get; set; }
        public int SeguradoraID { get; set; }
        public string TipoSeguro { get; set; }
        public string Produto { get; set; }
        public int PagamentoID { get; set; }
        public double PremioLiquido { get; set; }
        public double Comissao { get; set; }
        public string linkApolice { get; set; }
    }
}
