using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string ImageURL { get; set; } = string.Empty;
        public int SportId { get; set; }
        public Sport Sport { get; set; } = default!;
        public ICollection<Game> HomeGames { get; set; } = default!;
        public ICollection<Game> AwayGames { get; set; } = default!;
        public ICollection<Game> WinnerGames { get; set; } = default!;

    }
}
