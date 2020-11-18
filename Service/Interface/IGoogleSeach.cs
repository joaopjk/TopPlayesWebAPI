using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IGoogleSeach
    {
        Task<IActionResult> Search(string busca);
      
    }
}
