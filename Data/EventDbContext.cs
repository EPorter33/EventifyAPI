using Microsoft.EntityFrameworkCore;
using EventifyAPI.Models;

namespace EventifyAPI.Data;

public class EventifyDbContext : DbContext
{
    public EventifyDbContext(DbContextOptions<EventifyDbContext> options)
        : base(options)
    {
    }

    public DbSet<EventItem> Events { get; set; } = null!;
}