using ErrorOr;

namespace DGym.Domain;

public class RoomErrors
{
    public static readonly Error CannotHaveMoreSessionThanSubscriptionAllows = Error.Validation(
        "Room.CannotHaveMoreSessionThanSubscriptionAllows",
        "A room cannot have more scheduled sessions than the subscription allows");

    public static readonly Error CannotHaveTwoOrMoreOverlappingSessions = Error.Validation(
        "Room.CannotHaveTwoOrMoreOverlappingSessions",
        "A room cannot have two or more overlapping sessions");
}