using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto;
using Microsoft.AspNetCore.Http;
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
        public ActionResult<dynamic> Authenticate([FromBody]User user)
        {
            return _service.Authenticate(user);
        }
    }
}
