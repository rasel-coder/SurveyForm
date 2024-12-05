using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SurveyForm.Data;

public class ApplicationUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? RoleName { get; set; }
    public DateTime LastLoggedIn { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
}
