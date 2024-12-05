using System;
using System.Collections.Generic;

namespace SurveyForm.ViewModels;

public partial class TemplateSpecificUserViewModel
{
    public int TemplateSpecificUserId { get; set; }

    public string UserId { get; set; } = null!;
    public string UserName { get; set; } = null!;

    public int TemplateId { get; set; }

    public virtual TemplateViewModel Template { get; set; } = null!;
}
