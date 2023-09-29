using InnerBalance.API.Domain.Enums;

namespace InnerBalance.API.Domain.Models;

public class YogaClass
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Room Room { get; set; }
    public YogaStyle? YogaStyle { get; set; }
    public DifficultyLevel? DifficultyLevel { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public int? NumberOfSpots { get; set; }
    public YogaTeacher YogaTeacher { get; set; }
    public List<User> Participants { get; set; } = new List<User>();
}