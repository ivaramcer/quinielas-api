using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class QuinielaTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public virtual ICollection<QuinielaTypeConfiguration> QuinielaTypeConfigurations { get; set; } = new List<QuinielaTypeConfiguration>();
        public virtual ICollection<QuinielaDuration> QuinielaDurations { get; set; } = new List<QuinielaDuration>();
    }
}
