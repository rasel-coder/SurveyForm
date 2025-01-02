using AutoMapper;
using SurveyForm.Data;
using SurveyForm.Models;
using SurveyForm.Repository;
using SurveyForm.ViewModels;
using Microsoft.CodeAnalysis.FlowAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using SurveyForm.Utility;

namespace SurveyForm.Manager
{
    public class TemplateManager
    {
        private readonly TemplateRepository templateRepository;
        private readonly QuestionRepository questionRepository;
        private readonly FormsRepository formsRepository;
        private readonly IMapper mapper;

        public TemplateManager(TemplateRepository templateRepository
            , QuestionRepository questionRepository
            , FormsRepository formsRepository
            , IMapper mapper)
        {
            this.templateRepository = templateRepository;
            this.questionRepository = questionRepository;
            this.formsRepository = formsRepository;
            this.mapper = mapper;
        }

        public async Task<List<TemplateViewModel>> GettAllTemplateAsync()
        {
            try
            {
                var templates = await templateRepository.GetAllTemplate();
                return mapper.Map<List<TemplateViewModel>>(templates);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<TemplateViewModel>> GetSearchedTemplatesAsync(string search)
        {
            try
            {
                var templates = await templateRepository.GetSearchedTemplates(search);
                return mapper.Map<List<TemplateViewModel>>(templates);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<TemplateViewModel>> GetCommentsAsync(int templateId)
        {
            try
            {
                var templates = await templateRepository.GetSearchedTemplates(templateId);
                return mapper.Map<List<TemplateViewModel>>(templates);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<TemplateViewModel>> GetAllTemplateByUserIdAsync(string id, string userRole)
        {
            try
            {
                var templates = new List<Template>();
                if (userRole == Enums.AppRoleEnums.Admin.ToString())
                    templates = await templateRepository.GetAllTemplates();
                else
                    templates = await templateRepository.GetAllTemplateByUserId(id);
                return mapper.Map<List<TemplateViewModel>>(templates);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<TemplateViewModel>> GetFavouriteTemplatesByUserIdAsync(string templateId)
        {
            try
            {
                var templates = await templateRepository.GetFavouriteTemplatesByUserId(templateId);
                return mapper.Map<List<TemplateViewModel>>(templates);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<TemplateViewModel>> MostPopularTemplateAsync()
        {
            try
            {
                var templates = await templateRepository.MostPopularTemplate();
                var templatesViewModel = mapper.Map<List<TemplateViewModel>>(templates);
                foreach (var template in templatesViewModel)
                {
                    template.TemplateCount = templateRepository.TemplateCount(template.TemplateId); ;
                }
                return templatesViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TemplateViewModel> GetTemplateByIdAsync(int id)
        {
            try
            {
                var templates = await templateRepository.GetTemplateById(id);
                return mapper.Map<TemplateViewModel>(templates);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<TopicViewModel>> GettAllTopic()
        {
            try
            {
                var topics = await templateRepository.GettAllTopic();
                return mapper.Map<List<TopicViewModel>>(topics);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<string>> GetAllTagNameAsync()
        {
            try
            {
                var tags = await templateRepository.GetAllTagName();
                return mapper.Map<List<string>>(tags);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<TagViewModel>> GetAllTagAsync()
        {
            try
            {
                var tags = await templateRepository.GetAllTag();
                return mapper.Map<List<TagViewModel>>(tags);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> CreateTemplateAsync(TemplateViewModel model, IIdentity? User)
        {
            try
            {
                model.CreatedBy = User.Name;
                model.CreatedDate = DateTime.Now;

                List<Tag> tags = new List<Tag>();
                if (model.Tags != null)
                    tags = model.Tags.Split(',').Select(tag => new Tag { TagName = tag.Trim().ToLower() }).ToList();

                Template template = new Template();
                template = mapper.Map<Template>(model);
                return await templateRepository.CreateTemplate(template, tags);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdateTemplateAsync(TemplateViewModel model, IIdentity? User)
        {
            try
            {
                model.CreatedBy = User.Name;
                model.CreatedDate = DateTime.Now;

                List<Tag> tags = new List<Tag>();
                if (model.Tags != null)
                    tags = model.Tags.Split(',').Select(tag => new Tag { TagName = tag.Trim().ToLower() }).ToList();

                Template template = new Template();
                template = mapper.Map<Template>(model);
                return await templateRepository.UpdateTemplate(template, tags);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task DeleteTemplateAsync(int id)
        {
            try
            {
                await templateRepository.DeleteTemplate(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<CommentViewModel>> GetCommentsByTemplateIdAsync(int templateId)
        {
            try
            {
                var comments = await templateRepository.GetCommentsByTemplateId(templateId);
                return mapper.Map<List<CommentViewModel>>(comments);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> AddCommentAsync(CommentViewModel comment)
        {
            try
            {
                var commentEntity = mapper.Map<Comment>(comment);
                return await templateRepository.AddComment(commentEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<LikeViewModel>> GetLikesByTemplateIdAsync(int templateId)
        {
            try
            {
                var likes = await templateRepository.GetLikesByTemplateId(templateId);
                return mapper.Map<List<LikeViewModel>>(likes);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> AddToFavouriteAsync(int templateId, string userId)
        {
            try
            {
                Like like = new Like
                {
                    TemplateId = templateId,
                    UserId = userId,
                    LikedDate = DateTime.UtcNow
                };
                return await templateRepository.AddToFavourite(like);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TemplateViewModel> GetTemplateAllDetailsAsync(int templateId, string userId)
        {
            try
            {
                var template = await templateRepository.GetTemplateById(templateId);
                var templateViewModel = mapper.Map<TemplateViewModel>(template);

                foreach (var item in templateViewModel.Forms)
                {
                    foreach (var item1 in item.Answers)
                    {
                        
                    }
                }

                if (templateViewModel.Likes.Where(x => x.UserId == userId).FirstOrDefault() != null)
                    templateViewModel.IsLiked = true;

                return templateViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
