using DGym.Domain.UnitTests.TestConstants;

namespace DGym.Domain.UnitTests.TestUtils.Gyms;

public class GymFactory
{
    public static Gym CreateGym(
        int maxRooms = Constants.Subscriptions.MaxRoomsFreeTier,
        Guid? id = null)
    {
        return new Gym(
            maxRooms,
            subscriptionId: Constants.Subscriptions.Id,
            id: id ?? Constants.Gym.Id
            );
    }
}