using Entity.Contracts;
using Entity.Entities;
using Entity.Entities.Anagram;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class AnagramDbContext : DbContext, IAnagramDbContext
    {
        public DbSet<Anagram> Anagrams { get; set; }

        public AnagramDbContext(DbContextOptions<AnagramDbContext> options)
            : base(options)
        { }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
