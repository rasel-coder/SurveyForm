USE [SurveyFormDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 1/2/2025 10:31:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Answers]    Script Date: 1/2/2025 10:31:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answers](
	[AnswerId] [int] IDENTITY(1,1) NOT NULL,
	[FormId] [int] NULL,
	[QuestionId] [int] NULL,
	[TemplateId] [int] NOT NULL,
	[AnswerText] [nvarchar](max) NULL,
	[Marks] [int] NULL,
	[MaximumMarks] [int] NULL,
 CONSTRAINT [PK_Answers] PRIMARY KEY CLUSTERED 
(
	[AnswerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 1/2/2025 10:31:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 1/2/2025 10:31:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 1/2/2025 10:31:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 1/2/2025 10:31:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 1/2/2025 10:31:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 1/2/2025 10:31:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[RoleName] [nvarchar](max) NULL,
	[LastLoggedIn] [datetime2](7) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 1/2/2025 10:31:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 1/2/2025 10:31:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[CommentId] [int] IDENTITY(1,1) NOT NULL,
	[TemplateId] [int] NULL,
	[UserId] [nvarchar](max) NULL,
	[CommentText] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[CommentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Forms]    Script Date: 1/2/2025 10:31:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Forms](
	[FormId] [int] IDENTITY(1,1) NOT NULL,
	[TemplateId] [int] NULL,
	[UserId] [nvarchar](max) NULL,
	[SubmittedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Forms] PRIMARY KEY CLUSTERED 
(
	[FormId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FormSpecificUsers]    Script Date: 1/2/2025 10:31:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FormSpecificUsers](
	[FormSpecificUserId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](max) NULL,
	[TemplateId] [int] NULL,
 CONSTRAINT [PK_FormSpecificUsers] PRIMARY KEY CLUSTERED 
(
	[FormSpecificUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Likes]    Script Date: 1/2/2025 10:31:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Likes](
	[LikeId] [int] IDENTITY(1,1) NOT NULL,
	[TemplateId] [int] NULL,
	[UserId] [nvarchar](max) NULL,
	[LikedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Likes] PRIMARY KEY CLUSTERED 
(
	[LikeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuestionOptions]    Script Date: 1/2/2025 10:31:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionOptions](
	[QuestionOptionId] [int] IDENTITY(1,1) NOT NULL,
	[QuestionId] [int] NULL,
	[OptionName] [nvarchar](max) NULL,
	[IsCorrectAnswer] [bit] NULL,
 CONSTRAINT [PK_QuestionOptions] PRIMARY KEY CLUSTERED 
(
	[QuestionOptionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Questions]    Script Date: 1/2/2025 10:31:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questions](
	[QuestionId] [int] IDENTITY(1,1) NOT NULL,
	[TemplateId] [int] NULL,
	[QuestionType] [nvarchar](50) NULL,
	[SelectedOptionId] [int] NULL,
	[QuestionTitle] [nvarchar](255) NULL,
	[Description] [nvarchar](max) NULL,
	[IsDisplayed] [bit] NULL,
	[DisplayOrder] [int] NULL,
 CONSTRAINT [PK_Questions] PRIMARY KEY CLUSTERED 
(
	[QuestionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tags]    Script Date: 1/2/2025 10:31:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tags](
	[TagId] [int] IDENTITY(1,1) NOT NULL,
	[TagName] [nvarchar](max) NULL,
	[TemplateId] [int] NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[TagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Templates]    Script Date: 1/2/2025 10:31:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Templates](
	[TemplateId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](max) NULL,
	[Title] [nvarchar](255) NULL,
	[Description] [nvarchar](max) NULL,
	[TopicId] [int] NULL,
	[Tags] [nvarchar](max) NULL,
	[Image] [nvarchar](500) NULL,
	[AccessMode] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Templates] PRIMARY KEY CLUSTERED 
(
	[TemplateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Topics]    Script Date: 1/2/2025 10:31:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Topics](
	[TopicId] [int] IDENTITY(1,1) NOT NULL,
	[TopicName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Topics] PRIMARY KEY CLUSTERED 
(
	[TopicId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241222122720_initial', N'8.0.11')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241222122756_initial', N'8.0.11')
GO
SET IDENTITY_INSERT [dbo].[Answers] ON 

INSERT [dbo].[Answers] ([AnswerId], [FormId], [QuestionId], [TemplateId], [AnswerText], [Marks], [MaximumMarks]) VALUES (1, 1, 1, 1, N'1', 1, 5)
INSERT [dbo].[Answers] ([AnswerId], [FormId], [QuestionId], [TemplateId], [AnswerText], [Marks], [MaximumMarks]) VALUES (2, 1, 2, 1, N'Banani', 2, 5)
INSERT [dbo].[Answers] ([AnswerId], [FormId], [QuestionId], [TemplateId], [AnswerText], [Marks], [MaximumMarks]) VALUES (3, 1, 3, 1, N'Not to bad. It is an international brand', 3, 5)
INSERT [dbo].[Answers] ([AnswerId], [FormId], [QuestionId], [TemplateId], [AnswerText], [Marks], [MaximumMarks]) VALUES (4, 1, 4, 1, N'7', 4, 5)
INSERT [dbo].[Answers] ([AnswerId], [FormId], [QuestionId], [TemplateId], [AnswerText], [Marks], [MaximumMarks]) VALUES (5, 1, 5, 1, N'Don''t need', NULL, 5)
INSERT [dbo].[Answers] ([AnswerId], [FormId], [QuestionId], [TemplateId], [AnswerText], [Marks], [MaximumMarks]) VALUES (6, 2, 2, 1, N'Gulshan', NULL, 5)
INSERT [dbo].[Answers] ([AnswerId], [FormId], [QuestionId], [TemplateId], [AnswerText], [Marks], [MaximumMarks]) VALUES (7, 2, 3, 1, N'Cool, Love this place', NULL, 5)
INSERT [dbo].[Answers] ([AnswerId], [FormId], [QuestionId], [TemplateId], [AnswerText], [Marks], [MaximumMarks]) VALUES (8, 2, 4, 1, N'8', 2, 5)
INSERT [dbo].[Answers] ([AnswerId], [FormId], [QuestionId], [TemplateId], [AnswerText], [Marks], [MaximumMarks]) VALUES (9, 2, 1, 1, N'2', NULL, 5)
INSERT [dbo].[Answers] ([AnswerId], [FormId], [QuestionId], [TemplateId], [AnswerText], [Marks], [MaximumMarks]) VALUES (10, 2, 5, 1, N'Don''t need 2', NULL, 5)
SET IDENTITY_INSERT [dbo].[Answers] OFF
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'6a7babe2-e03f-45da-8eb9-96a9f6d82f2d', N'Anynomous', N'ANYNOMOUS', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'90df4184-8e50-41c6-a720-283922d6cdae', N'Admin', N'ADMIN', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'fd9b69ed-8f72-48c2-808a-07fb26619962', N'User', N'USER', NULL)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'725529dd-fd86-4f17-99a4-b51900879e3f', N'90df4184-8e50-41c6-a720-283922d6cdae')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'612963b2-5d8a-47b7-93f6-66c109683757', N'fd9b69ed-8f72-48c2-808a-07fb26619962')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'cc03fe0c-e209-4ecf-b71f-7d22a033bb5e', N'fd9b69ed-8f72-48c2-808a-07fb26619962')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'dfd8261b-a6cc-4532-9c11-0b70e9780dea', N'fd9b69ed-8f72-48c2-808a-07fb26619962')
GO
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [RoleName], [LastLoggedIn], [CreatedDate], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'612963b2-5d8a-47b7-93f6-66c109683757', N'Arif', N'Hossain', N'User', CAST(N'2024-12-22T14:25:45.5499951' AS DateTime2), CAST(N'2024-12-22T13:12:47.2383902' AS DateTime2), N'arif@placovu.com', N'ARIF@PLACOVU.COM', N'arif@placovu.com', N'ARIF@PLACOVU.COM', 0, N'AQAAAAIAAYagAAAAEGOvsxN8tTmwfoXMXUQIbB2x2nKi1YDD74uG7aZ/8cNppVp5YvNrcj+7ed5/zp9XiQ==', N'L7QN6ZEOIEOJES5TJVRBU5VJJVJEAEYA', N'226bd3ec-baa4-4c4f-967c-530f076941c3', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [RoleName], [LastLoggedIn], [CreatedDate], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'725529dd-fd86-4f17-99a4-b51900879e3f', N'Admin', N'A', N'Admin', CAST(N'2024-12-30T03:12:44.0611970' AS DateTime2), CAST(N'2024-12-22T12:30:33.6619802' AS DateTime2), N'admin@gmail.com', N'ADMIN@GMAIL.COM', N'admin@gmail.com', N'ADMIN@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEPVqwtdJNoBiTnAKxGNUDiSbfJ4mPFTjfFHfS4QAUUPSy0d2ZTbyIYaDJcmjsunXXg==', N'CNSGHK3K3SOECQNU4JFQCT3TQ7WOT2HJ', N'ac974764-3e11-4bf8-b766-b94f77ef2a99', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [RoleName], [LastLoggedIn], [CreatedDate], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'cc03fe0c-e209-4ecf-b71f-7d22a033bb5e', N'Sharmin', N'Jannat', N'User', CAST(N'2024-12-22T13:33:06.4739798' AS DateTime2), CAST(N'2024-12-22T12:30:05.0123094' AS DateTime2), N'sharmin@gmail.com', N'SHARMIN@GMAIL.COM', N'sharmin@gmail.com', N'SHARMIN@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAENqo4mPUr4ucaVjuMQdioXhKffipcKsFqzZHVmyWxm9KaMZoX+e+f6snfMjD6IJUag==', N'NMKTU3XU3B7ZASXMISYASGV4U3SDB4DZ', N'ee56c7d1-fef0-4748-bd56-d6417ee1ab63', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [RoleName], [LastLoggedIn], [CreatedDate], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'dfd8261b-a6cc-4532-9c11-0b70e9780dea', N'Rasel', N'Ahmed', N'User', CAST(N'2024-12-22T13:52:40.4608944' AS DateTime2), CAST(N'2024-12-22T12:29:37.3416765' AS DateTime2), N'rasel@gmail.com', N'RASEL@GMAIL.COM', N'rasel@gmail.com', N'RASEL@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAECG/8yw77G5o0SiNKItyLtoT8M5dU0IIgs1RqTMzdAbj0WOWeIppeZ73MLwp4eh3gw==', N'5HMCUQQPMHV4RAPNZKFRHDAPXML5TR3E', N'6d8ebbd1-ec8b-401e-ab11-19ab74f698b3', NULL, 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Comments] ON 

INSERT [dbo].[Comments] ([CommentId], [TemplateId], [UserId], [CommentText], [CreatedBy], [CreatedDate]) VALUES (1, 1, N'dfd8261b-a6cc-4532-9c11-0b70e9780dea', N'It''s Good', N'Rasel Ahmed', CAST(N'2024-12-22T12:45:07.8844270' AS DateTime2))
INSERT [dbo].[Comments] ([CommentId], [TemplateId], [UserId], [CommentText], [CreatedBy], [CreatedDate]) VALUES (2, 1, N'612963b2-5d8a-47b7-93f6-66c109683757', N'Cool Place', N'Arif Hossain', CAST(N'2024-12-22T13:13:50.1235677' AS DateTime2))
INSERT [dbo].[Comments] ([CommentId], [TemplateId], [UserId], [CommentText], [CreatedBy], [CreatedDate]) VALUES (3, 1, N'cc03fe0c-e209-4ecf-b71f-7d22a033bb5e', N'Thanks', N'Sharmin Jannat', CAST(N'2024-12-22T13:33:21.4273042' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Comments] OFF
GO
SET IDENTITY_INSERT [dbo].[Forms] ON 

INSERT [dbo].[Forms] ([FormId], [TemplateId], [UserId], [SubmittedDate]) VALUES (1, 1, N'dfd8261b-a6cc-4532-9c11-0b70e9780dea', CAST(N'2024-12-22T18:44:30.4279164' AS DateTime2))
INSERT [dbo].[Forms] ([FormId], [TemplateId], [UserId], [SubmittedDate]) VALUES (2, 1, N'612963b2-5d8a-47b7-93f6-66c109683757', CAST(N'2024-12-22T19:13:27.5158639' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Forms] OFF
GO
SET IDENTITY_INSERT [dbo].[FormSpecificUsers] ON 

INSERT [dbo].[FormSpecificUsers] ([FormSpecificUserId], [UserId], [TemplateId]) VALUES (3, N'Authenticated_User', 3)
INSERT [dbo].[FormSpecificUsers] ([FormSpecificUserId], [UserId], [TemplateId]) VALUES (15, N'cc03fe0c-e209-4ecf-b71f-7d22a033bb5e', 1)
INSERT [dbo].[FormSpecificUsers] ([FormSpecificUserId], [UserId], [TemplateId]) VALUES (16, N'dfd8261b-a6cc-4532-9c11-0b70e9780dea', 1)
INSERT [dbo].[FormSpecificUsers] ([FormSpecificUserId], [UserId], [TemplateId]) VALUES (17, N'725529dd-fd86-4f17-99a4-b51900879e3f', 1)
INSERT [dbo].[FormSpecificUsers] ([FormSpecificUserId], [UserId], [TemplateId]) VALUES (19, N'Authenticated_User', 2)
SET IDENTITY_INSERT [dbo].[FormSpecificUsers] OFF
GO
SET IDENTITY_INSERT [dbo].[Likes] ON 

INSERT [dbo].[Likes] ([LikeId], [TemplateId], [UserId], [LikedDate]) VALUES (1, 1, N'dfd8261b-a6cc-4532-9c11-0b70e9780dea', CAST(N'2024-12-22T12:44:57.5918453' AS DateTime2))
INSERT [dbo].[Likes] ([LikeId], [TemplateId], [UserId], [LikedDate]) VALUES (3, 1, N'cc03fe0c-e209-4ecf-b71f-7d22a033bb5e', CAST(N'2024-12-22T13:33:27.2966555' AS DateTime2))
INSERT [dbo].[Likes] ([LikeId], [TemplateId], [UserId], [LikedDate]) VALUES (5, 1, N'725529dd-fd86-4f17-99a4-b51900879e3f', CAST(N'2024-12-22T14:14:40.9492702' AS DateTime2))
INSERT [dbo].[Likes] ([LikeId], [TemplateId], [UserId], [LikedDate]) VALUES (7, 2, N'612963b2-5d8a-47b7-93f6-66c109683757', CAST(N'2024-12-22T14:42:38.4436096' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Likes] OFF
GO
SET IDENTITY_INSERT [dbo].[Questions] ON 

INSERT [dbo].[Questions] ([QuestionId], [TemplateId], [QuestionType], [SelectedOptionId], [QuestionTitle], [Description], [IsDisplayed], [DisplayOrder]) VALUES (1, 1, N'4', 1, N'Do you love Chinabon sweets?', N'Describe about how much you love to do Chinabon Sweets.', 1, 1)
INSERT [dbo].[Questions] ([QuestionId], [TemplateId], [QuestionType], [SelectedOptionId], [QuestionTitle], [Description], [IsDisplayed], [DisplayOrder]) VALUES (2, 1, N'1', 0, N'Where it is located?', N'Let us know about the location of Chinabon', 1, 2)
INSERT [dbo].[Questions] ([QuestionId], [TemplateId], [QuestionType], [SelectedOptionId], [QuestionTitle], [Description], [IsDisplayed], [DisplayOrder]) VALUES (3, 1, N'2', 0, N'Describe about the Chinnabon?', N'Describe about the Chinabon shortly', 1, 3)
INSERT [dbo].[Questions] ([QuestionId], [TemplateId], [QuestionType], [SelectedOptionId], [QuestionTitle], [Description], [IsDisplayed], [DisplayOrder]) VALUES (4, 1, N'3', 0, N'Rate Chinabon.', N'Rate Chinabon with your experience.', 1, 4)
INSERT [dbo].[Questions] ([QuestionId], [TemplateId], [QuestionType], [SelectedOptionId], [QuestionTitle], [Description], [IsDisplayed], [DisplayOrder]) VALUES (5, 1, N'1', 0, N'Test Question Appear.', N'Testing question is appear in the form or not', 0, 5)
SET IDENTITY_INSERT [dbo].[Questions] OFF
GO
SET IDENTITY_INSERT [dbo].[Tags] ON 

INSERT [dbo].[Tags] ([TagId], [TagName], [TemplateId]) VALUES (1, N'chemistry', NULL)
INSERT [dbo].[Tags] ([TagId], [TagName], [TemplateId]) VALUES (2, N'biology', NULL)
INSERT [dbo].[Tags] ([TagId], [TagName], [TemplateId]) VALUES (3, N'physics', NULL)
INSERT [dbo].[Tags] ([TagId], [TagName], [TemplateId]) VALUES (4, N'quiz_test', NULL)
INSERT [dbo].[Tags] ([TagId], [TagName], [TemplateId]) VALUES (5, N'asdf', NULL)
INSERT [dbo].[Tags] ([TagId], [TagName], [TemplateId]) VALUES (6, N'qwer', NULL)
INSERT [dbo].[Tags] ([TagId], [TagName], [TemplateId]) VALUES (7, N'zxcv', NULL)
INSERT [dbo].[Tags] ([TagId], [TagName], [TemplateId]) VALUES (8, N'rrrr', NULL)
INSERT [dbo].[Tags] ([TagId], [TagName], [TemplateId]) VALUES (9, N'qqqq', NULL)
SET IDENTITY_INSERT [dbo].[Tags] OFF
GO
SET IDENTITY_INSERT [dbo].[Templates] ON 

INSERT [dbo].[Templates] ([TemplateId], [UserId], [Title], [Description], [TopicId], [Tags], [Image], [AccessMode], [CreatedBy], [CreatedDate]) VALUES (1, N'725529dd-fd86-4f17-99a4-b51900879e3f', N'Chinabon', N'<p>About chinabon</p>', 3, NULL, N'/uploads/testimonials-1.jpg', N'Specified_User', N'admin@gmail.com', CAST(N'2024-12-28T11:31:40.1707437' AS DateTime2))
INSERT [dbo].[Templates] ([TemplateId], [UserId], [Title], [Description], [TopicId], [Tags], [Image], [AccessMode], [CreatedBy], [CreatedDate]) VALUES (2, N'725529dd-fd86-4f17-99a4-b51900879e3f', N'Test Template', N'<p>fvdfvfdv</p>', 0, N'asdf,qwer,zxcv,rrrr,qqqq,chemistry', N'/uploads/istockphoto-1437816897-612x612.jpg', N'Authenticated_User', N'admin@gmail.com', CAST(N'2024-12-30T11:08:40.5809260' AS DateTime2))
INSERT [dbo].[Templates] ([TemplateId], [UserId], [Title], [Description], [TopicId], [Tags], [Image], [AccessMode], [CreatedBy], [CreatedDate]) VALUES (3, N'dfd8261b-a6cc-4532-9c11-0b70e9780dea', N'Test template from rasel', NULL, 0, NULL, NULL, N'Authenticated_User', N'rasel@gmail.com', CAST(N'2024-12-22T18:42:58.4262419' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Templates] OFF
GO
SET IDENTITY_INSERT [dbo].[Topics] ON 

INSERT [dbo].[Topics] ([TopicId], [TopicName]) VALUES (1, N'Education')
INSERT [dbo].[Topics] ([TopicId], [TopicName]) VALUES (2, N'Quiz')
INSERT [dbo].[Topics] ([TopicId], [TopicName]) VALUES (3, N'Other')
SET IDENTITY_INSERT [dbo].[Topics] OFF
GO
ALTER TABLE [dbo].[Answers]  WITH CHECK ADD  CONSTRAINT [FK_Answers_Forms_FormId] FOREIGN KEY([FormId])
REFERENCES [dbo].[Forms] ([FormId])
GO
ALTER TABLE [dbo].[Answers] CHECK CONSTRAINT [FK_Answers_Forms_FormId]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Templates_TemplateId] FOREIGN KEY([TemplateId])
REFERENCES [dbo].[Templates] ([TemplateId])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Templates_TemplateId]
GO
ALTER TABLE [dbo].[Forms]  WITH CHECK ADD  CONSTRAINT [FK_Forms_Templates_TemplateId] FOREIGN KEY([TemplateId])
REFERENCES [dbo].[Templates] ([TemplateId])
GO
ALTER TABLE [dbo].[Forms] CHECK CONSTRAINT [FK_Forms_Templates_TemplateId]
GO
ALTER TABLE [dbo].[FormSpecificUsers]  WITH CHECK ADD  CONSTRAINT [FK_FormSpecificUsers_Templates_TemplateId] FOREIGN KEY([TemplateId])
REFERENCES [dbo].[Templates] ([TemplateId])
GO
ALTER TABLE [dbo].[FormSpecificUsers] CHECK CONSTRAINT [FK_FormSpecificUsers_Templates_TemplateId]
GO
ALTER TABLE [dbo].[Likes]  WITH CHECK ADD  CONSTRAINT [FK_Likes_Templates_TemplateId] FOREIGN KEY([TemplateId])
REFERENCES [dbo].[Templates] ([TemplateId])
GO
ALTER TABLE [dbo].[Likes] CHECK CONSTRAINT [FK_Likes_Templates_TemplateId]
GO
ALTER TABLE [dbo].[QuestionOptions]  WITH CHECK ADD  CONSTRAINT [FK_QuestionOptions_Questions_QuestionId] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Questions] ([QuestionId])
GO
ALTER TABLE [dbo].[QuestionOptions] CHECK CONSTRAINT [FK_QuestionOptions_Questions_QuestionId]
GO
ALTER TABLE [dbo].[Questions]  WITH CHECK ADD  CONSTRAINT [FK_Questions_Templates_TemplateId] FOREIGN KEY([TemplateId])
REFERENCES [dbo].[Templates] ([TemplateId])
GO
ALTER TABLE [dbo].[Questions] CHECK CONSTRAINT [FK_Questions_Templates_TemplateId]
GO
