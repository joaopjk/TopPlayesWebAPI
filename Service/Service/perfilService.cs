using Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Repositorio;
using Service.Interface;
using System;
using System.Threading.Tasks;

namespace Service.Service
{
    public class perfilService : ControllerBase, IperfilService
    {
        private readonly IPerfilRepository _repo;
        public perfilService(IPerfilRepository repo)
        {
            _repo = repo;
        }
        public async Task<IActionResult> Create(Perfil perfil)
        {
            try
            {
                perfil.Id =  _repo.GetMaxId();
                _repo.Add(perfil);
                if (await _repo.SaveChangesAsync())
                {
                    return Created("", perfil);
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        public async Task<IActionResult> GetPerfilByUsername(string username)
        {
            try
            {
                var perfil = await _repo.GetUserByUsername(username);
                if (perfil == null)
                {
                    return NotFound();
                }
                return Ok(perfil);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        public async Task<IActionResult> Update(Perfil perfil)
        {
            try
            {
                var perfilaux = await _repo.GetUserByUsername(perfil.Username);
                if (perfilaux != null)
                {
                    _repo.Update(perfil);
                    if (await _repo.SaveChangesAsync())
                    {
                        return Created("", perfil);
                    }
                }
                return NotFound();
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}
