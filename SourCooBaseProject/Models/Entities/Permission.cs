using System.ComponentModel.DataAnnotations;

namespace SourCooBaseProject.Models.Entities
{
    public class Permission
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public List<UserPermission> UserPermissions { get; set; } = default!;

    }
}
