using Microsoft.AspNetCore.Mvc;
using Seguros.Application.DTOs.Sinistro;
using Seguros.Application.Interfaces;

namespace Seguros.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SinistroController : Controller
    {
        private readonly ISinistroService _sinistroService;
        public SinistroController(ISinistroService sinistroService)
        {
            _sinistroService = sinistroService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateSinistro(SinistroPostDTO sinistroPostDTO)
        {
            var createdSinistro = await _sinistroService.AddAsync(sinistroPostDTO);
            if (createdSinistro == null)
            {
                return BadRequest("Não foi possível criar o sinistro.");
            }
            return Ok(new { message = "Sinistro criado com sucesso." });
        }

        [HttpPut]
        public async Task<ActionResult> UpdateSinistro(SinistroPutDTO sinistroPutDTO)
        {
            var updatedSinistro = await _sinistroService.UpdateAsync(sinistroPutDTO);
            if (updatedSinistro == null)
            {
                return BadRequest("Não foi possível atualizar o sinistro.");
            }
            return Ok(new { message = "Sinistro atualizado com sucesso." });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSinistro(int id)
        {
            var deleted = await _sinistroService.DeleteAsync(id);
            if (deleted == null)
            {
                return BadRequest("Não foi possível deletar o sinistro.");
            }
            return Ok(new { message = "Sinistro deletado com sucesso." });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSinistro(int id)
        {
            var sinistro = await _sinistroService.GetByIdAsync(id);
            if (sinistro == null)
            {
                return NotFound("Sinistro não encontrado.");
            }
            return Ok(sinistro);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllSinistros()
        {
            var sinistros = await _sinistroService.GetAllAsync();
            return Ok(sinistros);
        }
    }
}
