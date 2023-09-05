using DGym.Domain.Common.Interfaces;

namespace DGym.Domain.UnitTests.TestUtils.Services;

public class TestDateTimeProvider : IDateTimeProvider
{
    private readonly DateTime? _fixedDateDateTime;

    public TestDateTimeProvider(DateTime? fixedDateTime = null)
    {
        _fixedDateDateTime = fixedDateTime;
    }

    public DateTime UtcNow => _fixedDateDateTime ?? DateTime.UtcNow;
}