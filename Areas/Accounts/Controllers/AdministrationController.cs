using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SurveyForm.Controllers;
using SurveyForm.Data;
using SurveyForm.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using SurveyForm.Utility;

namespace SurveyForm.Areas.Accounts.Controllers;

[Area(nameof(Accounts))]
[Authorize(Roles = "Admin")]
public class AdministrationController : Controller
{
    private readonly UserManager<ApplicationUser> userManager;
    private readonly INotyfService toastNotification;
    private readonly IMapper mapper;
    private readonly ILogger<HomeController> logger;

    public AdministrationController(UserManager<ApplicationUser> userManager
    , INotyfService toastNotification
    , ILogger<HomeController> logger
    , IMapper mapper)
    {
        this.toastNotification = toastNotification;
        this.userManager = userManager;
        this.mapper = mapper;
        this.logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        try
        {
            var users = await userManager.Users.ToListAsync();
            return View(users);
        }
        catch (Exception)
        {
            throw;
        }
    }

    [HttpPost]
    public async Task<IActionResult> UserAction(List<string> UserIds, string action)
    {
        if (UserIds == null || !UserIds.Any())
        {
            toastNotification.Warning("No user selected");
            return RedirectToAction(nameof(Index));
        }

        var users = await userManager.Users.Where(u => UserIds.Contains(u.Id)).ToListAsync();
        switch (action.ToLower())
        {
            case "delete":
                await DeleteUsers(users);
                break;

            case "block":
                await BlockUsers(users);
                break;

            case "unblock":
                await UnblockUsers(users);
                break;

            case "add-to-admin":
                await AddToAdmin(users);
                break;

            case "remove-from-admin":
                await RemoveFromAdmin(users);
                break;

            default:
                toastNotification.Error("Unknown action");
                break;
        }
        if (users.Where(u => u.UserName == User.Identity?.Name).FirstOrDefault() != null && action != "unblock")
            return RedirectToAction("LogOut", "Account");

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task DeleteUsers(List<ApplicationUser> users)
    {
        foreach (var user in users)
        {
            var result = await userManager.DeleteAsync(user);
        }
        toastNotification.Success("User has been Deleted");
    }

    [HttpPost]
    public async Task BlockUsers(List<ApplicationUser> users)
    {
        foreach (var user in users)
        {
            var result = await userManager.SetLockoutEndDateAsync(user, DateTimeOffset.MaxValue);
        }
        toastNotification.Success("Selected users are blocked");
    }

    [HttpPost]
    public async Task UnblockUsers(List<ApplicationUser> users)
    {
        foreach (var user in users)
        {
            var result = await userManager.SetLockoutEndDateAsync(user, null);
        }
        toastNotification.Success("Selected users are unblocked");
    }

    [HttpPost]
    public async Task AddToAdmin(List<ApplicationUser> users)
    {
        foreach (var user in users)
        {
            await userManager.RemoveFromRoleAsync(user, Enums.AppRoleEnums.User.ToString());
            await userManager.AddToRoleAsync(user, Enums.AppRoleEnums.Admin.ToString());

            user.RoleName = Enums.AppRoleEnums.Admin.ToString();
            await userManager.UpdateAsync(user);
        }
        toastNotification.Success("Selected users are marked as Admin");
    }

    [HttpPost]
    public async Task RemoveFromAdmin(List<ApplicationUser> users)
    {
        foreach (var user in users)
        {
            await userManager.RemoveFromRoleAsync(user, Enums.AppRoleEnums.Admin.ToString());
            await userManager.AddToRoleAsync(user, Enums.AppRoleEnums.User.ToString());

            user.RoleName = Enums.AppRoleEnums.User.ToString();
            await userManager.UpdateAsync(user);
        }
        toastNotification.Success("Selected users are marked as User");
    }

    [HttpPost]
    public async Task<IActionResult> ShowUser(string userId)
    {
        var user = await userManager.FindByIdAsync(userId);
        return PartialView("~/Areas/Accounts/Views/Administration/_ViewUser.cshtml", user);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
