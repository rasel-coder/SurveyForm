using System;
using System.Collections.Generic;

namespace SurveyForm.ViewModels;

public partial class FormViewModel
{
    public FormViewModel()
    {
        Questions = new List<QuestionViewModel>();
        Answers = new List<AnswerViewModel>();
    }

    public int FormId { get; set; }
    public int TemplateId { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Image { get; set; } = null!;
    public string? UserId { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public DateTime SubmittedDate { get; set; }

    public virtual IEnumerable<QuestionViewModel> Questions { get; set; } = new List<QuestionViewModel>();
    public virtual IEnumerable<AnswerViewModel> Answers { get; set; } = new List<AnswerViewModel>();
    public virtual TemplateViewModel Template { get; set; } = null!;
}
