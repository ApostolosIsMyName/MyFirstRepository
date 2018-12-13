USE [CBIndividualProject]
GO

/****** Object:  Table [dbo].[CustTickets]    Script Date: 11/19/2018 12:25:15 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CustTickets](
	[TicketID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [varchar](30) NOT NULL,
	[CustomerEmail] [varchar](30) NOT NULL,
	[CustomerPhone] [varchar](20) NULL,
	[Description] [text] NOT NULL,
	[Date] [datetime] NOT NULL,
	[CSAgent] [varchar](15) NULL,
	[TechSupport] [varchar](15) NULL,
	[Closed] [bit] NOT NULL,
 CONSTRAINT [PK_CustTickets] PRIMARY KEY CLUSTERED 
(
	[TicketID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[CustTickets] ADD  CONSTRAINT [DF_CustTickets_Closed]  DEFAULT ((0)) FOR [Closed]
GO

ALTER TABLE [dbo].[CustTickets]  WITH CHECK ADD  CONSTRAINT [FK_CustTickets_CSAgents1] FOREIGN KEY([CSAgent])
REFERENCES [dbo].[CSAgents] ([Username])
GO

ALTER TABLE [dbo].[CustTickets] CHECK CONSTRAINT [FK_CustTickets_CSAgents1]
GO

ALTER TABLE [dbo].[CustTickets]  WITH CHECK ADD  CONSTRAINT [FK_CustTickets_TechSupportUsers1] FOREIGN KEY([TechSupport])
REFERENCES [dbo].[TechSupportUsers] ([Username])
GO

ALTER TABLE [dbo].[CustTickets] CHECK CONSTRAINT [FK_CustTickets_TechSupportUsers1]
GO

