using Microsoft.AspNetCore.Mvc;
using Seguros.Application.DTOs.Apolice;
using Seguros.Application.Interfaces;

namespace Seguros.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApoliceController : Controller
    {
        private readonly IApoliceService _apoliceService;
        public ApoliceController(IApoliceService apoliceService)
        {
            _apoliceService = apoliceService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateApolice(ApolicePostDTO apolicePostDTO)
        {
            var createdApolice = await _apoliceService.AddAsync(apolicePostDTO);
            if (createdApolice == null)
            {
                return BadRequest("Não foi possível criar a apólice.");
            }
            return Ok(new { message = "Apólice criada com sucesso." });
        }

        [HttpPut]
        public async Task<ActionResult> UpdateApolice(ApolicePutDTO apolicePutDTO)
        {
            var updatedApolice = await _apoliceService.UpdateAsync(apolicePutDTO);
            if (updatedApolice == null)
            {
                return BadRequest("Não foi possível atualizar a apólice.");
            }
            return Ok(new { message = "Apólice atualizada com sucesso." });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteApolice(int id)
        {
            var deleted = await _apoliceService.DeleteAsync(id);
            if (deleted == null)
            {
                return BadRequest("Não foi possível deletar a apólice.");
            }
            return Ok(new { message = "Apólice deletada com sucesso." });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetApolice(int id)
        {
            var apolice = await _apoliceService.GetByIdAsync(id);
            if (apolice == null)
            {
                return NotFound("Apólice não encontrada.");
            }
            return Ok(apolice);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllApolices()
        {
            var apolices = await _apoliceService.GetAllAsync();
            return Ok(apolices);
        }

        [HttpGet("details")]
        public async Task<ActionResult> GetAllApolicesDetails()
        {
            var apolices = await _apoliceService.GetAllDetailsAsync();
            return Ok(apolices);
        }
    }
};