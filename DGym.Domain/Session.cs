using ErrorOr;

namespace DGym.Domain;

public class Session
{
    private readonly Guid _trainerId;
    private readonly List<Reservation> _reservations = new();
   
    private readonly int _maxParticipants;
    
    public Guid Id { get; }
    public DateOnly Date { get; }
    public TimeRange Time { get; set; }

    public Session(
        DateOnly date,
        TimeRange time,
        int maxParticipants, 
        Guid trainerId,
        Guid? id = null)
    {
        Date = date;
        Time = time;
        _maxParticipants = maxParticipants;
        _trainerId = trainerId;
        Id = id ?? Guid.NewGuid();
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