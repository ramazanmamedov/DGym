using DGym.Domain.UnitTests.TestUtils.Participants;
using DGym.Domain.UnitTests.TestUtils.Sessions;
using FluentAssertions;

namespace DGym.Domain.UnitTests;

public class SessionTest
{
   [Fact]
   public void ReserveSpot_WhenNoMoreRoom_ShouldFailReservation()
   {
      //Arrange
      var session = SessionFactory.CreateSession(maxParticipants: 1);
      var participant1 = ParticipantFactory.CreateParticipant(id: Guid.NewGuid(), userId: Guid.NewGuid());
      var participant2 = ParticipantFactory.CreateParticipant(id: Guid.NewGuid(), userId: Guid.NewGuid());

      //Act
      session.ReserveSpot(participant1);
      var action = () => session.ReserveSpot(participant2);

      //Assert
      action.Should().Throw<Exception>();
   } 
}

