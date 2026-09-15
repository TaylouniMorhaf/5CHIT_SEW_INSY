using Microsoft.EntityFrameworkCore;

namespace BlazorConcurrencyCheck.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Ticket> Tickets { get; set; }
}
