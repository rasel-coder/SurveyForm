using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SurveyForm.Manager;
using SurveyForm.Models;

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
            var templates = await _templateManager.GettAllTemplateAsync();
            return View(templates);
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
