using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class SoccerGameUpdateDTO
    {
        public int Id { get; set; }
        public DateTime Schedule { get; set; }
        public string Venue { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public int? Round { get; set; }
        public string RoundName { get; set; } = string.Empty;

        public int HomeTeamId { get; set; }
        public SoccerTeam HomeTeam { get; set; } = default!;
        public int HomeScore { get; set; }

        public int AwayTeamId { get; set; }
        public SoccerTeam AwayTeam { get; set; } = default!;
        public int AwayScore { get; set; }


        public int? WinnerTeamId { get; set; }
        public SoccerTeam WinnerTeam { get; set; } = default!;

        public bool IsDraw { get; set; }
    }
}
