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
            builder.Ignore(user => user.Token);

            builder.OwnsOne(user => user.Email, email =>
            {
                email.HasIndex(email => email.Value).IsUnique(true);
                email.Property(email => email.Value).IsRequired(true).HasMaxLength(256).HasColumnName("Email");
            });
            builder.OwnsOne(user => user.Password, password =>
            {
                password.Property(pass => pass.Value).IsRequired(true).HasMaxLength(256).HasColumnName("Password");
                password.Property(pass => pass.Salt).IsRequired(true).HasMaxLength(256).HasColumnName("PasswordSalt");
            });

            builder.OwnsOne(user => user.ProfilePicture, profilePicture =>
            {
                profilePicture.Property(pass => pass.Value).IsRequired(true).HasMaxLength(256).HasColumnName("ProfilePictureURL");
            });

            builder.Property(user => user.CreationDate).ValueGeneratedOnAdd().HasColumnType("TIMESTAMP").HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(user => user.UpdateDate).ValueGeneratedOnAddOrUpdate().HasColumnType("TIMESTAMP").HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
