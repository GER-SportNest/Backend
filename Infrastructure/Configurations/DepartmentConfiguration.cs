using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportNest.Domain;

namespace SportNest.Infrastructure.Configurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.DepartmentName)
            .IsRequired();

        builder.HasMany(d => d.Groups)
            .WithOne(g => g.Department)
            .HasForeignKey(g => g.DepartmentId);

        builder.HasMany(d => d.DepartmentKPIs)
            .WithOne(k => k.Department)
            .HasForeignKey(k => k.DepartmentId);

        builder.HasMany(d => d.Options)
            .WithOne(o => o.Department)
            .HasForeignKey(o => o.DepartmentId);
        
        builder.HasMany(x => x.ClubPermissions)
            .WithOne(mr => mr.Department)
            .HasForeignKey(mr => mr.DepartmentId)
            .IsRequired(false);
    }
}