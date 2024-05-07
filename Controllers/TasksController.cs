using System.Data;
using Microsoft.AspNetCore.Mvc;

namespace Test1.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly DatabaseManager _dbManager;
    public TasksController(DatabaseManager dbManager )
    {
        _dbManager = dbManager;
    }

    [HttpGet("{id}")]
    public IActionResult Get(int teamMemberId)
    {
        string query = "SELECT Task.Name, Task.Description, Task.Deadline, Project.Name, TeamMember.IdTeamMember, TeamMember.FirstName, TeamMember.LastName, TeamMember.Email  FROM Task" 
        +" INNER JOIN TeamMember ON Task.IdCreator = TeamMember.IdTeamMember"
        +" INNER JOIN Project ON Task.IdProject = Project.IdProject"
        +$" WHERE Task.IdCreator = {teamMemberId} and Task.IdAssignedTo = {teamMemberId}"
        +" ORDER BY Task.Deadline DESC";

        try
        {
            DataTable results = _dbManager.ExecuteQuery(query);
            return Ok(results);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Member not found: " + ex.Message);
        }
    }

    [HttpPut]
    public IActionResult Add(Task task)
    {
        string queryGetLastId = "SELECT TOP 1 IdTask FROM Task ORDER BY IdTask DESC";
        DataTable idRes;
        //if (queryGetLastId is not null) idRes = _dbManager.ExecuteQuery(queryGetLastId).Columns[0];
        //string query = $"INSERT Task (IdTask, Name, Description, Deadline, IdProject, IdTaskType, IdAssignedTo, IdCreator) VALUES ({(int)++idRes}, {task.Name}, {task.Description}, {task.Deadline}, {task.project.IdProject}, {task.taskType.IdTaskType}, {task.IdAssignedTo}, {task.IdCreator})";
        return null;
    }
}
