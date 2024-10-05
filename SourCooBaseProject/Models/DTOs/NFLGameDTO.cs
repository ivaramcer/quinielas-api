using QuinielasApi.Utils.NFL.DTO;
using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class NFLGameDTO
    {
        [Key]
        public int Id { get; set; }
        public DateTime Schedule { get; set; }
        public string Venue { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string WeekString { get; set; } = string.Empty;
        public int Week { get; set; }

        public int HomeTeamId { get; set; }
        public NFLTeamDTO HomeTeam { get; set; } = default!;
        public int HomeScore { get; set; }

        public int AwayTeamId { get; set; }
        public NFLTeamDTO AwayTeam { get; set; } = default!;
        public int AwayScore { get; set; }


        public int? WinnerTeamId { get; set; }
        public NFLTeamDTO WinnerTeam { get; set; } = default!;
    }
}
