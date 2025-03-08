using Domain;

namespace Infrastructure.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
    }
}
