using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class NFLTeamUpdateDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string? Abbreviation { get; set; } = string.Empty;
        [Required]
        public string City { get; set; } = string.Empty;
        [Required]
        public string ImageURL { get; set; } = string.Empty;
    }
}
