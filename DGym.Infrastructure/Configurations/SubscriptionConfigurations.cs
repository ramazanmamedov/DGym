using DGym.Domain.SubscriptionAggregate;
using DGym.Infrastructure.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DGym.Infrastructure.Configurations;

public class SubscriptionConfigurations : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id)
            .ValueGeneratedNever();

        builder.Property("_maxGyms")
            .HasColumnName("MaxGyms");

        builder.Property("_adminId")
            .HasColumnName("AdminId");

        builder.Property(s => s.SubscriptionType)
            .HasConversion(
                subscriptionType => subscriptionType.Value,
                value => SubscriptionType.FromValue(value));

        builder.Property<List<Guid>>("_gymIds")
            .HasColumnName("GymIds")
            .HasListOfIdsConverter();
    }
}
