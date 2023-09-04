using ErrorOr;

namespace DGym.Domain;

public static class SessionErrors
{
    public static Error CannotHaveMoreReservationsThanParticipants = Error.Validation(
        code: "Session.CannotHaveMoreReservationsThanParticipants",
        description: "Cannot Have More Reservations Than Participants");

    public static Error CannotCancelReservationToCloseToSession = Error.Validation(
        code: "Session.CannotCancelReservationTooCloseToSession",
        description: "Cannot cancel reservation too close to session"
    );
}