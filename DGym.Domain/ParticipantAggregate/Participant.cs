using DGym.Domain.Common;
using DGym.Domain.Common.Entities;
using DGym.Domain.SessionAggregate;
using ErrorOr;

namespace DGym.Domain.ParticipantAggregate;

public class Participant : AggregateRoot
{
    private readonly Schedule _schedule;
    private readonly List<Guid> _sessionIds = new();
    public Guid UserId { get; }
    public IReadOnlyList<Guid> SessionIds => _sessionIds;

    public Participant(
        Guid userId,
        Schedule? schedule = null,
        Guid? id = null) : base(id ?? Guid.NewGuid())
    {
        UserId = userId;
        _schedule = schedule ?? Schedule.Empty();
    }

    public ErrorOr<Success> AddToSchedule(Session session)
    {
        if (_sessionIds.Contains(session.Id))
        {
            return Error.Conflict(description: "Session already exists int participant's schedule");
        }

        var bookTimeSlotResult = _schedule.BookTimeSlot(
            session.Date,
            session.Time);

        if (bookTimeSlotResult.IsError)
        {
            return bookTimeSlotResult.FirstError.Type == ErrorType.Conflict
                ? ParticipantErrors.CannotHaveTwoOrMoreOverlappingSessions
                : bookTimeSlotResult.Errors;
        }
        _sessionIds.Add(session.Id);
        return Result.Success;
    }
} 