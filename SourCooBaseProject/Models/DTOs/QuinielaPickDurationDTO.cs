using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class QuinielaPickDurationDTO
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public int QuinielaDurationId { get; set; }
        public virtual QuinielaDurationDTO QuinielaDuration { get; set; } = default!;
    }
    
    public class QuinielaPickDurationInsertDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public int QuinielaDurationId { get; set; }
        public virtual QuinielaDurationInsertDTO QuinielaDuration { get; set; } = default!;
    }
    
    public class QuinielaPickDurationUpdateDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public int QuinielaDurationId { get; set; }
        public virtual QuinielaDurationUpdateDTO QuinielaDuration { get; set; } = default!;
    }
}
