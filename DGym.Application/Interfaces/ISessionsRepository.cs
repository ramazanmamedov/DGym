
using DGym.Domain.SessionAggregate;

namespace DGym.Application.Interfaces;

public interface ISessionsRepository
{
    Task AddSessionAsync(Session session);
    Task UpdateSessionAsync(Session session);
}