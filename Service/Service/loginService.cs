using Dto;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Repository.Interface;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    public class loginService : ControllerBase,IloginService
    {
        private IUserRepository _repo;
        public loginService(IUserRepository repo)
        {
            _repo = repo;
        }
        public async Task<IActionResult> Authenticate(User user)
        {
            var usuario =  await _repo.Get(user.Username, user.Password);

            // Verifica se o usuário existe
            if (usuario == null)
            {
                return BadRequest();
            }

            // Gera o Token
            var token = TokenService.GenerateToken(user);
            return Ok(token) ;
        }

        public async Task<IActionResult> Create(User user)
        {
            var usuario = await _repo.Get(user.Username, user.Password);
            if (usuario == null)
            {
                _repo.Add(user);
                if (await _repo.SaveChangesAsync())
                {
                    user.Password = "";
                    return Created("", user);
                }
            }     
            return BadRequest();
        }
    }
}
