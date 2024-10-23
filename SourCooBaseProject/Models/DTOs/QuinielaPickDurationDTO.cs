using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class QuinielaPickDurationDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public int QuinielaDurationId { get; set; }
        public virtual QuinielaDuration QuinielaDuration { get; set; } = default!;
    }
    
    public class QuinielaPickDurationInsertDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public int QuinielaDurationId { get; set; }
        public virtual QuinielaDuration QuinielaDuration { get; set; } = default!;
    }
    
    public class QuinielaPickDurationUpdateDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public int QuinielaDurationId { get; set; }
        public virtual QuinielaDuration QuinielaDuration { get; set; } = default!;
    }
}
