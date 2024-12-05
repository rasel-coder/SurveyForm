
namespace SurveyForm.Data;

public partial class Form
{
    public Form()
    {
        Template = new Template();
        Answers = new List<Answer>();
    }

    public int FormId { get; set; }

    public int? TemplateId { get; set; }

    public string? SubmittedBy { get; set; }

    public DateTime? SubmittedDate { get; set; }

    public virtual Template? Template { get; set; }

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();
}
