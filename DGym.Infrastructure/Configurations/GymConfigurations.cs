using DGym.Domain.GymAggregate;
using DGym.Infrastructure.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DGym.Infrastructure.Configurations;

public class GymConfigurations : IEntityTypeConfiguration<Gym>
{
    public void Configure(EntityTypeBuilder<Gym> builder)
    {
        builder.HasKey(g => g.Id);

        builder.Property(g => g.Id)
            .ValueGeneratedNever();

        builder.Property("_maxRooms")
            .HasColumnName("MaxRooms");

        builder.Property<List<Guid>>("_roomIds")
            .HasColumnName("RoomIds")
            .HasListOfIdsConverter();

        builder.Property<List<Guid>>("_trainerIds")
            .HasColumnName("TrainerIds")
            .HasListOfIdsConverter();

        builder.Property(g => g.Name);

        builder.Property(g => g.SubscriptionId);
    }
}