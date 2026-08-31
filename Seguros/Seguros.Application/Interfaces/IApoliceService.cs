using Seguros.Application.DTOs.Apolice;
using Seguros.Application.DTOs.Cliente;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Application.Interfaces
{
    public interface IApoliceService
    {
        Task<ApoliceGetDTO> GetByIdAsync(int id);
        Task<List<ApoliceGetDTO>> GetAllAsync();
        Task<List<ApoliceDetailsGetDTO>> GetAllDetailsAsync();
        Task<ApoliceDetailsGetDTO> GetDetailsByIdAsync(int id);
        Task<ApoliceGetDTO> AddAsync(ApolicePostDTO apolicePostDTO);
        Task<ApoliceGetDTO> UpdateAsync(ApolicePutDTO apolicePutDTO);
        Task<ApoliceGetDTO> AtualizarCaminhoArquivoAsync(int id, string caminhoArquivo);
        Task<ApoliceGetDTO> DeleteAsync(int id);
    }
}
