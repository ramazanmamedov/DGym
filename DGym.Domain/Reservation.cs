using DGym.Domain.Common;

namespace DGym.Domain;

public class Reservation : Entity
{
    public Guid ParticipantId { get; }

    public Reservation(
        Guid participantId,
        Guid? id = null) : base(id ?? Guid.NewGuid())
    {
        ParticipantId = participantId;
    }
}