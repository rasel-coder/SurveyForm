
namespace SurveyForm.Data;

public partial class TemplateSpecificUser
{
    public TemplateSpecificUser()
    {
        Template = new Template();
    }

    public int TemplateSpecificUserId { get; set; }

    public string? UserId { get; set; }

    public int? TemplateId { get; set; }

    public virtual Template? Template { get; set; }
}
