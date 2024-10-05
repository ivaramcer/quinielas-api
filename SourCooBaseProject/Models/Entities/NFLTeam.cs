using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class NFLTeam
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string? Abbreviation { get; set; } = string.Empty;
        [Required]
        public string City { get; set; } = string.Empty;
        [Required]
        public string ImageURL { get; set; } = string.Empty;
        public int NFLLeagueId { get; set; }
        public NFLLeague NFLLeague { get; set; } = default!;
        public ICollection<NFLGame> HomeGames { get; set; } = default!;
        public ICollection<NFLGame> AwayGames { get; set; } = default!;
        public ICollection<NFLGame> WinnerGames { get; set; } = default!;
    }
}
