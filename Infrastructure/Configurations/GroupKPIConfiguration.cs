using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class GroupKPIConfiguration : IEntityTypeConfiguration<GroupKPI>
{
    public void Configure(EntityTypeBuilder<GroupKPI> builder)
    {
        builder.HasKey(gk => gk.Id);

        builder.Property(gk => gk.Name)
            .IsRequired();

        builder.HasOne(gk => gk.Group)
            .WithMany(g => g.GroupKPIs)
            .HasForeignKey(gk => gk.GroupId);

        builder.HasOne(gk => gk.DepartmentKPI)
            .WithMany(dk => dk.GroupKPIs)
            .HasForeignKey(gk => gk.DepartmentKPIId);

        builder.HasMany(gk => gk.UserGroupKPIValues)
            .WithOne(ugv => ugv.GroupKPI)
            .HasForeignKey(ugv => ugv.GroupKPIId);
    }
}