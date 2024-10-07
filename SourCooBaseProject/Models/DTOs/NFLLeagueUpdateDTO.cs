using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class NFLLeagueUpdateDTO
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string ImageURL { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        
    }
}
