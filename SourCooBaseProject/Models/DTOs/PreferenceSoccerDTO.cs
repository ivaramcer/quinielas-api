using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class PreferenceSoccerDTO
    {
        [Key]
        public int Id { get; set; }
        public int? SoccerTeamId { get; set; }
        public SoccerTeam? SoccerTeam { get; set; } = default!;
    }
}
