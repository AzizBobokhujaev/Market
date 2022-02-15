using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
    public class RoleConfiguration:IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                new Role
                {
                    Id = 1,
                    Name = "Администратор",
                    NormalizedName = "Администратор".ToUpper()
                },
                new Role
                {
                    Id = 2,
                    Name = "Контентщик",
                    NormalizedName = "Контентщик".ToUpper()
                });
        }
    }
}