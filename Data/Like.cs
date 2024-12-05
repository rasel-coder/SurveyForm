
namespace SurveyForm.Data;

public partial class Like
{
    public Like()
    {
        Template = new Template();
    }

    public int LikeId { get; set; }

    public int? TemplateId { get; set; }

    public int? UserId { get; set; }

    public DateTime? LikedAt { get; set; }

    public virtual Template? Template { get; set; }
}
