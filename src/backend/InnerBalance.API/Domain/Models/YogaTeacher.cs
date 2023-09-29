using Microsoft.AspNetCore.Identity;

namespace InnerBalance.API.Domain.Models;

public class YogaTeacher : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Certification { get; set; } = string.Empty;
    public int YearsOfExperience { get; set; }
}