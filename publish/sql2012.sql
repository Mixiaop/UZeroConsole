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

ALTER TABLE [dbo].[UZeroConsole_Admins] ADD  CONSTRAINT [DF_UZeroConsole_Admins_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[UZeroConsole_Admins] ADD  CONSTRAINT [DF_UZeroConsole_Admins_CreationTime]  DEFAULT (getdate()) FOR [CreationTime]
GO

ALTER TABLE [dbo].[UZeroConsole_Admins] ADD  CONSTRAINT [DF_UZeroConsole_Admins_CreatorUserId]  DEFAULT ((0)) FOR [CreatorUserId]
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
	[Name] [nvarchar](200) NULL,
	[Icon] [varchar](500) NULL,
	[Url] [varchar](200) NULL,
	[ParentId] [int] NULL,
	[Level] [int] NULL,
	[Order] [int] NULL,
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

ALTER TABLE [dbo].[UZeroConsole_Permissions] ADD  CONSTRAINT [DF_UZeroConsole_Permissions_CreationTime]  DEFAULT (getdate()) FOR [CreationTime]
GO

ALTER TABLE [dbo].[UZeroConsole_Permissions] ADD  CONSTRAINT [DF_UZeroConsole_Permissions_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

/****** Object:  Table [dbo].[UZeroConsole_Roles]   ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UZeroConsole_Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Remark] [nvarchar](200) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_UZeroConsole_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

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





INSERT INTO [UZeroConsole_Admins] (Name,Username,Password,RoleId,Remark,LastLoginTime,IsDeleted,CreationTime,CreatorUserId)  values ('超级管理员','admin','21232f297a57a5a743894a0e4a801fc3',3,'',getdate(),0,getdate(),0)

INSERT INTO [UZeroConsole_Permissions](Name,Icon,Url,ParentId,[Level],[Order]) VALUES('控制台 Console','','',0,1,-100)
INSERT INTO [UZeroConsole_Permissions](Name,Icon,Url,ParentId,[Level],[Order]) VALUES('权限','','/UZero/PermissionList.aspx',1,2,1)
INSERT INTO [UZeroConsole_Permissions](Name,Icon,Url,ParentId,[Level],[Order]) VALUES('角色','','/UZero/RoleList.aspx',1,2,2)
INSERT INTO [UZeroConsole_Permissions](Name,Icon,Url,ParentId,[Level],[Order]) VALUES('管理员','','/UZero/AdminList.aspx',1,2,3)