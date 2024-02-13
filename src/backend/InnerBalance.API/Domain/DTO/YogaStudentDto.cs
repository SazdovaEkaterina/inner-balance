using InnerBalance.API.Domain.Enums;

namespace InnerBalance.API.Domain.DTO;

public class YogaStudentDto : UserDto
{
    public Membership Membership { get; set; }
    public List<int> ClassesParticipating { get; set; } = new List<int>();
}