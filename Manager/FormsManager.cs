using AutoMapper;
using SurveyForm.Data;
using SurveyForm.Models;
using SurveyForm.Repository;
using SurveyForm.ViewModels;
using System.Security.Principal;

namespace SurveyForm.Manager
{
    public class FormsManager
    {
        private readonly FormsRepository formRepository;
        private readonly TemplateRepository templateRepository;
        private readonly QuestionRepository questionRepository;
        private readonly IMapper mapper;

        public FormsManager(FormsRepository formRepository
            , TemplateRepository templateRepository
            , QuestionRepository questionRepository
            , IMapper mapper)
        {
            this.formRepository = formRepository;
            this.templateRepository = templateRepository;
            this.questionRepository = questionRepository;
            this.mapper = mapper;
        }

        public async Task<List<FormViewModel>> GetFormsByTemplateIdAsync(int id)
        {
            try
            {
                List<Form> forms = await formRepository.GetFormsByTemplateId(id);
                return mapper.Map<List<FormViewModel>>(forms);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<FormViewModel> GetFormByTemplateIdAsync(int id)
        {
            try
            {
                FormViewModel formViewModel = new FormViewModel();
                var template = await templateRepository.GetTemplateById(id);
                return mapper.Map<FormViewModel>(template);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<FormViewModel> GetFormByIdAsync(int id, int templateId)
        {
            try
            {
                FormViewModel formViewModel = new FormViewModel();
                Form form = await formRepository.GetFormById(id);
                var questions = await questionRepository.GetQuestionsByTemplateId(templateId);
                formViewModel = mapper.Map<FormViewModel>(form);
                formViewModel.Questions = mapper.Map<List<QuestionViewModel>>(questions);
                return formViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateAnswerAsync(AnswerViewModel model)
        {
            try
            {
                var answer = mapper.Map<Answer>(model);
                return await formRepository.UpdateAnswer(answer);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> SaveFormAsync(FormViewModel model, string userId)
        {
            try
            {
                model.UserId = userId;
                model.SubmittedDate = DateTime.Now;
                Form form = mapper.Map<Form>(model);
                foreach (var item in model.Answers)
                {
                    item.MaximumMarks = 5;
                }
                return await formRepository.SaveForm(form);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
