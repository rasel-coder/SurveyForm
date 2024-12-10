using SurveyForm.Manager;
using SurveyForm.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SurveyForm.Data;
using SurveyForm.Utility;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SurveyForm.Areas.Templates.Controllers;

[Authorize]
[Area(nameof(Templates))]
public class TemplateController : Controller
{
    private readonly IWebHostEnvironment webHostEnvironment;
    private readonly UserManager<ApplicationUser> userManager;
    public readonly TemplateManager templateManager;
    private readonly QuestionManager questionManager;
    internal readonly FormsManager formsManager;

    public TemplateController(TemplateManager _templateManager
        , QuestionManager questionManager
        , FormsManager formsManager
        , UserManager<ApplicationUser> userManager
        , IWebHostEnvironment _webHostEnvironment)
    {
        templateManager = _templateManager;
        this.questionManager = questionManager;
        this.formsManager = formsManager;
        this.userManager = userManager;
        webHostEnvironment = _webHostEnvironment;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        var userId = await userManager.GetUserIdAsync(await userManager.GetUserAsync(User));
        var templates = await templateManager.GetAllTemplateByUserIdAsync(userId);
        return View(templates);
    }

    public async Task<IActionResult> SaveTemplate(int id, string tab = "Setup")
    {
        var userId = await userManager.GetUserIdAsync(await userManager.GetUserAsync(User));

        SaveTemplateViewModel template = new SaveTemplateViewModel();
        template.Template = await templateManager.GetTemplateByIdAsync(id) ?? new TemplateViewModel();
        template.TemplateId = id;
        template.ActiveTab = tab;

        var topics = await templateManager.GettAllTopic();
        ViewBag.Topics = new SelectList(topics, "TopicId", "TopicName");
        ViewBag.Tags = await templateManager.GetAllTagNameAsync();

        var users = await userManager.GetUsersInRoleAsync(Enums.AppRoleEnums.Admin.ToString());
        ViewBag.Users = users.Select(user => new { UserId = user.Id, UserName = user.FirstName + " " + user.LastName }).Where(x => x.UserId != userId).ToList();

        template.Questions = template.Template.Questions;
        return View(template);
    }

    [HttpPost]
    public async Task<IActionResult> SaveTemplateSetup(TemplateViewModel model)
    {
        var userId = await userManager.GetUserIdAsync(await userManager.GetUserAsync(User));

        List<TemplateSpecificUserViewModel> templates = new List<TemplateSpecificUserViewModel>();
        if (model.AccessMode == Enums.TemplateSpecificUser.Authenticated_User.ToString())
            model.TemplateSpecificUsers = new List<TemplateSpecificUserViewModel> { new() { UserId = Enums.TemplateSpecificUser.Authenticated_User.ToString() } };
        else if (model.AccessMode == Enums.TemplateSpecificUser.Specified_User.ToString() && !string.IsNullOrEmpty(Request.Form["TemplateSpecificUsers"]))
        {
            List<TemplateSpecificUserViewModel> users = JsonConvert.DeserializeObject<List<TemplateSpecificUserViewModel>>(Request.Form["TemplateSpecificUsers"]);
            users.Add(new TemplateSpecificUserViewModel() { UserId = userId });
            model.TemplateSpecificUsers = users;
        }
        else
            model.TemplateSpecificUsers = new List<TemplateSpecificUserViewModel> { new() { UserId = userId } };

        if (model.TemplateId == 0)
            model.TemplateId = await templateManager.CreateTemplateAsync(model, User.Identity);
        else
            model.TemplateId = await templateManager.UpdateTemplateAsync(model, User.Identity);
        
        return RedirectToAction("SaveTemplate", new { id = model.TemplateId, tab = "Questions" });
    }

    [HttpPost]
    public async Task<IActionResult> DeleteTemplate(int id)
    {
        await templateManager.DeleteTemplateAsync(id);
        return RedirectToAction(nameof(Index));
    }

    //[AllowAnonymous]
    //public async Task<IActionResult> Details(int id)
    //{
    //    var template = await templateManager.GetTemplateByIdAsync(id);
    //    var comments = await templateManager.GetCommentsByTemplateIdAsync(id);
    //    var likes = await templateManager.GetLikesByTemplateIdAsync(id);

    //    var templateDetailsViewModel = new TemplateDetailsViewModel
    //    {
    //        Template = template,
    //        Comments = comments,
    //        LikesCount = likes.Count
    //    };

    //    return View(templateDetailsViewModel);
    //}

    [AllowAnonymous]
    public async Task<IActionResult> TemplateDetails(int id)
    {
        var user = await userManager.GetUserAsync(User);
        var userId = await userManager.GetUserIdAsync(user?? new ApplicationUser());
        var templete = await templateManager.GetTemplateAllDetailsAsync(id, userId);
        if (user != null)
        {
            foreach (var item in templete.Forms)
            {
                item.UserName = user.FirstName + ' ' + user.LastName;
                item.Email = user.Email;
            }
        }

            ViewBag.TemplateStatus = "Read-Only";
        return View(templete);
    }

    [HttpPost]
    public async Task<IActionResult> AddComment(CommentViewModel comment)
    {
        var result = await templateManager.AddCommentAsync(comment);
        return RedirectToAction("Details", new { id = comment.TemplateId });
    }

    [HttpGet]
    public async Task<IActionResult> AddToFavourite(int templateId)
    {
        var userId = await userManager.GetUserIdAsync(await userManager.GetUserAsync(User));
        var result = await templateManager.AddToFavouriteAsync(templateId, userId);
        return RedirectToAction(nameof(TemplateDetails), new { id = templateId });
    }

    [HttpPost]
    public IActionResult UploadImage(IFormFile file)
    {
        if (file != null && file.Length > 0)
        {
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
            Directory.CreateDirectory(uploadsFolder);
            var filePath = Path.Combine(uploadsFolder, file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return Json(new { filePath = "/uploads/" + file.FileName });
        }
        return BadRequest("Invalid file.");
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> SearchTemplate(string search)
    {
        var templates = new List<TemplateViewModel>();
        if (string.IsNullOrEmpty(search))
            templates = await templateManager.GettAllTemplateAsync();
        else
            templates = await templateManager.GetSearchedTemplatesAsync(search);

        return PartialView("~/Views/Home/_LatestTemplate.cshtml", templates);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetComments(int templateId)
    {
        var comments = await templateManager.GetCommentsAsync(templateId);
        return PartialView("~/Areas/Templates/Views/Template/_CommentList.cshtml", comments);
    }
}
