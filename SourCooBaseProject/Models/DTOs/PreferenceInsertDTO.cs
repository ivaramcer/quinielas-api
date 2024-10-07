using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class PreferenceInsertDTO
    {
        public int UserId { get; set; }
        public int SportId { get; set; }

        public int? NFLTeamId { get; set; }
        public int? SoccerTeamId { get; set; }
    }
}
