using QuinielasApi.Utils.NFL.DTO;
using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class NFLGameUpdateDTO
    {
        [Key]
        public int Id { get; set; }
        public DateTime Schedule { get; set; }
        public string Venue { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public int Week { get; set; }

        public int HomeNFLTeamId { get; set; }
        public NFLTeam HomeNFLTeam { get; set; } = default!;
        public int HomeScore { get; set; }

        public int AwayNFLTeamId { get; set; }
        public NFLTeam AwayNFLTeam { get; set; } = default!;
        public int AwayScore { get; set; }


        public int? WinnerNFLTeamId { get; set; }
        public NFLTeam WinnerNFLTeam { get; set; } = default!;
    }
}
