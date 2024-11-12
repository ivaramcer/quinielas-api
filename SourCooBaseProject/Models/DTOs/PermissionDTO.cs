using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class PermissionDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

    }
    
    public class PermissionInsertDTO
    {
        public int Id { get; set; }
        [Required]

        public string Name { get; set; } = default!;
        [Required]

        public string Description { get; set; } = default!;

    }
    
    public class PermissionUpdateDTO
    {
        public int Id { get; set; }
        [Required]

        public string Name { get; set; } = default!;
        [Required]

        public string Description { get; set; } = default!;

    }
}
