using Seguros.Application.DTOs.Cliente;
using Seguros.Application.DTOs.Pagamento;
using Seguros.Application.DTOs.Seguradora;
using Seguros.Application.DTOs.Sinistro;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Application.DTOs.Apolice
{
    public class ApoliceDetailsGetDTO
    {
        public int Id { get; set; }
        public ClienteGetDTO Cliente { get; set; }
        public DateOnly VigenciaInicio { get; set; }
        public DateOnly VigenciaFim { get; set; }
        public SeguradoraGetDTO Seguradora { get; set; }
        public string TipoSeguro { get; set; }        
        public string Produto { get; set; }
        public PagamentoGetDTO Pagamento { get; set; }
        public double PremioLiquido { get; set; }
        public double Comissao { get; set; }
        public string linkApolice { get; set; }
        public List<SinistroGetDTO> Sinistros { get; set; }
    }
}
