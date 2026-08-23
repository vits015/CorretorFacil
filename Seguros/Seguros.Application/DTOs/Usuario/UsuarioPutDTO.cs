using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Application.DTOs.Usuario
{
    public class UsuarioPutDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }        
        public string Senha { get; set; }
        public string Perfil { get; set; }
        public string Email { get; set; }
    }
}
