﻿using SurveyForm.Models;

namespace SurveyForm.ViewModels
{
    public class TemplateDetailsViewModel
    {
        public TemplateViewModel Template { get; set; }
        public List<QuestionViewModel> Questions { get; set; }
        public List<CommentViewModel> Comments { get; set; }
        public int LikesCount { get; set; }
        public List<FormViewModel> SubmittedForms { get; set; }

    }
}
