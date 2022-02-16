using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configuration
{
    public class RoleConfiguration:IEntityTypeConfiguration<IdentityRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<int>> builder)
        {
            builder.HasData(
                new IdentityRole<int>
                {
                    Id = 1,
                    Name = "Администратор",
                    NormalizedName = "Администратор".ToUpper()
                },
                new IdentityRole<int>
                {
                    Id = 2,
                    Name = "Контентщик",
                    NormalizedName = "Контентщик".ToUpper()
                });
        }
        
    }
}