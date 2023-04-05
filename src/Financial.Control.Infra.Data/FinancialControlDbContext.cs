using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Entities.Base;
using Financial.Control.Infra.Data.Config.Types;
using Microsoft.EntityFrameworkCore;

namespace Financial.Control.Infra.Data
{
    public class FinancialControlDbContext : DbContext
    {
        public DbSet<User> Users { get; }
        public DbSet<Category> Categories { get; }
        public DbSet<Card> Cards { get; }
        public DbSet<Revenue> Revenues { get; }
        public DbSet<Expense> Expenses { get; }

        public FinancialControlDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration<Card>(new CardEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration<CreditCard>(new CardEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration<DebitCard>(new CardEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ExpenseEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RevenueEntityTypeConfiguration());
        }
    }
}
