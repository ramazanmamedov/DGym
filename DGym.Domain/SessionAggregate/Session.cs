using DGym.Domain.Common;
using DGym.Domain.Common.Interfaces;
using DGym.Domain.Common.ValueObjects;
using DGym.Domain.ParticipantAggregate;
using ErrorOr;

namespace DGym.Domain.SessionAggregate;

public class Session : AggregateRoot
{
    private readonly Guid _trainerId;
    private readonly List<Reservation> _reservations = new();
    private readonly int _maxParticipants;
    
    public DateOnly Date { get; }
    public TimeRange Time { get; set; }

    public Session(
        DateOnly date,
        TimeRange time,
        int maxParticipants, 
        Guid trainerId,
        Guid? id = null) : base(id ?? Guid.NewGuid())
    {
        Date = date;
        Time = time;
        _maxParticipants = maxParticipants;
        _trainerId = trainerId;
    }

    public ErrorOr<Success> ReserveSpot(Participant participant)
    {
        if (_reservations.Count >= _maxParticipants)
        {
            return SessionErrors.CannotHaveMoreReservationsThanParticipants;
        }

        if (_reservations.Any(reservation => reservation.ParticipantId == participant.Id))
        {
            return Error.Conflict(description: "Participants cannot reserve twice");
        }

        var reservation = new Reservation(participant.Id);
        _reservations.Add(reservation);
        
        return Result.Success;
    }

    public ErrorOr<Success> CancelReservation(Participant participant, IDateTimeProvider dateTimeProvider)
    {
        if (IsTooCloseToSession(dateTimeProvider.UtcNow))
        {
            return SessionErrors.CannotCancelReservationToCloseToSession;
        }

        var reservation = _reservations.FirstOrDefault(res => res.ParticipantId == participant.Id);
        if (reservation is null)
        {
            return Error.NotFound(description: "Participant not found");
 
        }

        _reservations.Remove(reservation);
        return Result.Success;
    }

    private bool IsTooCloseToSession(DateTime utcNow)
    {
        const int minHours = 24;
        return (Date.ToDateTime(Time.Start) - utcNow).TotalHours < minHours;
    }
}