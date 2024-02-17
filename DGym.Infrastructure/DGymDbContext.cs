using System.Reflection;
using DGym.Domain.AdminAggregate;
using DGym.Domain.Common;
using DGym.Domain.GymAggregate;
using DGym.Domain.ParticipantAggregate;
using DGym.Domain.RoomAggregate;
using DGym.Domain.SessionAggregate;
using DGym.Domain.SubscriptionAggregate;
using DGym.Domain.TrainerAggregate;
using Microsoft.EntityFrameworkCore;

namespace DGym.Infrastructure;

public class DGymDbContext : DbContext
{
    public DbSet<Subscription> Subscriptions { get; set; } = null!;
    public DbSet<Gym> Gyms { get; set; } = null!;
    public DbSet<Room> Rooms { get; set; } = null!;
    public DbSet<Session> Sessions { get; set; } = null!;
    public DbSet<Trainer> Trainers { get; set; } = null!;
    public DbSet<Participant> Participants { get; set; } = null!;
    public DbSet<Admin> Admins { get; set; } = null!;

    public DGymDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}