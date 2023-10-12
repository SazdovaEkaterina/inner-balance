using InnerBalance.API.Domain.Enums;

namespace InnerBalance.API.Domain.Models;

public class YogaStudent : User
{
    public Membership Membership { get; set; }
    public List<YogaClass> ClassesParticipating { get; set; } = new List<YogaClass>();
}