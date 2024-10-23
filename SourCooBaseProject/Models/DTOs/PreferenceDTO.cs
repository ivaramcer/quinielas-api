using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class PreferenceDTO
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = default!;
        public int SportId { get; set; }
        public Sport Sport { get; set; } = default!;

        public int TeamId { get; set; }
        public Team Team { get; set; } = default!;
    }
    
    public class PreferenceInsertDTO
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = default!;
        public int SportId { get; set; }
        public Sport Sport { get; set; } = default!;

        public int TeamId { get; set; }
        public Team Team { get; set; } = default!;
    }
    
    public class PreferenceUpdateDTO
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = default!;
        public int SportId { get; set; }
        public Sport Sport { get; set; } = default!;

        public int TeamId { get; set; }
        public Team Team { get; set; } = default!;
    }
    
    public class PreferenceBulkDTO
    {
        public int UserId { get; set; }
        public int SportId { get; set; }

        public List<int> TeamsId { get; set; }
    }
}
