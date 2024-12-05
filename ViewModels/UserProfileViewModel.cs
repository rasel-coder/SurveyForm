using Microsoft.AspNetCore.Identity;

namespace SurveyForm.ViewModels;

public class UserProfileViewModel : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? RoleName { get; set; }

    public bool? IsDeleted { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
