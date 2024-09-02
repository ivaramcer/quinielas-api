using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class Preference
    {
        [Key]
        public int Id { get; set; }
        public int SportId { get; set; }
        public Sport Sport { get; set; } = default!;
        public int PersonId { get; set; }
        public Person Person { get; set; } = default!;
        public int SportTeamId { get; set; }
        public SportTeam SportTeam { get; set; } = default!;
    }
}
