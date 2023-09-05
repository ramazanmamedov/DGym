using ErrorOr;

namespace DGym.Domain.SubscriptionAggregate;

public static class SubscriptionErrors
{
    public static readonly Error CannotHaveMoreGymsThanSubscriptionAllows = Error.Validation(
    "Subscription.CannotHaveMoreGymsThanSubscriptionAllows",
    "A subscription cannot have more gyms than subscription allows");
}