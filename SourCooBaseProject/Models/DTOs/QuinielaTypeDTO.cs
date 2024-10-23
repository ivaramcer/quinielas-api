using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class QuinielaTypeDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(250)]
        public string Description { get; set; } = string.Empty;


        public virtual ICollection<QuinielaTypeConfiguration> QuinielaTypeConfigurations { get; set; } = new List<QuinielaTypeConfiguration>();

        public virtual ICollection<QuinielaDuration> QuinielaDurations { get; set; } = new List<QuinielaDuration>();
    }
    
    public class QuinielaTypeInsertDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(250)]
        public string Description { get; set; } = string.Empty;


        public virtual ICollection<QuinielaTypeConfiguration> QuinielaTypeConfigurations { get; set; } = new List<QuinielaTypeConfiguration>();

        public virtual ICollection<QuinielaDuration> QuinielaDurations { get; set; } = new List<QuinielaDuration>();
    }
    
    public class QuinielaTypeUpdateDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(250)]
        public string Description { get; set; } = string.Empty;


        public virtual ICollection<QuinielaTypeConfiguration> QuinielaTypeConfigurations { get; set; } = new List<QuinielaTypeConfiguration>();

        public virtual ICollection<QuinielaDuration> QuinielaDurations { get; set; } = new List<QuinielaDuration>();
    }
}
