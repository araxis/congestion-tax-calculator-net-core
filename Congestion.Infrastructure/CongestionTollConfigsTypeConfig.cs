using congestion.calculator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Congestion.Infrastructure;

public class CongestionTollConfigsTypeConfig : IEntityTypeConfiguration<CongestionTollConfigs>
{
    public void Configure(EntityTypeBuilder<CongestionTollConfigs> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(p => p.Id).ValueGeneratedOnAdd();
        builder.HasOne(b => b.City);
        builder.OwnsMany(b => b.TollFees);

    }
}