using Seguros.Application.DTOs.Pagamento;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seguros.Application.Interfaces
{
    public interface IPagamentoService
    {
        Task<PagamentoGetDTO> GetByIdAsync(int id);
        Task<List<PagamentoGetDTO>> GetAllAsync();
        Task<PagamentoGetDTO> AddAsync(PagamentoPostDTO pagamentoPostDTO);
        Task<PagamentoGetDTO> UpdateAsync(PagamentoPutDTO pagamentoPutDTO);
        Task<PagamentoGetDTO> DeleteAsync(int id);
    }
}
