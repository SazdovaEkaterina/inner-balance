namespace InnerBalance.API.Domain.Models;

public class YogaTeacher : User
{
    public string Certification { get; set; } = string.Empty;
    public int YearsOfExperience { get; set; }
    public List<YogaClass> ClassesTeaching { get; set; } = new List<YogaClass>();
}