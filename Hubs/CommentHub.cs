using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SurveyForm.Data;
using SurveyForm.Models;

namespace SurveyForm.Hubs;

public class CommentHub : Hub
{
    private readonly SurveyFormDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public CommentHub(SurveyFormDbContext _context
        , UserManager<ApplicationUser> userManager)
    {
        this._context = _context;
        this._userManager = userManager;
    }

    public async Task AddComment(int templateId, string commentText)
    {
        var userId = Context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var user = await _userManager.FindByIdAsync(userId);

        Comment newComment = new Comment
        {
            TemplateId = templateId,
            CommentText = commentText,
            UserId = userId,
            CreatedBy = user.FirstName + " " + user.LastName,
            CreatedDate = DateTime.UtcNow
        };
        await _context.Comments.AddAsync(newComment);
        await _context.SaveChangesAsync();

        await NotifyUpdatedCommentList(templateId);
    }

    private async Task NotifyUpdatedCommentList(int templateId)
    {
        var comments = await _context.Comments
            .Where(user => user.TemplateId == templateId)
            .OrderByDescending(x => x.CreatedDate)
            .ToListAsync();

        await Clients.All.SendAsync("CommentListUpdated", comments);
    }
}
