using SurveyForm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurveyForm.ViewModels;

public partial class SaveTemplateViewModel
{
    public SaveTemplateViewModel()
    {
        Template = new TemplateViewModel();
        Questions = new List<QuestionViewModel>();
    }

    public int TemplateId { get; set; }
    public string? UserId { get; set; }
    public string? ActiveTab { get; set; }

    public virtual TemplateViewModel Template { get; set; } = new TemplateViewModel();

    public virtual IEnumerable<QuestionViewModel> Questions { get; set; } = new List<QuestionViewModel>();

}
