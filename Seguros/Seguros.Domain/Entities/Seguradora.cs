using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Domain.Entities
{
    public class Seguradora
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public ICollection<Contato> Contatos { get; set; }
    }
}
