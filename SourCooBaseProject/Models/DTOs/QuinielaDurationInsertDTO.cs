using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class QuinielaDurationInsertDTO
    {

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int QuinielaTypeId { get; set; }

    }
}
