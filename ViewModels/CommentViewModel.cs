using System;
using System.Collections.Generic;

namespace SurveyForm.ViewModels;

public partial class CommentViewModel
{
    public int CommentId { get; set; }

    public int TemplateId { get; set; }

    public string? UserId { get; set; }

    public string CommentText { get; set; } = null!;

    public string? CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual TemplateViewModel Template { get; set; } = null!;
}
