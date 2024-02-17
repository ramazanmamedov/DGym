using DGym.Domain.Common;

namespace DGym.Domain.AdminAggregate;

public class Admin : AggregateRoot
{
    public Guid UserId { get; }
    public Guid? SubscriptionId { get; private set; }

    public Admin(
        Guid userId,
        Guid subscriptionId,
        Guid id) : base(id)
    {
        UserId = userId;
        SubscriptionId = subscriptionId;
    }
}