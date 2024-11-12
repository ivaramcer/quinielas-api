using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty!;

        public string Description { get; set; } = default!;

    }
}
