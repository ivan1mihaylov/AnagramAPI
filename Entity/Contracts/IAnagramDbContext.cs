using Entity.Entities.Anagram;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Contracts
{
    public interface IAnagramDbContext : IDisposable
    {

        public DbSet<Word> Words { get; set; }
        public DbSet<CheckResult> CheckResults { get; set; }
        public DbSet<WordCheckResult> WordCheckResults { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync();

    }
}
