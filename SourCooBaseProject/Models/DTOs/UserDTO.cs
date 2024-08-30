using SourCooBaseProject.Models.Entities;

namespace BaseSourcoo.Models.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }

    public class UserForCreation
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirthday { get; set; }

    }
}