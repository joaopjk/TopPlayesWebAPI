using Dto;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Repository.Interface;

namespace Service
{
    public class loginService : IloginService
    {
        private IUserRepository _repo;
        public loginService(IUserRepository repo)
        {
            _repo = repo;
        }
        public ActionResult<dynamic> Authenticate(User user)
        {
            var usuario = _repo.Get(user.Username, user.Password);

            // Verifica se o usuário existe
            if (usuario == null)
            {
                //return NotFound(new { message = "Usuário ou senha inválidos" });
            }
                
            // Gera o Token
            var token = TokenService.GenerateToken(user);

            // Oculta a senha
            user.Password = "";

            return token;
        }
    }
}
