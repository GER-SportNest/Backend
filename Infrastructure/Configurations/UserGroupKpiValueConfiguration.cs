using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class UserGroupKPIValueConfiguration : IEntityTypeConfiguration<UserGroupKPIValue>
{
    public void Configure(EntityTypeBuilder<UserGroupKPIValue> builder)
    {
        builder.HasKey(ugv => ugv.Id);

        builder.HasOne(ugv => ugv.GroupKPI)
            .WithMany(gk => gk.UserGroupKPIValues)
            .HasForeignKey(ugv => ugv.GroupKPIId);

        builder.HasOne(ugv => ugv.User)
            .WithMany() // if you want a direct collection on User, add it
            .HasForeignKey(ugv => ugv.UserId);
    }
}