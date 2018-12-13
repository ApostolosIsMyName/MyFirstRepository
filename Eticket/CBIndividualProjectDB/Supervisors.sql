USE [CBIndividualProject]
GO

/****** Object:  Table [dbo].[Supervisors]    Script Date: 11/19/2018 12:25:41 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Supervisors](
	[Name] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[PhoneNumber] [varchar](20) NULL,
	[Username] [varchar](15) NOT NULL,
	[Password] [nvarchar](8) NOT NULL,
 CONSTRAINT [PK_Supervisors_1] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

