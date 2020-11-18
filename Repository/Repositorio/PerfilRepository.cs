using Dto;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repositorio
{
    public class PerfilRepository : IPerfilRepository
    {
        private Context _context { get; set; }
        public PerfilRepository(Context context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Perfil> GetUserByUsername(string username)
        {
            IQueryable<Perfil> query = _context.Perfils;
            query = query.AsNoTracking()
                .Where(u => u.Username == username);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await (_context.SaveChangesAsync()) > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public int GetMaxId()
        {
            int MaxId = _context.Perfils.Select(p => p.Id).DefaultIfEmpty(0).Max();
            return MaxId;
        }
    }
}
