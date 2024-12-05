using System.ComponentModel.DataAnnotations;

namespace SurveyForm.Utility;

public static class Enums
{
    public enum AppRoleEnums
    {
        Admin = 1,
        User = 2,
        Anynomous = 3
    }

    public enum TemplateQuestionTypeEnum
    {
        [Display(Name = "Single Line")]
        Single_Line = 1,

        [Display(Name = "Multiple Line")]
        Multiple_Line = 2,

        [Display(Name = "Positive Integer")]
        Positive_Integer = 3,

        [Display(Name = "Checkbox")]
        Checkbox = 4,
    }

    public enum TemplateSpecificUser
    {
        [Display(Name = "Only Me")]
        Only_Me = 1,

        [Display(Name = "Authenticated Users")]
        Authenticated_User = 2,

        [Display(Name = "Specified Users")]
        Specified_User = 3,
    }
}
