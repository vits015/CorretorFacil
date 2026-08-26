using Microsoft.AspNetCore.Mvc;
using Seguros.Application.DTOs.Pagamento;
using Seguros.Application.Interfaces;

namespace Seguros.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagamentoController : Controller
    {
        private readonly IPagamentoService _pagamentoService;
        public PagamentoController(IPagamentoService pagamentoService)
        {
            _pagamentoService = pagamentoService;
        }

        [HttpPost]
        public async Task<ActionResult> CreatePagamento(PagamentoPostDTO pagamentoPostDTO)
        {
            var createdPagamento = await _pagamentoService.AddAsync(pagamentoPostDTO);
            if (createdPagamento == null)
            {
                return BadRequest("Não foi possível criar o pagamento.");
            }
            return Ok(new { message = "Pagamento criado com sucesso.", createdPagamento });
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePagamento(PagamentoPutDTO pagamentoPutDTO)
        {
            var updatedPagamento = await _pagamentoService.UpdateAsync(pagamentoPutDTO);            
            if (updatedPagamento == null)            
                return BadRequest("Não foi possível atualizar o pagamento.");            
            return Ok(new { message = "Pagamento atualizado com sucesso." });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePagamento(int id)
        {
            var deleted = await _pagamentoService.DeleteAsync(id);
            if (deleted == null)
            {
                return BadRequest("Não foi possível deletar o pagamento.");
            }
            return Ok(new { message = "Pagamento deletado com sucesso." });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetPagamento(int id)
        {
            var pagamento = await _pagamentoService.GetByIdAsync(id);
            if (pagamento == null)
            {
                return NotFound("Pagamento não encontrado.");
            }
            return Ok(pagamento);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllPagamentos()
        {
            var pagamentos = await _pagamentoService.GetAllAsync();
            return Ok(pagamentos);
        }
    }
}
