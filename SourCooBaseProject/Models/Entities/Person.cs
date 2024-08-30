
namespace QuinielasApi.Models.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Lastname { get; set; } = default!;
        public string Gender { get; set; } = default!;
        public DateTime DateOfBirthday { get; set; }
        public int? AddressId { get; set; }
        public Address? Address { get; set; }

    }
}
