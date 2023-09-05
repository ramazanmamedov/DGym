using ErrorOr;

namespace DGym.Domain;

public class Session
{
    private readonly Guid _trainerId;
    private readonly List<Guid> _participantIds = new();
   
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
        if (_participantIds.Count >= _maxParticipants)
        {
            return SessionErrors.CannotHaveMoreReservationsThanParticipants;
        }
        _participantIds.Add(participant.Id);
        return Result.Success;
    }

    public ErrorOr<Success> CancelReservation(Participant participant, IDateTimeProvider dateTimeProvider)
    {
        if (IsTooCloseToSession(dateTimeProvider.UtcNow))
        {
            return SessionErrors.CannotCancelReservationToCloseToSession;
        }

        if (!_participantIds.Remove(participant.Id))
        {
            return Error.NotFound(description: "Participant not found");
        }

        return Result.Success;
    }

    private bool IsTooCloseToSession(DateTime utcNow)
    {
        const int minHours = 24;
        return (Date.ToDateTime(Time.Start) - utcNow).TotalHours < minHours;
    }
}