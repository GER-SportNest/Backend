using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportNest.Domain;

namespace SportNest.Infrastructure.Configurations;

public class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.HasKey(g => g.Id);

        builder.Property(g => g.GroupName)
            .IsRequired();

        builder.HasMany(g => g.TrainingSessions)
            .WithOne(t => t.Group)
            .HasForeignKey(t => t.GroupId);

        builder.HasMany(g => g.GroupKPIs)
            .WithOne(k => k.Group)
            .HasForeignKey(k => k.GroupId);

        builder.HasMany(g => g.Options)
            .WithOne(o => o.Group)
            .HasForeignKey(o => o.GroupId);
        
        builder.HasMany(x => x.ClubPermissions)
            .WithOne(mr => mr.Group)
            .HasForeignKey(mr => mr.GroupId)
            .IsRequired(false);
    }
}