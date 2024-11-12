using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class PreferenceDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserDTO User { get; set; } = default!;
        public int SportId { get; set; }
        public SportDTO Sport { get; set; } = default!;

        public int TeamId { get; set; }
        public TeamDTO Team { get; set; } = default!;
    }
    
    public class PreferenceInsertDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserInsertDTO User { get; set; } = default!;
        public int SportId { get; set; }
        public SportInsertDTO Sport { get; set; } = default!;

        public int TeamId { get; set; }
        public TeamInsertDTO Team { get; set; } = default!;
    }
    
    public class PreferenceUpdateDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserUpdateDTO User { get; set; } = default!;
        public int SportId { get; set; }
        public SportUpdateDTO Sport { get; set; } = default!;

        public int TeamId { get; set; }
        public TeamUpdateDTO Team { get; set; } = default!;
    }
    
    public class PreferenceBulkDTO
    {
        public int UserId { get; set; }
        public int SportId { get; set; }

        public List<int> TeamsId { get; set; } = default!;
    }
}
