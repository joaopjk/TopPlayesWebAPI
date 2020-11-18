using Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Perfil> Perfils { get; set; }
        public Context(DbContextOptions<Context> options) : base (options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite(@"Data Source=TopPlayerDB.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Chat>().ToTable("Chat");
            modelBuilder.Entity<Perfil>().ToTable("Perfil");

        }
    }
}
