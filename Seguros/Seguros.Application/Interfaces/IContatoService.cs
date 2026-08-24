using Seguros.Application.DTOs.Contato;
using Seguros.Application.DTOs.Endereco;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Application.Interfaces
{
    public interface IContatoService
    {
        Task<ContatoGetDTO> GetByIdAsync(int? id);
        Task<List<ContatoGetDTO>> GetAllAsync();
        Task<ContatoGetDTO> AddAsync(ContatoPostDTO contatoPostDTO);
        Task<ContatoGetDTO> UpdateAsync(ContatoPutDTO contatoPutDTO);
        Task<ContatoGetDTO> DeleteAsync(int id);
    }
}
