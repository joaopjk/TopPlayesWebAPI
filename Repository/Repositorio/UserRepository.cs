using Dto;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
   public  class UserRepository : IUserRepository
    {
        public Context _context { get; set; }
        public UserRepository(Context context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public async Task<User> Get(string username, string password)
        {
            IQueryable<User> query = _context.Users;
            query = query.AsNoTracking()
                .Where(u => u.Username == username)
                .Where(p => p.Password == password);
            return await query.FirstOrDefaultAsync();
          
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await(_context.SaveChangesAsync()) > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public int GetMaxId()
        {
             int MaxId = _context.Users.Select(p => p.Id).DefaultIfEmpty(0).Max();
            return MaxId;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            IQueryable<User> query = _context.Users;
            query = query.AsNoTracking()
                .Where(u => u.Email == email);
            return await query.FirstOrDefaultAsync();
        }
    }
}
