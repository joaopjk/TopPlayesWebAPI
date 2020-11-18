using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IGoogleSeach
    {
        Task<IActionResult> Search(string busca);
      
    }
}
