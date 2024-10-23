using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class QuinielaDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public double? Price { get; set; }

        public bool IsActive { get; set; } = true;

        public string Code { get; set; }

        public int QuotaPeople { get; set; }
        public double? ViudaPrice { get; set; }
        public int? Week { get; set; }
        public string? Round { get; set; } = default!;

        public DateTime Created { get; set; } = DateTime.UtcNow;
        
        public int QuinielaPickDurationId { get; set; }

        public virtual QuinielaPickDuration QuinielaPickDuration { get; set; } = default!;

        public int SportId { get; set; }
        public virtual Sport Sport { get; set; } = default!;
        public int StatusId { get; set; }
        public virtual Status Status { get; set; } = default!;

    }
    
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
    
    public class QuinielaUpdateDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public double? Price { get; set; }

        public bool IsActive { get; set; } = true;

        public string Code { get; set; }

        public int QuotaPeople { get; set; }
        public double? ViudaPrice { get; set; }
        public int? Week { get; set; }
        public string? Round { get; set; } = default!;

        public DateTime Created { get; set; } = DateTime.UtcNow;
        
        public int QuinielaPickDurationId { get; set; }

        public virtual QuinielaPickDuration QuinielaPickDuration { get; set; } = default!;

        public int SportId { get; set; }
        public virtual Sport Sport { get; set; } = default!;
        public int StatusId { get; set; }
        public virtual Status Status { get; set; } = default!;

    }
}
