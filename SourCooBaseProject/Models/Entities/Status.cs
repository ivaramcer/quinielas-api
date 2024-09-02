using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class Status
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(250)]
        public string Description { get; set; } = string.Empty;
    }
}
