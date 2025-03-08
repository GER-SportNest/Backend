using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class ClubConfiguration : IEntityTypeConfiguration<Club>
{
    public void Configure(EntityTypeBuilder<Club> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired();

        builder.Property(c => c.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.HasMany(c => c.Departments)
            .WithOne(d => d.Club)
            .HasForeignKey(d => d.ClubId);

        builder.HasMany(c => c.Memberships)
            .WithOne(m => m.Club)
            .HasForeignKey(m => m.ClubId);

        builder.HasMany(c => c.Options)
            .WithOne(o => o.Club)
            .HasForeignKey(o => o.ClubId);
    }
}