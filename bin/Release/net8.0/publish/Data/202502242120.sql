
/****** Object:  Table [dbo].[Admin]    Script Date: 2025/2/24 21:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[AdminID] [int] IDENTITY(1,1) NOT NULL,
	[CreateUserID] [int] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateUserID] [int] NULL,
	[UpdateDate] [datetime] NULL,
	[Del] [int] NULL,
	[AdminName] [nvarchar](50) NULL,
	[AdminNick] [nvarchar](50) NULL,
	[PassWord] [nvarchar](200) NULL,
	[RoleID] [int] NULL,
	[Statues] [int] NULL,
	[LoginAttempts] [int] NULL,
	[LoginAttemptsLast] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AdminID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdminPower]    Script Date: 2025/2/24 21:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminPower](
	[PowerID] [int] IDENTITY(1,1) NOT NULL,
	[CreateUserID] [int] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateUserID] [int] NULL,
	[UpdateDate] [datetime] NULL,
	[Del] [int] NULL,
	[ParentID] [int] NULL,
	[PowerTitle] [nvarchar](50) NULL,
 CONSTRAINT [PK_AdminPower] PRIMARY KEY CLUSTERED 
(
	[PowerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdminRoles]    Script Date: 2025/2/24 21:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminRoles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[CreateUserID] [int] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateUserID] [int] NULL,
	[UpdateDate] [datetime] NULL,
	[Del] [int] NULL,
	[RolesTitle] [nvarchar](50) NULL,
	[Powers] [nvarchar](2000) NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArticleCategory]    Script Date: 2025/2/24 21:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArticleCategory](
	[BigID] [int] IDENTITY(1,1) NOT NULL,
	[CreateUserID] [int] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateUserID] [int] NULL,
	[UpdateDate] [datetime] NULL,
	[Del] [int] NULL,
	[ParentID] [int] NULL,
	[Depths] [int] NULL,
	[ParentIDs] [nvarchar](2000) NULL,
	[ParentIDFirst] [int] NULL,
	[Statues] [int] NULL,
	[BigTitle] [nvarchar](50) NULL,
	[KeyTitle] [nvarchar](200) NULL,
	[KeyWord] [nvarchar](200) NULL,
	[KeyDesn] [nvarchar](500) NULL,
	[Images] [nvarchar](200) NULL,
	[ImagesPhone] [nvarchar](200) NULL,
	[Sorts] [int] NULL,
	[SiteUrl] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[BigID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Articles]    Script Date: 2025/2/24 21:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articles](
	[ArticleID] [int] IDENTITY(1,1) NOT NULL,
	[CreateUserID] [int] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateUserID] [int] NULL,
	[UpdateDate] [datetime] NULL,
	[Del] [int] NULL,
	[BigID] [int] NULL,
	[ArticleTitle] [nvarchar](200) NULL,
	[Articlekey] [nvarchar](200) NULL,
	[ArticleDesn] [nvarchar](500) NULL,
	[Statues] [int] NULL,
	[Sorts] [int] NULL,
	[NavSites] [nvarchar](200) NULL,
	[ReleaseTime] [datetime] NULL,
	[Hits] [int] NULL,
	[Image] [nvarchar](500) NULL,
	[Images] [nvarchar](500) NULL,
	[Desn] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ArticleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Admin] ON 
GO
INSERT [dbo].[Admin] ([AdminID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [AdminName], [AdminNick], [PassWord], [RoleID], [Statues], [LoginAttempts], [LoginAttemptsLast]) VALUES (1, 0, CAST(N'2024-10-23T14:23:25.210' AS DateTime), 1, CAST(N'2024-11-22T15:05:37.073' AS DateTime), 0, N'niqiu', N'niqiu', N'CE-0B-FD-15-05-9B-68-D6-76-88-88-4D-7A-3D-3E-8C', 1, 0, 0, CAST(N'2025-02-24T21:09:09.087' AS DateTime))
GO
INSERT [dbo].[Admin] ([AdminID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [AdminName], [AdminNick], [PassWord], [RoleID], [Statues], [LoginAttempts], [LoginAttemptsLast]) VALUES (2, 1, CAST(N'2024-11-22T09:03:45.333' AS DateTime), 1, CAST(N'2024-11-22T10:24:49.350' AS DateTime), 1, N'1', N'2', N'CE-0B-FD-15-05-9B-68-D6-76-88-88-4D-7A-3D-3E-8C', 7, 0, 0, NULL)
GO
INSERT [dbo].[Admin] ([AdminID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [AdminName], [AdminNick], [PassWord], [RoleID], [Statues], [LoginAttempts], [LoginAttemptsLast]) VALUES (3, 1, CAST(N'2024-11-22T09:16:32.057' AS DateTime), 1, CAST(N'2024-11-22T10:24:55.223' AS DateTime), 1, N'1', N'2', N'30-9F-C7-D3-BC-53-BB-63-AC-42-E3-59-26-0A-C7-40', 1, 0, 0, NULL)
GO
INSERT [dbo].[Admin] ([AdminID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [AdminName], [AdminNick], [PassWord], [RoleID], [Statues], [LoginAttempts], [LoginAttemptsLast]) VALUES (4, 1, CAST(N'2024-11-25T22:58:43.857' AS DateTime), 0, NULL, 0, N'sunuer', N'sunuer', N'CE-0B-FD-15-05-9B-68-D6-76-88-88-4D-7A-3D-3E-8C', 8, 0, 0, CAST(N'2024-11-25T22:59:46.497' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Admin] OFF
GO
SET IDENTITY_INSERT [dbo].[AdminPower] ON 
GO
INSERT [dbo].[AdminPower] ([PowerID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [ParentID], [PowerTitle]) VALUES (1, 0, CAST(N'2024-10-23T14:24:08.477' AS DateTime), 0, NULL, 0, 0, N'Permission Management')
GO
INSERT [dbo].[AdminPower] ([PowerID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [ParentID], [PowerTitle]) VALUES (2, 0, CAST(N'2024-10-23T14:24:11.987' AS DateTime), 0, NULL, 0, 1, N'Add Permission')
GO
INSERT [dbo].[AdminPower] ([PowerID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [ParentID], [PowerTitle]) VALUES (3, 0, CAST(N'2024-10-23T14:24:15.367' AS DateTime), 0, NULL, 0, 1, N'Edit Permission')
GO
INSERT [dbo].[AdminPower] ([PowerID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [ParentID], [PowerTitle]) VALUES (4, 0, CAST(N'2024-10-23T14:24:18.950' AS DateTime), 0, NULL, 0, 1, N'Delete Permission')
GO
INSERT [dbo].[AdminPower] ([PowerID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [ParentID], [PowerTitle]) VALUES (5, 0, CAST(N'2024-10-23T14:24:22.710' AS DateTime), 0, NULL, 0, 0, N'Role Management')
GO
INSERT [dbo].[AdminPower] ([PowerID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [ParentID], [PowerTitle]) VALUES (6, 0, CAST(N'2024-10-23T14:24:25.660' AS DateTime), 0, NULL, 0, 5, N'Add Role')
GO
INSERT [dbo].[AdminPower] ([PowerID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [ParentID], [PowerTitle]) VALUES (7, 0, CAST(N'2024-10-23T14:24:28.490' AS DateTime), 0, NULL, 0, 5, N'Edt Role')
GO
INSERT [dbo].[AdminPower] ([PowerID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [ParentID], [PowerTitle]) VALUES (8, 0, CAST(N'2024-10-23T14:24:34.993' AS DateTime), 0, NULL, 0, 5, N'Delete Role')
GO
INSERT [dbo].[AdminPower] ([PowerID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [ParentID], [PowerTitle]) VALUES (9, 0, CAST(N'2024-10-23T14:24:38.563' AS DateTime), 0, NULL, 0, 0, N'Administrator Management')
GO
INSERT [dbo].[AdminPower] ([PowerID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [ParentID], [PowerTitle]) VALUES (10, 0, CAST(N'2024-10-23T14:24:41.600' AS DateTime), 0, NULL, 0, 9, N'Add Administrator')
GO
INSERT [dbo].[AdminPower] ([PowerID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [ParentID], [PowerTitle]) VALUES (11, 0, CAST(N'2024-10-23T14:24:48.350' AS DateTime), 0, NULL, 0, 9, N'Edt Administrator')
GO
INSERT [dbo].[AdminPower] ([PowerID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [ParentID], [PowerTitle]) VALUES (12, 0, CAST(N'2024-10-23T14:24:49.173' AS DateTime), 0, NULL, 0, 9, N'Delete Administrator')
GO
INSERT [dbo].[AdminPower] ([PowerID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [ParentID], [PowerTitle]) VALUES (13, 1, CAST(N'2024-11-21T15:26:35.610' AS DateTime), 0, NULL, 0, 0, N'My Settings')
GO
INSERT [dbo].[AdminPower] ([PowerID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [ParentID], [PowerTitle]) VALUES (14, 1, CAST(N'2024-11-21T15:26:37.307' AS DateTime), 0, NULL, 0, 13, N'Basic Information')
GO
INSERT [dbo].[AdminPower] ([PowerID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [ParentID], [PowerTitle]) VALUES (15, 1, CAST(N'2024-11-21T15:27:06.943' AS DateTime), 1, CAST(N'2024-11-21T16:14:13.460' AS DateTime), 0, 13, N'Change Password')
GO
INSERT [dbo].[AdminPower] ([PowerID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [ParentID], [PowerTitle]) VALUES (16, 1, CAST(N'2024-11-21T15:27:37.940' AS DateTime), 1, CAST(N'2024-11-21T16:15:50.470' AS DateTime), 1, 0, N'Article Management')
GO
INSERT [dbo].[AdminPower] ([PowerID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [ParentID], [PowerTitle]) VALUES (17, 1, CAST(N'2024-11-21T15:56:28.290' AS DateTime), 0, NULL, 0, 16, N'Article Categories')
GO
INSERT [dbo].[AdminPower] ([PowerID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [ParentID], [PowerTitle]) VALUES (19, 1, CAST(N'2024-11-21T16:20:57.590' AS DateTime), 0, NULL, 0, 16, N'Add Article Category')
GO
INSERT [dbo].[AdminPower] ([PowerID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [ParentID], [PowerTitle]) VALUES (20, 0, CAST(N'2024-11-22T15:09:06.470' AS DateTime), 0, NULL, 0, 16, N'Edit Article Category')
GO
INSERT [dbo].[AdminPower] ([PowerID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [ParentID], [PowerTitle]) VALUES (21, 0, CAST(N'2024-11-22T15:09:09.760' AS DateTime), 0, NULL, 0, 16, N'Delete Article Category')
GO
INSERT [dbo].[AdminPower] ([PowerID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [ParentID], [PowerTitle]) VALUES (22, 0, CAST(N'2024-11-22T15:09:20.227' AS DateTime), 0, NULL, 0, 16, N'Add Article')
GO
INSERT [dbo].[AdminPower] ([PowerID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [ParentID], [PowerTitle]) VALUES (23, 0, CAST(N'2024-11-22T15:09:24.637' AS DateTime), 0, NULL, 0, 16, N'Edit Article')
GO
INSERT [dbo].[AdminPower] ([PowerID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [ParentID], [PowerTitle]) VALUES (24, 0, CAST(N'2024-11-22T15:09:27.413' AS DateTime), 0, NULL, 0, 16, N'Delete Article')
GO
SET IDENTITY_INSERT [dbo].[AdminPower] OFF
GO
SET IDENTITY_INSERT [dbo].[AdminRoles] ON 
GO
INSERT [dbo].[AdminRoles] ([RoleID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [RolesTitle], [Powers]) VALUES (1, 0, CAST(N'2024-10-23T14:25:32.850' AS DateTime), 0, NULL, 0, N'Super Administrator', N'|1|2|3|4|5|6|7|8|9|10|11|12|13|14|15|16|17|18|19|20|21|22|23|24|25|26|27|28|')
GO
INSERT [dbo].[AdminRoles] ([RoleID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [RolesTitle], [Powers]) VALUES (9, 1, CAST(N'2024-11-25T23:01:33.960' AS DateTime), 1, CAST(N'2024-11-25T23:01:47.697' AS DateTime), 0, N'Employee', N'|9|10|11|')
GO
SET IDENTITY_INSERT [dbo].[AdminRoles] OFF
GO
SET IDENTITY_INSERT [dbo].[ArticleCategory] ON 
GO
INSERT [dbo].[ArticleCategory] ([BigID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [ParentID], [Depths], [ParentIDs], [ParentIDFirst], [Statues], [BigTitle], [KeyTitle], [KeyWord], [KeyDesn], [Images], [ImagesPhone], [Sorts], [SiteUrl]) VALUES (1, 1, CAST(N'2024-11-28T10:59:15.923' AS DateTime), 0, NULL, 0, 0, 1, N'0', 1, 0, N'Menu', N'Menu', N'Menu', N'', N'/images/morenimg.png', N'/images/morenimg.png', 0, NULL)
GO
INSERT [dbo].[ArticleCategory] ([BigID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [ParentID], [Depths], [ParentIDs], [ParentIDFirst], [Statues], [BigTitle], [KeyTitle], [KeyWord], [KeyDesn], [Images], [ImagesPhone], [Sorts], [SiteUrl]) VALUES (2, 1, CAST(N'2024-11-28T11:00:12.990' AS DateTime), 1, CAST(N'2024-12-03T11:06:42.490' AS DateTime), 0, 1, 2, N'0,1', 1, 0, N'Cases', N'Cases', N'Cases', N'Cases', N'/Uploadfile/2024/12/42498982-2530-4d6b-80dd-c20573b57eff.jpg', N'/images/morenimg.png', 0, N'Cases')
GO
INSERT [dbo].[ArticleCategory] ([BigID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [ParentID], [Depths], [ParentIDs], [ParentIDFirst], [Statues], [BigTitle], [KeyTitle], [KeyWord], [KeyDesn], [Images], [ImagesPhone], [Sorts], [SiteUrl]) VALUES (3, 1, CAST(N'2024-11-28T11:00:38.570' AS DateTime), 1, CAST(N'2024-12-03T14:01:33.807' AS DateTime), 0, 1, 2, N'0,1', 1, 0, N'News', N'News', N'News', N'News', N'/Uploadfile/2024/12/8e773f36-b270-437b-a426-d4e5ea9bb644.jpg', N'/images/morenimg.png', 0, N'News')
GO
INSERT [dbo].[ArticleCategory] ([BigID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [ParentID], [Depths], [ParentIDs], [ParentIDFirst], [Statues], [BigTitle], [KeyTitle], [KeyWord], [KeyDesn], [Images], [ImagesPhone], [Sorts], [SiteUrl]) VALUES (4, 1, CAST(N'2024-11-28T11:00:53.253' AS DateTime), 1, CAST(N'2024-12-03T14:01:52.930' AS DateTime), 0, 3, 3, N'0,1,3', 1, 0, N'News Information', N'News Information', N'News Information', N'News Information', N'/Uploadfile/2024/12/26db936f-f478-4969-9412-3e5ef946f419.jpg', N'/images/morenimg.png', 0, N'News?nid=4')
GO
INSERT [dbo].[ArticleCategory] ([BigID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [ParentID], [Depths], [ParentIDs], [ParentIDFirst], [Statues], [BigTitle], [KeyTitle], [KeyWord], [KeyDesn], [Images], [ImagesPhone], [Sorts], [SiteUrl]) VALUES (5, 1, CAST(N'2024-11-28T11:01:08.050' AS DateTime), 1, CAST(N'2024-12-03T14:02:04.597' AS DateTime), 0, 3, 3, N'0,1,3', 1, 0, N'Development News', N'Development News', N'Development News', N'Development News', N'/Uploadfile/2024/12/660c2906-6da5-4983-abe2-3d21d9958bde.jpg', N'/images/morenimg.png', 0, N'News?nid=5')
GO
INSERT [dbo].[ArticleCategory] ([BigID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [ParentID], [Depths], [ParentIDs], [ParentIDFirst], [Statues], [BigTitle], [KeyTitle], [KeyWord], [KeyDesn], [Images], [ImagesPhone], [Sorts], [SiteUrl]) VALUES (6, 1, CAST(N'2024-11-28T11:01:20.407' AS DateTime), 1, CAST(N'2024-12-03T14:02:19.583' AS DateTime), 0, 3, 3, N'0,1,3', 1, 0, N'IT News', N'IT News', N'IT News', N'IT News', N'/Uploadfile/2024/12/ead5ff6e-3e62-4bc6-b746-3e7f58696688.jpg', N'/images/morenimg.png', 0, N'News?nid=6')
GO
INSERT [dbo].[ArticleCategory] ([BigID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [ParentID], [Depths], [ParentIDs], [ParentIDFirst], [Statues], [BigTitle], [KeyTitle], [KeyWord], [KeyDesn], [Images], [ImagesPhone], [Sorts], [SiteUrl]) VALUES (7, 1, CAST(N'2024-11-28T11:01:40.713' AS DateTime), 1, CAST(N'2024-12-03T15:28:33.720' AS DateTime), 0, 1, 2, N'0,1', 1, 0, N'About Us', N'About Us', N'About Us', N'About Us', N'/Uploadfile/2024/12/88494729-acd0-4dd6-a843-ef3891a32e84.jpg', N'/images/morenimg.png', 0, N'About')
GO
INSERT [dbo].[ArticleCategory] ([BigID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [ParentID], [Depths], [ParentIDs], [ParentIDFirst], [Statues], [BigTitle], [KeyTitle], [KeyWord], [KeyDesn], [Images], [ImagesPhone], [Sorts], [SiteUrl]) VALUES (8, 1, CAST(N'2024-11-28T11:01:52.713' AS DateTime), 1, CAST(N'2024-12-03T15:28:53.353' AS DateTime), 0, 1, 2, N'0,1', 1, 0, N'Contact Us', N'Contact Us', N'Contact Us', N'Contact Us', N'/Uploadfile/2024/12/3fe62bc1-e6ba-4444-9e51-aeebed00c1be.jpg', N'/images/morenimg.png', 0, N'Contact')
GO
INSERT [dbo].[ArticleCategory] ([BigID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [ParentID], [Depths], [ParentIDs], [ParentIDFirst], [Statues], [BigTitle], [KeyTitle], [KeyWord], [KeyDesn], [Images], [ImagesPhone], [Sorts], [SiteUrl]) VALUES (9, 1, CAST(N'2024-11-28T11:03:51.827' AS DateTime), 1, CAST(N'2024-12-03T10:01:11.270' AS DateTime), 0, 1, 2, N'0,1', 1, 1, N'Carousel', N'Carousel', N'Carousel', N'Carousel', N'/images/morenimg.png', N'/images/morenimg.png', 0, N'')
GO
INSERT [dbo].[ArticleCategory] ([BigID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [ParentID], [Depths], [ParentIDs], [ParentIDFirst], [Statues], [BigTitle], [KeyTitle], [KeyWord], [KeyDesn], [Images], [ImagesPhone], [Sorts], [SiteUrl]) VALUES (10, 1, CAST(N'2024-12-02T13:37:23.397' AS DateTime), 1, CAST(N'2024-12-03T11:00:27.900' AS DateTime), 0, 1, 2, N'0,1', 1, 0, N'Products', N'Products', N'Products', N'', N'/images/morenimg.png', N'/images/morenimg.png', 10, N'Products')
GO
SET IDENTITY_INSERT [dbo].[ArticleCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[Articles] ON 
GO
INSERT [dbo].[Articles] ([ArticleID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [BigID], [ArticleTitle], [Articlekey], [ArticleDesn], [Statues], [Sorts], [NavSites], [ReleaseTime], [Hits], [Image], [Images], [Desn]) VALUES (1, 1, CAST(N'2024-12-02T11:48:17.593' AS DateTime), 1, CAST(N'2024-12-28T16:31:33.337' AS DateTime), 1, 9, N'MES系统', N'MES Manage', N'项目看板管理、生产过程控制、工具工装管理等功能', 0, 0, N'', CAST(N'2024-12-02T11:46:36.000' AS DateTime), 0, N'/Uploadfile/2024/12/b36d95a1-f6f6-460c-9617-60464f4f4a46.jpg', N'/Uploadfile/2024/12/e2136ad6-76ef-4695-b228-aba59caf8850.jpg', N'')
GO
INSERT [dbo].[Articles] ([ArticleID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [BigID], [ArticleTitle], [Articlekey], [ArticleDesn], [Statues], [Sorts], [NavSites], [ReleaseTime], [Hits], [Image], [Images], [Desn]) VALUES (2, 1, CAST(N'2024-12-02T11:54:18.433' AS DateTime), 1, CAST(N'2025-02-24T21:09:32.803' AS DateTime), 0, 9, N'Sunuer Manage', N'Sunuer Manage Management System', N'The all-in-one solution for modern management', 0, 0, N'', CAST(N'2024-12-02T11:52:38.000' AS DateTime), 0, N'/Uploadfile/2025/02/ad0eeb60-04ca-4de9-8571-0c235c9d584f.png', N'', N'<p>The all-in-one solution for modern management</p>')
GO
INSERT [dbo].[Articles] ([ArticleID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [BigID], [ArticleTitle], [Articlekey], [ArticleDesn], [Statues], [Sorts], [NavSites], [ReleaseTime], [Hits], [Image], [Images], [Desn]) VALUES (3, 1, CAST(N'2024-12-02T11:56:59.227' AS DateTime), 1, CAST(N'2025-02-24T21:09:24.570' AS DateTime), 0, 9, N'Sunuer Easy', N'Sunuer Easy Code Generator', N'Code smarter, build faster', 0, 0, N'', CAST(N'2024-12-02T11:54:22.000' AS DateTime), 0, N'/Uploadfile/2025/02/f5c6f39c-17fd-4d6d-a15f-ba1f3aed6fca.png', N'', N'<p>Code smarter, build faster</p>')
GO
INSERT [dbo].[Articles] ([ArticleID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [BigID], [ArticleTitle], [Articlekey], [ArticleDesn], [Statues], [Sorts], [NavSites], [ReleaseTime], [Hits], [Image], [Images], [Desn]) VALUES (4, 1, CAST(N'2024-12-02T20:38:47.773' AS DateTime), 1, CAST(N'2025-02-24T21:13:24.060' AS DateTime), 0, 2, N'Sunuer Finance', N'Sunuer Finance', N'Sunuer Finance', 0, 0, N'', CAST(N'2024-12-02T20:37:14.000' AS DateTime), 0, N'/Uploadfile/2025/02/17cf8ea1-a8f1-42df-959a-a32faf97a7bb.png', N'', N'<p>Sunuer Finance</p>')
GO
INSERT [dbo].[Articles] ([ArticleID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [BigID], [ArticleTitle], [Articlekey], [ArticleDesn], [Statues], [Sorts], [NavSites], [ReleaseTime], [Hits], [Image], [Images], [Desn]) VALUES (5, 1, CAST(N'2024-12-03T08:49:30.333' AS DateTime), 1, CAST(N'2025-02-24T21:14:21.693' AS DateTime), 0, 7, N'About Us', N'About Us', N'About Us, SunuerManage, Smarter Management, More Efficient Work', 0, 0, N'', CAST(N'2024-12-03T08:47:37.000' AS DateTime), 0, N'/images/morenimg.png', N'', N'<p style="text-indent: 2em; color: rgba(0, 0, 0, 0.85); font-family: &quot;Helvetica Neue&quot;, Helvetica, &quot;PingFang SC&quot;, Tahoma, Arial, sans-serif;">About Us, SunuerManage, Smarter Management, More Efficient Work</p>')
GO
INSERT [dbo].[Articles] ([ArticleID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [BigID], [ArticleTitle], [Articlekey], [ArticleDesn], [Statues], [Sorts], [NavSites], [ReleaseTime], [Hits], [Image], [Images], [Desn]) VALUES (6, 1, CAST(N'2024-12-03T08:49:51.567' AS DateTime), 1, CAST(N'2025-02-24T21:14:49.307' AS DateTime), 0, 8, N'Contact Us', N'Contact Us', N'Contact Us', 0, 0, N'', CAST(N'2024-12-03T08:49:34.000' AS DateTime), 0, N'/images/morenimg.png', N'', N'<p style="text-indent: 2em; color: rgba(0, 0, 0, 0.85); font-family: &quot;Helvetica Neue&quot;, Helvetica, &quot;PingFang SC&quot;, Tahoma, Arial, sans-serif;">Contact Us</p>')
GO
INSERT [dbo].[Articles] ([ArticleID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [BigID], [ArticleTitle], [Articlekey], [ArticleDesn], [Statues], [Sorts], [NavSites], [ReleaseTime], [Hits], [Image], [Images], [Desn]) VALUES (7, 1, CAST(N'2024-12-03T08:58:20.527' AS DateTime), 1, CAST(N'2025-02-24T20:44:41.047' AS DateTime), 0, 5, N'Mixing Razor and JavaScript code', N'Mixing Razor and JavaScript code', N'Mixing Razor and JavaScript code', 0, 0, N'', CAST(N'2024-12-03T08:57:29.000' AS DateTime), 0, N'/Uploadfile/2024/12/bc40c475-1b54-4ff3-8c51-af9e6175494d.png', N'', N'<p>Mixing Razor and JavaScript code</p>')
GO
INSERT [dbo].[Articles] ([ArticleID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [BigID], [ArticleTitle], [Articlekey], [ArticleDesn], [Statues], [Sorts], [NavSites], [ReleaseTime], [Hits], [Image], [Images], [Desn]) VALUES (8, 1, CAST(N'2024-12-03T08:59:48.880' AS DateTime), 1, CAST(N'2025-02-24T20:44:01.567' AS DateTime), 0, 5, N'In ASP.NET, @() is the syntax used in Razor for nesting expressions, indicating dynamic content generation.', N'In ASP.NET, @() is the syntax used in Razor for nesting expressions, indicating dynamic content generation.', N'In ASP.NET, @() is the syntax used in Razor for nesting expressions, indicating dynamic content generation.', 0, 0, N'', CAST(N'2024-12-03T08:58:23.000' AS DateTime), 0, N'/Uploadfile/2024/12/86108d27-392e-4a7c-aa43-ae9c67a18f40.png', N'', N'<p>In ASP.NET, <code data-start="12" data-end="17">@()</code> is the syntax used in Razor for nesting expressions, indicating dynamic content generation.</p>')
GO
INSERT [dbo].[Articles] ([ArticleID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [BigID], [ArticleTitle], [Articlekey], [ArticleDesn], [Statues], [Sorts], [NavSites], [ReleaseTime], [Hits], [Image], [Images], [Desn]) VALUES (9, 1, CAST(N'2024-12-03T09:01:06.110' AS DateTime), 1, CAST(N'2025-02-24T20:43:18.040' AS DateTime), 0, 5, N'How to calculate the day of the week for a date in MSSQL?', N'How to calculate the day of the week for a date in MSSQL?', N'How to calculate the day of the week for a date in MSSQL?', 0, 0, N'', CAST(N'2024-12-03T09:00:23.000' AS DateTime), 0, N'/Uploadfile/2024/12/9207b86a-f274-4919-a64f-4f694be5a2c2.png', N'', N'<p style="margin-bottom: 0px; font-family: 微软雅黑, Arial, Helvetica, sans-serif; color: rgb(102, 102, 102); font-size: 16px;">How to calculate the day of the week for a date in MSSQL?</p>')
GO
INSERT [dbo].[Articles] ([ArticleID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [BigID], [ArticleTitle], [Articlekey], [ArticleDesn], [Statues], [Sorts], [NavSites], [ReleaseTime], [Hits], [Image], [Images], [Desn]) VALUES (10, 1, CAST(N'2024-12-03T09:02:20.993' AS DateTime), 1, CAST(N'2025-02-24T20:42:40.150' AS DateTime), 0, 5, N'How large can the maximum size of nvarchar be defined?', N'How large can the maximum size of nvarchar be defined?', N'How large can the maximum size of nvarchar be defined?', 0, 0, N'', CAST(N'2024-12-03T09:01:43.000' AS DateTime), 0, N'/Uploadfile/2024/12/f02b093d-c43b-40ac-936b-acd3e695ac4a.png', N'', N'<p>How large can the maximum size of <code data-start="35" data-end="45">nvarchar</code> be defined?</p>')
GO
INSERT [dbo].[Articles] ([ArticleID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [BigID], [ArticleTitle], [Articlekey], [ArticleDesn], [Statues], [Sorts], [NavSites], [ReleaseTime], [Hits], [Image], [Images], [Desn]) VALUES (11, 1, CAST(N'2024-12-03T09:02:59.913' AS DateTime), 1, CAST(N'2025-02-24T20:42:08.403' AS DateTime), 0, 5, N'In ASP.NET, to ensure a string is filled to a specified length, you can use methods like PadLeft() or PadRight() from the String class. These methods help pad a string with a specified character, usua', N'In ASP.NET, to ensure a string is filled to a specified length, you can use methods like PadLeft() or PadRight() from the String class. These methods help pad a string with a specified character, usua', N'In ASP.NET, to ensure a string is filled to a specified length, you can use methods like PadLeft() or PadRight() from the String class. These methods help pad a string with a specified character, usually for formatting purposes.', 0, 0, N'', CAST(N'2024-12-03T09:02:23.000' AS DateTime), 0, N'/Uploadfile/2024/12/2ac5a59d-2378-4bc2-8b98-d59161a9483f.png', N'', N'<p>In ASP.NET, to ensure a string is filled to a specified length, you can use methods like <code data-start="89" data-end="100">PadLeft()</code> or <code data-start="104" data-end="116">PadRight()</code> from the <code data-start="126" data-end="134">String</code> class. These methods help pad a string with a specified character, usually for formatting purposes.</p>')
GO
INSERT [dbo].[Articles] ([ArticleID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [BigID], [ArticleTitle], [Articlekey], [ArticleDesn], [Statues], [Sorts], [NavSites], [ReleaseTime], [Hits], [Image], [Images], [Desn]) VALUES (12, 1, CAST(N'2024-12-03T09:56:04.107' AS DateTime), 1, CAST(N'2025-02-24T20:41:05.220' AS DateTime), 0, 4, N'Elon Musk has applied for an injunction to prevent OpenAI from transitioning into a for-profit entity.', N'Elon Musk has applied for an injunction to prevent OpenAI from transitioning into a for-profit entity.', N'Elon Musk has applied for an injunction to prevent OpenAI from transitioning into a for-profit entity.', 0, 0, N'', CAST(N'2024-12-03T09:03:02.000' AS DateTime), 0, N'/Uploadfile/2024/12/cca1b07e-ad7d-4d70-98f6-9a5faff3836f.png', N'', N'<p>Elon Musk has applied for an injunction to prevent OpenAI from transitioning into a for-profit entity.</p>')
GO
INSERT [dbo].[Articles] ([ArticleID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [BigID], [ArticleTitle], [Articlekey], [ArticleDesn], [Statues], [Sorts], [NavSites], [ReleaseTime], [Hits], [Image], [Images], [Desn]) VALUES (13, 1, CAST(N'2024-12-03T09:56:22.870' AS DateTime), 1, CAST(N'2025-02-24T20:40:33.650' AS DateTime), 0, 4, N'The Ministry of Transport reported that in October, ride-hailing orders reached 1.007 billion, a 1.9% month-on-month increase.', N'The Ministry of Transport reported that in October, ride-hailing orders reached 1.007 billion, a 1.9% month-on-month increase.', N'The Ministry of Transport reported that in October, ride-hailing orders reached 1.007 billion, a 1.9% month-on-month increase.', 0, 0, N'', CAST(N'2024-12-03T09:56:06.000' AS DateTime), 0, N'/Uploadfile/2024/12/cb54d479-8709-4443-a43c-eac4fbd1772d.png', N'', N'<p>The Ministry of Transport reported that in October, ride-hailing orders reached 1.007 billion, a 1.9% month-on-month increase.</p>')
GO
INSERT [dbo].[Articles] ([ArticleID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [BigID], [ArticleTitle], [Articlekey], [ArticleDesn], [Statues], [Sorts], [NavSites], [ReleaseTime], [Hits], [Image], [Images], [Desn]) VALUES (14, 1, CAST(N'2024-12-03T09:56:40.817' AS DateTime), 1, CAST(N'2025-02-24T20:40:01.843' AS DateTime), 0, 4, N'Elon Musk''s X platform will introduce a "prank account" label to help users distinguish between fake and real celebrities.', N'Elon Musk''s X platform will introduce a "prank account" label to help users distinguish between fake and real celebrities.', N'Elon Musk''s X platform will introduce a "prank account" label to help users distinguish between fake and real celebrities.', 0, 0, N'', CAST(N'2024-12-03T09:56:27.000' AS DateTime), 0, N'/Uploadfile/2024/12/d6d18721-b785-464d-ad10-2b86310a4f2c.png', N'', N'<p>Elon Musk''s X platform will introduce a "prank account" label to help users distinguish between fake and real celebrities.</p>')
GO
INSERT [dbo].[Articles] ([ArticleID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [BigID], [ArticleTitle], [Articlekey], [ArticleDesn], [Statues], [Sorts], [NavSites], [ReleaseTime], [Hits], [Image], [Images], [Desn]) VALUES (15, 1, CAST(N'2024-12-03T09:58:44.353' AS DateTime), 1, CAST(N'2025-02-24T20:25:04.247' AS DateTime), 0, 4, N'Over 80 media companies accuse Meta of unfair competition, with a court hearing set for next year in Spain.', N'Over 80 media companies accuse Meta of unfair competition, with a court hearing set for next year in Spain.', N'Over 80 media companies accuse Meta of unfair competition, with a court hearing set for next year in Spain.', 0, 0, N'', CAST(N'2024-12-03T09:58:27.000' AS DateTime), 0, N'/Uploadfile/2024/12/511db2f4-07ed-4751-a2e9-c5e09cab3a7c.png', N'', N'<p>Over 80 media companies accuse Meta of unfair competition, with a court hearing set for next year in Spain.</p>')
GO
INSERT [dbo].[Articles] ([ArticleID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [BigID], [ArticleTitle], [Articlekey], [ArticleDesn], [Statues], [Sorts], [NavSites], [ReleaseTime], [Hits], [Image], [Images], [Desn]) VALUES (16, 1, CAST(N'2024-12-03T09:59:00.617' AS DateTime), 1, CAST(N'2025-02-24T20:24:36.067' AS DateTime), 0, 4, N'Leaked image shows that Microsoft had planned to use class-round tray icons for UWP apps on Win10X "Centaurus" dual-screen devices.', N'Leaked image shows that Microsoft had planned to use class-round tray icons for UWP apps on Win10X "Centaurus" dual-screen devices.', N'Leaked image shows that Microsoft had planned to use class-round tray icons for UWP apps on Win10X "Centaurus" dual-screen devices.', 0, 0, N'', CAST(N'2024-12-03T09:58:49.000' AS DateTime), 0, N'/Uploadfile/2024/12/6b4a2ee4-158f-40e6-bd54-a83efe21dc3b.png', N'', N'<p>Leaked image shows that Microsoft had planned to use class-round tray icons for UWP apps on Win10X "Centaurus" dual-screen devices.</p>')
GO
INSERT [dbo].[Articles] ([ArticleID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [BigID], [ArticleTitle], [Articlekey], [ArticleDesn], [Statues], [Sorts], [NavSites], [ReleaseTime], [Hits], [Image], [Images], [Desn]) VALUES (17, 1, CAST(N'2024-12-03T10:05:40.053' AS DateTime), 1, CAST(N'2025-02-24T20:23:25.043' AS DateTime), 0, 6, N'China Unicom Anti-Fraud Center: Over 8,000 persuasive calls are made daily, preventing direct economic losses of over 700 million yuan each month.', N'China Unicom Anti-Fraud Center: Over 8,000 persuasive calls are made daily, preventing direct economic losses of over 700 million yuan each month.', N'China Unicom Anti-Fraud Center: Over 8,000 persuasive calls are made daily, preventing direct economic losses of over 700 million yuan each month.', 0, 0, N'', CAST(N'2024-12-03T10:05:22.000' AS DateTime), 0, N'/Uploadfile/2024/12/ba51c249-7074-4313-a374-d7c0853b13c6.png', N'', N'<p>China Unicom Anti-Fraud Center: Over 8,000 persuasive calls are made daily, preventing direct economic losses of over 700 million yuan each month.</p>')
GO
INSERT [dbo].[Articles] ([ArticleID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [BigID], [ArticleTitle], [Articlekey], [ArticleDesn], [Statues], [Sorts], [NavSites], [ReleaseTime], [Hits], [Image], [Images], [Desn]) VALUES (18, 1, CAST(N'2024-12-03T10:05:57.933' AS DateTime), 1, CAST(N'2025-02-24T20:22:47.077' AS DateTime), 0, 6, N'India strengthens digital regulation: it will address issues such as online gaming addiction and cybercrime.', N'India strengthens digital regulation: it will address issues such as online gaming addiction and cybercrime.', N'India strengthens digital regulation: it will address issues such as online gaming addiction and cybercrime.', 0, 0, N'', CAST(N'2024-12-03T10:05:46.000' AS DateTime), 0, N'/Uploadfile/2024/12/7c09a5ca-71d5-42e9-9751-f3c0adc5eec7.png', N'', N'<p>India strengthens digital regulation: it will address issues such as online gaming addiction and cybercrime.</p>')
GO
INSERT [dbo].[Articles] ([ArticleID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [BigID], [ArticleTitle], [Articlekey], [ArticleDesn], [Statues], [Sorts], [NavSites], [ReleaseTime], [Hits], [Image], [Images], [Desn]) VALUES (19, 1, CAST(N'2024-12-03T10:06:14.547' AS DateTime), 1, CAST(N'2025-02-24T20:21:21.923' AS DateTime), 0, 6, N'The Shanghai Suburban Railway Airport Link will open within the year, with train cars supporting wireless mobile charging and USB-C charging ports.', N'The Shanghai Suburban Railway Airport Link will open within the year, with train cars supporting wireless mobile charging and USB-C charging ports.', N'The Shanghai Suburban Railway Airport Link will open within the year, with train cars supporting wireless mobile charging and USB-C charging ports.', 0, 0, N'', CAST(N'2024-12-03T10:06:03.000' AS DateTime), 0, N'/Uploadfile/2024/12/602b9fb6-556f-449b-a0cc-4491c2e4de11.png', N'', N'<p>The Shanghai Suburban Railway Airport Link will open within the year, with train cars supporting wireless mobile charging and USB-C charging ports.</p>')
GO
INSERT [dbo].[Articles] ([ArticleID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [BigID], [ArticleTitle], [Articlekey], [ArticleDesn], [Statues], [Sorts], [NavSites], [ReleaseTime], [Hits], [Image], [Images], [Desn]) VALUES (20, 1, CAST(N'2024-12-03T10:06:55.530' AS DateTime), 1, CAST(N'2025-02-24T20:20:53.393' AS DateTime), 0, 6, N'Nissan faces a "tumultuous autumn": reports suggest that the CFO is about to resign.', N'Nissan faces a "tumultuous autumn": reports suggest that the CFO is about to resign.', N'Nissan faces a "tumultuous autumn": reports suggest that the CFO is about to resign.', 0, 0, N'', CAST(N'2024-12-03T10:06:42.000' AS DateTime), 0, N'/Uploadfile/2024/12/7c20d88f-3f81-4d1e-83e0-0fdec90f7911.png', N'', N'<p>Nissan faces a "tumultuous autumn": reports suggest that the CFO is about to resign.</p>')
GO
INSERT [dbo].[Articles] ([ArticleID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [BigID], [ArticleTitle], [Articlekey], [ArticleDesn], [Statues], [Sorts], [NavSites], [ReleaseTime], [Hits], [Image], [Images], [Desn]) VALUES (21, 1, CAST(N'2024-12-03T10:07:14.933' AS DateTime), 1, CAST(N'2025-02-24T20:20:25.150' AS DateTime), 0, 6, N'LiDAR manufacturer Suteng Juchuang achieved a total sales volume of 381,900 units in the first three quarters of this year, a year-on-year increase of 259.6%.', N'LiDAR manufacturer Suteng Juchuang achieved a total sales volume of 381,900 units in the first three quarters of this year, a year-on-year increase of 259.6%.', N'LiDAR manufacturer Suteng Juchuang achieved a total sales volume of 381,900 units in the first three quarters of this year, a year-on-year increase of 259.6%.', 0, 0, N'', CAST(N'2024-12-03T10:07:02.000' AS DateTime), 0, N'/Uploadfile/2024/12/ed31e847-b3c6-4050-84d7-a87c72c18adc.png', N'', N'<p>LiDAR manufacturer Suteng Juchuang achieved a total sales volume of 381,900 units in the first three quarters of this year, a year-on-year increase of 259.6%.</p>')
GO
INSERT [dbo].[Articles] ([ArticleID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [BigID], [ArticleTitle], [Articlekey], [ArticleDesn], [Statues], [Sorts], [NavSites], [ReleaseTime], [Hits], [Image], [Images], [Desn]) VALUES (22, 1, CAST(N'2024-12-03T11:27:54.450' AS DateTime), 1, CAST(N'2025-02-24T21:12:23.197' AS DateTime), 0, 2, N'Sunuer Manage', N'Sunuer Manage', N'Sunuer Manage', 0, 0, N'', CAST(N'2024-12-03T11:27:44.000' AS DateTime), 0, N'/Uploadfile/2025/02/3e0f70aa-d9f6-4b3d-8fd7-16537d695f62.png', N'', N'Sunuer Manage')
GO
INSERT [dbo].[Articles] ([ArticleID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [BigID], [ArticleTitle], [Articlekey], [ArticleDesn], [Statues], [Sorts], [NavSites], [ReleaseTime], [Hits], [Image], [Images], [Desn]) VALUES (23, 1, CAST(N'2024-12-03T11:28:05.357' AS DateTime), 1, CAST(N'2025-02-24T21:11:57.363' AS DateTime), 0, 2, N'Sunuer Easy', N'Sunuer Easy Code Generator', N'Sunuer Easy Code Generator', 0, 0, N'', CAST(N'2024-12-03T11:27:57.000' AS DateTime), 0, N'/Uploadfile/2025/02/d88c024c-d9ad-4293-adb1-39cf81cdae87.png', N'', N'<p><img src="/Uploadfile/2025/02/83e15424-5fea-4fbe-9e2e-2ea4528c35b6.png" style="width: 375px;"></p><p>Sunuer Easy Code Generator</p>')
GO
INSERT [dbo].[Articles] ([ArticleID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [BigID], [ArticleTitle], [Articlekey], [ArticleDesn], [Statues], [Sorts], [NavSites], [ReleaseTime], [Hits], [Image], [Images], [Desn]) VALUES (24, 1, CAST(N'2025-02-24T15:42:19.377' AS DateTime), 1, CAST(N'2025-02-24T21:10:46.410' AS DateTime), 0, 10, N'Sunuer Finance', N'Sunuer Finance', N'Sunuer Finance', 0, 0, N'', CAST(N'2025-02-24T15:41:53.000' AS DateTime), 0, N'/Uploadfile/2025/02/e60d9c92-8101-4fb9-8949-d651cf95b8a2.png', N'', N'<p>Sunuer Finance</p>')
GO
INSERT [dbo].[Articles] ([ArticleID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [BigID], [ArticleTitle], [Articlekey], [ArticleDesn], [Statues], [Sorts], [NavSites], [ReleaseTime], [Hits], [Image], [Images], [Desn]) VALUES (25, 1, CAST(N'2025-02-24T15:42:39.690' AS DateTime), 1, CAST(N'2025-02-24T21:10:29.410' AS DateTime), 0, 10, N'Sunuer Easy', N'Sunuer Easy', N'Sunuer Easy', 0, 0, N'', CAST(N'2025-02-24T15:42:21.000' AS DateTime), 0, N'/Uploadfile/2025/02/b94fce39-ed89-4819-97e5-f7efd4fc3370.png', N'', N'<p>Sunuer Easy</p>')
GO
INSERT [dbo].[Articles] ([ArticleID], [CreateUserID], [CreateDate], [UpdateUserID], [UpdateDate], [Del], [BigID], [ArticleTitle], [Articlekey], [ArticleDesn], [Statues], [Sorts], [NavSites], [ReleaseTime], [Hits], [Image], [Images], [Desn]) VALUES (26, 1, CAST(N'2025-02-24T15:42:54.703' AS DateTime), 1, CAST(N'2025-02-24T21:10:14.957' AS DateTime), 0, 10, N'Sunuer Manage', N'Sunuer Manage', N'Sunuer Manage', 0, 0, N'', CAST(N'2025-02-24T15:42:41.000' AS DateTime), 0, N'/Uploadfile/2025/02/864f2174-45ff-4df0-b77e-313b9fcfc291.png', N'', N'<p>Sunuer Manage</p>')
GO
SET IDENTITY_INSERT [dbo].[Articles] OFF
GO
ALTER TABLE [dbo].[Admin] ADD  DEFAULT ((0)) FOR [CreateUserID]
GO
ALTER TABLE [dbo].[Admin] ADD  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Admin] ADD  DEFAULT ((0)) FOR [UpdateUserID]
GO
ALTER TABLE [dbo].[Admin] ADD  DEFAULT ((0)) FOR [Del]
GO
ALTER TABLE [dbo].[Admin] ADD  DEFAULT ((0)) FOR [RoleID]
GO
ALTER TABLE [dbo].[Admin] ADD  DEFAULT ((0)) FOR [Statues]
GO
ALTER TABLE [dbo].[Admin] ADD  DEFAULT ((0)) FOR [LoginAttempts]
GO
ALTER TABLE [dbo].[AdminPower] ADD  CONSTRAINT [DF__AdminPowe__Creat__45F365D3]  DEFAULT ((0)) FOR [CreateUserID]
GO
ALTER TABLE [dbo].[AdminPower] ADD  CONSTRAINT [DF__AdminPowe__Creat__46E78A0C]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[AdminPower] ADD  CONSTRAINT [DF__AdminPowe__Updat__47DBAE45]  DEFAULT ((0)) FOR [UpdateUserID]
GO
ALTER TABLE [dbo].[AdminPower] ADD  CONSTRAINT [DF__AdminPower__Del__48CFD27E]  DEFAULT ((0)) FOR [Del]
GO
ALTER TABLE [dbo].[AdminPower] ADD  CONSTRAINT [DF__AdminPowe__Paren__49C3F6B7]  DEFAULT ((0)) FOR [ParentID]
GO
ALTER TABLE [dbo].[AdminRoles] ADD  DEFAULT ((0)) FOR [CreateUserID]
GO
ALTER TABLE [dbo].[AdminRoles] ADD  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[AdminRoles] ADD  DEFAULT ((0)) FOR [UpdateUserID]
GO
ALTER TABLE [dbo].[AdminRoles] ADD  DEFAULT ((0)) FOR [Del]
GO
ALTER TABLE [dbo].[ArticleCategory] ADD  DEFAULT ((0)) FOR [CreateUserID]
GO
ALTER TABLE [dbo].[ArticleCategory] ADD  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[ArticleCategory] ADD  DEFAULT ((0)) FOR [UpdateUserID]
GO
ALTER TABLE [dbo].[ArticleCategory] ADD  DEFAULT ((0)) FOR [Del]
GO
ALTER TABLE [dbo].[ArticleCategory] ADD  DEFAULT ((0)) FOR [ParentID]
GO
ALTER TABLE [dbo].[ArticleCategory] ADD  DEFAULT ((0)) FOR [Depths]
GO
ALTER TABLE [dbo].[ArticleCategory] ADD  DEFAULT ((0)) FOR [ParentIDFirst]
GO
ALTER TABLE [dbo].[ArticleCategory] ADD  DEFAULT ((0)) FOR [Statues]
GO
ALTER TABLE [dbo].[ArticleCategory] ADD  DEFAULT ((0)) FOR [Sorts]
GO
ALTER TABLE [dbo].[Articles] ADD  DEFAULT ((0)) FOR [CreateUserID]
GO
ALTER TABLE [dbo].[Articles] ADD  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Articles] ADD  DEFAULT ((0)) FOR [UpdateUserID]
GO
ALTER TABLE [dbo].[Articles] ADD  DEFAULT ((0)) FOR [Del]
GO
ALTER TABLE [dbo].[Articles] ADD  DEFAULT ((0)) FOR [BigID]
GO
ALTER TABLE [dbo].[Articles] ADD  DEFAULT ((0)) FOR [Statues]
GO
ALTER TABLE [dbo].[Articles] ADD  DEFAULT ((0)) FOR [Sorts]
GO
ALTER TABLE [dbo].[Articles] ADD  DEFAULT ((0)) FOR [Hits]
GO
/****** Object:  StoredProcedure [dbo].[ArticleCategory_Add]    Script Date: 2025/2/24 21:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--Add a record
--Project name：Sunuer Manage
--Table name：ArticleCategoryArticle category
--BY:HaiDong
--DateTime:2024-11-22 16:36:09
------------------------------------
CREATE Procedure [dbo].[ArticleCategory_Add]
    @CreateUserID int,
    @ParentID int,
    @Statues int,
    @BigTitle nvarchar(50),
    @KeyTitle nvarchar(200),
    @KeyWord nvarchar(200),
    @KeyDesn nvarchar(500),
    @Images nvarchar(200),
    @ImagesPhone nvarchar(200),
    @SiteUrl nvarchar(200),
    @Sorts int
as
 declare @fanhui int ---Return parameters
 select @fanhui=0
 declare @ParentIDFirst int --Top-level parent ID
select @ParentIDFirst=0
 declare @Depths int --Depth
select @Depths=0
declare @ParentIDS nvarchar(2000) --Parent collection
select @ParentIDS=''
--Determine if it's a duplicate based on the same top-level parent ID; if the top-level parent ID is 0, it's considered a top-level category
select @ParentIDFirst=ParentIDFirst,@Depths=Depths,@ParentIDS=ParentIDS from [ArticleCategory] where BigID=@ParentID

   if @ParentIDS<>''
	begin
	  select @ParentIDS=@ParentIDS+','
	  select @ParentIDS=@ParentIDS+convert( nvarchar(50) ,@ParentID)
	end
	else
	begin
	select @ParentIDS=0
	end
    select @Depths=@Depths+1
     insert into [dbo].[ArticleCategory] (CreateUserID,  ParentID, Depths, ParentIDs, ParentIDFirst, Statues, BigTitle, KeyTitle, KeyWord, KeyDesn, Images, ImagesPhone, Sorts,SiteUrl)
    values ( @CreateUserID,  @ParentID, @Depths, @ParentIDs, @ParentIDFirst, @Statues, @BigTitle, @KeyTitle, @KeyWord, @KeyDesn, @Images, @ImagesPhone, @Sorts,@SiteUrl)
   
	select  @fanhui=@@IDENTITY

    if(@ParentID=0)
    begin
      update [ArticleCategory] set ParentIDFirst=@fanhui where BigID=@fanhui
    end    
 return @fanhui
GO
/****** Object:  StoredProcedure [dbo].[ArticleCategory_Delete]    Script Date: 2025/2/24 21:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--Delete a record
--Project name：Sunuer Manage
--Table name：ArticleCategoryArticle category
--BY:HaiDong
--DateTime:2024-11-22 16:36:09
------------------------------------
Create Procedure [dbo].[ArticleCategory_Delete]
    @BigID int,
    @UpdateUserID int
as

    update  [dbo].[ArticleCategory] set Del=1,UpdateUserID = @UpdateUserID, UpdateDate = getdate() where BigID = @BigID
    return @@rowcount
GO
/****** Object:  StoredProcedure [dbo].[ArticleCategory_Get]    Script Date: 2025/2/24 21:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--Read the record list
--Project name：Sunuer Manage
--Table name：ArticleCategoryArticle category
--BY:HaiDong
--DateTime:2024-11-22 16:47:32
------------------------------------
CREATE Procedure [dbo].[ArticleCategory_Get]
    @ParentID int
as
begin
    select * from ArticleCategory where Del=0 and ParentID=@ParentID order by Sorts desc 
end
GO
/****** Object:  StoredProcedure [dbo].[ArticleCategory_GetAll]    Script Date: 2025/2/24 21:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------
--Read the record list
--Project name：Sunuer Manage
--Table name：ArticleCategoryArticle category
--BY:HaiDong
--DateTime:2024-11-22 16:47:32
------------------------------------
Create Procedure [dbo].[ArticleCategory_GetAll]
as
begin
    select * from ArticleCategory where Del=0
end
GO
/****** Object:  StoredProcedure [dbo].[ArticleCategory_GetModel]    Script Date: 2025/2/24 21:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--Retrieve a record
--Project name：Sunuer Manage
--Table name：ArticleCategoryArticle category
--BY:HaiDong
--DateTime:2024-11-22 16:47:32
------------------------------------
CREATE Procedure [dbo].[ArticleCategory_GetModel]
    @BigID int
AS
begin
    select * from [dbo].[ArticleCategory]
    where BigID = @BigID
end
GO
/****** Object:  StoredProcedure [dbo].[ArticleCategory_GetNumber]    Script Date: 2025/2/24 21:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--Read the record list
--Project name：Sunuer Manage
--Table name：ArticleCategoryArticle category Number of articles under
--BY:HaiDong
--DateTime:2024-11-22 16:47:32
------------------------------------
CREATE Procedure [dbo].[ArticleCategory_GetNumber]
    @ParentID int
as
begin
    select n.BigTitle,n.BigID,(	
    select count(ArticleID) FROM  [dbo].[Articles] as a
	left join ArticleCategory as b  on a.BigID=b.BigID 
	 where a.Del=0 and (n.BigID=a.BigID or  charindex(','+CAST(n.BigID AS NVARCHAR(50))+',', ','+b.ParentIDs+',') > 0)) as Number from ArticleCategory as n where n.Del=0 and n.ParentID=@ParentID
end
GO
/****** Object:  StoredProcedure [dbo].[ArticleCategory_GetParentIDAll]    Script Date: 2025/2/24 21:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--Read the record list
--Project name：Sunuer Manage
--Table name：ArticleCategoryArticle category  Include all with @ParentID
--BY:HaiDong
--DateTime:2024-11-22 16:47:32
------------------------------------
CREATE Procedure [dbo].[ArticleCategory_GetParentIDAll]
    @ParentID int
as
begin
    select * from ArticleCategory where Del=0 and  charindex(','+CAST(@ParentID AS NVARCHAR)+',',','+ParentIDs+',')>0
end
GO
/****** Object:  StoredProcedure [dbo].[ArticleCategory_Update]    Script Date: 2025/2/24 21:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------
--Update a record
--Project name：Sunuer Manage
--Table name：ArticleCategoryArticle category
--BY:HaiDong
--DateTime:2024-11-22 16:36:09
------------------------------------
CREATE Procedure [dbo].[ArticleCategory_Update]
    @BigID int,
    @UpdateUserID int,
    @ParentID int,
    @Statues int,
    @BigTitle nvarchar(50),
    @KeyTitle nvarchar(200),
    @KeyWord nvarchar(200),
    @KeyDesn nvarchar(500),
    @Images nvarchar(200),
    @SiteUrl nvarchar(200),
    @ImagesPhone nvarchar(200),
    @Sorts int
AS
	declare @fanhui int ---Return parameters
	 select @fanhui=0
	 declare @ParentIDFirst int --Top-level parent ID
	select @ParentIDFirst=0
	 declare @Depths int --Parent class Depth
	select @Depths=0
	 declare @DepthsOld int --Depth-Old
	select @DepthsOld=0
	declare @ParentIDS nvarchar(2000) --Parent collection
	select @ParentIDS=''
	declare @ParentIDSOld nvarchar(2000) --Parent collection-旧
	select @ParentIDSOld=''
	--Determine if it's a duplicate based on the same top-level parent ID; if the top-level parent ID is 0, it's considered a top-level category
	select @ParentIDFirst=ParentIDFirst,@Depths=Depths,@ParentIDS=ParentIDS from [ArticleCategory] where BigID=@ParentID

	   if @ParentIDS<>''
		begin
		  select @ParentIDS=@ParentIDS+','
		 select @ParentIDS=@ParentIDS+convert( nvarchar(50) ,@ParentID)
		end
		else
		begin
		select @ParentIDS=0
		end
		select @Depths=@Depths+1
		  update [dbo].[ArticleCategory]
    set  UpdateUserID = @UpdateUserID, UpdateDate = getdate(),@DepthsOld=Depths,@ParentIDSOld=[ParentIDs], ParentID = @ParentID, Depths = @Depths, ParentIDs = @ParentIDs, ParentIDFirst = @ParentIDFirst, Statues = @Statues, BigTitle = @BigTitle, KeyTitle = @KeyTitle, KeyWord = @KeyWord, KeyDesn = @KeyDesn, Images = @Images, ImagesPhone = @ImagesPhone, Sorts = @Sorts,SiteUrl=@SiteUrl
    where BigID = @BigID
		select  @fanhui=@@rowcount
			 
	    select @DepthsOld=@Depths-@DepthsOld
		if(@ParentID=0)
		begin
		  select @ParentIDFirst=@BigID
		  update [ArticleCategory] set ParentIDFirst=@BigID where BigID=@BigID --Update top-level category
		end    
		--Update sub-level category classification
		--Update sub-level parent collection
		 update [ArticleCategory] set ParentIDFirst=@ParentIDFirst,Depths=Depths+@DepthsOld, ParentIDS=substring(REPLACE(','+ParentIDS+',',','+@ParentIDSOld+',',','+@ParentIDS+','),2,len(REPLACE(','+ParentIDS+',',','+@ParentIDSOld+',',','+@ParentIDS+','))-2),[UpdateDate] = GETDATE(),UpdateUserID = @UpdateUserID where charindex(','+convert( nvarchar(50) ,@BigID)+',',','+ParentIDS+',')>0
 
 return @fanhui
GO
/****** Object:  StoredProcedure [dbo].[Articles_Add]    Script Date: 2025/2/24 21:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------
--Add a record
--Project name：Sunuer Manage
--Table name：Articles
--BY:HaiDong
--DateTime:2024-11-23 15:01:17
------------------------------------
CREATE Procedure [dbo].[Articles_Add]
    @CreateUserID int,
    @BigID int,
    @ArticleTitle nvarchar(200),
    @Articlekey nvarchar(200),
    @ArticleDesn nvarchar(500),
    @Statues int,
    @Sorts int,
    @NavSites nvarchar(200),
    @ReleaseTime datetime,
    @Hits int,
    @Image nvarchar(500),
    @Images nvarchar(500),
    @Desn nvarchar(MAX)
as
begin
    insert into [dbo].[Articles] ( CreateUserID, BigID, ArticleTitle, Articlekey, ArticleDesn, Statues, Sorts, NavSites, ReleaseTime, Hits, Image, Images, Desn)
    values ( @CreateUserID, @BigID, @ArticleTitle, @Articlekey, @ArticleDesn, @Statues, @Sorts, @NavSites, @ReleaseTime, @Hits, @Image, @Images, @Desn)
    return @@identity
end
GO
/****** Object:  StoredProcedure [dbo].[Articles_Delete]    Script Date: 2025/2/24 21:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------
--Delete a record
--Project name：Sunuer Manage
--Table name：Articles
--BY:HaiDong
--DateTime:2024-11-23 15:15:29
------------------------------------
CREATE Procedure [dbo].[Articles_Delete]
    @ArticleID int,
    @UpdateUserID int
as
begin
    update  [dbo].[Articles] set Del=1 ,UpdateUserID = @UpdateUserID, UpdateDate = getdate() where ArticleID = @ArticleID
    return @@rowcount
end
GO
/****** Object:  StoredProcedure [dbo].[Articles_Get]    Script Date: 2025/2/24 21:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------
--Read the record list
--Project name：Sunuer Manage
--Table name：Articles
--BY:HaiDong
--DateTime:2024-11-23 15:15:29
------------------------------------
CREATE Procedure [dbo].[Articles_Get]
    @BigID int, 
    @ArticleTitle nvarchar(50), 
    @StartRecord int, 
    @EndRecord int
as
declare @s nvarchar(MAX)
declare @searchs nvarchar(2000) = '';
-- Check if @Title is empty
if @ArticleTitle <> ''
begin
    -- Use parameterized queries to prevent SQL injection
    set @searchs = @searchs + ' and charindex(@ArticleTitle, n.ArticleTitle) > 0';
end
if @BigID <> -1
begin
    -- Use parameterized queries to prevent SQL injection
    set @searchs = @searchs + ' and (n.BigID=@BigID or  charindex('',''+CAST(@BigID AS NVARCHAR(50))+'','', '',''+b.ParentIDs+'','') > 0)';
end
set @s ='  select a.*from(
    select row_number() over(order by  n.ArticleID desc) as aid ,n.*,b.BigTitle FROM  [dbo].[Articles] as n
	left join ArticleCategory as b  on n.BigID=b.BigID 
	 where n.del=0 	'+@searchs+'
	) as a
    where a.aid between @StartRecord and (@EndRecord+@StartRecord-1) order by aid asc';
-- Print the query statement for debugging purposes
print @s;

-- Pass the @Title parameter when executing the query
EXEC sp_executesql @s, N'@ArticleTitle nvarchar(50),@BigID int,@StartRecord int,@EndRecord int', @ArticleTitle,@BigID,@StartRecord,@EndRecord

GO
/****** Object:  StoredProcedure [dbo].[Articles_GetCount]    Script Date: 2025/2/24 21:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------
--Read the record list
--Project name：Sunuer Manage
--Table name：Articles
--BY:HaiDong
--DateTime:2024-11-23 15:15:29
------------------------------------
CREATE Procedure [dbo].[Articles_GetCount]
    @BigID int, 
    @ArticleTitle nvarchar(50)
as
declare @s nvarchar(MAX)
declare @searchs nvarchar(2000) = '';
-- Check if @Title is empty
if @ArticleTitle <> ''
begin
    -- Use parameterized queries to prevent SQL injection
    set @searchs = @searchs + ' and charindex(@ArticleTitle, n.ArticleTitle) > 0';
end
if @BigID <> -1
begin
    -- Use parameterized queries to prevent SQL injection
    set @searchs = @searchs + ' and (n.BigID=@BigID or  charindex('',''+CAST(@BigID AS NVARCHAR(50))+'','', '',''+b.ParentIDs+'','') > 0)';
end
set @s ='select Count(n.ArticleID) as Num from  [dbo].[Articles] as n
	left join ArticleCategory as b  on n.BigID=b.BigID 	
	where n.del=0 '+@searchs;
-- Print the query statement for debugging purposes
print @s;

-- Pass the @Title parameter when executing the query
EXEC sp_executesql @s, N'@ArticleTitle nvarchar(50),@BigID int', @ArticleTitle,@BigID
 
GO
/****** Object:  StoredProcedure [dbo].[Articles_GetCount30]    Script Date: 2025/2/24 21:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------
--Read the daily record count
--Project name：Sunuer Manage
--Table name：Articles
--BY:HaiDong
--DateTime:2024-11-28 15:15:29
------------------------------------
CREATE Procedure [dbo].[Articles_GetCount30]
    @StarTime DateTime, 
    @EndTime DateTime
as
select count(ArticleID) as Number ,convert(varchar(11),CreateDate,111) as Datas from Articles  where  Del=0  and @StarTime<=CreateDate  and @EndTime>=CreateDate group by convert(varchar(11),CreateDate,111)order by convert(varchar(11),CreateDate,111)
GO
/****** Object:  StoredProcedure [dbo].[Articles_GetLast]    Script Date: 2025/2/24 21:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


------------------------------------
--Retrieve a record
--Project name：Sunuer Manage
--Table name：Article Get the previous record
--BY:HaiDong
--DateTime:2024-12-3 16:47:32
------------------------------------
create procedure [dbo].[Articles_GetLast]
(
@ArticleID int
)
as

select top 1 ArticleID,ArticleTitle,NavSites from Articles   where bigid=(select BigID from Articles where ArticleID=@ArticleID) and ArticleID<@ArticleID and del=0 and ReleaseTime<getdate() order by ArticleID asc




GO
/****** Object:  StoredProcedure [dbo].[Articles_GetModel]    Script Date: 2025/2/24 21:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------
--Retrieve a record
--Project name：Sunuer Manage
--Table name：Articles
--BY:HaiDong
--DateTime:2024-11-23 15:15:29
------------------------------------
Create Procedure [dbo].[Articles_GetModel]
    @ArticleID int
AS
begin
    select * from [dbo].[Articles]
    where Del=0 and ArticleID = @ArticleID
end
GO
/****** Object:  StoredProcedure [dbo].[Articles_GetNext]    Script Date: 2025/2/24 21:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


------------------------------------
--Retrieve a record
--Project name：Sunuer Manage
--Table name：Article Get the next record
--BY:HaiDong
--DateTime:2024-12-3 16:47:32
------------------------------------
create procedure [dbo].[Articles_GetNext]
(
@ArticleID int
)
as

select top 1 ArticleID,ArticleTitle,NavSites from Articles   where bigid=(select BigID from Articles where ArticleID=@ArticleID) and ArticleID>@ArticleID and del=0 and ReleaseTime<getdate() order by ArticleID asc




GO
/****** Object:  StoredProcedure [dbo].[Articles_GetTop]    Script Date: 2025/2/24 21:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------
--Read the record list
--Project name：Sunuer Manage
--Table name：Articles
--BY:HaiDong
--DateTime:2024-11-23 15:15:29
------------------------------------
CREATE Procedure [dbo].[Articles_GetTop]
    @BigID int, 
    @ArticleTitle nvarchar(50), 
    @StartRecord int, 
    @EndRecord int
as
declare @s nvarchar(MAX)
declare @searchs nvarchar(2000) = '';
-- Check if @Title is empty
if @ArticleTitle <> ''
begin
    -- Use parameterized queries to prevent SQL injection
    set @searchs = @searchs + ' and charindex(@ArticleTitle, n.ArticleTitle) > 0';
end
if @BigID <> -1
begin
    -- Use parameterized queries to prevent SQL injection
    set @searchs = @searchs + ' and (n.BigID=@BigID or  charindex('',''+CAST(@BigID AS NVARCHAR(50))+'','', '',''+b.ParentIDs+'','') > 0)';
end
set @s ='  select a.*from(
    select row_number() over(order by n.Sorts desc, n.ArticleID desc) as aid ,n.*,b.BigTitle FROM  [dbo].[Articles] as n
	left join ArticleCategory as b  on n.BigID=b.BigID 
	 where n.del=0 	 and n.Statues=0 and n.ReleaseTime<=getdate() '+@searchs+'
	) as a
    where a.aid between @StartRecord and (@EndRecord+@StartRecord-1) order by aid asc';
-- Print the query statement for debugging purposes
print @s;

-- Pass the @Title parameter when executing the query
EXEC sp_executesql @s, N'@ArticleTitle nvarchar(50),@BigID int,@StartRecord int,@EndRecord int', @ArticleTitle,@BigID,@StartRecord,@EndRecord


GO
/****** Object:  StoredProcedure [dbo].[Articles_GetTopCount]    Script Date: 2025/2/24 21:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------
--Read the record list
--Project name：Sunuer Manage
--Table name：Articles
--BY:HaiDong
--DateTime:2024-11-23 15:15:29
------------------------------------
CREATE Procedure [dbo].[Articles_GetTopCount]
    @BigID int, 
    @ArticleTitle nvarchar(50)
as
declare @s nvarchar(MAX)
declare @searchs nvarchar(2000) = '';
-- Check if @Title is empty
if @ArticleTitle <> ''
begin
    -- Use parameterized queries to prevent SQL injection
    set @searchs = @searchs + ' and charindex(@ArticleTitle, n.ArticleTitle) > 0';
end
if @BigID <> -1
begin
    -- Use parameterized queries to prevent SQL injection
    set @searchs = @searchs + ' and (n.BigID=@BigID or  charindex('',''+CAST(@BigID AS NVARCHAR(50))+'','', '',''+b.ParentIDs+'','') > 0)';
end
set @s ='select Count(n.ArticleID) as Num from  [dbo].[Articles] as n
	left join ArticleCategory as b  on n.BigID=b.BigID 	
	where n.del=0 and n.Statues=0 and n.ReleaseTime<=getdate()'+@searchs;
-- Print the query statement for debugging purposes
print @s;

-- Pass the @Title parameter when executing the query
EXEC sp_executesql @s, N'@ArticleTitle nvarchar(50),@BigID int', @ArticleTitle,@BigID
 
GO
/****** Object:  StoredProcedure [dbo].[Articles_Update]    Script Date: 2025/2/24 21:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------------------------------------
--Update a record
--Project name：Sunuer Manage
--Table name：Articles
--BY:HaiDong
--DateTime:2024-11-23 15:01:17
------------------------------------
CREATE Procedure [dbo].[Articles_Update]
    @ArticleID int,
    @UpdateUserID int,
    @BigID int,
    @ArticleTitle nvarchar(200),
    @Articlekey nvarchar(200),
    @ArticleDesn nvarchar(500),
    @Statues int,
    @Sorts int,
    @NavSites nvarchar(200),
    @ReleaseTime datetime,
    @Hits int,
    @Image nvarchar(500),
    @Images nvarchar(500),
    @Desn nvarchar(MAX)
AS
begin
    update [dbo].[Articles]
    set UpdateUserID = @UpdateUserID, UpdateDate = getdate(),  BigID = @BigID, ArticleTitle = @ArticleTitle, Articlekey = @Articlekey, ArticleDesn = @ArticleDesn, Statues = @Statues, Sorts = @Sorts, NavSites = @NavSites, ReleaseTime = @ReleaseTime, Hits = @Hits, Image = @Image, Images = @Images, Desn = @Desn
    where ArticleID = @ArticleID
    return @@rowcount
end
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Administrator' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin', @level2type=N'COLUMN',@level2name=N'AdminID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Creator' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin', @level2type=N'COLUMN',@level2name=N'CreateUserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Creation Time' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin', @level2type=N'COLUMN',@level2name=N'CreateDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Updater' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin', @level2type=N'COLUMN',@level2name=N'UpdateUserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Update Time' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin', @level2type=N'COLUMN',@level2name=N'UpdateDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Delete 0 No 1 Yes' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin', @level2type=N'COLUMN',@level2name=N'Del'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Username' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin', @level2type=N'COLUMN',@level2name=N'AdminName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nickname' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin', @level2type=N'COLUMN',@level2name=N'AdminNick'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Password' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin', @level2type=N'COLUMN',@level2name=N'PassWord'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Role ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin', @level2type=N'COLUMN',@level2name=N'RoleID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Status (0: Normal, 1: Frozen)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin', @level2type=N'COLUMN',@level2name=N'Statues'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Login Attempt Count' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin', @level2type=N'COLUMN',@level2name=N'LoginAttempts'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Last Login Attempt Time' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Admin', @level2type=N'COLUMN',@level2name=N'LoginAttemptsLast'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Creator' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AdminPower', @level2type=N'COLUMN',@level2name=N'CreateUserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Creation Time' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AdminPower', @level2type=N'COLUMN',@level2name=N'CreateDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Updater' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AdminPower', @level2type=N'COLUMN',@level2name=N'UpdateUserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Update Time' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AdminPower', @level2type=N'COLUMN',@level2name=N'UpdateDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Delete 0 No 1 Yes' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AdminPower', @level2type=N'COLUMN',@level2name=N'Del'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AdminPower', @level2type=N'COLUMN',@level2name=N'ParentID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Permission Name' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AdminPower', @level2type=N'COLUMN',@level2name=N'PowerTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Creator' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AdminRoles', @level2type=N'COLUMN',@level2name=N'CreateUserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Creation Time' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AdminRoles', @level2type=N'COLUMN',@level2name=N'CreateDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Updater' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AdminRoles', @level2type=N'COLUMN',@level2name=N'UpdateUserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Update Time' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AdminRoles', @level2type=N'COLUMN',@level2name=N'UpdateDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Delete 0 No 1 Yes' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AdminRoles', @level2type=N'COLUMN',@level2name=N'Del'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Role Name' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AdminRoles', @level2type=N'COLUMN',@level2name=N'RolesTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Permission Set' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AdminRoles', @level2type=N'COLUMN',@level2name=N'Powers'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Article Category' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ArticleCategory', @level2type=N'COLUMN',@level2name=N'BigID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Creator' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ArticleCategory', @level2type=N'COLUMN',@level2name=N'CreateUserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Creation Time' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ArticleCategory', @level2type=N'COLUMN',@level2name=N'CreateDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Updater' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ArticleCategory', @level2type=N'COLUMN',@level2name=N'UpdateUserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Update Time' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ArticleCategory', @level2type=N'COLUMN',@level2name=N'UpdateDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Delete 0 No 1 Yes' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ArticleCategory', @level2type=N'COLUMN',@level2name=N'Del'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Parent ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ArticleCategory', @level2type=N'COLUMN',@level2name=N'ParentID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Depth (Default: 0, Top Level: 1)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ArticleCategory', @level2type=N'COLUMN',@level2name=N'Depths'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'All Parent IDs (Separated by Commas)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ArticleCategory', @level2type=N'COLUMN',@level2name=N'ParentIDs'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Top Parent ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ArticleCategory', @level2type=N'COLUMN',@level2name=N'ParentIDFirst'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Navigation (0: No, 1: Yes)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ArticleCategory', @level2type=N'COLUMN',@level2name=N'Statues'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Category Name' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ArticleCategory', @level2type=N'COLUMN',@level2name=N'BigTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Optimized Title' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ArticleCategory', @level2type=N'COLUMN',@level2name=N'KeyTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Keywords' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ArticleCategory', @level2type=N'COLUMN',@level2name=N'KeyWord'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ArticleCategory', @level2type=N'COLUMN',@level2name=N'KeyDesn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Image' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ArticleCategory', @level2type=N'COLUMN',@level2name=N'Images'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Mobile Image' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ArticleCategory', @level2type=N'COLUMN',@level2name=N'ImagesPhone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Sort Order (Larger Number Comes First)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ArticleCategory', @level2type=N'COLUMN',@level2name=N'Sorts'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Redirect Link' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ArticleCategory', @level2type=N'COLUMN',@level2name=N'SiteUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Creator' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Articles', @level2type=N'COLUMN',@level2name=N'CreateUserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Creation Time' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Articles', @level2type=N'COLUMN',@level2name=N'CreateDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Updater' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Articles', @level2type=N'COLUMN',@level2name=N'UpdateUserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Update Time' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Articles', @level2type=N'COLUMN',@level2name=N'UpdateDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Delete 0 No 1 Yes' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Articles', @level2type=N'COLUMN',@level2name=N'Del'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Category' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Articles', @level2type=N'COLUMN',@level2name=N'BigID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Title' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Articles', @level2type=N'COLUMN',@level2name=N'ArticleTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Keywords' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Articles', @level2type=N'COLUMN',@level2name=N'Articlekey'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Articles', @level2type=N'COLUMN',@level2name=N'ArticleDesn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Display (0: No, 1: Yes)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Articles', @level2type=N'COLUMN',@level2name=N'Statues'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Sort Order' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Articles', @level2type=N'COLUMN',@level2name=N'Sorts'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Redirect URL' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Articles', @level2type=N'COLUMN',@level2name=N'NavSites'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Publish Time' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Articles', @level2type=N'COLUMN',@level2name=N'ReleaseTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Click Rate' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Articles', @level2type=N'COLUMN',@level2name=N'Hits'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Header Image' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Articles', @level2type=N'COLUMN',@level2name=N'Image'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Image Collection' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Articles', @level2type=N'COLUMN',@level2name=N'Images'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Details' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Articles', @level2type=N'COLUMN',@level2name=N'Desn'
GO
