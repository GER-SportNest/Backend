using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class OptionConfiguration : IEntityTypeConfiguration<Option>
{
    public void Configure(EntityTypeBuilder<Option> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Type)
            .IsRequired();

        builder.Property(o => o.Name)
            .IsRequired();

        // Each option can link to only one of the following: Club, Department, Group
        // The foreign keys are nullable in the entity, so we keep it that way.
        builder.HasOne(o => o.Club)
            .WithMany(c => c.Options)
            .HasForeignKey(o => o.ClubId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(o => o.Department)
            .WithMany(d => d.Options)
            .HasForeignKey(o => o.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(o => o.Group)
            .WithMany(g => g.Options)
            .HasForeignKey(o => o.GroupId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}