using Dto;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositorio
{
    public class ChatRepository : IChatRepository
    {
        public Context _context { get; set; }
        public ChatRepository(Context context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public async Task<Chat[]> GetAllMsg(long IdUsuario, long IdRemetente)
        {
            IQueryable<Chat> query = _context.Chats;
            query = query.AsNoTracking()
                .Where(u => u.IdUsuario == IdUsuario)
                .Where(p => p.IdRemetente == IdRemetente)
                .OrderBy(o => o.Horario);
            return await query.ToArrayAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await(_context.SaveChangesAsync()) > 0;
        }
    }
}
