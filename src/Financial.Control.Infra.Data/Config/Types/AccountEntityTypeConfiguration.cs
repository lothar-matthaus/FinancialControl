using Financial.Control.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financial.Control.Infra.Data.Config.Types
{
    public class AccountEntityTypeConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable(nameof(Account));
            builder.HasKey(account => account.Id);

            builder.Ignore(account => account.Token);

            builder.OwnsOne(account => account.Email, email =>
            {
                email.HasIndex(email => email.Value).IsUnique(true);
                email.Property(email => email.Value).IsRequired(true).HasMaxLength(256).HasColumnName("Email");
            });
            builder.OwnsOne(account => account.Password, password =>
            {
                password.Property(pass => pass.Value).IsRequired(true).HasMaxLength(256).HasColumnName("Password");
                password.Property(pass => pass.Salt).IsRequired(true).HasMaxLength(256).HasColumnName("PasswordSalt");
            });

            builder.OwnsOne(account => account.ProfilePicture, profilePicture =>
            {
                profilePicture.Property(pass => pass.Value).IsRequired(true).HasMaxLength(256).HasColumnName("ProfilePictureURL");
            });
        }
    }
}
