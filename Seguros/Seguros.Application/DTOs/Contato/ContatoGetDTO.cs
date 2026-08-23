using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Application.DTOs.Contato
{
    public class ContatoGetDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int ClienteID { get; set; }
    }
}
