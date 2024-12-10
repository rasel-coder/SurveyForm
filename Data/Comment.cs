
namespace SurveyForm.Data;

public partial class Comment
{
    public int CommentId { get; set; }

    public int? TemplateId { get; set; }

    public string? UserId { get; set; }

    public string? CommentText { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;

    public virtual Template? Template { get; set; } = null;
}
