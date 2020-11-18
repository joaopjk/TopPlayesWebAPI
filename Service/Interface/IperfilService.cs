using Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IperfilService
    {
        Task<IActionResult> GetPerfilByUsername(string username);
        Task<IActionResult> Create(Perfil perfil);
        Task<IActionResult> Update(Perfil perfil);
    }
}
