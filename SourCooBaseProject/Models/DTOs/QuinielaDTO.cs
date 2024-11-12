using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class QuinielaDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public double? Price { get; set; }

        public bool IsActive { get; set; } = true;

        public string Code { get; set; } = string.Empty;

        public int QuotaPeople { get; set; }
        public int QuotaPeopleFilled { get; set; }
        public double? ViudaPrice { get; set; }
        public int? Week { get; set; }
        public string? Round { get; set; } = default!;

        public DateTime Created { get; set; } = DateTime.UtcNow;
        
        public int QuinielaPickDurationId { get; set; }

        public virtual QuinielaPickDurationDTO QuinielaPickDuration { get; set; } = default!;

        public int SportId { get; set; }
        public virtual SportDTO Sport { get; set; } = default!;
        public int StatusId { get; set; }
        public virtual StatusDTO Status { get; set; } = default!;

    }
    
    public class QuinielaDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Sport { get; set; }= string.Empty;
        public int Members { get; set; }
        public string QuinielaType { get; set; }= string.Empty;
        public string Code { get; set; }= string.Empty;
        public string League { get; set; }= string.Empty;
        public string Spots { get; set; }= string.Empty;
        public string Duration { get; set; }= string.Empty;
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

        public int LeagueId { get; set; }
        public int SportId { get; set; }
        public int StatusId { get; set; }

    }
    
    public class QuinielaUpdateDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public double? Price { get; set; }

        public bool IsActive { get; set; } = true;

        public string Code { get; set; } = string.Empty;

        public int QuotaPeople { get; set; }
        public double? ViudaPrice { get; set; }
        public int? Week { get; set; }
        public string? Round { get; set; } = default!;

        public DateTime Created { get; set; } = DateTime.UtcNow;
        
        public int QuinielaPickDurationId { get; set; }

        public virtual QuinielaPickDurationUpdateDTO QuinielaPickDuration { get; set; } = default!;

        public int SportId { get; set; }
        public virtual SportUpdateDTO Sport { get; set; } = default!;
        public int StatusId { get; set; }
        public virtual StatusUpdateDTO Status { get; set; } = default!;

    }
}
