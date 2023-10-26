using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InnerBalance.API.Domain.Enums;

namespace InnerBalance.API.Domain.Models;

public class YogaClass
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Room? Room { get; set; }
    public Style? Style { get; set; }
    public DifficultyLevel? DifficultyLevel { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public int? NumberOfSpots { get; set; }
    public YogaTeacher? Teacher { get; set; }
    public List<YogaStudent> Participants { get; set; } = new List<YogaStudent>();
}