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
        public string Code { get; set; } = GenerateRandomCode();
        public int QuotaPeople { get; set; }
        public DateTime Created { get; set; }
        public int QuinielaTypeId { get; set; }
        public QuinielaType QuinielaType { get; set; } = default!;
        public int StatusId { get; set; }
        public Status Status{ get; set; } = default!;


        private static string GenerateRandomCode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
