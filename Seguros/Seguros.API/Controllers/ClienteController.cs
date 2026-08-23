using Microsoft.AspNetCore.Mvc;
using Seguros.Application.DTOs.Cliente;
using Seguros.Application.Interfaces;

namespace Seguros.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateCliente(ClientePostDTO clientePostDTO)
        {
            var createdCliente = await _clienteService.AddAsync(clientePostDTO);
            if (createdCliente == null)
            {
                return BadRequest("Não foi possível criar o cliente.");
            }
            return Ok(new { message = "Cliente criado com sucesso." });
        }
        [HttpPut]
        public async Task<ActionResult> UpdateCliente(ClientePutDTO clientePutDTO)
        {
            var updatedCliente = await _clienteService.UpdateAsync(clientePutDTO);
            if (updatedCliente == null)
            {
                return BadRequest("Não foi possível atualizar o cliente.");
            }
            return Ok(new { message = "Cliente atualizado com sucesso." });
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCliente(int id)
        {
            var deleted = await _clienteService.DeleteAsync(id);
            if (deleted==null)
            {
                return BadRequest("Não foi possível deletar o cliente.");
            }
            return Ok(new { message = "Cliente deletado com sucesso." });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCliente(int id)
        {
            var cliente = await _clienteService.GetByIdAsync(id);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado.");
            }
            return Ok(cliente);
        }
        
        [HttpGet]
        public async Task<ActionResult> GetAllClientes()
        {
            var clientes = await _clienteService.GetAllAsync();
            return Ok(clientes);
        }   
        [HttpGet("details")]
        public async Task<ActionResult> GetAllClientesDetails()
        {
            var clientes = await _clienteService.GetAllDetailsAsync();
            return Ok(clientes);
        }
    }
}
