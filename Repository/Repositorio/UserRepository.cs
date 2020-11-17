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
            //var users = new List<User>();
            //users.Add(new User { Id = 1, Username = "batman", Password = "batman", Role = "manager" });
            //users.Add(new User { Id = 2, Username = "robin", Password = "robin", Role = "employee" });
            //return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
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
    }
}
