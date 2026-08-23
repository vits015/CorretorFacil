using Seguros.Application.DTOs.Usuario;
using Seguros.Application.Interfaces;
using Seguros.Domain.Entities;
using Seguros.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Seguros.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<UsuarioGetDTO> AddAsync(UsuarioPostDTO usuarioPostDTO)
        {
            using var hmac = new HMACSHA512();
            byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(usuarioPostDTO.Senha));
            byte[] passwordSalt = hmac.Key;

            var usuario = new Usuario
            {
                Nome = usuarioPostDTO.Nome,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Perfil = usuarioPostDTO.Perfil,
                Email = usuarioPostDTO.Email
            };
            var created = await _usuarioRepository.AddAsync(usuario);
            return new UsuarioGetDTO
            {
                Id = created.Id,
                Nome = created.Nome,
                Perfil = created.Perfil,
                Email = created.Email
            };
        }

        public async Task DeleteAsync(int id)
        {
            await _usuarioRepository.DeleteAsync(id);
        }

        public async Task<List<UsuarioGetDTO>> GetAllAsync()
        {
            var usuarios = await _usuarioRepository.GetAllAsync();
            var result = new List<UsuarioGetDTO>();
            foreach (var u in usuarios)
            {
                if (!u.Excluido)
                    result.Add(new UsuarioGetDTO { Id = u.Id, Nome = u.Nome, Perfil = u.Perfil, Email = u.Email });
            }
            return result;
        }

        public async Task<UsuarioGetDTO> GetByIdAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null || usuario.Excluido)
                return null;            
            return new UsuarioGetDTO { Id = usuario.Id, Nome = usuario.Nome, Perfil = usuario.Perfil };
        }

        public async Task<UsuarioGetDTO> UpdateAsync(UsuarioPutDTO usuarioPutDTO)
        {
            using var hmac = new HMACSHA3_512();
            byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(usuarioPutDTO.Senha));
            byte[] passwordSalt = hmac.Key;

            var usuario = new Usuario
            {
                Id = usuarioPutDTO.Id,
                Nome = usuarioPutDTO.Nome,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Perfil = usuarioPutDTO.Perfil,
                Email = usuarioPutDTO.Email
            };
            var updated = await _usuarioRepository.UpdateAsync(usuario);
            if (updated == null)
                return null;
            return new UsuarioGetDTO { Id = updated.Id, Nome = updated.Nome, Perfil = updated.Perfil, Email = updated.Email };
        }
    }
}

