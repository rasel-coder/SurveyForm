﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SurveyForm.Models;

#nullable disable

namespace SurveyForm.Migrations.SurveyFormDb
{
    [DbContext(typeof(SurveyFormDbContext))]
    partial class SurveyFormDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SurveyForm.Data.Answer", b =>
                {
                    b.Property<int>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AnswerId"));

                    b.Property<int?>("AnswerInt")
                        .HasColumnType("int");

                    b.Property<string>("AnswerText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FormId")
                        .HasColumnType("int");

                    b.Property<int?>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("AnswerId");

                    b.HasIndex(new[] { "FormId" }, "IX_Answers_FormId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("SurveyForm.Data.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"));

                    b.Property<string>("CommentText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TemplateId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex(new[] { "TemplateId" }, "IX_Comments_TemplateId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("SurveyForm.Data.Form", b =>
                {
                    b.Property<int>("FormId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FormId"));

                    b.Property<string>("SubmittedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("SubmittedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TemplateId")
                        .HasColumnType("int");

                    b.HasKey("FormId");

                    b.HasIndex(new[] { "TemplateId" }, "IX_Forms_TemplateId");

                    b.ToTable("Forms");
                });

            modelBuilder.Entity("SurveyForm.Data.Like", b =>
                {
                    b.Property<int>("LikeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LikeId"));

                    b.Property<DateTime?>("LikedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TemplateId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LikeId");

                    b.HasIndex(new[] { "TemplateId" }, "IX_Likes_TemplateId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("SurveyForm.Data.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuestionId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<bool?>("IsDisplayed")
                        .HasColumnType("bit");

                    b.Property<string>("QuestionTitle")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("QuestionType")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("SelectedOptionId")
                        .HasColumnType("int");

                    b.Property<int?>("TemplateId")
                        .HasColumnType("int");

                    b.HasKey("QuestionId");

                    b.HasIndex(new[] { "TemplateId" }, "IX_Questions_TemplateId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("SurveyForm.Data.QuestionOption", b =>
                {
                    b.Property<int>("QuestionOptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuestionOptionId"));

                    b.Property<bool?>("IsCorrectAnswer")
                        .HasColumnType("bit");

                    b.Property<string>("OptionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("QuestionOptionId");

                    b.HasIndex("QuestionId");

                    b.ToTable("QuestionOptions");
                });

            modelBuilder.Entity("SurveyForm.Data.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TagId"));

                    b.Property<string>("TagName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TemplateId")
                        .HasColumnType("int");

                    b.HasKey("TagId");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            TagId = 1,
                            TagName = "chemistry"
                        },
                        new
                        {
                            TagId = 2,
                            TagName = "biology"
                        },
                        new
                        {
                            TagId = 3,
                            TagName = "physics"
                        },
                        new
                        {
                            TagId = 4,
                            TagName = "quiz_test"
                        });
                });

            modelBuilder.Entity("SurveyForm.Data.Template", b =>
                {
                    b.Property<int>("TemplateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TemplateId"));

                    b.Property<string>("AccessMode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Tags")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("TopicId")
                        .HasMaxLength(100)
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TemplateId");

                    b.ToTable("Templates");
                });

            modelBuilder.Entity("SurveyForm.Data.TemplateSpecificUser", b =>
                {
                    b.Property<int>("TemplateSpecificUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TemplateSpecificUserId"));

                    b.Property<int?>("TemplateId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TemplateSpecificUserId");

                    b.HasIndex(new[] { "TemplateId" }, "IX_TemplateSpecificUsers_TemplateId");

                    b.ToTable("TemplateSpecificUsers");
                });

            modelBuilder.Entity("SurveyForm.Data.Topic", b =>
                {
                    b.Property<int>("TopicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TopicId"));

                    b.Property<string>("TopicName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TopicId");

                    b.ToTable("Topics");

                    b.HasData(
                        new
                        {
                            TopicId = 1,
                            TopicName = "Education"
                        },
                        new
                        {
                            TopicId = 2,
                            TopicName = "Quiz"
                        },
                        new
                        {
                            TopicId = 3,
                            TopicName = "Other"
                        });
                });

            modelBuilder.Entity("SurveyForm.Data.Answer", b =>
                {
                    b.HasOne("SurveyForm.Data.Form", "Form")
                        .WithMany("Answers")
                        .HasForeignKey("FormId");

                    b.Navigation("Form");
                });

            modelBuilder.Entity("SurveyForm.Data.Comment", b =>
                {
                    b.HasOne("SurveyForm.Data.Template", "Template")
                        .WithMany("Comments")
                        .HasForeignKey("TemplateId");

                    b.Navigation("Template");
                });

            modelBuilder.Entity("SurveyForm.Data.Form", b =>
                {
                    b.HasOne("SurveyForm.Data.Template", "Template")
                        .WithMany("Forms")
                        .HasForeignKey("TemplateId");

                    b.Navigation("Template");
                });

            modelBuilder.Entity("SurveyForm.Data.Like", b =>
                {
                    b.HasOne("SurveyForm.Data.Template", "Template")
                        .WithMany("Likes")
                        .HasForeignKey("TemplateId");

                    b.Navigation("Template");
                });

            modelBuilder.Entity("SurveyForm.Data.Question", b =>
                {
                    b.HasOne("SurveyForm.Data.Template", null)
                        .WithMany("Questions")
                        .HasForeignKey("TemplateId");
                });

            modelBuilder.Entity("SurveyForm.Data.QuestionOption", b =>
                {
                    b.HasOne("SurveyForm.Data.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("SurveyForm.Data.TemplateSpecificUser", b =>
                {
                    b.HasOne("SurveyForm.Data.Template", "Template")
                        .WithMany("TemplateSpecificUsers")
                        .HasForeignKey("TemplateId");

                    b.Navigation("Template");
                });

            modelBuilder.Entity("SurveyForm.Data.Form", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("SurveyForm.Data.Template", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Forms");

                    b.Navigation("Likes");

                    b.Navigation("Questions");

                    b.Navigation("TemplateSpecificUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
