using DGym.Domain.UnitTests.TestConstants;
using DGym.Domain.UnitTests.TestUtils.Common;
using DGym.Domain.UnitTests.TestUtils.Participants;
using DGym.Domain.UnitTests.TestUtils.Sessions;
using FluentAssertions;

namespace DGym.Domain.UnitTests;

public class ParticipantTests
{
    [Theory]
    [InlineData(1,3,1,3)]
    [InlineData(1,3,2,3)]
    [InlineData(1,3,2,4)]
    [InlineData(1,3,0,2)]
    public void AddSessionToSchedule_WhenSessionOverlapsWithAnotherSession_ShouldFail(
        int startHoursSession1,
        int endHoursSession1,
        int startHoursSession2,
        int endHoursSession2)
    {
        //Arrange
        var participant = ParticipantFactory.CreateParticipant();

        var session1 = SessionFactory.CreateSession(
            date: Constants.Session.Date,
            time: TimeRangeFactory.CreateFromHours(startHoursSession1, endHoursSession1),
            id: Guid.NewGuid());
        
        var session2 = SessionFactory.CreateSession(
            date: Constants.Session.Date,
            time: TimeRangeFactory.CreateFromHours(startHoursSession2, endHoursSession2),
            id: Guid.NewGuid());

        //Act
        var addSession1Result = participant.AddToSchedule(session1);
        var addSession2Result = participant.AddToSchedule(session2);

        //Assert
        addSession1Result.IsError.Should().BeFalse();

        addSession2Result.IsError.Should().BeTrue();
        addSession2Result.FirstError.Should().Be(ParticipantErrors.CannotHaveTwoOrMoreOverlappingSessions);
    }
}