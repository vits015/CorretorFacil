using Microsoft.AspNetCore.Mvc;
using Seguros.Application.DTOs.Seguradora;
using Seguros.Application.Interfaces;

namespace Seguros.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeguradoraController : Controller
    {
        private readonly ISeguradoraService _seguradoraService;
        public SeguradoraController(ISeguradoraService seguradoraService)
        {
            _seguradoraService = seguradoraService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateSeguradora(SeguradoraPostDTO seguradoraPostDTO)
        {
            var createdSeguradora = await _seguradoraService.AddAsync(seguradoraPostDTO);
            if (createdSeguradora == null)
            {
                return BadRequest("Não foi possível criar a seguradora.");
            }
            return Ok(new { message = "Seguradora criada com sucesso." });
        }

        [HttpPut]
        public async Task<ActionResult> UpdateSeguradora(SeguradoraPutDTO seguradoraPutDTO)
        {
            var updatedSeguradora = await _seguradoraService.UpdateAsync(seguradoraPutDTO);
            if (updatedSeguradora == null)
            {
                return BadRequest("Não foi possível atualizar a seguradora.");
            }
            return Ok(new { message = "Seguradora atualizada com sucesso." });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSeguradora(int id)
        {
            var deleted = await _seguradoraService.DeleteAsync(id);
            if (deleted == null)
            {
                return BadRequest("Não foi possível deletar a seguradora.");
            }
            return Ok(new { message = "Seguradora deletada com sucesso." });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSeguradora(int id)
        {
            var seguradora = await _seguradoraService.GetByIdAsync(id);
            if (seguradora == null)
            {
                return NotFound("Seguradora não encontrada.");
            }
            return Ok(seguradora);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllSeguradoras()
        {
            var seguradoras = await _seguradoraService.GetAllAsync();
            return Ok(seguradoras);
        }
    }
}
