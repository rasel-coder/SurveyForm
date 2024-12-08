using SurveyForm.Data;
using SurveyForm.Models;
using Microsoft.EntityFrameworkCore;
using SurveyForm.Utility;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SurveyForm.Repository
{
    public class TemplateRepository
    {
        private readonly SurveyFormDbContext context;

        public TemplateRepository(SurveyFormDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Template>> GetAllTemplate()
        {
            try
            {
                return await context.Templates.OrderByDescending(x => x.TemplateId).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Template>> GetSearchedTemplates(string search)
        {
            try
            {
                return await context.Templates
                    .Where(t => t.Title.Contains(search) ||
                        t.Description.Contains(search) ||
                        t.Tags.Contains(search))
                    .OrderByDescending(x => x.TemplateId)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Template>> GetAllTemplateByUserId(string id)
        {
            try
            {
                var userIds = new[] { id, Enums.TemplateSpecificUser.Authenticated_User.ToString() };
                var templateUsers = await context.TemplateSpecificUsers
                    .Include(x => x.Template)
                    .Where(x => userIds.Contains(x.UserId))
                    .ToListAsync();
                return templateUsers.Select(x => x.Template).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Template> GetTemplateById(int id)
        {
            try
            {
                return await context.Templates
                    .Include(x => x.TemplateSpecificUsers)
                    .Include(x => x.Questions)
                    .Where(x => x.TemplateId == id).FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Topic>> GettAllTopic()
        {
            try
            {
                return await context.Topics.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<string>> GetAllTagName()
        {
            try
            {
                return await context.Tags.Select(t => t.TagName).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<string>> GetAllUser()
        {
            try
            {
                return await context.Tags.Select(t => t.TagName).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Tag>> GetAllTag()
        {
            try
            {
                return await context.Tags.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> CreateTemplate(Template model, List<Tag> tags)
        {
            try
            {
                await context.Templates.AddAsync(model);
                await context.SaveChangesAsync();

                var unavailableTags = tags
                    .Where(tag => !context.Tags.Select(t => t.TagName).ToList()
                        .Contains(tag.TagName))
                    .ToList();

                if (unavailableTags.Any())
                {
                    await context.Tags.AddRangeAsync(unavailableTags);
                    await context.SaveChangesAsync();
                }
                return model.TemplateId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdateTemplate(Template model, List<Tag> tags)
        {
            try
            {
                var templateUsers = await context.TemplateSpecificUsers.Where(x => x.TemplateId == model.TemplateId).ToListAsync();
                context.TemplateSpecificUsers.RemoveRange(templateUsers);

                context.Templates.Update(model);
                await context.SaveChangesAsync();

                var unavailableTags = tags
                    .Where(tag => !context.Tags.Select(t => t.TagName).ToList()
                        .Contains(tag.TagName))
                    .ToList();

                if (unavailableTags.Any())
                    await context.Tags.AddRangeAsync(unavailableTags);

                await context.SaveChangesAsync();
                return model.TemplateId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteTemplate(int id)
        {
            try
            {
                Template template = await context.Templates.FindAsync(id);
                if (template != null)
                {
                    context.Templates.Remove(template);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<Comment>> GetCommentsByTemplateId(int templateId)
        {
            return await context.Comments
                .Where(c => c.TemplateId == templateId)
                .ToListAsync();
        }

        public async Task<bool> AddComment(Comment comment)
        {
            context.Comments.Add(comment);
            var result = await context.SaveChangesAsync();
            return result > 0;
        }
        public async Task<List<Like>> GetLikesByTemplateId(int templateId)
        {
            return await context.Likes
                .Where(l => l.TemplateId == templateId)
                .ToListAsync();
        }

        public async Task<bool> AddLike(Like like)
        {
            var existingLike = await context.Likes
                .FirstOrDefaultAsync(l => l.TemplateId == like.TemplateId && l.UserId == like.UserId);

            if (existingLike != null)
            {
                return false;
            }

            context.Likes.Add(like);
            var result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<List<Template>> MostPopularTemplate()
        {
            var topTemplateIds = await context.Forms.GroupBy(f => f.TemplateId)
                .OrderByDescending(g => g.Count())
                .Take(5)
                .Select(g => new
                {
                    TemplateId = g.Key,
                    Count = g.Count()
                }).ToListAsync();

            var templateIdList = topTemplateIds.Select(t => t.TemplateId).ToList();

            return await context.Templates
                .Where(x => templateIdList.Contains(x.TemplateId))
                .ToListAsync();
        }

        public int TemplateCount(int id)
        {
            return context.Forms.Where(x => x.TemplateId == id).Count();
        }
    }
}
