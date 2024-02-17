using DGym.Domain.Common.Entities;
using DGym.Domain.Common.ValueObjects;
using DGym.Domain.ParticipantAggregate;
using DGym.Infrastructure.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DGym.Infrastructure.Configurations;

public class ParticipantConfigurations : IEntityTypeConfiguration<Participant>
{
    public void Configure(EntityTypeBuilder<Participant> builder)
    {
        builder.HasKey(g => g.Id);

        builder.Property(g => g.Id)
            .ValueGeneratedNever();

        builder.OwnsOne<Schedule>("_schedule", sb =>
        {
            sb.Property<Dictionary<DateOnly, List<TimeRange>>>("_calendar")
                .HasColumnName("ScheduleCalendar")
                .HasValueJsonConverter();

            sb.Property(s => s.Id)
                .HasColumnName("ScheduleId");
        });

        builder.Property<List<Guid>>("_sessionIds")
            .HasColumnName("SessionIds")
            .HasListOfIdsConverter();

        builder.Property(g => g.UserId);
    }
}
