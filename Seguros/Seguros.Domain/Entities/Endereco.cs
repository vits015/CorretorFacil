using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Domain.Entities
{
    public class Endereco
    {
        public int Id { get; set; }        
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
        public string Logradouro { get; set; }
        public string CEP { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Complemento { get; set; }
        public string Nome { get; set; }

        public static implicit operator List<object>(Endereco v)
        {
            throw new NotImplementedException();
        }
    }
}
