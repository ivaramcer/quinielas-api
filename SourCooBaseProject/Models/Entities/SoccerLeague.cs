using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class SoccerLeague
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        
    }
}
