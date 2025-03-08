using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Email)
            .HasMaxLength(255);
        
        builder.HasIndex(u => u.Email)
            .IsUnique();
        
        builder.HasIndex(u => u.PhoneNumber)
            .IsUnique();

        builder.HasMany(u => u.UserClubMemberships)
            .WithOne(ucm => ucm.User)
            .HasForeignKey(ucm => ucm.UserId);
    }
}