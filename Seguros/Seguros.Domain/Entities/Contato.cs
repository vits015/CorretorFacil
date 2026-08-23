using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Domain.Entities
{
    public class Contato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int ClienteID { get; set; }
        public int SeguradoraID { get; set; }
        public string Descricao { get; set; }

    }
}
