using Dto;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IChatRepository
    {
        void Add<T>(T entity) where T : class;
        Task<Chat[]> GetAllMsg(long IdUsuario, long IdRemetente);
        Task<bool> SaveChangesAsync();
    }
}
