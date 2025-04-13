using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportNest.Domain;

namespace SportNest.Infrastructure.Configurations;

public class UserGroupMembershipConfiguration : IEntityTypeConfiguration<UserGroupMembership>
{
    public void Configure(EntityTypeBuilder<UserGroupMembership> builder)
    {
        builder.HasKey(m => new { m.UserId, m.GroupId });

        builder.HasOne(x => x.User)
            .WithMany(x => x.Memberships)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Group)
            .WithMany(x => x.Memberships)
            .HasForeignKey(x => x.GroupId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}