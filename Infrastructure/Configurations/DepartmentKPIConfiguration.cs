using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class DepartmentKPIConfiguration : IEntityTypeConfiguration<DepartmentKPI>
{
    public void Configure(EntityTypeBuilder<DepartmentKPI> builder)
    {
        builder.HasKey(k => k.Id);

        builder.Property(k => k.Name)
            .IsRequired();

        builder.HasOne(k => k.Department)
            .WithMany(d => d.DepartmentKPIs)
            .HasForeignKey(k => k.DepartmentId);

        builder.HasMany(k => k.GroupKPIs)
            .WithOne(gk => gk.DepartmentKPI)
            .HasForeignKey(gk => gk.DepartmentKPIId);
    }
}