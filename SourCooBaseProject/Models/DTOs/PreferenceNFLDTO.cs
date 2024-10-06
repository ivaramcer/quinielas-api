using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class PreferenceNFLDTO
    {
        [Key]
        public int Id { get; set; }
        public int? NFLTeamId { get; set; }
        public NFLTeam? NFLTeam { get; set; } = default!;
    }
}
