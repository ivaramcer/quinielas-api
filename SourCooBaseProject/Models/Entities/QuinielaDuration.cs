using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class QuinielaDuration
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public int QuinielaTypeId { get; set; }
        public virtual QuinielaType QuinielaType { get; set; } = default!;
        public virtual ICollection<QuinielaPickDuration> QuinielaPickDurations { get; set; } = new List<QuinielaPickDuration>();
    }
}
