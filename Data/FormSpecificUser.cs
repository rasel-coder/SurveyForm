
namespace SurveyForm.Data;

public partial class FormSpecificUser
{
    public FormSpecificUser()
    {
        Template = new Template();
    }

    public int FormSpecificUserId { get; set; }

    public string? UserId { get; set; }

    public int? TemplateId { get; set; }

    public virtual Template? Template { get; set; }
}
