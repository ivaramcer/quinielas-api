using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class QuinielaDurationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int QuinielaTypeId { get; set; }
        public virtual QuinielaType QuinielaType { get; set; } = default!;
        public virtual ICollection<QuinielaPickDuration> QuinielaPickDurations { get; set; } = new List<QuinielaPickDuration>();
    }
}
