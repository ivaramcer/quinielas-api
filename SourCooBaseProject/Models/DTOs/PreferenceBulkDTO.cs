using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class PreferenceBulkDTO
    {
        public int UserId { get; set; }
        public int SportId { get; set; }

        public List<int> TeamsId { get; set; }
    }
}
