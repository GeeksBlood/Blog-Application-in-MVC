USE [MVCBlog]
GO
/****** Object:  Table [dbo].[t_category]    Script Date: 8/25/2017 5:19:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[category] [nvarchar](50) NOT NULL,
	[description] [nvarchar](200) NULL,
 CONSTRAINT [PK_t_category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[t_comment]    Script Date: 8/25/2017 5:19:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_comment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[postid] [int] NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[comment] [nvarchar](max) NOT NULL,
	[date_time] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_t_comment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[t_posts]    Script Date: 8/25/2017 5:19:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_posts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userid] [int] NOT NULL,
	[title] [nvarchar](100) NOT NULL,
	[url] [nvarchar](100) NOT NULL,
	[tags] [nvarchar](200) NULL,
	[categoryId] [int] NOT NULL,
	[postContent] [nvarchar](max) NOT NULL,
	[is_active] [bit] NOT NULL,
	[date_time] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_t_posts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[t_user]    Script Date: 8/25/2017 5:19:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[mobile_no] [nvarchar](10) NULL,
	[city] [nvarchar](50) NULL,
	[last_login] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[is_type] [int] NOT NULL,
	[is_active] [bit] NOT NULL,
	[reg_date] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_t_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[t_userType]    Script Date: 8/25/2017 5:19:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_userType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[is_type] [nvarchar](50) NULL,
 CONSTRAINT [PK_t_userType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[t_category] ON 

INSERT [dbo].[t_category] ([id], [category], [description]) VALUES (1, N'Asp', NULL)
INSERT [dbo].[t_category] ([id], [category], [description]) VALUES (2, N'jQuery', NULL)
INSERT [dbo].[t_category] ([id], [category], [description]) VALUES (3, N'CSharp', NULL)
SET IDENTITY_INSERT [dbo].[t_category] OFF
SET IDENTITY_INSERT [dbo].[t_comment] ON 

INSERT [dbo].[t_comment] ([id], [postid], [username], [email], [comment], [date_time]) VALUES (2, 1, N'samidrawat@gmail.com', N'samidrawat@gmail.com', N'Hi This is awesom post', N'2016-07-26')
SET IDENTITY_INSERT [dbo].[t_comment] OFF
SET IDENTITY_INSERT [dbo].[t_posts] ON 

INSERT [dbo].[t_posts] ([id], [userid], [title], [url], [tags], [categoryId], [postContent], [is_active], [date_time]) VALUES (1, 4, N'First post', N'example1', N'test', 2, N'Hello
This is the first post of the blog', 1, N'Jul  5 2016  4:49PM')
INSERT [dbo].[t_posts] ([id], [userid], [title], [url], [tags], [categoryId], [postContent], [is_active], [date_time]) VALUES (2, 1, N'abc', N'hi', N'h1', 2, N'hiiiiiiiiiiiiiiiiiiii', 0, N'Jul  5 2016  4:49PM')
INSERT [dbo].[t_posts] ([id], [userid], [title], [url], [tags], [categoryId], [postContent], [is_active], [date_time]) VALUES (5, 1, N'h1 fast railway', N'h1-fast-railway', N'f1', 3, N'<p style="text-align: center;"><em><strong>branches</strong></em></p>
<ol>
<li><span style="text-decoration: underline;"><strong>BuildProcessTemplates</strong></span></li>
<li><span style="text-decoration: underline;"><strong>Resources</strong></span></li>
<li><span style="text-decoration: underline;"><strong>tags</strong></span></li>
<li><span style="text-decoration: underline;"><strong>trunk</strong></span></li>
<li><span style="text-decoration: underline;"><strong>This is last one.</strong></span></li>
</ol>', 1, N'2016-07-22')
SET IDENTITY_INSERT [dbo].[t_posts] OFF
SET IDENTITY_INSERT [dbo].[t_user] ON 

INSERT [dbo].[t_user] ([id], [username], [email], [mobile_no], [city], [last_login], [password], [is_type], [is_active], [reg_date]) VALUES (1, N'Ankit', N'ankit@gmail.com', N'9999999976', N'Delhi', N'Jul  5 2016  4:49PM', N'12345678', 3, 1, N'Jul  5 2016  4:49PM')
INSERT [dbo].[t_user] ([id], [username], [email], [mobile_no], [city], [last_login], [password], [is_type], [is_active], [reg_date]) VALUES (4, N'Abhishek1', N'Abhishek@gmai.com', N'9999999943', N'Delhi', N'Jul  5 2016  4:49PM', N'aaaaaaaa', 1, 1, N'Jul  5 2016  4:49PM')
INSERT [dbo].[t_user] ([id], [username], [email], [mobile_no], [city], [last_login], [password], [is_type], [is_active], [reg_date]) VALUES (5, N'Kapil', N'kapil@gmail.com', N'9999999999', N'Delhi', N'Jul  5 2016  4:49PM', N'aaaaaaaa', 1, 1, N'Jul  5 2016  4:49PM')
INSERT [dbo].[t_user] ([id], [username], [email], [mobile_no], [city], [last_login], [password], [is_type], [is_active], [reg_date]) VALUES (6, N'samidrawat@gmail.com', N'samidrawat@gmail.com', N'8285595074', N'Delhi', N'6:45:46 PM', N'aaaaaaaa', 3, 1, N'6:45:46 PM')
SET IDENTITY_INSERT [dbo].[t_user] OFF
SET IDENTITY_INSERT [dbo].[t_userType] ON 

INSERT [dbo].[t_userType] ([id], [is_type]) VALUES (1, N'Admin')
INSERT [dbo].[t_userType] ([id], [is_type]) VALUES (2, N'User')
INSERT [dbo].[t_userType] ([id], [is_type]) VALUES (3, N'Author')
SET IDENTITY_INSERT [dbo].[t_userType] OFF
ALTER TABLE [dbo].[t_comment]  WITH CHECK ADD  CONSTRAINT [FK_t_comment_t_posts] FOREIGN KEY([postid])
REFERENCES [dbo].[t_posts] ([id])
GO
ALTER TABLE [dbo].[t_comment] CHECK CONSTRAINT [FK_t_comment_t_posts]
GO
ALTER TABLE [dbo].[t_posts]  WITH CHECK ADD  CONSTRAINT [FK_t_posts_t_category] FOREIGN KEY([categoryId])
REFERENCES [dbo].[t_category] ([id])
GO
ALTER TABLE [dbo].[t_posts] CHECK CONSTRAINT [FK_t_posts_t_category]
GO
ALTER TABLE [dbo].[t_posts]  WITH CHECK ADD  CONSTRAINT [FK_t_posts_t_user] FOREIGN KEY([userid])
REFERENCES [dbo].[t_user] ([id])
GO
ALTER TABLE [dbo].[t_posts] CHECK CONSTRAINT [FK_t_posts_t_user]
GO
ALTER TABLE [dbo].[t_user]  WITH CHECK ADD  CONSTRAINT [FK_t_user_t_userType] FOREIGN KEY([is_type])
REFERENCES [dbo].[t_userType] ([id])
GO
ALTER TABLE [dbo].[t_user] CHECK CONSTRAINT [FK_t_user_t_userType]
GO
