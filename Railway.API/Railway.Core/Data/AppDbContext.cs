using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Railway.Core.Data.Configurations;
using Railway.Core.Entities;

namespace Railway.Core.Data;

public class AppDbContext : IdentityDbContext<User>
{
    public DbSet<TrainType> TrainTypes { get; set; }

    public DbSet<Train> Trains { get; set; }

    public DbSet<Station> Stations { get; set; }

    public DbSet<StationTrack> StationTracks { get; set; }

    public DbSet<Locality> Localities { get; set; }

    public DbSet<Route> Routes { get; set; }

    public DbSet<CoachType> CoachTypes { get; set; }

    public DbSet<RouteDetail> RouteDetails { get; set; }

    public DbSet<RouteStop> RouteStops { get; set; }

    public DbSet<RouteSeat> RouteSeats { get; set; }

    public DbSet<Schedule> Schedule { get; set; }

    public DbSet<TicketType> TicketTypes { get; set; }

    public DbSet<Ticket> Tickets { get; set; }

    public DbSet<Option> Options { get; set; }

    public DbSet<TicketOption> TicketsOptions { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new CoachTypeConfiguration());
        modelBuilder.ApplyConfiguration(new TrainTypeConfiguration());
        modelBuilder.ApplyConfiguration(new TrainConfiguration());
        modelBuilder.ApplyConfiguration(new TrainTypeDetailConfiguration());
        modelBuilder.ApplyConfiguration(new LocalityConfiguration());
        modelBuilder.ApplyConfiguration(new StationConfiguration());
        modelBuilder.ApplyConfiguration(new StationTrackConfiguration());
        modelBuilder.ApplyConfiguration(new RouteConfiguration());
        modelBuilder.ApplyConfiguration(new RouteDetailConfiguration());
        modelBuilder.ApplyConfiguration(new RouteSeatConfiguration());
        modelBuilder.ApplyConfiguration(new RouteStopConfiguration());
        modelBuilder.ApplyConfiguration(new ScheduleConfiguration());
        modelBuilder.ApplyConfiguration(new OptionConfiguration());
        modelBuilder.ApplyConfiguration(new TicketTypeConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new TicketConfiguration());
        modelBuilder.ApplyConfiguration(new TicketOptionConfiguration());
    }
}
