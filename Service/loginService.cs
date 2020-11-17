using Dto;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace Service
{
    public class loginService : IloginService
    {
        public ActionResult<dynamic> Authenticate(User user)
        {
            var usuario = UserRepository.Get(user.Username, user.Password);

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
            //// Retorna os dados
            //return new
            //{
            //    usuario = user,
            //    token = token
            //};

        }
    }
}
