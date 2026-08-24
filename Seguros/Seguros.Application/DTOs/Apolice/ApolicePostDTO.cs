using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Seguros.Application.DTOs.Apolice
{
    public class ApolicePostDTO
    {
        [Required(ErrorMessage = "O Cliente é obrigatório.")]
        public int ClienteID { get; set; }
        [Required(ErrorMessage = "A data de início da vigência é obrigatória.")]
        public DateOnly VigenciaInicio { get; set; }
        [Required(ErrorMessage = "A data de fim da vigência é obrigatória.")]
        public DateOnly VigenciaFim { get; set; }
        [Required(ErrorMessage = "A Seguradora é obrigatória.")]
        public int SeguradoraID { get; set; }
        [Required(ErrorMessage = "O Tipo de Seguro é obrigatório.")]
        public string TipoSeguro { get; set; }
        public string Produto { get; set; }
        [Required(ErrorMessage = "O Pagamento é obrigatório.")]
        public int PagamentoID { get; set; }
        [Required(ErrorMessage = "O Prêmio Líquido é obrigatório.")]
        public double PremioLiquido { get; set; }
        [Required(ErrorMessage = "A Comissão é obrigatória.")]
        public double Comissao { get; set; }        
    }
}
