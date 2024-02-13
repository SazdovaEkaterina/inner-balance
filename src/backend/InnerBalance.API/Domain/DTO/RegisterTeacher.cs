using System.ComponentModel.DataAnnotations;

namespace InnerBalance.API.Domain.DTO;

public class RegisterTeacher
{
    [Required(ErrorMessage = "First Name is required")]  
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last Name is required")]  
    public string LastName { get; set; }

    [Required(ErrorMessage = "User Name is required")]  
    public string UserName { get; set; }  

    [EmailAddress]  
    [Required(ErrorMessage = "Email is required")]  
    public string Email { get; set; }  
    
    public string Certification { get; set; }  
    
    public int YearsOfExperience { get; set; }  

    [Required(ErrorMessage = "Password is required")]  
    public string Password { get; set; }
}