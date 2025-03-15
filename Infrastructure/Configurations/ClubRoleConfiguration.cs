using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportNest.Domain;

namespace SportNest.Infrastructure.Configurations;

public class ClubRoleConfiguration : IEntityTypeConfiguration<ClubRole>
{
    public void Configure(EntityTypeBuilder<ClubRole> builder)
    {
        builder.HasKey(cr => cr.Id);

        builder.Property(cr => cr.RoleName)
            .IsRequired();

        builder.HasMany(cr => cr.MembershipRoles)
            .WithOne(mr => mr.ClubRole)
            .HasForeignKey(mr => mr.ClubRoleId);
        
        builder.HasMany(x => x.ClubPermissions)
            .WithOne(mr => mr.ClubRole)
            .HasForeignKey(mr => mr.ClubRoleId);
    }
}
