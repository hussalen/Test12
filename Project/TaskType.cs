using System.ComponentModel.DataAnnotations;

public record TaskType
{
    [Required]
    public int IdTaskType { get; set; }

    [Required]
    public string Name { get; set; }

} 