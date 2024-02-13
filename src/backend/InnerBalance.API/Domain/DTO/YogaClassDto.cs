using InnerBalance.API.Domain.Enums;

namespace InnerBalance.API.Domain.DTO;

public class YogaClassDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; } = string.Empty;
    public int? Room { get; set; }
    public int? Style { get; set; }
    public DifficultyLevel DifficultyLevel { get; set; } = DifficultyLevel.Beginner;
    public DateOnly Date { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public int NumberOfSpots { get; set; }
    public string? TeacherId { get; set; }
    public List<string> ParticipantsIds { get; set; } = new();
}