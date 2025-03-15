using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportNest.Domain;

namespace SportNest.Infrastructure.Configurations;

public class UserClubMembershipConfiguration : IEntityTypeConfiguration<UserClubMembership>
{
    public void Configure(EntityTypeBuilder<UserClubMembership> builder)
    {
        builder.HasKey(m => m.Id);

        builder.HasOne(m => m.User)
            .WithMany(u => u.UserClubMemberships)
            .HasForeignKey(m => m.UserId);

        builder.HasOne(m => m.Club)
            .WithMany(c => c.Memberships)
            .HasForeignKey(m => m.ClubId);

        builder.HasMany(m => m.MembershipRoles)
            .WithOne(mr => mr.UserClubMembership)
            .HasForeignKey(mr => mr.UserClubMembershipId);
    }
}