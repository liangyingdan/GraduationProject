USE [DaYueDB]
GO
/****** Object:  Table [dbo].[Manage]    Script Date: 2020/7/14 21:54:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manage](
	[ManageID] [int] IDENTITY(1,1) NOT NULL,
	[ManageAccount] [nvarchar](50) NOT NULL,
	[ManagePwd] [nvarchar](50) NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Manage] PRIMARY KEY CLUSTERED 
(
	[ManageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Music]    Script Date: 2020/7/14 21:54:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Music](
	[MusicID] [int] IDENTITY(1,1) NOT NULL,
	[SingerID] [int] NOT NULL,
	[TypeID] [int] NOT NULL,
	[MusicImage] [nvarchar](4000) NULL,
	[MusicName] [nvarchar](50) NOT NULL,
	[MusicCountry] [nvarchar](50) NOT NULL,
	[MusicDate] [date] NOT NULL,
	[MusicFiles] [nvarchar](4000) NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Music] PRIMARY KEY CLUSTERED 
(
	[MusicID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MusicList]    Script Date: 2020/7/14 21:54:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MusicList](
	[ListID] [int] IDENTITY(1,1) NOT NULL,
	[MusicID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_MusicList] PRIMARY KEY CLUSTERED 
(
	[ListID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MusicType]    Script Date: 2020/7/14 21:54:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MusicType](
	[TypeID] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](50) NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Type] PRIMARY KEY CLUSTERED 
(
	[TypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Singer]    Script Date: 2020/7/14 21:54:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Singer](
	[SingerID] [int] IDENTITY(1,1) NOT NULL,
	[SingerName] [nvarchar](50) NOT NULL,
	[SingerType] [nvarchar](50) NOT NULL,
	[SingerImage] [nvarchar](50) NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Singer] PRIMARY KEY CLUSTERED 
(
	[SingerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 2020/7/14 21:54:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfo](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[UserPwd] [nvarchar](50) NOT NULL,
	[UserPhone] [nvarchar](50) NOT NULL,
	[UserEmail] [nvarchar](50) NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_UserInfo] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Manage] ON 

INSERT [dbo].[Manage] ([ManageID], [ManageAccount], [ManagePwd], [IsDelete]) VALUES (1, N'admin', N'lyd123', 1)
SET IDENTITY_INSERT [dbo].[Manage] OFF
SET IDENTITY_INSERT [dbo].[Music] ON 

INSERT [dbo].[Music] ([MusicID], [SingerID], [TypeID], [MusicImage], [MusicName], [MusicCountry], [MusicDate], [MusicFiles], [IsDelete]) VALUES (1, 1, 4, N'漂洋过海来看你.jpg', N'飘洋过海来看你', N'中国', CAST(0x543B0B00 AS Date), N'周深 - 漂洋过海来看你.mp3', 1)
INSERT [dbo].[Music] ([MusicID], [SingerID], [TypeID], [MusicImage], [MusicName], [MusicCountry], [MusicDate], [MusicFiles], [IsDelete]) VALUES (2, 5, 4, N'躲起来.jpg', N'躲起来', N'中国', CAST(0x043F0B00 AS Date), N'郁可唯 - 躲起来 (Live).mp3', 1)
INSERT [dbo].[Music] ([MusicID], [SingerID], [TypeID], [MusicImage], [MusicName], [MusicCountry], [MusicDate], [MusicFiles], [IsDelete]) VALUES (3, 2, 2, N'3.jpg', N'一吻天荒', N'中国', CAST(0xE2350B00 AS Date), N'胡歌 - 一吻天荒(电视剧《轩辕剑》片头曲).mp3', 1)
INSERT [dbo].[Music] ([MusicID], [SingerID], [TypeID], [MusicImage], [MusicName], [MusicCountry], [MusicDate], [MusicFiles], [IsDelete]) VALUES (4, 6, 4, N'咚巴拉.jpg', N'咚巴拉', N'中国', CAST(0x8A3E0B00 AS Date), N'萨顶顶 - 咚巴啦.mp3', 1)
INSERT [dbo].[Music] ([MusicID], [SingerID], [TypeID], [MusicImage], [MusicName], [MusicCountry], [MusicDate], [MusicFiles], [IsDelete]) VALUES (5, 7, 3, N'5.jpg', N'奇妙能力歌', N'中国', CAST(0x9D390B00 AS Date), N'陈粒 - 奇妙能力歌.mp3', 1)
INSERT [dbo].[Music] ([MusicID], [SingerID], [TypeID], [MusicImage], [MusicName], [MusicCountry], [MusicDate], [MusicFiles], [IsDelete]) VALUES (6, 3, 3, N'6.jpg', N'安河桥', N'中国', CAST(0x78370B00 AS Date), N'宋冬野 - 安和桥.mp3', 1)
INSERT [dbo].[Music] ([MusicID], [SingerID], [TypeID], [MusicImage], [MusicName], [MusicCountry], [MusicDate], [MusicFiles], [IsDelete]) VALUES (7, 4, 6, N'喜欢你.jpg', N'喜欢你', N'中国', CAST(0xFE3C0B00 AS Date), N'毛不易 - 喜欢你 (Live).mp3', 1)
INSERT [dbo].[Music] ([MusicID], [SingerID], [TypeID], [MusicImage], [MusicName], [MusicCountry], [MusicDate], [MusicFiles], [IsDelete]) VALUES (8, 8, 4, N'天使的指纹.jpg', N'天使的指纹', N'新加坡', CAST(0x3F2E0B00 AS Date), N'孙燕姿 - 天使的指纹.mp3', 1)
INSERT [dbo].[Music] ([MusicID], [SingerID], [TypeID], [MusicImage], [MusicName], [MusicCountry], [MusicDate], [MusicFiles], [IsDelete]) VALUES (9, 9, 5, N'9.jpg', N'寄明月', N'中国', CAST(0x423D0B00 AS Date), N'SING女团 - 寄明月.mp3', 1)
INSERT [dbo].[Music] ([MusicID], [SingerID], [TypeID], [MusicImage], [MusicName], [MusicCountry], [MusicDate], [MusicFiles], [IsDelete]) VALUES (10, 10, 6, N'张三的歌.jpg', N'张三的歌', N'中国', CAST(0x76310B00 AS Date), N'青鸟飞鱼 - 张三的歌.mp3', 1)
INSERT [dbo].[Music] ([MusicID], [SingerID], [TypeID], [MusicImage], [MusicName], [MusicCountry], [MusicDate], [MusicFiles], [IsDelete]) VALUES (18, 2, 2, N'光棍.jpg', N'光棍', N'中国', CAST(0xCA340B00 AS Date), N'胡歌 - 光棍.mp3', 1)
INSERT [dbo].[Music] ([MusicID], [SingerID], [TypeID], [MusicImage], [MusicName], [MusicCountry], [MusicDate], [MusicFiles], [IsDelete]) VALUES (19, 15, 1, N'月夜.jpg', N'月夜', N'中国', CAST(0x46410B00 AS Date), N'双笙 _ 妖扬 - 月夜.mp3', 1)
INSERT [dbo].[Music] ([MusicID], [SingerID], [TypeID], [MusicImage], [MusicName], [MusicCountry], [MusicDate], [MusicFiles], [IsDelete]) VALUES (20, 16, 2, N'你好灰姑娘.jpg', N'你好灰姑娘', N'中国', CAST(0x4E410B00 AS Date), N'胡夏 - 你好灰姑娘.mp3', 0)
INSERT [dbo].[Music] ([MusicID], [SingerID], [TypeID], [MusicImage], [MusicName], [MusicCountry], [MusicDate], [MusicFiles], [IsDelete]) VALUES (21, 1, 7, N'9.jpg', N'飒小姐', N'中国', CAST(0x53410B00 AS Date), N'火箭少女101 - 飒小姐 (Live).mp3', 1)
SET IDENTITY_INSERT [dbo].[Music] OFF
SET IDENTITY_INSERT [dbo].[MusicList] ON 

INSERT [dbo].[MusicList] ([ListID], [MusicID], [UserID], [IsDelete]) VALUES (2, 20, 1, 0)
INSERT [dbo].[MusicList] ([ListID], [MusicID], [UserID], [IsDelete]) VALUES (3, 18, 1, 1)
INSERT [dbo].[MusicList] ([ListID], [MusicID], [UserID], [IsDelete]) VALUES (6, 1, 1, 1)
SET IDENTITY_INSERT [dbo].[MusicList] OFF
SET IDENTITY_INSERT [dbo].[MusicType] ON 

INSERT [dbo].[MusicType] ([TypeID], [TypeName], [IsDelete]) VALUES (1, N'古风', 1)
INSERT [dbo].[MusicType] ([TypeID], [TypeName], [IsDelete]) VALUES (2, N'影视', 1)
INSERT [dbo].[MusicType] ([TypeID], [TypeName], [IsDelete]) VALUES (3, N'民谣', 1)
INSERT [dbo].[MusicType] ([TypeID], [TypeName], [IsDelete]) VALUES (4, N'流行', 1)
INSERT [dbo].[MusicType] ([TypeID], [TypeName], [IsDelete]) VALUES (5, N'电子', 1)
INSERT [dbo].[MusicType] ([TypeID], [TypeName], [IsDelete]) VALUES (6, N'抒情', 1)
INSERT [dbo].[MusicType] ([TypeID], [TypeName], [IsDelete]) VALUES (7, N'乡村', 1)
SET IDENTITY_INSERT [dbo].[MusicType] OFF
SET IDENTITY_INSERT [dbo].[Singer] ON 

INSERT [dbo].[Singer] ([SingerID], [SingerName], [SingerType], [SingerImage], [IsDelete]) VALUES (1, N'周深', N'1', N'周深.jpg', 1)
INSERT [dbo].[Singer] ([SingerID], [SingerName], [SingerType], [SingerImage], [IsDelete]) VALUES (2, N'胡歌', N'1', N'胡歌.jpg', 1)
INSERT [dbo].[Singer] ([SingerID], [SingerName], [SingerType], [SingerImage], [IsDelete]) VALUES (3, N'宋东野', N'1', N'宋东野.jpg', 1)
INSERT [dbo].[Singer] ([SingerID], [SingerName], [SingerType], [SingerImage], [IsDelete]) VALUES (4, N'毛不易', N'1', N'毛不易.jpg', 1)
INSERT [dbo].[Singer] ([SingerID], [SingerName], [SingerType], [SingerImage], [IsDelete]) VALUES (5, N'郁可唯', N'0', N'郁可唯.jpg', 1)
INSERT [dbo].[Singer] ([SingerID], [SingerName], [SingerType], [SingerImage], [IsDelete]) VALUES (6, N'萨顶顶', N'0', N'萨顶顶.jpg', 1)
INSERT [dbo].[Singer] ([SingerID], [SingerName], [SingerType], [SingerImage], [IsDelete]) VALUES (7, N'陈粒', N'0', N'陈粒.jpg', 1)
INSERT [dbo].[Singer] ([SingerID], [SingerName], [SingerType], [SingerImage], [IsDelete]) VALUES (8, N'孙燕姿', N'0', N'孙燕姿.jpg', 1)
INSERT [dbo].[Singer] ([SingerID], [SingerName], [SingerType], [SingerImage], [IsDelete]) VALUES (9, N'SING', N'2', N'SING.jpg', 1)
INSERT [dbo].[Singer] ([SingerID], [SingerName], [SingerType], [SingerImage], [IsDelete]) VALUES (10, N'青鸟飞鱼', N'2', N'青鸟飞鱼.jpg', 1)
INSERT [dbo].[Singer] ([SingerID], [SingerName], [SingerType], [SingerImage], [IsDelete]) VALUES (14, N'花粥', N'0', N'花粥.jpg', 1)
INSERT [dbo].[Singer] ([SingerID], [SingerName], [SingerType], [SingerImage], [IsDelete]) VALUES (15, N'双笙', N'0', N'双笙.png', 1)
INSERT [dbo].[Singer] ([SingerID], [SingerName], [SingerType], [SingerImage], [IsDelete]) VALUES (16, N'胡夏', N'1', N'胡夏.png', 0)
SET IDENTITY_INSERT [dbo].[Singer] OFF
SET IDENTITY_INSERT [dbo].[UserInfo] ON 

INSERT [dbo].[UserInfo] ([UserID], [UserName], [UserPwd], [UserPhone], [UserEmail], [IsDelete]) VALUES (1, N'丁禹兮', N'lyd123', N'13874457739', N'1046471532@qq.com', 0)
INSERT [dbo].[UserInfo] ([UserID], [UserName], [UserPwd], [UserPhone], [UserEmail], [IsDelete]) VALUES (2, N'赵露思', N'lyd123', N'15115192260', N'1046471532@163.com', 1)
INSERT [dbo].[UserInfo] ([UserID], [UserName], [UserPwd], [UserPhone], [UserEmail], [IsDelete]) VALUES (4, N'陈星旭', N'lyd123', N'13874491394', N'132133@163.com', 0)
INSERT [dbo].[UserInfo] ([UserID], [UserName], [UserPwd], [UserPhone], [UserEmail], [IsDelete]) VALUES (8, N'xiaoding', N'lyd123', N'13874457739', N'1046471532@qq.com', 0)
SET IDENTITY_INSERT [dbo].[UserInfo] OFF
ALTER TABLE [dbo].[Music]  WITH CHECK ADD  CONSTRAINT [FK_Music_Singer] FOREIGN KEY([SingerID])
REFERENCES [dbo].[Singer] ([SingerID])
GO
ALTER TABLE [dbo].[Music] CHECK CONSTRAINT [FK_Music_Singer]
GO
ALTER TABLE [dbo].[Music]  WITH CHECK ADD  CONSTRAINT [FK_Music_Type] FOREIGN KEY([TypeID])
REFERENCES [dbo].[MusicType] ([TypeID])
GO
ALTER TABLE [dbo].[Music] CHECK CONSTRAINT [FK_Music_Type]
GO
ALTER TABLE [dbo].[MusicList]  WITH CHECK ADD  CONSTRAINT [FK_MusicList_Music] FOREIGN KEY([MusicID])
REFERENCES [dbo].[Music] ([MusicID])
GO
ALTER TABLE [dbo].[MusicList] CHECK CONSTRAINT [FK_MusicList_Music]
GO
ALTER TABLE [dbo].[MusicList]  WITH CHECK ADD  CONSTRAINT [FK_MusicList_UserInfo] FOREIGN KEY([UserID])
REFERENCES [dbo].[UserInfo] ([UserID])
GO
ALTER TABLE [dbo].[MusicList] CHECK CONSTRAINT [FK_MusicList_UserInfo]
GO
