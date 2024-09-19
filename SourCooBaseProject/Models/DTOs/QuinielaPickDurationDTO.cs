using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class QuinielaPickDurationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public int QuinielaDurationId { get; set; }
        public virtual QuinielaDuration QuinielaDuration { get; set; } = default!;
    }
}
