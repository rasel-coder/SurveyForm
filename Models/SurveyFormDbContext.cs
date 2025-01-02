using Azure;
using Microsoft.EntityFrameworkCore;
using SurveyForm.Data;

namespace SurveyForm.Models;

public class SurveyFormDbContext : DbContext
{
    public SurveyFormDbContext() { }

    public SurveyFormDbContext(DbContextOptions<SurveyFormDbContext> options)
        : base(options) { }

    public virtual DbSet<Answer> Answers { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Form> Forms { get; set; }

    public virtual DbSet<Like> Likes { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<QuestionOption> QuestionOptions { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<Template> Templates { get; set; }

    public virtual DbSet<FormSpecificUser> FormSpecificUsers { get; set; }

    public virtual DbSet<Topic> Topics { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Answer>(entity =>
        {
            entity.HasIndex(e => e.FormId, "IX_Answers_FormId");

            entity.HasOne(d => d.Form).WithMany(p => p.Answers).HasForeignKey(d => d.FormId);
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasIndex(e => e.TemplateId, "IX_Comments_TemplateId");

            entity.HasOne(d => d.Template).WithMany(p => p.Comments).HasForeignKey(d => d.TemplateId);
        });

        modelBuilder.Entity<Form>(entity =>
        {
            entity.HasIndex(e => e.TemplateId, "IX_Forms_TemplateId");

            entity.HasOne(d => d.Template).WithMany(p => p.Forms).HasForeignKey(d => d.TemplateId);
        });

        modelBuilder.Entity<Like>(entity =>
        {
            entity.HasIndex(e => e.TemplateId, "IX_Likes_TemplateId");

            entity.HasOne(d => d.Template).WithMany(p => p.Likes).HasForeignKey(d => d.TemplateId);
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasIndex(e => e.TemplateId, "IX_Questions_TemplateId");

            entity.Property(e => e.QuestionTitle).HasMaxLength(255);
            entity.Property(e => e.QuestionType).HasMaxLength(50);

            //entity.HasOne(d => d.Template).WithMany(p => p.Questions).HasForeignKey(d => d.TemplateId);
        });

        modelBuilder.Entity<Template>(entity =>
        {
            entity.Property(e => e.Image).HasMaxLength(500);
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.TopicId).HasMaxLength(100);
        });

        modelBuilder.Entity<FormSpecificUser>(entity =>
        {
            entity.HasIndex(e => e.TemplateId, "IX_FormSpecificUsers_TemplateId");

            entity.HasOne(d => d.Template).WithMany(p => p.FormSpecificUsers).HasForeignKey(d => d.TemplateId);
        });

        modelBuilder.Entity<Topic>().HasData(
            new Topic { TopicId = 1, TopicName = "Education" },
            new Topic { TopicId = 2, TopicName = "Quiz" },
            new Topic { TopicId = 3, TopicName = "Other" }
        );
        modelBuilder.Entity<Tag>().HasData(
        new Tag { TagId = 1, TagName = "chemistry" },
        new Tag { TagId = 2, TagName = "biology" },
            new Tag { TagId = 3, TagName = "physics" },
            new Tag { TagId = 4, TagName = "quiz_test" }
        );
    }
}
