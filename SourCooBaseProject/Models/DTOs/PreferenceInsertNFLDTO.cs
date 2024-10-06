using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class PreferenceNFLInsertDTO
    {
        public int UserId { get; set; }
        public int SportId { get; set; }
        public int? NFLTeamId { get; set; }
    }
}
