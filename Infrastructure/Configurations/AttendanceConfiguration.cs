using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
{
    public void Configure(EntityTypeBuilder<Attendance> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasOne(a => a.TrainingSession)
            .WithMany(t => t.Attendances)
            .HasForeignKey(a => a.TrainingSessionId);

        builder.HasOne(a => a.User)
            .WithMany() // if you want a direct collection on User, add it
            .HasForeignKey(a => a.UserId);
    }
}