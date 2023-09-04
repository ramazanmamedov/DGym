namespace DGym.Domain.UnitTests.TestConstants;

public static partial class Constants
{
    public static class Session
    {
        public const int MaxParticipants = 1;
        public static readonly Guid Id = Guid.NewGuid();
        public static DateOnly Date = DateOnly.FromDateTime(DateTime.Now);
        public static TimeOnly StartTime = TimeOnly.FromDateTime(DateTime.Now.AddDays(-1));
        public static TimeOnly EndTime = TimeOnly.FromDateTime(DateTime.Now.AddDays(1));
    }
} 