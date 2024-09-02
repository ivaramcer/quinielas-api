using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class Country
    {
        public int Id { get; set; }
        [Required]

        public string Name { get; set; } = string.Empty;
        [Required]

        public string ISOCode { get; set; } = string.Empty; // Código ISO 3166-1 alpha-2 o alpha-3

        public ICollection<State> States { get; set; } = default!;
    }
}
