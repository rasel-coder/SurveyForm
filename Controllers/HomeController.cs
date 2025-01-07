using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SurveyForm.Manager;
using SurveyForm.Models;
using SurveyForm.Repository;
using SurveyForm.ViewModels;

namespace SurveyForm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TemplateManager _templateManager;

        public HomeController(ILogger<HomeController> _logger
            , TemplateManager _templateManager)
        {
            this._logger = _logger;
            this._templateManager = _templateManager;
        }

        public async Task<IActionResult> Index()
        {
            TemplatePageViewModel template = new TemplatePageViewModel();

            var templates = await _templateManager.GettAllTemplateAsync();
            template.LatestTemplates = templates;
            template.PopularTemplates = templates.Select(template =>
                {
                    template.TemplateCount = template.Forms.Count();
                    return template;
                })
                .OrderByDescending(template => template.TemplateCount)
                .Take(5).ToList();
            return View(template);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
