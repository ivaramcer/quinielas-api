
using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class PersonDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public string Name { get; set; } = default!;
        [Required]

        public string Lastname { get; set; } = default!;
        [Required]

        public string Gender { get; set; } = default!;

        public DateTime DateOfBirthday { get; set; }


    }
    
    public class PersonInsertDTO
    {
        [Key]
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
        [Key]
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
