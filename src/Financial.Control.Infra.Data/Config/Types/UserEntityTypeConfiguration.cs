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

            builder.OwnsOne(user => user.Email, email =>
            {
                email.Property(pass => pass.Value).IsRequired(true).HasMaxLength(256).HasColumnName("Email");
            });
            builder.OwnsOne(user => user.Password, password =>
            {
                password.Property(pass => pass.Value).IsRequired(true).HasMaxLength(256).HasColumnName("Password");
            });

            builder.OwnsOne(user => user.ProfilePicture, profilePicture =>
            {
                profilePicture.Property(pass => pass.Value).IsRequired(true).HasMaxLength(256).HasColumnName("ProfilePictureURL");
            });

            builder.Property(user => user.Name).IsRequired().HasMaxLength(100);
            builder.Property(user => user.CreationDate).IsRequired().ValueGeneratedOnAdd();
            builder.Property(user => user.UpdateDate).IsRequired().ValueGeneratedOnUpdate();
        }
    }
}
