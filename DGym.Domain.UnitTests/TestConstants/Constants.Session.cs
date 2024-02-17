using DGym.Domain.Common.ValueObjects;
using DGym.Domain.SessionAggregate;

namespace DGym.Domain.UnitTests.TestConstants;

public static partial class Constants
{
    public static class Session
    {
        public static readonly Guid Id = Guid.NewGuid();
        public static DateOnly Date = DateOnly.FromDateTime(DateTime.Now);
        public static readonly TimeRange Time = new (
            TimeOnly.MinValue.AddHours(8),
            TimeOnly.MinValue.AddHours(9));
        
        public const int MaxParticipants = 10;
        
        public static readonly List<SessionCategory> Categories = new();
        
        public const string Name = "Boxing";
        public const string Description = "The best boxing";
    }
} 