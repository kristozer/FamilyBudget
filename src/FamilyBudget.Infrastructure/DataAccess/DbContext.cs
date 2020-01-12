using FamilyBudget.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FamilyBudget.Infrastructure.DataAccess
{
    public class DbContext : IdentityDbContext
    {
        private readonly IConfiguration _configuration;
        
        public DbSet<FinancialPeriod> FinancialPeriods { get; set; }
        
        public DbContext(DbContextOptions<DbContext> options, IConfiguration configuration)
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
                .HasData(new {Id=1, Name="First"});
            base.OnModelCreating(builder);
        }
    }
}