﻿
using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class Person
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
}
