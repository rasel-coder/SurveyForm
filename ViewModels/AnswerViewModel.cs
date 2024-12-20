using System;
using System.Collections.Generic;

namespace SurveyForm.ViewModels;

public partial class AnswerViewModel
{
    public int AnswerId { get; set; }

    public int FormId { get; set; }
    public int TemplateId { get; set; }

    public int QuestionId { get; set; }

    public string AnswerText { get; set; } = null!;

    public int? Marks { get; set; }
    public int MaximumMarks { get; set; } = 5;

    public virtual FormViewModel Form { get; set; } = null!;
}
