
namespace SurveyForm.Data;

public partial class Comment
{
    public Comment()
    {
        Template = new Template();
    }

    public int CommentId { get; set; }

    public int? TemplateId { get; set; }

    public int? UserId { get; set; }

    public string? CommentText { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Template? Template { get; set; }
}
