using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportNest.Domain;

namespace SportNest.Infrastructure.Configurations;

public class TrainingSessionConfiguration : IEntityTypeConfiguration<TrainingSession>
{
    public void Configure(EntityTypeBuilder<TrainingSession> builder)
    {
        builder.HasKey(t => t.Id);

        builder.HasOne(t => t.Group)
            .WithMany(g => g.TrainingSessions)
            .HasForeignKey(t => t.GroupId);

        builder.HasMany(t => t.Attendances)
            .WithOne(a => a.TrainingSession)
            .HasForeignKey(a => a.TrainingSessionId);
    }
}