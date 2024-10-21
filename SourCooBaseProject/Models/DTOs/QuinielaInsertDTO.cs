using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class QuinielaInsertDTO
    {
        public string Name { get; set; } = string.Empty;

        public double Price { get; set; }

        public bool IsActive { get; set; } = true;


        public int QuotaPeople { get; set; }
        public int? Week { get; set; }
        public string? Round { get; set; } = default!;

        
        public int QuinielaPickDurationId { get; set; }


        public int SportId { get; set; }
        public int StatusId { get; set; }


    }
}
