using Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IloginService
    {
        Task<IActionResult> Authenticate(User user);
        Task<IActionResult> Create(User user);
        Task<IActionResult> Update(User user);
        Task<IActionResult> Delete(User user);
    }
}
