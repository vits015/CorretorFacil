using Seguros.Application.DTOs.Endereco;
using Seguros.Application.DTOs.Usuario;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioGetDTO> GetByIdAsync(int id);
        Task<List<UsuarioGetDTO>> GetAllAsync();
        Task<UsuarioGetDTO> AddAsync(UsuarioPostDTO usuarioPostDTO);
        Task<UsuarioGetDTO> UpdateAsync(UsuarioPutDTO usuarioPutDTO);
        Task DeleteAsync(int id);
    }
}
