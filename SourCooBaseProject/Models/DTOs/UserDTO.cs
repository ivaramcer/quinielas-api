

using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class UserDTO
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
    
    public class UserInsertDTO
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
    
    public class UserUpdateDTO
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
    
    public class UserForCreation
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public DateTime DateOfBirthday { get; set; }

    }
}
