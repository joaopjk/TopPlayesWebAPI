using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using Service.Interface;

namespace TopPlayesWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class chatController : ControllerBase
    {
        private readonly IchatService _service;
        public chatController(IchatService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> PostMessage ([FromBody] Chat chat)
        {
            return await _service.Add(chat);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMessage(int id,int id2)
        {
            return await _service.GetAllMsg(id, id2);
        }
    }
}
