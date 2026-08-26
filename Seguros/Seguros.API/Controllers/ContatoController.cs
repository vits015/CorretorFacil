using Microsoft.AspNetCore.Mvc;
using Seguros.Application.DTOs.Contato;
using Seguros.Application.Interfaces;

namespace Seguros.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContatoController : Controller
    {
        private readonly IContatoService _contatoService;
        public ContatoController(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateContato(ContatoPostDTO contatoPostDTO)
        {
            var createdContato = await _contatoService.AddAsync(contatoPostDTO);
            if (createdContato == null)
            {
                return BadRequest("Não foi possível criar o contato.");
            }
            return Ok(new { 
                message = "Contato criado com sucesso.",
                createdContato
            });
        }

        [HttpPut]
        public async Task<ActionResult> UpdateContato(ContatoPutDTO contatoPutDTO)
        {
            var updatedContato = await _contatoService.UpdateAsync(contatoPutDTO);
            if (updatedContato == null)
            {
                return BadRequest("Não foi possível atualizar o contato.");
            }
            return Ok(new { message = "Contato atualizado com sucesso." });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContato(int id)
        {
            var deleted = await _contatoService.DeleteAsync(id);
            if (deleted == null)
            {
                return BadRequest("Não foi possível deletar o contato.");
            }
            return Ok(new { message = "Contato deletado com sucesso." });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetContato(int id)
        {
            var contato = await _contatoService.GetByIdAsync(id);
            if (contato == null)
            {
                return NotFound("Contato não encontrado.");
            }
            return Ok(contato);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllContatos()
        {
            var contatos = await _contatoService.GetAllAsync();
            return Ok(contatos);
        }
    }
}
