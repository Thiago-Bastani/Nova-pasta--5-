using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Goal
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Task> Tasks { get; } = new List<Task>();
}