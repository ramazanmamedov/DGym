using System.Runtime.InteropServices.JavaScript;
using ErrorOr;

namespace DGym.Domain;

public static class SubscriptionErrors
{
    public static readonly Error CannotHaveMoreGymsThanSubscriptionAllows = Error.Validation(
    "Subscription.CannotHaveMoreGymsThanSubscriptionAllows",
    "A subscription cannot have more gyms than subscription allows");
}