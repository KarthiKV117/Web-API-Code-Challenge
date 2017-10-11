USE [Order]
GO

/****** Object:  Table [dbo].[Product]    Script Date: 10/12/2017 01:27:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Product](
	[DatePublished] [datetime] NULL,
	[Title] [nvarchar](max) NOT NULL,
	[ShortDescription] [nvarchar](max) NOT NULL,
	[Brand] [nvarchar](max) NOT NULL,
	[Product_Id] [int] IDENTITY(0,1) NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Product_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-----------------------------------------------------------------------------------------------------------------------------------------
USE [Order]
GO

/****** Object:  Table [dbo].[Review]    Script Date: 10/12/2017 01:27:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Review](
	[Reviews_Id] [int] IDENTITY(0,1) NOT NULL,
	[Product_Id] [int] NULL,
	[Rating] [bigint] NOT NULL,
	[Comment] [nvarchar](256) NOT NULL,
	[User] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Review] PRIMARY KEY CLUSTERED 
(
	[Reviews_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Review]  WITH CHECK ADD  CONSTRAINT [Product_Review] FOREIGN KEY([Product_Id])
REFERENCES [dbo].[Product] ([Product_Id])
GO

ALTER TABLE [dbo].[Review] CHECK CONSTRAINT [Product_Review]
GO

