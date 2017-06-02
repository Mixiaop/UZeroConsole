/****** Object:  Table [dbo].[UZeroConsole_Logging_LogApps]     ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UZeroConsole_Logging_LogApps](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](1000) NOT NULL,
	[Key] [nvarchar](100) NOT NULL,
	[LastExceptionTime] [datetime] NULL,
	[LastActionTime] [datetime] NULL,
	[CreationTime] [datetime] NOT NULL,
	[CreatorUserId] [bigint] NULL,
 CONSTRAINT [PK_UZeroConsole_Logging_LogApps] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[UZeroConsole_Logging_LogApps] ADD  CONSTRAINT [DF_UZeroConsole_Logging_LogApps_Name]  DEFAULT ('') FOR [Name]
GO

ALTER TABLE [dbo].[UZeroConsole_Logging_LogApps] ADD  CONSTRAINT [DF_UZeroConsole_Logging_LogApps_Description]  DEFAULT ('') FOR [Description]
GO

ALTER TABLE [dbo].[UZeroConsole_Logging_LogApps] ADD  CONSTRAINT [DF_UZeroConsole_Logging_LogApps_Key]  DEFAULT ('') FOR [Key]
GO

ALTER TABLE [dbo].[UZeroConsole_Logging_LogApps] ADD  CONSTRAINT [DF_UZeroConsole_Logging_LogApps_CreationTime]  DEFAULT (getdate()) FOR [CreationTime]
GO

ALTER TABLE [dbo].[UZeroConsole_Logging_LogApps] ADD  CONSTRAINT [DF_UZeroConsole_Logging_LogApps_CreatorUserId]  DEFAULT ((0)) FOR [CreatorUserId]
GO

/****** Object:  Table [dbo].[UZeroConsole_Logging_ExceptionLogs]     ******/

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UZeroConsole_Logging_ExceptionLogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AppId] [int] NOT NULL,
	[MachineName] [nvarchar](255) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[ShortMessage] [nvarchar](255) NOT NULL,
	[FullMessage] [ntext] NOT NULL,
	[IpAddress] [nvarchar](255) NOT NULL,
	[Host] [nvarchar](255) NOT NULL,
	[Url] [nvarchar](255) NOT NULL,
	[UserAgent] [nvarchar](255) NOT NULL,
	[HttpMethod] [nvarchar](50) NOT NULL,
	[StatusCode] [nvarchar](50) NOT NULL,
	[CreationTime] [datetime] NOT NULL,
	[CreatorUserId] [bigint] NULL,
 CONSTRAINT [PK_UZeroConsole_Logging_ExceptionLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[UZeroConsole_Logging_ExceptionLogs] ADD  CONSTRAINT [DF_UZeroConsole_Logging_ExceptionLogs_AppId]  DEFAULT ((0)) FOR [AppId]
GO

ALTER TABLE [dbo].[UZeroConsole_Logging_ExceptionLogs] ADD  CONSTRAINT [DF_UZeroConsole_Logging_ExceptionLogs_MachineName]  DEFAULT ('') FOR [MachineName]
GO

ALTER TABLE [dbo].[UZeroConsole_Logging_ExceptionLogs] ADD  CONSTRAINT [DF_UZeroConsole_Logging_ExceptionLogs_Type]  DEFAULT ('') FOR [Type]
GO

ALTER TABLE [dbo].[UZeroConsole_Logging_ExceptionLogs] ADD  CONSTRAINT [DF_UZeroConsole_Logging_ExceptionLogs_ShortMessage]  DEFAULT ('') FOR [ShortMessage]
GO

ALTER TABLE [dbo].[UZeroConsole_Logging_ExceptionLogs] ADD  CONSTRAINT [DF_UZeroConsole_Logging_ExceptionLogs_FullMessage]  DEFAULT ('') FOR [FullMessage]
GO

ALTER TABLE [dbo].[UZeroConsole_Logging_ExceptionLogs] ADD  CONSTRAINT [DF_UZeroConsole_Logging_ExceptionLogs_IpAddress]  DEFAULT ('') FOR [IpAddress]
GO

ALTER TABLE [dbo].[UZeroConsole_Logging_ExceptionLogs] ADD  CONSTRAINT [DF_UZeroConsole_Logging_ExceptionLogs_Host]  DEFAULT ('') FOR [Host]
GO

ALTER TABLE [dbo].[UZeroConsole_Logging_ExceptionLogs] ADD  CONSTRAINT [DF_UZeroConsole_Logging_ExceptionLogs_Url]  DEFAULT ('') FOR [Url]
GO

ALTER TABLE [dbo].[UZeroConsole_Logging_ExceptionLogs] ADD  CONSTRAINT [DF_UZeroConsole_Logging_ExceptionLogs_UserAgent]  DEFAULT ('') FOR [UserAgent]
GO

ALTER TABLE [dbo].[UZeroConsole_Logging_ExceptionLogs] ADD  CONSTRAINT [DF_UZeroConsole_Logging_ExceptionLogs_HttpMethod]  DEFAULT ('') FOR [HttpMethod]
GO

ALTER TABLE [dbo].[UZeroConsole_Logging_ExceptionLogs] ADD  CONSTRAINT [DF_UZeroConsole_Logging_ExceptionLogs_StatusCode]  DEFAULT ('') FOR [StatusCode]
GO

ALTER TABLE [dbo].[UZeroConsole_Logging_ExceptionLogs] ADD  CONSTRAINT [DF_UZeroConsole_Logging_ExceptionLogs_CreationTime]  DEFAULT (getdate()) FOR [CreationTime]
GO

ALTER TABLE [dbo].[UZeroConsole_Logging_ExceptionLogs] ADD  CONSTRAINT [DF_UZeroConsole_Logging_ExceptionLogs_CreatorUserId]  DEFAULT ((0)) FOR [CreatorUserId]
GO


/****** Object:  Table [dbo].[UZeroConsole_Logging_ActionLogs]   ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UZeroConsole_Logging_ActionLogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AppId] [int] NOT NULL,
	[ModuleName] [nvarchar](255) NOT NULL,
	[OperateTypeId] [int] NOT NULL,
	[ShortMessage] [nvarchar](500) NOT NULL,
	[FullMessage] [ntext] NOT NULL,
	[IpAddress] [nvarchar](50) NOT NULL,
	[Url] [nvarchar](1000) NOT NULL,
	[UserAgent] [nvarchar](500) NOT NULL,
	[Operator] [nvarchar](255) NOT NULL,
	[OperatorId] [nvarchar](255) NOT NULL,
	[Remark] [nvarchar](1000) NULL,
	[CreationTime] [datetime] NOT NULL,
	[CreatorUserId] [bigint] NULL,
 CONSTRAINT [PK_UZeroConsole_Logging_ActionLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[UZeroConsole_Logging_ActionLogs] ADD  CONSTRAINT [DF_UZeroConsole_Logging_ActionLogs_AppId]  DEFAULT ((0)) FOR [AppId]
GO

ALTER TABLE [dbo].[UZeroConsole_Logging_ActionLogs] ADD  CONSTRAINT [DF_UZeroConsole_Logging_ActionLogs_ModuleName]  DEFAULT ('') FOR [ModuleName]
GO

ALTER TABLE [dbo].[UZeroConsole_Logging_ActionLogs] ADD  CONSTRAINT [DF_UZeroConsole_Logging_ActionLogs_OperateTypeId]  DEFAULT ((0)) FOR [OperateTypeId]
GO

ALTER TABLE [dbo].[UZeroConsole_Logging_ActionLogs] ADD  CONSTRAINT [DF_UZeroConsole_Logging_ActionLogs_ShortMessage]  DEFAULT ('') FOR [ShortMessage]
GO

ALTER TABLE [dbo].[UZeroConsole_Logging_ActionLogs] ADD  CONSTRAINT [DF_UZeroConsole_Logging_ActionLogs_FullMessage]  DEFAULT ('') FOR [FullMessage]
GO

ALTER TABLE [dbo].[UZeroConsole_Logging_ActionLogs] ADD  CONSTRAINT [DF_UZeroConsole_Logging_ActionLogs_IpAddress]  DEFAULT ('') FOR [IpAddress]
GO

ALTER TABLE [dbo].[UZeroConsole_Logging_ActionLogs] ADD  CONSTRAINT [DF_UZeroConsole_Logging_ActionLogs_Url]  DEFAULT ('') FOR [Url]
GO

ALTER TABLE [dbo].[UZeroConsole_Logging_ActionLogs] ADD  CONSTRAINT [DF_UZeroConsole_Logging_ActionLogs_UserAgent]  DEFAULT ('') FOR [UserAgent]
GO

ALTER TABLE [dbo].[UZeroConsole_Logging_ActionLogs] ADD  CONSTRAINT [DF_UZeroConsole_Logging_ActionLogs_Operator]  DEFAULT ('') FOR [Operator]
GO

ALTER TABLE [dbo].[UZeroConsole_Logging_ActionLogs] ADD  CONSTRAINT [DF_UZeroConsole_Logging_ActionLogs_OperatorId]  DEFAULT ('') FOR [OperatorId]
GO

ALTER TABLE [dbo].[UZeroConsole_Logging_ActionLogs] ADD  CONSTRAINT [DF_UZeroConsole_Logging_ActionLogs_Remark]  DEFAULT ('') FOR [Remark]
GO

ALTER TABLE [dbo].[UZeroConsole_Logging_ActionLogs] ADD  CONSTRAINT [DF_UZeroConsole_Logging_ActionLogs_CreationTime]  DEFAULT (getdate()) FOR [CreationTime]
GO

ALTER TABLE [dbo].[UZeroConsole_Logging_ActionLogs] ADD  CONSTRAINT [DF_UZeroConsole_Logging_ActionLogs_CreatorUserId]  DEFAULT ((0)) FOR [CreatorUserId]
GO


