using Seguros.Application.DTOs.Contato;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Application.DTOs.Seguradora
{
    public class SeguradoraDetailsGetDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<ContatoGetDTO> Contatos { get; set; }
    }
}
