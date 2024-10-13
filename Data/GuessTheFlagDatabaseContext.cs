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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var europe = new FlagDeck() { Identifier = 1, Name = "Europa" };
        var northAmerica = new FlagDeck() { Identifier = 2, Name = "Noord-Amerika" };

        var netherlands = new Flag()
        {
            Identifier = 1,
            CountryCode = "nl",
            CorrectAnswer = "Nederland",
            FlagDeckIdentifier = europe.Identifier,
        };
        var belgium = new Flag()
        {
            Identifier = 2,
            CountryCode = "be",
            CorrectAnswer = "België",
            FlagDeckIdentifier = europe.Identifier,
        };
        var germany = new Flag()
        {
            Identifier = 3,
            CountryCode = "de",
            CorrectAnswer = "Duitsland",
            FlagDeckIdentifier = europe.Identifier,
        };

        var canada = new Flag()
        {
            Identifier = 4,
            CountryCode = "ca",
            CorrectAnswer = "Canada",
            FlagDeckIdentifier = northAmerica.Identifier,
        };
        var usa = new Flag()
        {
            Identifier = 5,
            CountryCode = "us",
            CorrectAnswer = "Verenigde Staten",
            FlagDeckIdentifier = northAmerica.Identifier,
        };

        var flagDecks = new List<FlagDeck>() { europe, northAmerica };
        var flags = new List<Flag>() { netherlands, belgium, germany, canada, usa };

        foreach (var flagDeck in flagDecks)
        {
            modelBuilder.Entity<FlagDeck>().HasData(flagDeck);
        }

        foreach (var flag in flags)
        {
            modelBuilder.Entity<Flag>().HasData(flag);
        }

        modelBuilder
            .Entity<Score>()
            .HasData(
                new Score()
                {
                    Identifier = 1,
                    AchievedBy = "Jordy",
                    AchievedScore = 2,
                    FlagDeckIdentifier = europe.Identifier,
                }
            );
    }
}
