// C#
using Microsoft.AspNetCore.Mvc;
using Seguros.Application.DTOs.Endereco;
using Seguros.Application.Interfaces;

namespace Seguros.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecoController : Controller
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateEndereco(EnderecoPostDTO enderecoPostDTO)
        {
            var created = await _enderecoService.AddAsync(enderecoPostDTO);
            if (created == null) return BadRequest("Não foi possível criar o endereço.");
            return Ok(new { 
                  message = "Endereço criado com sucesso.",
                  created});
        }

        [HttpPut]
        public async Task<ActionResult> UpdateEndereco(EnderecoPutDTO enderecoPutDTO)
        {
            var updated = await _enderecoService.UpdateAsync(enderecoPutDTO);
            if (updated == null) return BadRequest("Não foi possível atualizar o endereço.");
            return Ok(new { message = "Endereço atualizado com sucesso." });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEndereco(int id)
        {
            var deleted = await _enderecoService.DeleteAsync(id);
            if (deleted == null) return BadRequest("Não foi possível deletar o endereço.");
            return Ok(new { message = "Endereço deletado com sucesso." });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetEndereco(int id)
        {
            var endereco = await _enderecoService.GetByIdAsync(id);
            if (endereco == null) return NotFound("Endereço não encontrado.");
            return Ok(endereco);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllEnderecos()
        {
            var enderecos = await _enderecoService.GetAllAsync();
            return Ok(enderecos);
        }
    }
}