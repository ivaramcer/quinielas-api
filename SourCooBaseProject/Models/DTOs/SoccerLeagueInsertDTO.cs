using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class SoccerLeagueInsertDTO
    {
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        
    }
}
