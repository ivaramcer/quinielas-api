using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class PreferenceSoccerInsertDTO
    {
        public int UserId { get; set; }
        public int SportId { get; set; }
        public int? SoccerTeamId { get; set; }
    }
}
