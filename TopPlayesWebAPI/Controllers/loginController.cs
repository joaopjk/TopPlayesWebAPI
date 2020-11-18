using System.Threading.Tasks;
using Dto;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace TopPlayesWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class loginController : ControllerBase
    {
        private readonly IloginService _service;
        public loginController(IloginService Service)
        {
            this._service = Service; 
        }
        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody]User user)
        {
            return await _service.Authenticate(user);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            return await _service.Create(user);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] User user)
        {
            return await _service.Delete(user);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] User user)
        {
            return await _service.Update(user);
        }
    }
}
