using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class Role
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty!;
        [Required]

        public string Description { get; set; } = default!;

    }
}
