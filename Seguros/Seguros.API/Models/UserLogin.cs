using System.ComponentModel.DataAnnotations;

namespace Seguros.API.Models
{
    public class UserLogin
    {
        [Required(ErrorMessage = "O E-mail é obrigatório.")]
        [MaxLength(250, ErrorMessage = "E-mail deve ter, no mínimo, 250 caracteres.")]
        [EmailAddress(ErrorMessage = "O E-mail é inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A Senha é obrigatória.")]
        public string Senha { get; set; }
    }
}
