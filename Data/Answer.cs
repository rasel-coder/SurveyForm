﻿
namespace SurveyForm.Data;

public partial class Answer
{
    public Answer()
    {
        Form = new Form();
    }

    public int AnswerId { get; set; }

    public int? FormId { get; set; }

    public int? QuestionId { get; set; }

    public string? AnswerText { get; set; }

    public int? AnswerInt { get; set; }

    public virtual Form? Form { get; set; }
}