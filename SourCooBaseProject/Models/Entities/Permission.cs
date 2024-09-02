using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class Permission
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public string Name { get; set; } = default!;
        [Required]

        public string Description { get; set; } = default!;
        public IEnumerable<UserPermission> UserPermissions { get; set; } = default!;

    }
}
