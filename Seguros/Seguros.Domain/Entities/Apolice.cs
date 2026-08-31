using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Domain.Entities
{
    public class Apolice
    {
        public int Id { get; set; }
        public int ClienteID { get; set; }
        public DateOnly VigenciaInicio { get; set; }
        public DateOnly VigenciaFim { get; set; }
        public int SeguradoraID { get; set; }
        public string TipoSeguro { get; set; } // (novo, renovação,endosso)        
        public string Produto { get; set; } //(auto, residencial, empresarial, vida)
        public int PagamentoID { get; set; }
        public double PremioLiquido { get; set; }
        public double Comissao { get; set; }
        public string? LinkArquivos { get; set; }
        public bool Excluido { get; set; } = false;        
        public List<Sinistro> Sinistros { get; set; } = new();
        public List<ArquivoApolice> Arquivos { get; set; } = new();
    }
}
