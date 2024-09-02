using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public int Number { get; set; }

        [Required]
        public string Street { get; set; } = string.Empty;
        [Required]

        public string ZipCode { get; set; } = string.Empty;

        public int CityId { get; set; }
        public City City { get; set; } = default!;
    }
}
