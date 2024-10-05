using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class NFLGame
    {
        [Key]
        public int Id { get; set; }
        public DateTime Schedule { get; set; }
        public string Venue { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public int? Week { get; set; }
        public string WeekString { get; set; } = string.Empty;

        public int HomeTeamId { get; set; }
        public NFLTeam HomeTeam { get; set; } = default!;
        public int HomeScore { get; set; }

        public int AwayTeamId { get; set; }
        public NFLTeam AwayTeam { get; set; } = default!;
        public int AwayScore { get; set; }


        public int? WinnerTeamId { get; set; }
        public NFLTeam WinnerTeam { get; set; } = default!;
    }
}
