using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class State
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string ISOCode { get; set; } = string.Empty;// Código ISO 3166-2

        public int CountryId { get; set; }
        public Country Country { get; set; } = default!;

        public List<City> Cities { get; set; } = default!;
    }
}
