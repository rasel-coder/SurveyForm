using System;
using System.Collections.Generic;

namespace SurveyForm.ViewModels;

public partial class LikeViewModel
{
    public int LikeId { get; set; }

    public int TemplateId { get; set; }

    public string? UserId { get; set; }

    public DateTime? LikedDate { get; set; }

    public virtual TemplateViewModel Template { get; set; } = null!;
}
