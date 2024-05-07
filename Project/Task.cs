using System.ComponentModel.DataAnnotations;

public record Task
{
    public int Id {get; set;}
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }

    [Required]
    public DateOnly Deadline { get; set; }

    public TaskType taskType {get; set;}

    public Project project {get; set;}
    public int IdAssignedTo {get; set;}
    public int IdCreator {get; set;}
} 