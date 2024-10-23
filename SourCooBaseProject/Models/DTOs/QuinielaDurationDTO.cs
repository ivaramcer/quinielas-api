using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class QuinielaDurationDTO
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
    public class QuinielaDurationInsertDTO
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
    public class QuinielaDurationUpdateDTO
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
