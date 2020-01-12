using System;
using System.Linq;
using System.Threading.Tasks;
using FamilyBudget.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FamilyBudget.Infrastructure.DataAccess
{
    public class AppDbContext : IdentityDbContext
    {
        private readonly IConfiguration _configuration;
        
        public DbSet<FinancialPeriod> FinancialPeriods { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<FinancialPeriod>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();
            
            builder.Entity<FinancialPeriod>()
                .HasData(new {Id=1, Name="First", Created = DateTime.UtcNow, Modified = DateTime.UtcNow});
            base.OnModelCreating(builder);
        }
        
        public override int SaveChanges()
        {
            AddAuitInfo();
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            AddAuitInfo();
            return await base.SaveChangesAsync();
        }

        private void AddAuitInfo()
        {
            var entries = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((BaseEntity)entry.Entity).Created = DateTime.UtcNow;
                }
                ((BaseEntity)entry.Entity).Modified = DateTime.UtcNow;
            }
        }
    }
}