using Dto;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using Service.Interface;
using System;
using System.Threading.Tasks;

namespace Service.Service
{
    public class chatService : ControllerBase, IchatService
    {
        private IChatRepository _repo;
        public chatService(IChatRepository repo)
        {
            _repo = repo;
        }
        public async Task<IActionResult> Add(Chat chat)
        {
            chat.Horario = DateTime.Now;
            _repo.Add(chat);
            if (await _repo.SaveChangesAsync())
            {
                return Ok();
            }
            return BadRequest();
        }

        public async Task<IActionResult> GetAllMsg(int Id, int Id2)
        {
            var results = await _repo.GetAllMsg(Id, Id2);
            return Ok(results);
        }
    }
}
