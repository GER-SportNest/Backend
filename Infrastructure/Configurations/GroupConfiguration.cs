using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportNest.Domain;

namespace SportNest.Infrastructure.Configurations;

public class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired();
        
        builder.HasOne(x => x.Sport)
            .WithMany(x => x.Groups)
            .HasForeignKey(x => x.SportId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}