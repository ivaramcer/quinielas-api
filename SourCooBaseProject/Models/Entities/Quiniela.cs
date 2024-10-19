using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class Quiniela
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public double Price { get; set; }

        public bool IsActive { get; set; } = true;

        public string Code { get; set; }

        public int QuotaPeople { get; set; }
        public double ViudaPrice { get; set; }
        public int? Week { get; set; }
        public string? Round { get; set; } = default!;

        public DateTime Created { get; set; } = DateTime.UtcNow;
        
        public int QuinielaPickDurationId { get; set; }

        public virtual QuinielaPickDuration QuinielaPickDuration { get; set; } = default!;

        public int SportId { get; set; }
        public virtual Sport Sport { get; set; } = default!;
        public int StatusId { get; set; }
        public virtual Status Status { get; set; } = default!;
        public virtual ICollection<QuinielaConfiguration> QuinielaConfigurations { get; set; } = new List<QuinielaConfiguration>();


        public Quiniela()
        {
            Code = GenerateRandomCode();
        }

        private static string GenerateRandomCode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
