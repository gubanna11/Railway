using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Railway.Core.Entities.Static;

namespace Railway.Core.Data.Configurations;

public sealed class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
        new IdentityRole
        {
            Name = UserRoles.User,
            NormalizedName = UserRoles.User.ToUpper()
        },
        new IdentityRole
        {
            Name = UserRoles.Admin,
            NormalizedName = UserRoles.Admin.ToUpper()
        });
    }
}
