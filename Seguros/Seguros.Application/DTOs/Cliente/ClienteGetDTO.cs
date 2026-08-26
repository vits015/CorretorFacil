using Seguros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Application.DTOs.Cliente
{
    public class ClienteGetDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public string EstadoCivil { get; set; }
        public string Sexo { get; set; }
        public string Profissao { get; set; }
    }
}
