﻿using SurveyForm.Data;
using Microsoft.EntityFrameworkCore;
using SurveyForm.Models;

namespace SurveyForm.Repository
{
    public class FormsRepository
    {
        private readonly SurveyFormDbContext context;

        public FormsRepository(SurveyFormDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Form>> GetFormsByTemplateId(int id)
        {
            try
            {
                return await context.Forms
                    .Include(x => x.Answers)
                    .Where(x => x.TemplateId == id).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Form> GetFormById(int id)
        {
            try
            {
                return await context.Forms.Where(x => x.FormId == id).Include(f => f.Answers).FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> SaveForm(Form model)
        {
            try
            {
                await context.Forms.AddAsync(model);
                return await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<Form>> GetSubmittedFormsByTemplateIdAsync(int templateId)
        {
            return await context.Forms
                .Where(f => f.TemplateId == templateId && f.SubmittedDate.HasValue)
                .ToListAsync();
        }
    }
}
