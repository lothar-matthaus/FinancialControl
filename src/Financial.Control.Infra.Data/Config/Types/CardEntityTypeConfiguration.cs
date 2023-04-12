using Financial.Control.Domain.Entities;
using Financial.Control.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financial.Control.Infra.Data.Config.Types
{
    internal class CardEntityTypeConfiguration : IEntityTypeConfiguration<Card>, IEntityTypeConfiguration<CreditCard>, IEntityTypeConfiguration<DebitCard>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.ToTable(nameof(Card));

            builder.HasKey(card => card.Id);

            builder.Property(card => card.CardType).IsRequired(true);
            builder.Property(card => card.Name).IsRequired(true);
            builder.Property(card => card.Flag).IsRequired(true);
            builder.Property(card => card.CardNumber).IsRequired(true).HasMaxLength(16);

            builder.HasDiscriminator<CardType>("CardType")
                .HasValue<CreditCard>(CardType.Credit)
                .HasValue<DebitCard>(CardType.Debit);

            builder.Property(card => card.CreationDate).ValueGeneratedOnAdd().HasColumnType("TIMESTAMP").HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(card => card.UpdateDate).ValueGeneratedOnAddOrUpdate().HasColumnType("TIMESTAMP").HasDefaultValueSql("CURRENT_TIMESTAMP");
        }

        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder.Property(card => card.Limit).IsRequired(true);
            builder.Property(card => card.CardInvoiceDay).IsRequired(true).HasColumnName("CardInvoiceDay");
        }

        public void Configure(EntityTypeBuilder<DebitCard> builder)
        {
        }
    }
}
