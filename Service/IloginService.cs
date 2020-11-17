using Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public interface IloginService
    {
        ActionResult<dynamic> Authenticate(User user);
    }
}
