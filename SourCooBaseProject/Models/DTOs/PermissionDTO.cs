using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class PermissionDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public string Name { get; set; } = default!;
        [Required]

        public string Description { get; set; } = default!;

    }
    
    public class PermissionInsertDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public string Name { get; set; } = default!;
        [Required]

        public string Description { get; set; } = default!;

    }
    
    public class PermissionUpdateDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public string Name { get; set; } = default!;
        [Required]

        public string Description { get; set; } = default!;

    }
}
