using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class City
    {
        public int Id { get; set; }
        [Required]

        public string Name { get; set; } = string.Empty;

        public int StateId { get; set; }
        public State State { get; set; } = default!;

    }
}
