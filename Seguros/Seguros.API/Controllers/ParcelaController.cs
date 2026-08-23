using Microsoft.AspNetCore.Mvc;
using Seguros.Application.DTOs.Parcela;
using Seguros.Application.Interfaces;

namespace Seguros.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParcelaController : Controller
    {
        private readonly IParcelaService _parcelaService;
        public ParcelaController(IParcelaService parcelaService)
        {
            _parcelaService = parcelaService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateParcela(ParcelaPostDTO parcelaPostDTO)
        {
            var createdParcela = await _parcelaService.AddAsync(parcelaPostDTO);
            if (createdParcela == null)
            {
                return BadRequest("Não foi possível criar a parcela.");
            }
            return Ok(new { message = "Parcela criada com sucesso." });
        }

        [HttpPut]
        public async Task<ActionResult> UpdateParcela(ParcelaPutDTO parcelaPutDTO)
        {
            var updatedParcela = await _parcelaService.UpdateAsync(parcelaPutDTO);
            if (updatedParcela == null)
            {
                return BadRequest("Não foi possível atualizar a parcela.");
            }
            return Ok(new { message = "Parcela atualizada com sucesso." });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteParcela(int id)
        {
            var deleted = await _parcelaService.DeleteAsync(id);
            if (deleted == null)
            {
                return BadRequest("Não foi possível deletar a parcela.");
            }
            return Ok(new { message = "Parcela deletada com sucesso." });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetParcela(int id)
        {
            var parcela = await _parcelaService.GetByIdAsync(id);
            if (parcela == null)
            {
                return NotFound("Parcela não encontrada.");
            }
            return Ok(parcela);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllParcelas()
        {
            var parcelas = await _parcelaService.GetAllAsync();
            return Ok(parcelas);
        }
    }
}
