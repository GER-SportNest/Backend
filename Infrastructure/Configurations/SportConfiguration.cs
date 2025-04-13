using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportNest.Domain;

namespace SportNest.Infrastructure.Configurations;

public class SportConfiguration : IEntityTypeConfiguration<Sport>
{
    public void Configure(EntityTypeBuilder<Sport> builder)
    {
        builder.HasKey(x => x.Id);
        builder
            .HasGeneratedTsVectorColumn(
                x => x.SearchVector, 
                "german", 
                x => x.Name)
            .HasIndex(x => x.SearchVector)
            .HasMethod("GIN");
    }
}