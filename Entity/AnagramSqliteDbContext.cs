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
    /// <summary>
    /// Main DbContext 
    /// </summary>
    public class AnagramSqliteDbContext : DbContext, IAnagramDbContext
    {
        public DbSet<Word> Words { get; set; }
        public DbSet<CheckResult> CheckResults { get; set; }
        public DbSet<WordCheckResult> WordCheckResults { get; set; }

        public AnagramSqliteDbContext(DbContextOptions<AnagramSqliteDbContext> options)
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

            modelBuilder.Entity<WordCheckResult>()
                .HasKey(wr => new { wr.CheckResultId, wr.WordId });
            modelBuilder.Entity<WordCheckResult>()
                .HasOne(wr => wr.Word)
                .WithMany(w => w.WordCheckResults)
                .HasForeignKey(wr => wr.WordId);
            modelBuilder.Entity<WordCheckResult>()
                .HasOne(wr => wr.CheckResult)
                .WithMany(r => r.WordCheckResults)
                .HasForeignKey(wr => wr.CheckResultId);

            base.OnModelCreating(modelBuilder);

        }
    }
}
