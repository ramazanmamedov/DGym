using DGym.Domain.Common;
using DGym.Domain.Common.Entities;
using DGym.Domain.SessionAggregate;
using ErrorOr;

namespace DGym.Domain.RoomAggregate;

public class Room : AggregateRoot
{
    private readonly List<Guid> _sessionIds = new();
    private readonly int _maxDailySessions;
    private readonly Guid _gymId;
    private readonly Schedule _schedule;
    
    public Room(
        int maxDailySessions,
        Guid gymId,
        Schedule? schedule = null,
        Guid? id = null) : base(id ?? Guid.NewGuid())
    {
        _maxDailySessions = maxDailySessions;
        _gymId = gymId;
        _schedule = schedule ?? Schedule.Empty();
    }

    public ErrorOr<Success> ScheduleSession(Session session)
    {
        if (_sessionIds.Any(id => id == session.Id))
        {
            return Error.Conflict(description: "Session already exists in room");
        }

        if (_sessionIds.Count >= _maxDailySessions)
        {
            return RoomErrors.CannotHaveMoreSessionThanSubscriptionAllows;
        }

        var addEventResult = _schedule.BookTimeSlot(session.Date, session.Time);
        if (addEventResult is {IsError: true, FirstError.Type: ErrorType.Conflict})
        {
            return RoomErrors.CannotHaveTwoOrMoreOverlappingSessions;
        }
        
        _sessionIds.Add(session.Id);
        return Result.Success;
    }

}