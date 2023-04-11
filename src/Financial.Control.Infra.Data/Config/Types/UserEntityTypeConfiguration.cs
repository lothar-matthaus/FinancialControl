using Financial.Control.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financial.Control.Infra.Data.Config.Types
{
    internal class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));
            builder.HasKey(user => user.Id);

            builder.Property(user => user.Name).IsRequired(true).HasMaxLength(100);

            builder.Property(user => user.CreationDate).ValueGeneratedOnAdd().HasColumnType("TIMESTAMP").HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(user => user.UpdateDate).ValueGeneratedOnAddOrUpdate().HasColumnType("TIMESTAMP").HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.HasOne(user => user.Account).WithMany(account => account.Users).HasForeignKey(user => user.AccountId);
            builder.HasMany(user => user.Cards).WithOne(user => user.User).HasForeignKey(card => card.UserId);
            builder.HasMany(user => user.Expenses).WithOne(expense => expense.User).HasForeignKey(expense => expense.UserId);
            builder.HasOne(user => user.Revenue).WithMany(revenue => revenue.Users).HasForeignKey(user => user.RevenueId);
        }
    }
}
