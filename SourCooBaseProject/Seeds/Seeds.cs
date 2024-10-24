using Microsoft.EntityFrameworkCore;
using QuinielasApi.Models.Entities;

public static class ModelBuilderExtensions
{
    
    public static void SeedStatus(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Status>().HasData(
            new Status { Id = 1, Name = "Public", Description = "Everyone has access!" },
            new Status { Id = 2, Name = "Private", Description = "Selected people has access!" }
        );
    }
    
    public static void SeedRole(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>().HasData(
            new Role { Id = 1, Name = "User", Description = "Regular user" },
            new Role { Id = 2, Name = "Administrator", Description = "User with privileges" }
        );
    }

    public static void SeedSport(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sport>().HasData(
            new Sport { Id = 1, Name = "Soccer", Description = "Soccer, also known as football, is a team sport where two teams of eleven players compete to score goals by kicking a ball" },
            new Sport { Id = 2, Name = "NFL", Description = "The NFL (National Football League) is a professional American football league consisting of 32 teams." }
        );
    }

    public static void SeedQuinielaType(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<QuinielaType>().HasData(
            new QuinielaType { Id = 1, Name = "Regular", Description = "Participants predict the outcomes of multiple sports matches or races." },
            new QuinielaType { Id = 2, Name = "Survivor", Description = "A survivor-type quiniela involves picking a winner for each round, with elimination upon incorrect predictions until one remains." },
            new QuinielaType { Id = 3, Name = "Spread", Description = "A spread-type quiniela requires predicting the point difference (spread) between teams, not just the match winner." }
        );
    }

    public static void SeedQuinielaDuration(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<QuinielaDuration>().HasData(
            new QuinielaDuration { Id = 1, Name = "Round", Description = "Participants predict outcomes for that specific set of matches or events.", QuinielaTypeId = 1 },
            new QuinielaDuration { Id = 2, Name = "Season", Description = "Participants predicting outcomes across multiple rounds or events throughout the season.", QuinielaTypeId = 1 },
            new QuinielaDuration { Id = 3, Name = "Custom", Description = "Allows participants to choose specific matches.", QuinielaTypeId = 1 },
            new QuinielaDuration { Id = 4, Name = "Season", Description = "Participants predicting outcomes across multiple rounds or events throughout the season.", QuinielaTypeId = 2 },
            new QuinielaDuration { Id = 5, Name = "Round", Description = "Participants predict outcomes for that specific set of matches or events.", QuinielaTypeId = 3 },
            new QuinielaDuration { Id = 6, Name = "Season", Description = "Participants predicting outcomes across multiple rounds or events throughout the season.", QuinielaTypeId = 3 },
            new QuinielaDuration { Id = 7, Name = "Custom", Description = "Allows participants to choose specific matches.", QuinielaTypeId = 3 }
        );
    }

    public static void SeedQuinielaPickDuration(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<QuinielaPickDuration>().HasData(
            // QuinielaDurationId 1
            new QuinielaPickDuration { Id = 1, Name = "Before first game", QuinielaDurationId = 1, Value = "beforeFirst" },
            new QuinielaPickDuration { Id = 2, Name = "Before each game", QuinielaDurationId = 1, Value = "beforeEach" },

            // QuinielaDurationId 2
            new QuinielaPickDuration { Id = 3, Name = "Before first game", QuinielaDurationId = 2, Value = "beforeFirst" },
            new QuinielaPickDuration { Id = 4, Name = "Before each game", QuinielaDurationId = 2, Value = "beforeEach" },

            // QuinielaDurationId 3
            new QuinielaPickDuration { Id = 5, Name = "Before first game", QuinielaDurationId = 3, Value = "beforeFirst" },
            new QuinielaPickDuration { Id = 6, Name = "Before each game", QuinielaDurationId = 3, Value = "beforeEach" },

            // QuinielaDurationId 4 - Use ordinal names
            new QuinielaPickDuration { Id = 7, Name = "First", QuinielaDurationId = 4, Value = "viudaOne" },
            new QuinielaPickDuration { Id = 8, Name = "Second", QuinielaDurationId = 4, Value = "viudaTwo" },
            new QuinielaPickDuration { Id = 9, Name = "Third", QuinielaDurationId = 4, Value = "viudaThree" },
            new QuinielaPickDuration { Id = 10, Name = "Fourth", QuinielaDurationId = 4, Value = "viudaFour" },
            new QuinielaPickDuration { Id = 11, Name = "Fifth", QuinielaDurationId = 4, Value = "viudaFive" },
            new QuinielaPickDuration { Id = 12, Name = "Sixth", QuinielaDurationId = 4, Value = "viudaSix" },
            new QuinielaPickDuration { Id = 13, Name = "Seventh", QuinielaDurationId = 4, Value = "viudaSeven" },
            new QuinielaPickDuration { Id = 14, Name = "Eighth", QuinielaDurationId = 4, Value = "viudaEight" },
            new QuinielaPickDuration { Id = 15, Name = "Ninth", QuinielaDurationId = 4, Value = "viudaNine" },
            new QuinielaPickDuration { Id = 16, Name = "Tenth", QuinielaDurationId = 4, Value = "viudaTen" },
            new QuinielaPickDuration { Id = 17, Name = "Eleventh", QuinielaDurationId = 4, Value = "viudaEleven" },
            new QuinielaPickDuration { Id = 18, Name = "Twelfth", QuinielaDurationId = 4, Value = "viudaTwelve" },
            new QuinielaPickDuration { Id = 19, Name = "Thirteenth", QuinielaDurationId = 4, Value = "viudaThirteen" },
            new QuinielaPickDuration { Id = 20, Name = "Fourteenth", QuinielaDurationId = 4, Value = "viudaFourteen" },
            new QuinielaPickDuration { Id = 21, Name = "Fifteenth", QuinielaDurationId = 4, Value = "viudaFifteen" },
            new QuinielaPickDuration { Id = 22, Name = "Sixteenth", QuinielaDurationId = 4, Value = "viudaSixteen" },
            new QuinielaPickDuration { Id = 23, Name = "Seventeenth", QuinielaDurationId = 4, Value = "viudaSeventeen" },
            new QuinielaPickDuration { Id = 24, Name = "Eighteenth", QuinielaDurationId = 4, Value = "viudaEighteen" },
            new QuinielaPickDuration { Id = 25, Name = "Nineteenth", QuinielaDurationId = 4, Value = "viudaNineteen" },
            new QuinielaPickDuration { Id = 26, Name = "Twentieth", QuinielaDurationId = 4, Value = "viudaTwenty" },

            // QuinielaDurationId 5
            new QuinielaPickDuration { Id = 27, Name = "Before first game", QuinielaDurationId = 5, Value = "beforeFirst" },
            new QuinielaPickDuration { Id = 28, Name = "Before each game", QuinielaDurationId = 5, Value = "beforeEach" },

            // QuinielaDurationId 6
            new QuinielaPickDuration { Id = 29, Name = "Before first game", QuinielaDurationId = 6, Value = "beforeFirst" },
            new QuinielaPickDuration { Id = 30, Name = "Before each game", QuinielaDurationId = 6, Value = "beforeEach" },

            // QuinielaDurationId 7
            new QuinielaPickDuration { Id = 31, Name = "Before first game", QuinielaDurationId = 7, Value = "beforeFirst" },
            new QuinielaPickDuration { Id = 32, Name = "Before each game", QuinielaDurationId = 7, Value = "beforeEach" }
        );
    }



}