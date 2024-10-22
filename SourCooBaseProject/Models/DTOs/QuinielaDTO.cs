using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class QuinielaDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public double Price { get; set; }
        public int QuotaPeople { get; set; }
        public DateTime Created { get; set; }
        public int QuinielaTypeId { get; set; }

    }
}
