using DGym.Domain.TrainerAggregate;
using DGym.Domain.UnitTests.TestConstants;
using DGym.Domain.UnitTests.TestUtils.Common;
using DGym.Domain.UnitTests.TestUtils.Sessions;
using DGym.Domain.UnitTests.TestUtils.Trainers;
using FluentAssertions;

namespace DGym.Domain.UnitTests;

public class TrainerTests
{
    [Theory]
    [InlineData(1, 3, 1, 3)]
    [InlineData(1, 3, 2, 3)]
    [InlineData(1, 3, 2, 4)]
    [InlineData(1, 3, 0, 2)]
    public void AddSessionToSchedule_WhenSessionOverlapsWithAnotherSession_ShouldFail(
        int startHourSession1,
        int endHourSession1,
        int startHourSession2,
        int endHourSession2)
    {
        // Arrange
        var trainer = TrainerFactory.CreateTrainer();

        var session1 = SessionFactory.CreateSession(
            date: Constants.Session.Date,
            time: TimeRangeFactory.CreateFromHours(startHourSession1, endHourSession1),
            id: Guid.NewGuid());

        var session2 = SessionFactory.CreateSession(
            date: Constants.Session.Date,
            time: TimeRangeFactory.CreateFromHours(startHourSession2, endHourSession2),
            id: Guid.NewGuid());

        // Act
        var addSession1Result = trainer.AddSessionToSchedule(session1);
        var addSession2Result = trainer.AddSessionToSchedule(session2);

        // Assert
        addSession1Result.IsError.Should().BeFalse();

        addSession2Result.IsError.Should().BeTrue();
        addSession2Result.FirstError.Should().Be(TrainerErrors.CannotHaveTwoOrMoreOverlappingSessions);
    }
}