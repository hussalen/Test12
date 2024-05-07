using System.ComponentModel.DataAnnotations;

public record TeamMember
{
    [Required]
    public int IdTeamMember { get; set; }

    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Email { get; set; }

    public List<Task> tasks {get; set;}
} 