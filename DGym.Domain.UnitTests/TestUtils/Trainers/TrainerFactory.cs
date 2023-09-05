using DGym.Domain.UnitTests.TestConstants;

namespace DGym.Domain.UnitTests.TestUtils.Trainers;

public class TrainerFactory
{
    public static Trainer CreateTrainer(
        Guid? userId = null,
        Guid? id = null)
    {
        return new Trainer(
            userId: userId ?? Guid.NewGuid(),
            id: id ?? Constants.Trainer.Id);
    }
}