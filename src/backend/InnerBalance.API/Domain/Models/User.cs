using Microsoft.AspNetCore.Identity;

namespace InnerBalance.API.Domain.Models;

public class User : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}