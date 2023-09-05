using DGym.Domain.Common;

namespace DGym.Domain.AdminAggregate;

public class Admin : AggregateRoot
{
    private readonly Guid _userId;
    private readonly Guid _subscriptionId;

    public Admin(Guid id) : base(id)
    {
    }
}