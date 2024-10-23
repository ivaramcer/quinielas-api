using Microsoft.Build.Evaluation;
using System.ComponentModel.DataAnnotations;

namespace QuinielasApi.Models.Entities
{
    public class QuinielaTypeConfigurationDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public int OperationTypeId { get; set; }
        public OperationType OperationType { get; set; } = default!;
        [Required]
        [MaxLength(250)]
        public string Description { get; set; } = string.Empty;
        [Required]
        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(250)]
        public string Value { get; set; } = string.Empty;
        public int QuinielaTypeId  { get; set; }
        public QuinielaType QuinielaType { get; set; } = default!;

    }
    
    public class QuinielaTypeConfigurationInsertDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public int OperationTypeId { get; set; }
        public OperationType OperationType { get; set; } = default!;
        [Required]
        [MaxLength(250)]
        public string Description { get; set; } = string.Empty;
        [Required]
        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(250)]
        public string Value { get; set; } = string.Empty;
        public int QuinielaTypeId  { get; set; }
        public QuinielaType QuinielaType { get; set; } = default!;

    }
    
    public class QuinielaTypeConfigurationUpdateDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public int OperationTypeId { get; set; }
        public OperationType OperationType { get; set; } = default!;
        [Required]
        [MaxLength(250)]
        public string Description { get; set; } = string.Empty;
        [Required]
        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(250)]
        public string Value { get; set; } = string.Empty;
        public int QuinielaTypeId  { get; set; }
        public QuinielaType QuinielaType { get; set; } = default!;

    }
}
