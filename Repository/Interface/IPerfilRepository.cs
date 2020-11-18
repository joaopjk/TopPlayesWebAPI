using Dto;
using System.Threading.Tasks;

namespace Repository.Repositorio
{
    public interface IPerfilRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();
        Task<Perfil> GetUserByUsername(string username);
        int GetMaxId();
    }
}
