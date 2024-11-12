using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class QuinielaDurationDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public int QuinielaTypeId { get; set; }
        public virtual QuinielaTypeDTO QuinielaType { get; set; } = default!;
        public virtual ICollection<QuinielaPickDurationDTO> QuinielaPickDurations { get; set; } = new List<QuinielaPickDurationDTO>();
    }
    public class QuinielaDurationInsertDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public int QuinielaTypeId { get; set; }
        public virtual QuinielaTypeInsertDTO QuinielaType { get; set; } = default!;
        public virtual ICollection<QuinielaPickDurationInsertDTO> QuinielaPickDurations { get; set; } = new List<QuinielaPickDurationInsertDTO>();
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
        public virtual ICollection<QuinielaPickDurationUpdateDTO> QuinielaPickDurations { get; set; } = new List<QuinielaPickDurationUpdateDTO>();
    }
}
