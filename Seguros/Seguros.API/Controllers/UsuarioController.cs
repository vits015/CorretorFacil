using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Seguros.API.Models;
using Seguros.Application.DTOs.Usuario;
using Seguros.Application.Interfaces;
using Seguros.Domain.Account;
using Seguros.Domain.Entities;

namespace Seguros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IAuthenticate _authenticate;
        public UsuarioController(IUsuarioService usuarioService, IAuthenticate authenticate)
        {
            _usuarioService = usuarioService;
            _authenticate = authenticate;
        }

        //        [HttpPost]
        //        public async Task<ActionResult> CreateUsuario(UsuarioPostDTO usuarioPostDTO)
        //        {
        //            var userExists = await _authenticate.UserExists(usuarioPostDTO.Email);
        //            if (userExists)
        //                return BadRequest("Já existe um usuário com este email.");
        //            var created = await _usuarioService.AddAsync(usuarioPostDTO);
        //            if (created == null)
        //                return BadRequest("Não foi possível criar o usuário.");
        //            var token = _authenticate.GenerateToken(
        //                id: created.Id,
        //                email: created.Email.ToLower(),
        //                role: created.Perfil);
        //            return Ok(new { message = "Usuário "+created.Nome+" criado com sucesso.", token = token });
        //        }

        //        [HttpPut]
        //        public async Task<ActionResult> UpdateUsuario(UsuarioPutDTO usuarioPutDTO)
        //        {
        //            var updated = await _usuarioService.UpdateAsync(usuarioPutDTO);
        //            if (updated == null)
        //                return BadRequest("Não foi possível atualizar o usuário.");
        //            return Ok(new { message = "Usuário atualizado com sucesso." });
        //        }

        //        [HttpDelete("{id}")]
        //        [Authorize]
        //        public async Task<ActionResult> DeleteUsuario(int id)
        //        {
        //            await _usuarioService.DeleteAsync(id);
        //            return Ok(new { message = "Usuário deletado com sucesso." });
        //        }

        //        [HttpGet("{id}")]
        //        public async Task<ActionResult> GetUsuario(int id)
        //        {
        //            var usuario = await _usuarioService.GetByIdAsync(id);
        //            if (usuario == null)
        //                return NotFound("Usuário não encontrado.");
        //            return Ok(usuario);
        //        }

        //        [HttpGet]
        //        [Authorize]
        //        public async Task<ActionResult> GetAllUsuarios()
        //        {
        //            var usuarios = await _usuarioService.GetAllAsync();
        //            return Ok(usuarios);
        //        }
        //        [HttpGet("rota-de-teste")]
        //        [Authorize(Roles ="Administrador")]
        //        public async Task<ActionResult> Teste()
        //        {
        //            return Ok();
        //        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult> GetTokenUsuario(UserLogin userLogin)
        {
            var usuario = await _authenticate.GetUsuarioByEmail(userLogin.Email);
            if (usuario == null)
                return BadRequest("Usuário ou Senha inválidos.");
            var isAuthenticated = await _authenticate.AuthenticateAsync(userLogin.Email, userLogin.Senha);
            if (!isAuthenticated)
                return BadRequest("Usuário ou Senha inválidos.");

            var token = _authenticate.GenerateToken(
                id: usuario.Id,
                email: usuario.Email.ToLower(),
                role: usuario.Perfil);

            return Ok(new { Nome = usuario.Nome, Token = token });
        }

    }
}
