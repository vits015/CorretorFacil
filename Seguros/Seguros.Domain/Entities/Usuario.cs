using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Seguros.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool Excluido { get; set; } = false;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Perfil { get; set; }
    }
}
