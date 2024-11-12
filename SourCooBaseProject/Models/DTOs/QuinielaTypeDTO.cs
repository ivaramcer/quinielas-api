using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class QuinielaTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public virtual ICollection<QuinielaTypeConfigurationDTO> QuinielaTypeConfigurations { get; set; } = new List<QuinielaTypeConfigurationDTO>();
        public virtual ICollection<QuinielaDurationDTO> QuinielaDurations { get; set; } = new List<QuinielaDurationDTO>();
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


        public virtual ICollection<QuinielaTypeConfigurationInsertDTO> QuinielaTypeConfigurations { get; set; } = new List<QuinielaTypeConfigurationInsertDTO>();

        public virtual ICollection<QuinielaDurationInsertDTO> QuinielaDurations { get; set; } = new List<QuinielaDurationInsertDTO>();
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


        public virtual ICollection<QuinielaTypeConfigurationUpdateDTO> QuinielaTypeConfigurations { get; set; } = new List<QuinielaTypeConfigurationUpdateDTO>();

        public virtual ICollection<QuinielaDurationUpdateDTO> QuinielaDurations { get; set; } = new List<QuinielaDurationUpdateDTO>();
    }
}
