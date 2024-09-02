using QuinielasApi.Models.Entities;

namespace QuinielasApi.Models.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
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