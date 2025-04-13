using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportNest.Domain;

namespace SportNest.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Email)
            .HasMaxLength(255);
        
        builder.HasIndex(x => x.Email)
            .IsUnique();
        
        builder.HasIndex(x => x.PhoneNumber)
            .IsUnique();
    }
}