﻿using SurveyForm.Manager;
using SurveyForm.Models;
using SurveyForm.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace SurveyForm.Areas.Templates.Controllers
{
    [Authorize]
    [Area(nameof(Templates))]
    public class QuestionController : Controller
    {
        private readonly QuestionManager questionManager;

        public QuestionController(QuestionManager questionManager)
        {
            this.questionManager = questionManager;
        }

        [HttpGet]
        public async Task<IActionResult> SaveQuestion(int questionId, int templateId)
        {
            QuestionViewModel model = new QuestionViewModel();
            model = await questionManager.GetQuestionByIdAsync(questionId);
            model.TemplateId = templateId;
            return PartialView("~/Areas/Templates/Views/Question/_QuestionForm.cshtml", model);
        }

        public IActionResult AddQuestionCheckbox(int questionType)
        {
            QuestionViewModel questionViewModel = new QuestionViewModel();
            return PartialView("~/Areas/Templates/Views/Question/_QuestionCheckbox.cshtml", questionViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SaveQuestion(QuestionViewModel model)
        {
            if (model.QuestionId == 0)
                model.QuestionId = await questionManager.AddTemplateQuestionAsync(model, User.Identity);
            else
                model.QuestionId = await questionManager.UpdateTemplateQuestionAsync(model, User.Identity);
            return RedirectToAction("SaveTemplate", "Template", new { area = "Templates", id = model.TemplateId, tab = "Questions" });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteQuestion(int QuestionId, int TemplateId)
        {
            await questionManager.DeleteTemplateQuestionAsync(QuestionId);
            return RedirectToAction("SaveTemplate", "Template", new { area = "Templates", id = TemplateId, tab = "Questions" });
        }

        [HttpPost]
        public async Task<IActionResult> SaveQuestionOrder([FromBody] List<QuestionOrderViewModel> questionOrderList)
        {
            await questionManager.SaveQuestionOrderAsync(questionOrderList);
            return Json(new { success = true });
        }
    }
}