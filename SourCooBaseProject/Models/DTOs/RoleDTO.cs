using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class RoleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty!;

        public string Description { get; set; } = default!;

    }
    
    public class RoleInsertDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty!;
        [Required]

        public string Description { get; set; } = default!;

    }
    
    public class RoleUpdateDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty!;
        [Required]

        public string Description { get; set; } = default!;

    }
}
