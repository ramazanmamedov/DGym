using DGym.Domain.Common;
using DGym.Domain.Common.Entities;
using DGym.Domain.SessionAggregate;
using ErrorOr;

namespace DGym.Domain.TrainerAggregate;

public class Trainer : AggregateRoot
{
    private readonly List<Guid> _sessionIds = new();
    private readonly Schedule _schedule;

    public Guid UserId { get; }

    public Trainer(
        Guid userId,
        Schedule? schedule = null,
        Guid? id = null)
        : base(id ?? Guid.NewGuid())
    {
        UserId = userId;
        _schedule = schedule ?? Schedule.Empty();
    }

    public ErrorOr<Success> AddSessionToSchedule(Session session)
    {
        if (_sessionIds.Contains(session.Id))
        {
            return Error.Conflict(description: "Session already exists int trainer's schedule");
        }

        var bookTimeSlotResult = _schedule.BookTimeSlot(session.Date, session.Time);
        if (bookTimeSlotResult is {IsError: true, FirstError.Type: ErrorType.Conflict})
        {
            return TrainerErrors.CannotHaveTwoOrMoreOverlappingSessions;
        }
        
        _sessionIds.Add(session.Id);
        return Result.Success;
    }
}