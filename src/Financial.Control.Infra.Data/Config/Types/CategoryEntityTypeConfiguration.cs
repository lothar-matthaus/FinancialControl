using Financial.Control.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financial.Control.Infra.Data.Config.Types
{
    internal class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(nameof(Category));
            builder.HasKey(category => category.Id);

            builder.Property(category => category.Name).IsRequired(true).HasMaxLength(120);

            builder.Property(category => category.CreationDate).IsRequired().ValueGeneratedOnAdd();
            builder.Property(category => category.UpdateDate).IsRequired().ValueGeneratedOnUpdate();
        }
    }
}
