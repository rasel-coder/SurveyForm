
namespace SurveyForm.Data;

public partial class Like
{
    public int LikeId { get; set; }

    public int? TemplateId { get; set; }

    public string? UserId { get; set; }

    public DateTime? LikedDate { get; set; }

    public virtual Template? Template { get; set; } = null;
}
