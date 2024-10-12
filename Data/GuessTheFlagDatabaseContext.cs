using _2024_b1_individueel.Models;
using Microsoft.EntityFrameworkCore;

namespace _2024_b1_individueel.Data;

/// <summary>
/// DatabaseContext class to be used to connect to the database using Entity Framework Core.
/// </summary>
public class GuessTheFlagDatabaseContext : DbContext
{
    public DbSet<Flag> FlagSet { get; set; }
    public DbSet<FlagDeck> FlagDeckSet { get; set; }
    public DbSet<Score> ScoreSet { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connection =
            @"Data Source=.;Initial Catalog=GuessTheFlag;Integrated Security=true;TrustServerCertificate=true;";

        optionsBuilder.UseSqlServer(connection);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) { }
}
