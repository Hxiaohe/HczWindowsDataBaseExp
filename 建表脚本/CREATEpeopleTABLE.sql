USE [xiaohe]
GO

/****** Object:  Table [dbo].[people]    Script Date: 2018/11/9 星期五 19:36:13 ******/
DROP TABLE [dbo].[people]
GO

/****** Object:  Table [dbo].[people]    Script Date: 2018/11/9 星期五 19:36:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[people](
	[id] [nchar](50) NOT NULL,
	[name] [nchar](50) NOT NULL,
 CONSTRAINT [PK_people] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

