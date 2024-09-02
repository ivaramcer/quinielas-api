using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class SportTeam
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string ImageURL { get; set; } = string.Empty;
        public int SportId { get; set; }
        public Sport Sport { get; set; } = default!;
    }
}
