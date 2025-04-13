using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportNest.Domain;

namespace SportNest.Infrastructure.Configurations;

public class TrainingSessionConfiguration : IEntityTypeConfiguration<TrainingSession>
{
    public void Configure(EntityTypeBuilder<TrainingSession> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Group)
            .WithMany(x => x.TrainingSessions)
            .HasForeignKey(x => x.GroupId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}