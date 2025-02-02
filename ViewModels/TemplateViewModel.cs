﻿using SurveyForm.Data;
using SurveyForm.Models;
using SurveyForm.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurveyForm.ViewModels;

public partial class TemplateViewModel
{
    public TemplateViewModel()
    {
        Comments = new List<CommentViewModel>();
        Forms = new List<FormViewModel>();
        Likes = new List<LikeViewModel>();
        Questions = new List<QuestionViewModel>();
    }

    public int TemplateId { get; set; }
    public string UserId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    [Display(Name = "Topic")]
    public int TopicId { get; set; }

    public string Tags { get; set; } = null!;

    public string Image { get; set; } = null!;

    [Display(Name = "Access Mode")]
    public string AccessMode { get; set; } = Enums.TemplateSpecificUser.Authenticated_User.ToString();

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedDate { get; set; }
    public int TemplateCount { get; set; }
    public bool IsLiked { get; set; }

    public virtual List<List<AnswerViewModel>> Aggrigations { get; set; } = new List<List<AnswerViewModel>>();

    public virtual IEnumerable<CommentViewModel> Comments { get; set; } = new List<CommentViewModel>();

    public virtual IEnumerable<FormViewModel> Forms { get; set; } = new List<FormViewModel>();

    public virtual IEnumerable<LikeViewModel> Likes { get; set; } = new List<LikeViewModel>();

    public virtual IEnumerable<QuestionViewModel> Questions { get; set; } = new List<QuestionViewModel>();

    public virtual IEnumerable<FormSpecificUserViewModel> FormSpecificUsers { get; set; } = null;

}
