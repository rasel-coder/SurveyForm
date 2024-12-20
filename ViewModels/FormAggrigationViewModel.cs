namespace SurveyForm.ViewModels;

public partial class FormAggrigationViewModel
{
    public FormAggrigationViewModel()
    {
        Question = new QuestionViewModel();
        Answers = new List<AnswerViewModel>();
    }

    public virtual QuestionViewModel Question { get; set; }
    public virtual List<AnswerViewModel> Answers { get; set; }
}
