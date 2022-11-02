using congestion.calculator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Congestion.Infrastructure;

public class CityTypeConfig:IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(b => b.Name).IsRequired();
    }
}