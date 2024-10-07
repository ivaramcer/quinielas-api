using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class PreferenceDTO
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? NFLTeamId { get; set; }
        public NFLTeam? NFLTeam { get; set; } = default!;
        public int? SoccerTeamId { get; set; }
        public SoccerTeam? SoccerTeam { get; set; } = default!;
    }
}
