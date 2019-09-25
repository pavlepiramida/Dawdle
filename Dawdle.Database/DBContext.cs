using Dawdle.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Dawdle.Database
{
    public class DBContex : DbContext, IDisposable
    {
        public DbSet<User> Users { get; set; }
        public DBContex(DbContextOptions<DBContex> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(p => p.Id).IsRequired();
            modelBuilder.Entity<User>().HasKey(hk => hk.Id);
        }

        public override void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
