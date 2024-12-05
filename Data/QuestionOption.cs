
namespace SurveyForm.Data;

public partial class QuestionOption
{
    public QuestionOption()
    {
        Question = new Question();
    }

    public int QuestionOptionId { get; set; }

    public int? QuestionId { get; set; }

    public string? OptionName { get; set; }

    public bool? IsCorrectAnswer { get; set; }

    public virtual Question? Question { get; set; }
}
