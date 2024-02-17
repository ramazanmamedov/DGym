using DGym.Domain.RoomAggregate;
using DGym.Domain.UnitTests.TestConstants;

namespace DGym.Domain.UnitTests.TestUtils.Rooms;

public class RoomFactory
{
    public static Room CreateRoom(
        string name = Constants.Room.Name,
        int maxDailySessions = Constants.Room.MaxDailySessions,
        Guid? gymId = null,
        Guid? id = null)
    {
        return new Room(
            name: name,
            maxDailySessions: maxDailySessions,
            gymId: gymId ?? Constants.Gym.Id,
            id: id ?? Constants.Room.Id);
    }
}