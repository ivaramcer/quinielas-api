

using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; } = default!;
        [Required]

        public string Password { get; set; } = default!;
        public int RoleId { get; set; }
        public Role Role { get; set; } = default!;
        public int PersonId { get; set; }
        public Person Person { get; set; } = default!;
    }
}
