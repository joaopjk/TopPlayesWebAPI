using Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder
                . (@"Data Source=CustomerDB.db;");
    }
}
