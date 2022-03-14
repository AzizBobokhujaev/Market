using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
    public class UserConfiguration:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var hasher = new PasswordHasher<User>();
            builder.HasData(
                new User
                {
                    Id = 1,
                    UserName = "Admin",
                    NormalizedUserName = "admin".ToUpper(),
                    Email = "Admin@mail.ru",
                    NormalizedEmail = "admin@mail.ru".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "Adm!n_P@ssW0rd"),
                    SecurityStamp = string.Empty,
                    EmailConfirmed = false

                });
            builder.HasIndex(b => b.Email).IsUnique();
        }
    }
}