using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class Sport
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;

    }
}
