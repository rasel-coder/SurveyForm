using SurveyForm.Data;
using SurveyForm.Models;
using SurveyForm.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurveyForm.ViewModels;

public partial class TemplatePageViewModel
{
    public TemplatePageViewModel()
    {

    }

    public int TemplateId { get; set; }
    public string UserId { get; set; }

    public virtual List<TemplateViewModel> MyTemplates { get; set; } = new List<TemplateViewModel>();
    public virtual List<TemplateViewModel> FavouriteTemplates { get; set; } = new List<TemplateViewModel>();
}
