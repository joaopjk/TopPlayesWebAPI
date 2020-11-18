using Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IchatService
    {
        Task<IActionResult> Add(Chat chat);
        Task<IActionResult> GetAllMsg(int Id,int Id2);
    }
}
