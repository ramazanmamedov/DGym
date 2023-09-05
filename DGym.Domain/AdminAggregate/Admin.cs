using DGym.Domain.Common;

namespace DGym.Domain.AdminAggregate;

public class Admin : AggregateRoot
{
    private readonly Guid _userId;
    private readonly Guid _subscriptionId;

    public Admin(
        Guid userId,
        Guid subscriptionId,
        Guid id) : base(id)
    {
        _userId = userId;
        _subscriptionId = subscriptionId;
    }
}