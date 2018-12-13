USE [CBIndividualProject]
GO

/****** Object:  Table [dbo].[CSAgents]    Script Date: 11/19/2018 12:24:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CSAgents](
	[Name] [varchar](30) NOT NULL,
	[Email] [varchar](30) NOT NULL,
	[PhoneNumber] [varchar](20) NULL,
	[Username] [varchar](15) NOT NULL,
	[Password] [nvarchar](8) NOT NULL,
 CONSTRAINT [PK_CSAgents_1] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CSAgents]  WITH CHECK ADD  CONSTRAINT [CK_CSAgents] CHECK  ((len([Password])=(8)))
GO

ALTER TABLE [dbo].[CSAgents] CHECK CONSTRAINT [CK_CSAgents]
GO

