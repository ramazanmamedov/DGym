namespace DGym.Domain;

public class Participant
{
    private readonly Guid _userId;
    private readonly List<Guid> _sessionIds = new();

    public Guid Id { get; }
    public Participant(
        Guid userId,
        Guid? id = null)
    {
        _userId = userId;
        Id = id ?? Guid.NewGuid();
    }
} 