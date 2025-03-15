using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportNest.Domain;

namespace SportNest.Infrastructure.Configurations;

public class MembershipRoleConfiguration : IEntityTypeConfiguration<MembershipRole>
{
    public void Configure(EntityTypeBuilder<MembershipRole> builder)
    {
        builder.HasKey(mr => mr.Id);

        // The bridging relationships
        builder.HasOne(mr => mr.UserClubMembership)
            .WithMany(ucm => ucm.MembershipRoles)
            .HasForeignKey(mr => mr.UserClubMembershipId);

        builder.HasOne(mr => mr.ClubRole)
            .WithMany(cr => cr.MembershipRoles)
            .HasForeignKey(mr => mr.ClubRoleId);
    }
}
