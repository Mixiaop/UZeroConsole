
/****** Object:  Table [dbo].[UZeroConsole_Sso_Apps]    ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[UZeroConsole_Sso_Apps](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AppKey] [varchar](50) NOT NULL,
	[SecretKey] [varchar](50) NOT NULL,
	[IsSystem] [bit] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Remark] [nvarchar](500) NOT NULL,
	[ReturnUrl] [nvarchar](50) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreationTime] [datetime] NOT NULL,
	[CreatorUserId] [bigint] NULL,
 CONSTRAINT [PK_UZeroConsole_Sso_Apps] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[UZeroConsole_Sso_Apps] ADD  CONSTRAINT [DF_UZeroConsole_Sso_Apps_AppKey]  DEFAULT ('') FOR [AppKey]
GO

ALTER TABLE [dbo].[UZeroConsole_Sso_Apps] ADD  CONSTRAINT [DF_UZeroConsole_Sso_Apps_SecretKey]  DEFAULT ('') FOR [SecretKey]
GO

ALTER TABLE [dbo].[UZeroConsole_Sso_Apps] ADD  CONSTRAINT [DF_UZeroConsole_Sso_Apps_IsSystem]  DEFAULT ((0)) FOR [IsSystem]
GO

ALTER TABLE [dbo].[UZeroConsole_Sso_Apps] ADD  CONSTRAINT [DF_UZeroConsole_Sso_Apps_Name]  DEFAULT ('') FOR [Name]
GO

ALTER TABLE [dbo].[UZeroConsole_Sso_Apps] ADD  CONSTRAINT [DF_UZeroConsole_Sso_Apps_Remark]  DEFAULT ('') FOR [Remark]
GO

ALTER TABLE [dbo].[UZeroConsole_Sso_Apps] ADD  CONSTRAINT [DF_UZeroConsole_Sso_Apps_ReturnUrl]  DEFAULT ('') FOR [ReturnUrl]
GO

ALTER TABLE [dbo].[UZeroConsole_Sso_Apps] ADD  CONSTRAINT [DF_UZeroConsole_Sso_Apps_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[UZeroConsole_Sso_Apps] ADD  CONSTRAINT [DF_UZeroConsole_Sso_Apps_CreationTime]  DEFAULT (getdate()) FOR [CreationTime]
GO

ALTER TABLE [dbo].[UZeroConsole_Sso_Apps] ADD  CONSTRAINT [DF_UZeroConsole_Sso_Apps_CreatorUserId]  DEFAULT ((0)) FOR [CreatorUserId]
GO


/****** Object:  Table [dbo].[UZeroConsole_Sso_AdminAuthSessions]   ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UZeroConsole_Sso_AdminAuthSessions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SessionKey] [nvarchar](50) NOT NULL,
	[CurrentAppKey] [nvarchar](50) NOT NULL,
	[AppKeys] [nvarchar](max) NOT NULL,
	[AuthedAppKeys] [nvarchar](max) NOT NULL,
	[AdminId] [int] NOT NULL,
	[IpAddress] [nvarchar](100) NOT NULL,
	[ExpiresTime] [datetime] NOT NULL,
	[CreationTime] [datetime] NOT NULL,
 CONSTRAINT [PK_UZeroConsole_Sso_AdminAuthSessions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[UZeroConsole_Sso_AdminAuthSessions] ADD  CONSTRAINT [DF_UZeroConsole_Sso_AdminAuthSessions_SessionKey]  DEFAULT ('') FOR [SessionKey]
GO

ALTER TABLE [dbo].[UZeroConsole_Sso_AdminAuthSessions] ADD  CONSTRAINT [DF_UZeroConsole_Sso_AdminAuthSessions_CurrentAppKey]  DEFAULT ('') FOR [CurrentAppKey]
GO

ALTER TABLE [dbo].[UZeroConsole_Sso_AdminAuthSessions] ADD  CONSTRAINT [DF_UZeroConsole_Sso_AdminAuthSessions_AppKeys]  DEFAULT ('') FOR [AppKeys]
GO

ALTER TABLE [dbo].[UZeroConsole_Sso_AdminAuthSessions] ADD  CONSTRAINT [DF_UZeroConsole_Sso_AdminAuthSessions_AuthedAppKeys]  DEFAULT ('') FOR [AuthedAppKeys]
GO

ALTER TABLE [dbo].[UZeroConsole_Sso_AdminAuthSessions] ADD  CONSTRAINT [DF_UZeroConsole_Sso_AdminAuthSessions_AdminId]  DEFAULT ((0)) FOR [AdminId]
GO

ALTER TABLE [dbo].[UZeroConsole_Sso_AdminAuthSessions] ADD  CONSTRAINT [DF_UZeroConsole_Sso_AdminAuthSessions_IpAddress]  DEFAULT ('') FOR [IpAddress]
GO

ALTER TABLE [dbo].[UZeroConsole_Sso_AdminAuthSessions] ADD  CONSTRAINT [DF_UZeroConsole_Sso_AdminAuthSessions_ExpiresTime]  DEFAULT (getdate()) FOR [ExpiresTime]
GO

ALTER TABLE [dbo].[UZeroConsole_Sso_AdminAuthSessions] ADD  CONSTRAINT [DF_UZeroConsole_Sso_AdminAuthSessions_CreationTime]  DEFAULT (getdate()) FOR [CreationTime]
GO




/****** Object:  Table [dbo].[UZeroConsole_Admins]     ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UZeroConsole_Admins](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](32) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](128) NOT NULL,
	[RoleId] [int] NOT NULL,
	[Remark] [nvarchar](500) NULL,
	[LastLoginTime] [datetime] NULL,
	[UNoteUsername] [nvarchar](255) NOT NULL,
	[CorpWeixinUserId] [nvarchar](255) NOT NULL,
	[IsSystem] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreationTime] [datetime] NOT NULL,
	[CreatorUserId] [bigint] NULL,
 CONSTRAINT [PK_UZeroConsole_Admins] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[UZeroConsole_Admins] ADD  CONSTRAINT [DF_UZeroConsole_Admins_Name]  DEFAULT ('') FOR [Name]
GO

ALTER TABLE [dbo].[UZeroConsole_Admins] ADD  CONSTRAINT [DF_UZeroConsole_Admins_Username]  DEFAULT ('') FOR [Username]
GO

ALTER TABLE [dbo].[UZeroConsole_Admins] ADD  CONSTRAINT [DF_UZeroConsole_Admins_Password]  DEFAULT ('') FOR [Password]
GO

ALTER TABLE [dbo].[UZeroConsole_Admins] ADD  CONSTRAINT [DF_UZeroConsole_Admins_RoleId]  DEFAULT ((0)) FOR [RoleId]
GO

ALTER TABLE [dbo].[UZeroConsole_Admins] ADD  CONSTRAINT [DF_UZeroConsole_Admins_Remark]  DEFAULT ('') FOR [Remark]
GO

ALTER TABLE [dbo].[UZeroConsole_Admins] ADD  CONSTRAINT [DF_UZeroConsole_Admins_LastLoginTime]  DEFAULT (getdate()) FOR [LastLoginTime]
GO

ALTER TABLE [dbo].[UZeroConsole_Admins] ADD  CONSTRAINT [DF_UZeroConsole_Admins_UNoteUsername]  DEFAULT ('') FOR [UNoteUsername]
GO

ALTER TABLE [dbo].[UZeroConsole_Admins] ADD  CONSTRAINT [DF_UZeroConsole_Admins_CorpWeixinUserId]  DEFAULT ('') FOR [CorpWeixinUserId]
GO

ALTER TABLE [dbo].[UZeroConsole_Admins] ADD  CONSTRAINT [DF_UZeroConsole_Admins_IsSystem]  DEFAULT ((0)) FOR [IsSystem]
GO

ALTER TABLE [dbo].[UZeroConsole_Admins] ADD  CONSTRAINT [DF_UZeroConsole_Admins_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[UZeroConsole_Admins] ADD  CONSTRAINT [DF_UZeroConsole_Admins_CreationTime]  DEFAULT (getdate()) FOR [CreationTime]
GO

ALTER TABLE [dbo].[UZeroConsole_Admins] ADD  CONSTRAINT [DF_UZeroConsole_Admins_CreatorUserId]  DEFAULT ((0)) FOR [CreatorUserId]
GO

/****** Object:  Table [dbo].[UZeroConsole_AdminRoles_Mapping]     ******/

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UZeroConsole_AdminRoles_Mapping](
	[AdminId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_UZeroConsole_AdminRoles_Mapping] PRIMARY KEY CLUSTERED 
(
	[AdminId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[UZeroConsole_AdminRoles_Mapping] ADD  CONSTRAINT [DF_UZeroConsole_AdminRoles_Mapping_AdminId]  DEFAULT ((0)) FOR [AdminId]
GO

ALTER TABLE [dbo].[UZeroConsole_AdminRoles_Mapping] ADD  CONSTRAINT [DF_UZeroConsole_AdminRoles_Mapping_RoleId]  DEFAULT ((0)) FOR [RoleId]
GO



/****** Object:  Table [dbo].[UZeroConsole_Permissions]    ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[UZeroConsole_Permissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SsoAppId] [int] NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Icon] [varchar](500) NULL,
	[Url] [varchar](200) NULL,
	[ParentId] [int] NULL,
	[Level] [int] NULL,
	[Order] [int] NULL,
	[IsSystem] [bit] NOT NULL,
	[CreationTime] [datetime] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_UZeroConsole_Permissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[UZeroConsole_Permissions] ADD  CONSTRAINT [DF_UZeroConsole_Permissions_SsoAppId]  DEFAULT ((0)) FOR [SsoAppId]
GO

ALTER TABLE [dbo].[UZeroConsole_Permissions] ADD  CONSTRAINT [DF_UZeroConsole_Permissions_Name]  DEFAULT ('') FOR [Name]
GO

ALTER TABLE [dbo].[UZeroConsole_Permissions] ADD  CONSTRAINT [DF_UZeroConsole_Permissions_Icon]  DEFAULT ('') FOR [Icon]
GO

ALTER TABLE [dbo].[UZeroConsole_Permissions] ADD  CONSTRAINT [DF_UZeroConsole_Permissions_Url]  DEFAULT ('') FOR [Url]
GO

ALTER TABLE [dbo].[UZeroConsole_Permissions] ADD  CONSTRAINT [DF_UZeroConsole_Permissions_ParentId]  DEFAULT ((0)) FOR [ParentId]
GO

ALTER TABLE [dbo].[UZeroConsole_Permissions] ADD  CONSTRAINT [DF_UZeroConsole_Permissions_Level]  DEFAULT ((0)) FOR [Level]
GO

ALTER TABLE [dbo].[UZeroConsole_Permissions] ADD  CONSTRAINT [DF_UZeroConsole_Permissions_Order]  DEFAULT ((0)) FOR [Order]
GO

ALTER TABLE [dbo].[UZeroConsole_Permissions] ADD  CONSTRAINT [DF_UZeroConsole_Permissions_IsSystem]  DEFAULT ((0)) FOR [IsSystem]
GO

ALTER TABLE [dbo].[UZeroConsole_Permissions] ADD  CONSTRAINT [DF_UZeroConsole_Permissions_CreationTime]  DEFAULT (getdate()) FOR [CreationTime]
GO

ALTER TABLE [dbo].[UZeroConsole_Permissions] ADD  CONSTRAINT [DF_UZeroConsole_Permissions_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]


/****** Object:  Table [dbo].[UZeroConsole_Roles]   ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UZeroConsole_Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SsoAppId] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Remark] [nvarchar](200) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_UZeroConsole_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[UZeroConsole_Roles] ADD  CONSTRAINT [DF_UZeroConsole_Roles_SsoAppId]  DEFAULT ((0)) FOR [SsoAppId]
GO

ALTER TABLE [dbo].[UZeroConsole_Roles] ADD  CONSTRAINT [DF_UZeroConsole_Roles_Name]  DEFAULT ('') FOR [Name]
GO

ALTER TABLE [dbo].[UZeroConsole_Roles] ADD  CONSTRAINT [DF_UZeroConsole_Roles_Remark]  DEFAULT ('') FOR [Remark]
GO

ALTER TABLE [dbo].[UZeroConsole_Roles] ADD  CONSTRAINT [DF_UZeroConsole_Roles_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO




/****** Object:  Table [dbo].[UZeroConsole_RolePermissions]     ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UZeroConsole_RolePermissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[PermissionId] [int] NOT NULL,
 CONSTRAINT [PK_UZeroConsole_RolePermissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[UZeroConsole_RolePermissions] ADD  CONSTRAINT [DF_UZeroConsole_RolePermissions_RoleId]  DEFAULT ((0)) FOR [RoleId]
GO

ALTER TABLE [dbo].[UZeroConsole_RolePermissions] ADD  CONSTRAINT [DF_UZeroConsole_RolePermissions_PermissionId]  DEFAULT ((0)) FOR [PermissionId]
GO


/****** Object:  Table [dbo].[UZeroConsole_Tags]     ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UZeroConsole_Tags](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Alias] [nvarchar](255) NOT NULL,
	[Count] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[TypeId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletionTime] [datetime] NULL,
	[DeleterUserId] [bigint] NULL,
	[LastModificationTime] [datetime] NULL,
	[LastModifierUserId] [bigint] NULL,
	[CreatorUserId] [bigint] NULL,
	[CreationTime] [datetime] NOT NULL,
 CONSTRAINT [PK_UZeroConsole_Tags] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[UZeroConsole_Tags] ADD  CONSTRAINT [DF_UZeroConsole_Tags_Name]  DEFAULT ('') FOR [Name]
GO

ALTER TABLE [dbo].[UZeroConsole_Tags] ADD  CONSTRAINT [DF_UZeroConsole_Tags_Alias]  DEFAULT ('') FOR [Alias]
GO

ALTER TABLE [dbo].[UZeroConsole_Tags] ADD  CONSTRAINT [DF_UZeroConsole_Tags_Count]  DEFAULT ((0)) FOR [Count]
GO

ALTER TABLE [dbo].[UZeroConsole_Tags] ADD  CONSTRAINT [DF_UZeroConsole_Tags_UserId]  DEFAULT ((0)) FOR [UserId]
GO

ALTER TABLE [dbo].[UZeroConsole_Tags] ADD  CONSTRAINT [DF_UZeroConsole_Tags_TypeId]  DEFAULT ((0)) FOR [TypeId]
GO

ALTER TABLE [dbo].[UZeroConsole_Tags] ADD  CONSTRAINT [DF_UZeroConsole_Tags_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[UZeroConsole_Tags] ADD  CONSTRAINT [DF_UZeroConsole_Tags_CreationTime]  DEFAULT (getdate()) FOR [CreationTime]
GO





/****** Object:  Table [dbo].[UZeroConsole_Jobs_RemoteJobs]     ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UZeroConsole_Jobs_RemoteJobs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Key] [nvarchar](255) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Url] [nvarchar](500) NOT NULL,
	[Desc] [nvarchar](1000) NOT NULL,
	[IsExecuting] [bit] NOT NULL,
	[LastSuccessTime] [datetime] NULL,
	[LastErrorTime] [datetime] NULL,
	[LastErrorDesc] [nvarchar](1000) NOT NULL,
	[TypeId] [int] NOT NULL,
	[RecurringSeconds] [int] NOT NULL,
	[AtTime] [datetime] NULL,
	[AppJobId] [nvarchar](255) NOT NULL,
	[Tags] [nvarchar](255) NOT NULL,
	[CreationTime] [datetime] NOT NULL,
	[CreatorUserId] [bigint] NULL,
 CONSTRAINT [PK_UZeroConsole_Jobs_RemoteJobs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[UZeroConsole_Jobs_RemoteJobs] ADD  CONSTRAINT [DF_UZeroConsole_Jobs_RemoteJobs_Key]  DEFAULT ('') FOR [Key]
GO

ALTER TABLE [dbo].[UZeroConsole_Jobs_RemoteJobs] ADD  CONSTRAINT [DF_UZeroConsole_Jobs_RemoteJobs_Name]  DEFAULT ('') FOR [Name]
GO

ALTER TABLE [dbo].[UZeroConsole_Jobs_RemoteJobs] ADD  CONSTRAINT [DF_UZeroConsole_Jobs_RemoteJobs_Url]  DEFAULT ('') FOR [Url]
GO

ALTER TABLE [dbo].[UZeroConsole_Jobs_RemoteJobs] ADD  CONSTRAINT [DF_UZeroConsole_Jobs_RemoteJobs_Desc]  DEFAULT ('') FOR [Desc]
GO

ALTER TABLE [dbo].[UZeroConsole_Jobs_RemoteJobs] ADD  CONSTRAINT [DF_UZeroConsole_Jobs_RemoteJobs_IsExecuting]  DEFAULT ((0)) FOR [IsExecuting]
GO

ALTER TABLE [dbo].[UZeroConsole_Jobs_RemoteJobs] ADD  CONSTRAINT [DF_UZeroConsole_Jobs_RemoteJobs_LastSuccessTime]  DEFAULT (getdate()) FOR [LastSuccessTime]
GO

ALTER TABLE [dbo].[UZeroConsole_Jobs_RemoteJobs] ADD  CONSTRAINT [DF_UZeroConsole_Jobs_RemoteJobs_LastErrorTime]  DEFAULT (getdate()) FOR [LastErrorTime]
GO

ALTER TABLE [dbo].[UZeroConsole_Jobs_RemoteJobs] ADD  CONSTRAINT [DF_UZeroConsole_Jobs_RemoteJobs_LastErrorDesc]  DEFAULT ('') FOR [LastErrorDesc]
GO

ALTER TABLE [dbo].[UZeroConsole_Jobs_RemoteJobs] ADD  CONSTRAINT [DF_UZeroConsole_Jobs_RemoteJobs_TypeId]  DEFAULT ((0)) FOR [TypeId]
GO

ALTER TABLE [dbo].[UZeroConsole_Jobs_RemoteJobs] ADD  CONSTRAINT [DF_UZeroConsole_Jobs_RemoteJobs_RecurringSeconds]  DEFAULT ((0)) FOR [RecurringSeconds]
GO

ALTER TABLE [dbo].[UZeroConsole_Jobs_RemoteJobs] ADD  CONSTRAINT [DF_UZeroConsole_Jobs_RemoteJobs_AppJobId]  DEFAULT ('') FOR [AppJobId]
GO

ALTER TABLE [dbo].[UZeroConsole_Jobs_RemoteJobs] ADD  CONSTRAINT [DF_UZeroConsole_Jobs_RemoteJobs_Tags]  DEFAULT ('') FOR [Tags]
GO

ALTER TABLE [dbo].[UZeroConsole_Jobs_RemoteJobs] ADD  CONSTRAINT [DF_UZeroConsole_Jobs_RemoteJobs_CreationTime]  DEFAULT (getdate()) FOR [CreationTime]
GO

ALTER TABLE [dbo].[UZeroConsole_Jobs_RemoteJobs] ADD  CONSTRAINT [DF_UZeroConsole_Jobs_RemoteJobs_CreatorUserId]  DEFAULT ((0)) FOR [CreatorUserId]
GO


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
	[IsTests] [bit] NOT NULL,
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

ALTER TABLE [dbo].[UZeroConsole_Logging_LogApps] ADD  CONSTRAINT [DF_UZeroConsole_Logging_LogApps_IsTests]  DEFAULT ((0)) FOR [IsTests]
GO

ALTER TABLE [dbo].[UZeroConsole_Logging_LogApps] ADD  CONSTRAINT [DF_UZeroConsole_Logging_LogApps_CreationTime]  DEFAULT (getdate()) FOR [CreationTime]
GO

ALTER TABLE [dbo].[UZeroConsole_Logging_LogApps] ADD  CONSTRAINT [DF_UZeroConsole_Logging_LogApps_CreatorUserId]  DEFAULT ((0)) FOR [CreatorUserId]
GO

/****** Object:  Table [dbo].[UZeroConsole_Logging_ActionModules]     ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UZeroConsole_Logging_ActionModules](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AppId] [int] NOT NULL,
	[ModuleName] [nvarchar](255) NOT NULL,
	[CreationTime] [datetime] NOT NULL,
	[CreatorUserId] [bigint] NULL,
 CONSTRAINT [PK_UZeroConsole_Logging_ActionModules] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[UZeroConsole_Logging_ActionModules] ADD  CONSTRAINT [DF_UZeroConsole_Logging_ActionModules_AppId]  DEFAULT ((0)) FOR [AppId]
GO

ALTER TABLE [dbo].[UZeroConsole_Logging_ActionModules] ADD  CONSTRAINT [DF_UZeroConsole_Logging_ActionModules_ModuleName]  DEFAULT ('') FOR [ModuleName]
GO

ALTER TABLE [dbo].[UZeroConsole_Logging_ActionModules] ADD  CONSTRAINT [DF_UZeroConsole_Logging_ActionModules_CreationTime]  DEFAULT (getdate()) FOR [CreationTime]
GO

ALTER TABLE [dbo].[UZeroConsole_Logging_ActionModules] ADD  CONSTRAINT [DF_UZeroConsole_Logging_ActionModules_CreatorUserId]  DEFAULT ((0)) FOR [CreatorUserId]
GO


/****** Object:  Table [dbo].[UZeroConsole_Logging_ActionLogs]     ******/
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

/****** Object:  Table [dbo].[UZeroConsole_Logging_ExceptionLogs]    ******/
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

