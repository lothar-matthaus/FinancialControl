﻿using Financial.Control.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financial.Control.Infra.Data.Config.Types
{
    internal class ExpenseEntityTypeConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.ToTable(nameof(Expense));
            builder.HasKey(ex => ex.Id);

            builder.Property(ex => ex.Description).IsRequired(true).HasMaxLength(300);
            builder.Property(ex => ex.PaidOut).IsRequired().HasDefaultValue(false);

            builder.OwnsOne(ex => ex.Payment, payment =>
            {
                payment.Property(pay => pay.PaymentType).IsRequired(true).HasColumnName("PaymentType");
                payment.Property(pay => pay.Installment).IsRequired(true).HasColumnName("Installment").HasDefaultValue(1);
                payment.Property(pay => pay.Value).IsRequired(true).HasColumnName("Value");
            });

            builder.Property(ex => ex.CreationDate).ValueGeneratedOnAdd().HasColumnType("TIMESTAMP").HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(ex => ex.UpdateDate).ValueGeneratedOnAddOrUpdate().HasColumnType("TIMESTAMP").HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.HasOne(ex => ex.Category).WithMany(cat => cat.Expenses).HasForeignKey(ex => ex.CategoryId);
            builder.HasOne(ex => ex.Card).WithMany(card => card.Expenses).HasForeignKey(ex => ex.CardId).IsRequired(false);
            builder.HasOne(ex => ex.User).WithMany(user => user.Expenses).HasForeignKey(ex => ex.UserId);
        }
    }
}
