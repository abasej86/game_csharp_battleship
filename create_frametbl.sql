USE [project2]
GO

/****** Object:  Table [dbo].[frame]    Script Date: 2018-11-03 10:15:49 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[frame](
	[frameId] [int] IDENTITY(1,1) NOT NULL,
	[array_y] [int] NOT NULL,
	[array_x0] [int] NOT NULL,
	[array_x1] [int] NOT NULL,
	[array_x2] [int] NOT NULL,
	[array_x3] [int] NOT NULL,
	[array_x4] [int] NOT NULL,
	[array_x5] [int] NOT NULL,
	[array_x6] [int] NOT NULL,
	[array_x7] [int] NOT NULL,
	[array_x8] [int] NOT NULL,
	[array_x9] [int] NOT NULL,
	[gameFK] [int] NULL,
 CONSTRAINT [PK_tbl_book] PRIMARY KEY CLUSTERED 
(
	[frameId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


