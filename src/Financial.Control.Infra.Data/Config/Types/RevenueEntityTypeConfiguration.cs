using Financial.Control.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financial.Control.Infra.Data.Config.Types
{
    internal class RevenueEntityTypeConfiguration : IEntityTypeConfiguration<Revenue>
    {
        public void Configure(EntityTypeBuilder<Revenue> builder)
        {
            builder.ToTable(nameof(Revenue));
            builder.HasKey(rev => rev.Id);
            builder.Ignore(rev => rev.IsValid);

            builder.Property(rev => rev.Value).IsRequired(true);
            builder.Property(rev => rev.Name).IsRequired(true);
            builder.Property(rev => rev.Date).IsRequired(true).HasColumnType("DATE");

            builder.Property(rev => rev.CreationDate).ValueGeneratedOnAdd().HasColumnType("TIMESTAMP").HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(rev => rev.UpdateDate).ValueGeneratedOnAddOrUpdate().HasColumnType("TIMESTAMP").HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.HasOne(rev => rev.User).WithMany(user => user.Revenues).HasForeignKey(revenue => revenue.UserId);
        }
    }
}
