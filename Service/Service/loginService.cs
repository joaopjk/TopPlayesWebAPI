using Dto;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Repository.Interface;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Service
{
    public class loginService : ControllerBase, IloginService
    {
        private IUserRepository _repo;
        public loginService(IUserRepository repo)
        {
            _repo = repo;
        }
        public async Task<IActionResult> Authenticate(User user)
        {
            try
            {
                var usuario = await _repo.Get(user.Username, user.Password);

                // Verifica se o usuário existe
                if (usuario == null)
                {
                    return BadRequest();
                }

                // Gera o Token
                var token = TokenService.GenerateToken(user);
                return Ok(token);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        public async Task<IActionResult> Create(User user)
        {
            try
            {
                var usuario = await _repo.Get(user.Username, user.Password);
                if (usuario == null)
                {
                    user.Id = _repo.GetMaxId();
                    _repo.Add(user);
                    if (await _repo.SaveChangesAsync())
                    {
                        user.Password = "";
                        return Created("", user);
                    }
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        public async Task<IActionResult> Delete(User user)
        {
            try
            {
                var usuario = await _repo.GetUserByEmail(user.Email);
                if (usuario != null)
                {
                    _repo.Delete(User);
                    if (await _repo.SaveChangesAsync())
                    {
                        user.Password = "";
                        return Created($"/api/[controler]/User{user.Email}", user);
                    }
                }
                return NotFound($"Não existe usuário com o email{user.Email}");
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        public async Task<IActionResult> Update(User user)
        {
            try
            {
                var usuario = await _repo.GetUserByEmail(user.Email);
                if (usuario != null)
                {
                    _repo.Update(User);
                    if (await _repo.SaveChangesAsync())
                    {
                        user.Password = "";
                        return Created($"/api/[controler]/User{user.Email}",user);
                    }
                }
                return NotFound($"Não existe usuário com o email{user.Email}");
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}
