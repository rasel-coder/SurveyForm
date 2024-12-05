﻿using SurveyForm.Models;
using System;
using System.Collections.Generic;

namespace SurveyForm.ViewModels;

public partial class QuestionOptionViewModel
{
    public QuestionOptionViewModel()
    {
        
    }

    public int QuestionOptionId { get; set; }

    public int QuestionId { get; set; }

    public string OptionName { get; set; } = null!;

    public bool IsCorrectAnswer { get; set; }

    public virtual QuestionViewModel Question { get; set; } = null!;

}
