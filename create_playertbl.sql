USE [project2]
GO

/****** Object:  Table [dbo].[player]    Script Date: 2018-11-03 10:16:07 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[player](
	[playerId] [int] IDENTITY(1,1) NOT NULL,
	[frame_fk] [int] NOT NULL,
	[playerScore] [int] NOT NULL,
	[playerName] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_player] PRIMARY KEY CLUSTERED 
(
	[playerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


