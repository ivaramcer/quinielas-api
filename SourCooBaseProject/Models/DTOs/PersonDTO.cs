
using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class PersonDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public string Lastname { get; set; } = default!;
        public string Gender { get; set; } = default!;

        public DateTime DateOfBirthday { get; set; }


    }
    
    public class PersonInsertDTO
    {
        public int Id { get; set; }
        [Required]

        public string Name { get; set; } = default!;
        [Required]

        public string Lastname { get; set; } = default!;
        [Required]

        public string Gender { get; set; } = default!;

        public DateTime DateOfBirthday { get; set; }


    }
    
    public class PersonUpdateDTO
    {
        public int Id { get; set; }
        [Required]

        public string Name { get; set; } = default!;
        [Required]

        public string Lastname { get; set; } = default!;
        [Required]

        public string Gender { get; set; } = default!;

        public DateTime DateOfBirthday { get; set; }


    }
    
    public class PersonNameDTO
    {
        public string Name { get; set; } = default!;
        public string Lastname { get; set; } = default!;
    }
}
