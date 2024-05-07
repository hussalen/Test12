using System.ComponentModel.DataAnnotations;

public record Project
{
    [Required]
    public int IdProject { get; set; }

    [Required]
    public string Name { get; set; }
    [Required]
    public DateOnly Deadline { get; set; }
} 