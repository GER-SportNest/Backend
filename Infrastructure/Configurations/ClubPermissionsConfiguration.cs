using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportNest.Domain;

namespace SportNest.Infrastructure.Configurations;

public class ClubPermissionsConfiguration : IEntityTypeConfiguration<ClubPermission>
{
    public void Configure(EntityTypeBuilder<ClubPermission> builder)
    {
        builder.HasKey(x => x.Id);
    }
}