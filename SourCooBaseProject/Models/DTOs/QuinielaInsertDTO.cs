using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class QuinielaInsertDTO
    {
        
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty;

        public double? Price { get; set; }
        public double? ViudaPrice { get; set; }


        public bool IsActive { get; set; } = true;

        [Required(ErrorMessage = "QuotaPeople is required")]
        [Range(1, int.MaxValue, ErrorMessage = "QuotaPeople must be between 1 and 100")]        public int QuotaPeople { get; set; }
        public int? Week { get; set; }
        public string? Round { get; set; } = default!;

        
        public int QuinielaPickDurationId { get; set; }


        public int SportId { get; set; }
        public int StatusId { get; set; }

    }
}
