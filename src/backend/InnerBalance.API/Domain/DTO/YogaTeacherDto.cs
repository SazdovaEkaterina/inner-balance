namespace InnerBalance.API.Domain.DTO;

public class YogaTeacherDto : UserDto
{
    public string Certification { get; set; } = string.Empty;
    public int YearsOfExperience { get; set; }
    public List<int> ClassesTeaching { get; set; } = new();
}