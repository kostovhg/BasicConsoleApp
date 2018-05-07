
CREATE TABLE [categories] (
    [id]       INT           IDENTITY (1, 1) NOT NULL,
    [category] VARCHAR (255) NOT NULL,
    CONSTRAINT [PK_product] PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE [posts] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [category_id] INT           NOT NULL,
    [title]       VARCHAR (255) DEFAULT ('title') NOT NULL,
    [views]       INT           DEFAULT ((0)) NOT NULL,
    [created_at]  DATE          NOT NULL,
    CONSTRAINT [PK_posts] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_post_category] FOREIGN KEY ([category_id]) REFERENCES [dbo].[categories] ([id])
);

SET IDENTITY_INSERT [dbo].[categories] ON
INSERT INTO [dbo].[categories] ([id], [category]) VALUES (1, N'art')
INSERT INTO [dbo].[categories] ([id], [category]) VALUES (2, N'business')
INSERT INTO [dbo].[categories] ([id], [category]) VALUES (3, N'sport')
INSERT INTO [dbo].[categories] ([id], [category]) VALUES (4, N'politics')
INSERT INTO [dbo].[categories] ([id], [category]) VALUES (5, N'science')
INSERT INTO [dbo].[categories] ([id], [category]) VALUES (6, N'other')
SET IDENTITY_INSERT [dbo].[categories] OFF


SET IDENTITY_INSERT [dbo].[posts] ON
INSERT INTO [dbo].[posts] ([id], [category_id], [title], [views], [created_at]) VALUES (1, 1, N'Art post 1', 256, N'2016-10-05')
INSERT INTO [dbo].[posts] ([id], [category_id], [title], [views], [created_at]) VALUES (2, 5, N'Sciense post 1', 10, N'2016-10-15')
INSERT INTO [dbo].[posts] ([id], [category_id], [title], [views], [created_at]) VALUES (3, 2, N'Business post 1', 518, N'2016-10-22')
INSERT INTO [dbo].[posts] ([id], [category_id], [title], [views], [created_at]) VALUES (4, 1, N'Art post 2', 654, N'2016-11-03')
INSERT INTO [dbo].[posts] ([id], [category_id], [title], [views], [created_at]) VALUES (5, 3, N'Sport post 1', 3214, N'2016-11-22')
INSERT INTO [dbo].[posts] ([id], [category_id], [title], [views], [created_at]) VALUES (6, 4, N'Politics post 1', 14, N'2016-11-25')
INSERT INTO [dbo].[posts] ([id], [category_id], [title], [views], [created_at]) VALUES (7, 1, N'Art post 3', 154, N'2016-12-06')
INSERT INTO [dbo].[posts] ([id], [category_id], [title], [views], [created_at]) VALUES (8, 6, N'Some post 1', 5, N'2017-01-02')
INSERT INTO [dbo].[posts] ([id], [category_id], [title], [views], [created_at]) VALUES (9, 2, N'Business post 2', 684, N'2017-01-16')
INSERT INTO [dbo].[posts] ([id], [category_id], [title], [views], [created_at]) VALUES (10, 3, N'Sport post 2', 3216, N'2017-01-17')
INSERT INTO [dbo].[posts] ([id], [category_id], [title], [views], [created_at]) VALUES (11, 2, N'Business post 3', 158, N'2017-01-20')
INSERT INTO [dbo].[posts] ([id], [category_id], [title], [views], [created_at]) VALUES (13, 2, N'Business post 4', 357, N'2017-01-22')
INSERT INTO [dbo].[posts] ([id], [category_id], [title], [views], [created_at]) VALUES (14, 4, N'Politics post 2', 328, N'2017-01-25')
INSERT INTO [dbo].[posts] ([id], [category_id], [title], [views], [created_at]) VALUES (15, 1, N'Art post 4', 358, N'2017-02-03')
INSERT INTO [dbo].[posts] ([id], [category_id], [title], [views], [created_at]) VALUES (16, 2, N'Business post 5', 268, N'2017-02-06')
INSERT INTO [dbo].[posts] ([id], [category_id], [title], [views], [created_at]) VALUES (17, 5, N'Sciense post 2', 3589, N'2017-02-08')
INSERT INTO [dbo].[posts] ([id], [category_id], [title], [views], [created_at]) VALUES (18, 3, N'Sport post 3 ', 954, N'2017-02-15')
INSERT INTO [dbo].[posts] ([id], [category_id], [title], [views], [created_at]) VALUES (19, 1, N'Art post 5', 269, N'2017-02-17')
SET IDENTITY_INSERT [dbo].[posts] OFF
