using ErrorOr;

namespace DGym.Domain;

public class TrainerErrors
{
    public static readonly Error CannotHaveTwoOrMoreOverlappingSessions = Error.Validation(
        "Trainer.CannotHaveTwoOrMoreOverlappingSessions",
        "A trainer cannot have two or more overlapping sessions");
}