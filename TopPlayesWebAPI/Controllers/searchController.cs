using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace TopPlayesWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class searchController : ControllerBase
    {
        private readonly IGoogleSeach _service;
        public searchController(IGoogleSeach service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Busca(string busca)
        {
            return await _service.Search(busca);
        }
    }
}
