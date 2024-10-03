using QuinielasApi.Utils.NFL.DTO;
using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class GameDTO
    {
        [Key]
        public int Id { get; set; }
        public DateTime Schedule { get; set; }
        public string Venue { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string WeekString { get; set; } = string.Empty;
        public int Week { get; set; }

        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; } = default!;
        public int HomeScore { get; set; }

        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; } = default!;
        public int AwayScore { get; set; }


        public int? WinnerTeamId { get; set; }
        public Team WinnerTeam { get; set; } = default!;
    }
}
