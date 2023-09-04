namespace DGym.Domain;

public interface IDateTimeProvider
{
    public DateTime UtcNow { get; }
}