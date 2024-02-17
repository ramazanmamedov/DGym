using DGym.Domain.GymAggregate;
using DGym.Domain.UnitTests.TestConstants;

namespace DGym.Domain.UnitTests.TestUtils.Gyms;

public class GymFactory
{
    public static Gym CreateGym(
        string name = Constants.Gym.Name,
        int maxRooms = Constants.Subscriptions.MaxRoomsFreeTier,
        Guid? id = null)
    {
        return new Gym(
            name,
            maxRooms,
            subscriptionId: Constants.Subscriptions.Id,
            id: id ?? Constants.Gym.Id);
    }
}