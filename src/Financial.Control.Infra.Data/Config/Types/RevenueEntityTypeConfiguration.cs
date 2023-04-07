using Financial.Control.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financial.Control.Infra.Data.Config.Types
{
    internal class RevenueEntityTypeConfiguration : IEntityTypeConfiguration<Revenue>
    {
        public void Configure(EntityTypeBuilder<Revenue> builder)
        {
            builder.HasKey(rev => rev.Id);

            builder.Property(rev => rev.CreationDate).ValueGeneratedOnAdd().HasColumnType("TIMESTAMP").HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(rev => rev.UpdateDate).ValueGeneratedOnAddOrUpdate().HasColumnType("TIMESTAMP").HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(rev => rev.Value).IsRequired(true);

            builder.HasOne(rev => rev.User).WithMany(us => us.Revenues).HasForeignKey(rev => rev.UserId);

        }
    }
}
