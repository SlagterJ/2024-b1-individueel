using Microsoft.EntityFrameworkCore;

namespace _2024_b1_individueel.Data;

/// <summary>
/// DatabaseContext class to be used to connect to the database using Entity Framework Core.
/// </summary>
public class GuessTheFlagDatabaseContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connection =
            @"Data Source=.;Initial Catalog=GuessTheFlag;Integrated Security=true;TrustServerCertificate=true;";

        optionsBuilder.UseSqlServer(connection);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) { }
}
