using Mfm.Jane.Data.Contracts;
using Mfm.Jane.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mfm.Jane.Data.Services
{
    public class JaneTestDbContext : DbContext, IJaneTestDbContext
    {
        public JaneTestDbContext(DbContextOptions<JaneTestDbContext> options) : base(options){}

        public void EnsureCreated()
        {
            Database.EnsureCreated();
        }

        public DbSet<TestEntity> TestModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestEntity>().ToTable("TestModel");
        }
    }
}

