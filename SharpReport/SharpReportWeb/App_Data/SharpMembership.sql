USE [SharpMembership]
GO
/****** Object:  User [SharpReportUser]    Script Date: 07/27/2014 22:55:03 ******/
CREATE USER [SharpReportUser] FOR LOGIN [SharpReportUser] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 07/27/2014 22:54:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Remark] [nvarchar](256) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'Remark'
GO
SET IDENTITY_INSERT [dbo].[Role] ON
INSERT [dbo].[Role] ([ID], [Name], [Remark]) VALUES (1, N'系统管理员', NULL)
INSERT [dbo].[Role] ([ID], [Name], [Remark]) VALUES (2, N'公司领导角色', NULL)
INSERT [dbo].[Role] ([ID], [Name], [Remark]) VALUES (3, N'航运部角色', NULL)
INSERT [dbo].[Role] ([ID], [Name], [Remark]) VALUES (4, N'船技部角色', NULL)
INSERT [dbo].[Role] ([ID], [Name], [Remark]) VALUES (5, N'安监部角色', NULL)
INSERT [dbo].[Role] ([ID], [Name], [Remark]) VALUES (6, N'人资部角色', NULL)
INSERT [dbo].[Role] ([ID], [Name], [Remark]) VALUES (7, N'财审部角色', NULL)
SET IDENTITY_INSERT [dbo].[Role] OFF
/****** Object:  Table [dbo].[Relation_User_Role]    Script Date: 07/27/2014 22:54:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Relation_User_Role](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[RoleID] [int] NOT NULL,
 CONSTRAINT [PK_Relation_User_Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Relation_User_Role] ON
INSERT [dbo].[Relation_User_Role] ([ID], [UserID], [RoleID]) VALUES (1, 1, 1)
INSERT [dbo].[Relation_User_Role] ([ID], [UserID], [RoleID]) VALUES (2, 2, 2)
INSERT [dbo].[Relation_User_Role] ([ID], [UserID], [RoleID]) VALUES (3, 3, 7)
INSERT [dbo].[Relation_User_Role] ([ID], [UserID], [RoleID]) VALUES (4, 4, 3)
INSERT [dbo].[Relation_User_Role] ([ID], [UserID], [RoleID]) VALUES (5, 5, 4)
INSERT [dbo].[Relation_User_Role] ([ID], [UserID], [RoleID]) VALUES (6, 6, 5)
INSERT [dbo].[Relation_User_Role] ([ID], [UserID], [RoleID]) VALUES (7, 7, 6)
SET IDENTITY_INSERT [dbo].[Relation_User_Role] OFF
/****** Object:  Table [dbo].[Menu]    Script Date: 07/27/2014 22:54:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Remark] [nvarchar](256) NULL,
	[MenuCode] [nvarchar](256) NULL,
	[URL] [nvarchar](256) NULL,
	[Target] [nvarchar](256) NULL,
	[ParentID] [int] NULL,
	[Visable] [bit] NULL,
	[OrderID] [int] NOT NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'栏目名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'栏目代码，00为根栏目，0000-00FF为其一级子栏目，依次类推。' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'MenuCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'栏目URL地址。' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'URL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'栏目脚本的目标框架' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Menu', @level2type=N'COLUMN',@level2name=N'Target'
GO
SET IDENTITY_INSERT [dbo].[Menu] ON
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (1, N'福建东方海运营收成本核算系统', N'福建东方海运营收成本核算系统', N'01', N'javascript:', NULL, NULL, 1, 1)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (2, N'部门报表管理', N'部门报表管理', N'0101', N'javascript:', NULL, 1, 1, 1)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (3, N'报表汇总统计', N'报表汇总统计', N'0102', N'javascript:', NULL, 1, 1, 1)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (4, N'航运部', N'航运部报表管理', N'010101', N'javascript:', NULL, 2, 1, 1)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (5, N'各部门报表报送情况汇总', N'各部门报表报送情况汇总', N'010206', N'javascript:', NULL, 3, 0, 1)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (6, N'船技部', N'船技部报表管理', N'010102', N'javascript:', NULL, 2, 1, 1)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (7, N'安监部', N'安监部安全费用界定和费用报表管理', N'010103', N'javascript:', NULL, 2, 1, 1)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (8, N'人资部', N'人资部报表管理', N'010104', N'javascript:', NULL, 2, 1, 1)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (9, N'财务部', N'财务部报表确认', N'010105', N'javascript:', NULL, 2, 1, 1)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (10, N'航运部报表汇总', N'航运部报表汇总统计', N'010201', N'javascript:', NULL, 3, 1, 1)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (11, N'船技部报表汇总', N'船技部报表汇总统计', N'010202', N'javascript:', NULL, 3, 1, 1)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (12, N'安监部报表汇总', N'安监部报表汇总统计', N'010203', N'javascript:', NULL, 3, 1, 1)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (13, N'人资部报表汇总', N'人资部报表汇总统计', N'010204', N'javascript:', NULL, 3, 1, 1)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (14, N'报表图形表达', N'报表图形表达', N'010205', N'javascript:', NULL, 3, 1, 1)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (15, N'系统管理', N'系统管理', N'0103', N'javascript:', NULL, 1, 1, 1)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (16, N'通知公告', N'通知公告', N'010301', N'javascript:', NULL, 15, 1, 1)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (17, N'数据字典管理', N'数据字典管理', N'010302', N'javascript:', NULL, 15, 1, 2)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (18, N'用户和权限', N'用户和权限', N'010303', N'javascript:', NULL, 15, 1, 3)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (19, N'燃、润料报表 ', N'燃、润料报表 ', N'01010201', N'../ChuanJ/RanrunList.aspx', NULL, 6, 1, 2)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (20, N'物料报表', N'物料报表', N'01010202', N'../ChuanJ/WuliaoSummary.aspx', NULL, 6, 1, 3)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (21, N'备件报表', N'备件报表', N'01010203', N'../ChuanJ/BeijianSummary.aspx', NULL, 6, 1, 4)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (22, N'检验报表', N'检验报表', N'01010204', N'../ChuanJ/JianyanSummary.aspx', NULL, 6, 1, 5)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (23, N'修理报表', N'修理报表', N'01010205', N'../ChuanJ/XiuliSummary.aspx', NULL, 6, 1, 6)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (25, N'航次船期维护', N'航次维护', N'01010101', N'../Hangy/Hangci.aspx', NULL, 2, 1, 2)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (26, N'燃料消耗统计报表', N'船舶燃料消耗统计报表', N'01020101', N'../ChuanJ/MonthReport.aspx', NULL, 11, 1, 1)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (27, N'物料季度消耗表', N'船舶物料季度消耗表', N'01020102', N'../ChuanJ/WuliaoStatistic.aspx', NULL, 11, 1, 1)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (28, N'备件季度消耗表', N'船舶备件季度消耗表', N'01020103', N'../ChuanJ/BeijianStatistic.aspx', NULL, 11, 1, 1)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (29, N'检验季度消耗表', N'船舶检验季度消耗表', N'01020104', N'../ChuanJ/JianyanStatistic.aspx', NULL, 11, 1, 1)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (30, N'修理季度消耗表', N'船舶修理季度消耗表', N'01020105', N'../ChuanJ/XiuliStatistic.aspx', NULL, 11, 1, 1)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (31, N'货运险', N'内贸线货运险投保货量及保费汇', N'01010102', N'../Hangy/InsuranceOfFreightTransport.aspx', NULL, 4, 1, 3)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (32, N'船舶保赔险', N'船舶险 保赔险', N'01010103', N'../Hangy/InsuranceOfCompensationList.aspx', NULL, 4, 1, 4)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (33, N'集装箱箱体保险', N'集装箱箱体保险', N'01010104', N'../Hangy/InsuranceOfContainerList.aspx', NULL, 4, 1, 5)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (34, N'证书记录汇总', N'证书记录汇总', N'01010105', N'../Hangy/CertificateList.aspx', NULL, 4, 1, 6)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (35, N'费用情况汇总', N'费用情况汇总', N'01010301', N'../Anjian/CommonFeeList.aspx', NULL, 7, 1, 1)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (36, N'费用情况汇总', N'费用情况汇总', N'01010401', N'../HR/CommonFeeList.aspx', NULL, 8, 1, 1)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (37, N'船舶维护', N'船舶维护', N'01010106', N'../Hangy/ShipForm.aspx', NULL, 2, 1, 1)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (38, N'散货船舶运费报表汇总', N'散货船舶运费计费报表汇总', N'01020101', N'../Hangy/LCLManageList.aspx', NULL, 10, 1, 1)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (39, N'安监部费用年度汇总', N'安监部费用年度汇总', N'01020301', N'../Anjian/CommonFeeStatistic.aspx', NULL, 12, 1, 1)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (40, N'人资部费用年度汇总', N'人资部费用年度汇总', N'01020401', N'../HR/CommonFeeStatistic.aspx', NULL, 13, 1, 1)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (41, N'财务部发票查询', N'财务部发票查询', N'01010501', N'../Caiwu/InvoiceSearch.aspx', NULL, 9, 1, 1)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (42, N'船舶出租租金计费表', N'船舶出租租金计费表', N'01010107', N'../Hangy/RentShipReportList.aspx', NULL, 4, 1, 7)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (43, N'货柜出租计费表', N'货柜出租计费表					', N'01010108', N'../Hangy/RentContainerReportList.aspx', NULL, 4, 1, 8)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (44, N'集装箱船舶运费报表汇总', N'集装箱船舶运费计费报表汇总', N'01020102', N'../Hangy/FCLManageList.aspx', NULL, 10, 1, 2)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (45, N'船舶其他费用报表汇总', N'船舶其他费用报表汇总', N'01020103', N'../Hangy/VoyageOtherList.aspx', NULL, 10, 1, 3)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (46, N'船舶月份收入统计表', N'船舶月份收入统计表', N'01020104', N'../Hangy/ShipIncomeMonthReport.aspx', NULL, 10, 1, 4)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (47, N'收入支出总表', N'收入支出总表', N'010206', N'javascript:', NULL, 3, 1, 1)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (48, N'集装箱运费报表录入', N'集装箱运费报表录入', N'01010106', N'../Hangy/FCLManageList.aspx', NULL, 4, 1, 7)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (49, N'散货运费报表录入', N'散货运费报表录入', N'01010107', N'../Hangy/LCLManageList.aspx', NULL, 4, 1, 8)
INSERT [dbo].[Menu] ([ID], [Name], [Remark], [MenuCode], [URL], [Target], [ParentID], [Visable], [OrderID]) VALUES (50, N'其他费用报表录入', N'其他费用报表录入', N'01010108', N'../Hangy/VoyageOtherList.aspx', NULL, 4, 1, 9)
SET IDENTITY_INSERT [dbo].[Menu] OFF
/****** Object:  Table [dbo].[PermissionGroup]    Script Date: 07/27/2014 22:54:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PermissionGroup](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Remark] [nvarchar](256) NULL,
 CONSTRAINT [PK_PermissionGroup] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PermissionGroup', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限组名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PermissionGroup', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PermissionGroup', @level2type=N'COLUMN',@level2name=N'Remark'
GO
SET IDENTITY_INSERT [dbo].[PermissionGroup] ON
INSERT [dbo].[PermissionGroup] ([ID], [Name], [Remark]) VALUES (1, N'标准权限组', N'标准权限组')
SET IDENTITY_INSERT [dbo].[PermissionGroup] OFF
/****** Object:  Table [dbo].[Department]    Script Date: 07/27/2014 22:54:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](256) NULL,
	[ShortName] [nvarchar](50) NULL,
	[Remark] [nvarchar](1000) NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Department', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'全名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Department', @level2type=N'COLUMN',@level2name=N'FullName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'简称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Department', @level2type=N'COLUMN',@level2name=N'ShortName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Department', @level2type=N'COLUMN',@level2name=N'Remark'
GO
SET IDENTITY_INSERT [dbo].[Department] ON
INSERT [dbo].[Department] ([ID], [FullName], [ShortName], [Remark]) VALUES (1, N'公司领导', N'公司领导', NULL)
INSERT [dbo].[Department] ([ID], [FullName], [ShortName], [Remark]) VALUES (2, N'航运部', N'航运部', NULL)
INSERT [dbo].[Department] ([ID], [FullName], [ShortName], [Remark]) VALUES (3, N'船技部', N'船技部', NULL)
INSERT [dbo].[Department] ([ID], [FullName], [ShortName], [Remark]) VALUES (4, N'安监部', N'安监部', NULL)
INSERT [dbo].[Department] ([ID], [FullName], [ShortName], [Remark]) VALUES (5, N'人资部', N'人资部', NULL)
INSERT [dbo].[Department] ([ID], [FullName], [ShortName], [Remark]) VALUES (6, N'财审部', N'财审部', NULL)
SET IDENTITY_INSERT [dbo].[Department] OFF
/****** Object:  Table [dbo].[User]    Script Date: 07/27/2014 22:54:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[LastLoginDate] [datetime] NOT NULL,
	[DepartmentID] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'Password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上次登陆时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'LastLoginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'DepartmentID'
GO
SET IDENTITY_INSERT [dbo].[User] ON
INSERT [dbo].[User] ([ID], [Name], [Password], [LastLoginDate], [DepartmentID], [CreateDate]) VALUES (1, N'admin', N'1', CAST(0x0000A163010256CD AS DateTime), 1, CAST(0x0000A19F009B0E35 AS DateTime))
INSERT [dbo].[User] ([ID], [Name], [Password], [LastLoginDate], [DepartmentID], [CreateDate]) VALUES (2, N'公司领导1', N'1', CAST(0x0000A19F00F11E2C AS DateTime), 1, CAST(0x0000A19F00F128EB AS DateTime))
INSERT [dbo].[User] ([ID], [Name], [Password], [LastLoginDate], [DepartmentID], [CreateDate]) VALUES (3, N'caiwu1', N'1', CAST(0x0000A284000188E3 AS DateTime), 6, CAST(0x0000A284000188E3 AS DateTime))
INSERT [dbo].[User] ([ID], [Name], [Password], [LastLoginDate], [DepartmentID], [CreateDate]) VALUES (4, N'hangyun1', N'1', CAST(0x0000A2840001C5D6 AS DateTime), 2, CAST(0x0000A2840001C5D6 AS DateTime))
INSERT [dbo].[User] ([ID], [Name], [Password], [LastLoginDate], [DepartmentID], [CreateDate]) VALUES (5, N'chuanji1', N'1', CAST(0x0000A2840001FC0D AS DateTime), 3, CAST(0x0000A2840001FC0D AS DateTime))
INSERT [dbo].[User] ([ID], [Name], [Password], [LastLoginDate], [DepartmentID], [CreateDate]) VALUES (6, N'anjian1', N'1', CAST(0x0000A28400021CF5 AS DateTime), 4, CAST(0x0000A28400021CF5 AS DateTime))
INSERT [dbo].[User] ([ID], [Name], [Password], [LastLoginDate], [DepartmentID], [CreateDate]) VALUES (7, N'renzi1', N'1', CAST(0x0000A28400022E4A AS DateTime), 5, CAST(0x0000A28400022E4A AS DateTime))
SET IDENTITY_INSERT [dbo].[User] OFF
/****** Object:  Table [dbo].[Relation_MenuPGroup]    Script Date: 07/27/2014 22:54:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Relation_MenuPGroup](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MenuID] [int] NOT NULL,
	[PermissionGroupID] [int] NOT NULL,
 CONSTRAINT [PK_Relation_MenuPGroup] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Relation_MenuPGroup] ON
INSERT [dbo].[Relation_MenuPGroup] ([ID], [MenuID], [PermissionGroupID]) VALUES (2, 1, 1)
INSERT [dbo].[Relation_MenuPGroup] ([ID], [MenuID], [PermissionGroupID]) VALUES (3, 2, 1)
INSERT [dbo].[Relation_MenuPGroup] ([ID], [MenuID], [PermissionGroupID]) VALUES (4, 4, 1)
INSERT [dbo].[Relation_MenuPGroup] ([ID], [MenuID], [PermissionGroupID]) VALUES (5, 25, 1)
INSERT [dbo].[Relation_MenuPGroup] ([ID], [MenuID], [PermissionGroupID]) VALUES (6, 31, 1)
INSERT [dbo].[Relation_MenuPGroup] ([ID], [MenuID], [PermissionGroupID]) VALUES (7, 32, 1)
INSERT [dbo].[Relation_MenuPGroup] ([ID], [MenuID], [PermissionGroupID]) VALUES (8, 33, 1)
INSERT [dbo].[Relation_MenuPGroup] ([ID], [MenuID], [PermissionGroupID]) VALUES (9, 34, 1)
INSERT [dbo].[Relation_MenuPGroup] ([ID], [MenuID], [PermissionGroupID]) VALUES (10, 37, 1)
INSERT [dbo].[Relation_MenuPGroup] ([ID], [MenuID], [PermissionGroupID]) VALUES (11, 6, 1)
INSERT [dbo].[Relation_MenuPGroup] ([ID], [MenuID], [PermissionGroupID]) VALUES (12, 19, 1)
INSERT [dbo].[Relation_MenuPGroup] ([ID], [MenuID], [PermissionGroupID]) VALUES (13, 20, 1)
INSERT [dbo].[Relation_MenuPGroup] ([ID], [MenuID], [PermissionGroupID]) VALUES (14, 21, 1)
INSERT [dbo].[Relation_MenuPGroup] ([ID], [MenuID], [PermissionGroupID]) VALUES (15, 22, 1)
INSERT [dbo].[Relation_MenuPGroup] ([ID], [MenuID], [PermissionGroupID]) VALUES (16, 23, 1)
INSERT [dbo].[Relation_MenuPGroup] ([ID], [MenuID], [PermissionGroupID]) VALUES (17, 7, 1)
INSERT [dbo].[Relation_MenuPGroup] ([ID], [MenuID], [PermissionGroupID]) VALUES (18, 35, 1)
INSERT [dbo].[Relation_MenuPGroup] ([ID], [MenuID], [PermissionGroupID]) VALUES (19, 8, 1)
INSERT [dbo].[Relation_MenuPGroup] ([ID], [MenuID], [PermissionGroupID]) VALUES (20, 36, 1)
INSERT [dbo].[Relation_MenuPGroup] ([ID], [MenuID], [PermissionGroupID]) VALUES (21, 9, 1)
INSERT [dbo].[Relation_MenuPGroup] ([ID], [MenuID], [PermissionGroupID]) VALUES (22, 3, 1)
INSERT [dbo].[Relation_MenuPGroup] ([ID], [MenuID], [PermissionGroupID]) VALUES (23, 10, 1)
INSERT [dbo].[Relation_MenuPGroup] ([ID], [MenuID], [PermissionGroupID]) VALUES (24, 26, 1)
INSERT [dbo].[Relation_MenuPGroup] ([ID], [MenuID], [PermissionGroupID]) VALUES (25, 38, 1)
INSERT [dbo].[Relation_MenuPGroup] ([ID], [MenuID], [PermissionGroupID]) VALUES (26, 27, 1)
INSERT [dbo].[Relation_MenuPGroup] ([ID], [MenuID], [PermissionGroupID]) VALUES (27, 28, 1)
INSERT [dbo].[Relation_MenuPGroup] ([ID], [MenuID], [PermissionGroupID]) VALUES (28, 29, 1)
INSERT [dbo].[Relation_MenuPGroup] ([ID], [MenuID], [PermissionGroupID]) VALUES (29, 30, 1)
INSERT [dbo].[Relation_MenuPGroup] ([ID], [MenuID], [PermissionGroupID]) VALUES (30, 11, 1)
INSERT [dbo].[Relation_MenuPGroup] ([ID], [MenuID], [PermissionGroupID]) VALUES (31, 14, 1)
INSERT [dbo].[Relation_MenuPGroup] ([ID], [MenuID], [PermissionGroupID]) VALUES (32, 12, 1)
INSERT [dbo].[Relation_MenuPGroup] ([ID], [MenuID], [PermissionGroupID]) VALUES (33, 13, 1)
INSERT [dbo].[Relation_MenuPGroup] ([ID], [MenuID], [PermissionGroupID]) VALUES (34, 15, 1)
INSERT [dbo].[Relation_MenuPGroup] ([ID], [MenuID], [PermissionGroupID]) VALUES (35, 16, 1)
INSERT [dbo].[Relation_MenuPGroup] ([ID], [MenuID], [PermissionGroupID]) VALUES (36, 17, 1)
INSERT [dbo].[Relation_MenuPGroup] ([ID], [MenuID], [PermissionGroupID]) VALUES (37, 18, 1)
INSERT [dbo].[Relation_MenuPGroup] ([ID], [MenuID], [PermissionGroupID]) VALUES (38, 5, 1)
SET IDENTITY_INSERT [dbo].[Relation_MenuPGroup] OFF
/****** Object:  Table [dbo].[Permission]    Script Date: 07/27/2014 22:54:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permission](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Remark] [nvarchar](256) NULL,
	[Flags] [nvarchar](50) NOT NULL,
	[GroupID] [int] NOT NULL,
 CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permission', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permission', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permission', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属的权限组' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Permission', @level2type=N'COLUMN',@level2name=N'GroupID'
GO
INSERT [dbo].[Permission] ([ID], [Name], [Remark], [Flags], [GroupID]) VALUES (1, N'浏览', N'浏览', N'1', 1)
INSERT [dbo].[Permission] ([ID], [Name], [Remark], [Flags], [GroupID]) VALUES (2, N'修改', N'修改', N'10', 1)
INSERT [dbo].[Permission] ([ID], [Name], [Remark], [Flags], [GroupID]) VALUES (3, N'审批', N'审批', N'100', 1)
INSERT [dbo].[Permission] ([ID], [Name], [Remark], [Flags], [GroupID]) VALUES (4, N'管理', N'管理', N'1000', 1)
/****** Object:  UserDefinedFunction [dbo].[fGetMenuTree]    Script Date: 07/27/2014 22:55:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** 对象:  用户定义的函数 dbo.fGetTreeTable    脚本日期: 2005-11-04 18:07:02 ******/
CREATE FUNCTION [dbo].[fGetMenuTree]
 (
 @ID int = null
 )
RETURNS @Tab TABLE(ID int, ParentID int, Name nvarchar(50), Remark nvarchar(256), MenuCode nvarchar(256), URL nvarchar(256), [Target] nvarchar(256), Lev int)
AS
 BEGIN
  Declare @lev int
  Set @lev=0
  
  While @lev=0 or @@ROWCount>0
  Begin
  Set @Lev=@Lev+1
   Insert @Tab(ID, ParentID, Name, Remark, MenuCode, URL, [Target], Lev)
   Select ID, ParentID, Name, Remark, MenuCode, URL, [Target], @Lev From Menu Where ((@Lev=1 and ((ParentID=@ID) or (@ID is null and ParentID is null))) or (ParentID in (Select ID From @Tab Where Lev=@Lev-1))) and  Visable = 1
   order by OrderID,ID
  End
  RETURN
 END
GO
/****** Object:  Table [dbo].[Relation_MenuPGroup_Role]    Script Date: 07/27/2014 22:54:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Relation_MenuPGroup_Role](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MenuPGRelationID] [int] NOT NULL,
	[PermissionGroupCode] [nvarchar](50) NOT NULL,
	[RoleID] [int] NOT NULL,
 CONSTRAINT [PK_Relation_MenuPGroup_Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Relation_MenuPGroup_Role] ON
INSERT [dbo].[Relation_MenuPGroup_Role] ([ID], [MenuPGRelationID], [PermissionGroupCode], [RoleID]) VALUES (1, 2, N'1111', 1)
INSERT [dbo].[Relation_MenuPGroup_Role] ([ID], [MenuPGRelationID], [PermissionGroupCode], [RoleID]) VALUES (3, 22, N'1111', 2)
INSERT [dbo].[Relation_MenuPGroup_Role] ([ID], [MenuPGRelationID], [PermissionGroupCode], [RoleID]) VALUES (6, 3, N'1111', 7)
INSERT [dbo].[Relation_MenuPGroup_Role] ([ID], [MenuPGRelationID], [PermissionGroupCode], [RoleID]) VALUES (7, 22, N'1111', 7)
INSERT [dbo].[Relation_MenuPGroup_Role] ([ID], [MenuPGRelationID], [PermissionGroupCode], [RoleID]) VALUES (8, 22, N'1111', 3)
INSERT [dbo].[Relation_MenuPGroup_Role] ([ID], [MenuPGRelationID], [PermissionGroupCode], [RoleID]) VALUES (9, 4, N'1111', 3)
INSERT [dbo].[Relation_MenuPGroup_Role] ([ID], [MenuPGRelationID], [PermissionGroupCode], [RoleID]) VALUES (10, 22, N'1111', 4)
INSERT [dbo].[Relation_MenuPGroup_Role] ([ID], [MenuPGRelationID], [PermissionGroupCode], [RoleID]) VALUES (11, 11, N'1111', 4)
INSERT [dbo].[Relation_MenuPGroup_Role] ([ID], [MenuPGRelationID], [PermissionGroupCode], [RoleID]) VALUES (12, 22, N'1111', 5)
INSERT [dbo].[Relation_MenuPGroup_Role] ([ID], [MenuPGRelationID], [PermissionGroupCode], [RoleID]) VALUES (13, 17, N'1111', 5)
INSERT [dbo].[Relation_MenuPGroup_Role] ([ID], [MenuPGRelationID], [PermissionGroupCode], [RoleID]) VALUES (14, 22, N'1111', 6)
INSERT [dbo].[Relation_MenuPGroup_Role] ([ID], [MenuPGRelationID], [PermissionGroupCode], [RoleID]) VALUES (15, 19, N'1111', 6)
SET IDENTITY_INSERT [dbo].[Relation_MenuPGroup_Role] OFF
/****** Object:  Table [dbo].[UserLoginGUID]    Script Date: 07/27/2014 22:54:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLoginGUID](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[GUID] [uniqueidentifier] NOT NULL,
	[ExpireDate] [datetime] NOT NULL,
 CONSTRAINT [PK_UserLoginGUID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[UserLoginGUID] ON
INSERT [dbo].[UserLoginGUID] ([ID], [UserID], [GUID], [ExpireDate]) VALUES (211, 4, N'dc721472-f0eb-4260-8f62-19a78469e5e0', CAST(0x0000A28400CE8A1A AS DateTime))
INSERT [dbo].[UserLoginGUID] ([ID], [UserID], [GUID], [ExpireDate]) VALUES (213, 5, N'b8b2bc18-570c-4bed-8612-803a02b92fba', CAST(0x0000A284018970AE AS DateTime))
INSERT [dbo].[UserLoginGUID] ([ID], [UserID], [GUID], [ExpireDate]) VALUES (341, 2, N'304a939f-aaa0-4602-98f8-08eb41b00ef3', CAST(0x0000A36400FF372B AS DateTime))
INSERT [dbo].[UserLoginGUID] ([ID], [UserID], [GUID], [ExpireDate]) VALUES (369, 1, N'9cbf5518-c250-40e1-85b5-51094e79ea20', CAST(0x0000A37501580B6E AS DateTime))
SET IDENTITY_INSERT [dbo].[UserLoginGUID] OFF
/****** Object:  View [dbo].[V_Role]    Script Date: 07/27/2014 22:55:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_Role]
AS
SELECT     dbo.Role.ID, dbo.Role.Name, dbo.Role.Remark, dbo.Relation_User_Role.UserID
FROM         dbo.Relation_User_Role INNER JOIN
                      dbo.[User] ON dbo.Relation_User_Role.UserID = dbo.[User].ID INNER JOIN
                      dbo.Role ON dbo.Relation_User_Role.RoleID = dbo.Role.ID
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Relation_User_Role"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 110
               Right = 180
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Role"
            Begin Extent = 
               Top = 110
               Left = 225
               Bottom = 219
               Right = 375
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "User"
            Begin Extent = 
               Top = 6
               Left = 398
               Bottom = 125
               Right = 555
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1770
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Role'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Role'
GO
/****** Object:  View [dbo].[V_PermissionGroup]    Script Date: 07/27/2014 22:55:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_PermissionGroup]
AS
SELECT     dbo.Menu.ID AS MenuID, dbo.Menu.Name AS MenuName, dbo.Menu.Remark AS MenuRemark, dbo.Menu.MenuCode, dbo.Menu.URL, dbo.Menu.Target, 
                      dbo.Menu.ParentID, dbo.PermissionGroup.ID, dbo.PermissionGroup.Name, dbo.PermissionGroup.Remark, 
                      dbo.Relation_MenuPGroup.PermissionGroupID AS RelationID
FROM         dbo.Menu INNER JOIN
                      dbo.Relation_MenuPGroup ON dbo.Menu.ID = dbo.Relation_MenuPGroup.MenuID INNER JOIN
                      dbo.PermissionGroup ON dbo.Relation_MenuPGroup.PermissionGroupID = dbo.PermissionGroup.ID
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Menu"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 180
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Relation_MenuPGroup"
            Begin Extent = 
               Top = 6
               Left = 218
               Bottom = 133
               Right = 441
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PermissionGroup"
            Begin Extent = 
               Top = 6
               Left = 479
               Bottom = 139
               Right = 666
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 12
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 1755
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_PermissionGroup'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_PermissionGroup'
GO
/****** Object:  View [dbo].[V_User]    Script Date: 07/27/2014 22:55:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_User]
AS
SELECT     dbo.[User].ID, dbo.[User].Name, dbo.[User].Password, dbo.[User].LastLoginDate, dbo.[User].DepartmentID, dbo.UserLoginGUID.GUID, dbo.UserLoginGUID.ExpireDate, 
                      dbo.Department.FullName AS DepartmentName, dbo.[User].CreateDate
FROM         dbo.[User] INNER JOIN
                      dbo.Department ON dbo.[User].DepartmentID = dbo.Department.ID LEFT OUTER JOIN
                      dbo.UserLoginGUID ON dbo.[User].ID = dbo.UserLoginGUID.UserID
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "User"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 195
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "UserLoginGUID"
            Begin Extent = 
               Top = 7
               Left = 330
               Bottom = 126
               Right = 471
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Department"
            Begin Extent = 
               Top = 168
               Left = 246
               Bottom = 287
               Right = 388
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 10
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_User'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_User'
GO
/****** Object:  View [dbo].[V_MenuRole]    Script Date: 07/27/2014 22:55:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_MenuRole]
AS
SELECT     dbo.Menu.ID, dbo.Menu.Name, dbo.Menu.Remark, dbo.Menu.MenuCode, dbo.Menu.URL, dbo.Menu.Target, dbo.Menu.ParentID, dbo.Relation_User_Role.RoleID, 
                      dbo.Relation_User_Role.UserID, dbo.Relation_MenuPGroup.PermissionGroupID, dbo.UserLoginGUID.GUID, 
                      dbo.Relation_MenuPGroup_Role.PermissionGroupCode
FROM         dbo.Menu INNER JOIN
                      dbo.Relation_MenuPGroup ON dbo.Menu.ID = dbo.Relation_MenuPGroup.MenuID INNER JOIN
                      dbo.Relation_MenuPGroup_Role ON dbo.Relation_MenuPGroup.ID = dbo.Relation_MenuPGroup_Role.MenuPGRelationID INNER JOIN
                      dbo.Role ON dbo.Relation_MenuPGroup_Role.RoleID = dbo.Role.ID INNER JOIN
                      dbo.Relation_User_Role ON dbo.Role.ID = dbo.Relation_User_Role.RoleID INNER JOIN
                      dbo.[User] ON dbo.Relation_User_Role.UserID = dbo.[User].ID INNER JOIN
                      dbo.PermissionGroup ON dbo.Relation_MenuPGroup.PermissionGroupID = dbo.PermissionGroup.ID LEFT OUTER JOIN
                      dbo.UserLoginGUID ON dbo.[User].ID = dbo.UserLoginGUID.UserID
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Menu"
            Begin Extent = 
               Top = 0
               Left = 571
               Bottom = 119
               Right = 713
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Relation_MenuPGroup"
            Begin Extent = 
               Top = 1
               Left = 269
               Bottom = 117
               Right = 493
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Relation_MenuPGroup_Role"
            Begin Extent = 
               Top = 24
               Left = 18
               Bottom = 143
               Right = 211
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Role"
            Begin Extent = 
               Top = 149
               Left = 263
               Bottom = 253
               Right = 405
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Relation_User_Role"
            Begin Extent = 
               Top = 249
               Left = 495
               Bottom = 375
               Right = 699
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "User"
            Begin Extent = 
               Top = 267
               Left = 251
               Bottom = 386
               Right = 408
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PermissionGroup"
            Begin Extent = 
               Top = 122
               Left = 571
               Bottom = 242
               Right = 743
        ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_MenuRole'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'    End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "UserLoginGUID"
            Begin Extent = 
               Top = 262
               Left = 13
               Bottom = 381
               Right = 155
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_MenuRole'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_MenuRole'
GO
/****** Object:  View [dbo].[V_MenuPGroupRole]    Script Date: 07/27/2014 22:55:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_MenuPGroupRole]
AS
SELECT     dbo.Menu.ID, dbo.Menu.Name, dbo.Menu.Remark, dbo.Menu.MenuCode, dbo.Menu.URL, dbo.Menu.Target, dbo.Menu.ParentID, dbo.Relation_MenuPGroup.PermissionGroupID, 
                      dbo.Relation_MenuPGroup_Role.PermissionGroupCode, dbo.Role.Name AS RoleName, dbo.Relation_MenuPGroup_Role.RoleID, dbo.Role.Remark AS RoleRemark
FROM         dbo.Menu INNER JOIN
                      dbo.Relation_MenuPGroup ON dbo.Menu.ID = dbo.Relation_MenuPGroup.MenuID INNER JOIN
                      dbo.Relation_MenuPGroup_Role ON dbo.Relation_MenuPGroup.ID = dbo.Relation_MenuPGroup_Role.MenuPGRelationID INNER JOIN
                      dbo.Role ON dbo.Relation_MenuPGroup_Role.RoleID = dbo.Role.ID INNER JOIN
                      dbo.PermissionGroup ON dbo.Relation_MenuPGroup.PermissionGroupID = dbo.PermissionGroup.ID
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[30] 4[19] 2[15] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Menu"
            Begin Extent = 
               Top = 14
               Left = 590
               Bottom = 134
               Right = 732
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Relation_MenuPGroup"
            Begin Extent = 
               Top = 22
               Left = 340
               Bottom = 127
               Right = 519
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Relation_MenuPGroup_Role"
            Begin Extent = 
               Top = 17
               Left = 44
               Bottom = 159
               Right = 290
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Role"
            Begin Extent = 
               Top = 129
               Left = 334
               Bottom = 257
               Right = 481
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PermissionGroup"
            Begin Extent = 
               Top = 148
               Left = 585
               Bottom = 253
               Right = 727
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 12
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_MenuPGroupRole'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N' CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_MenuPGroupRole'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_MenuPGroupRole'
GO
/****** Object:  Default [DF_Menu_ParentID]    Script Date: 07/27/2014 22:54:58 ******/
ALTER TABLE [dbo].[Menu] ADD  CONSTRAINT [DF_Menu_ParentID]  DEFAULT ((1)) FOR [ParentID]
GO
/****** Object:  Default [DF_Menu_Visable]    Script Date: 07/27/2014 22:54:58 ******/
ALTER TABLE [dbo].[Menu] ADD  CONSTRAINT [DF_Menu_Visable]  DEFAULT ((1)) FOR [Visable]
GO
/****** Object:  Default [DF_Menu_OrderID]    Script Date: 07/27/2014 22:54:58 ******/
ALTER TABLE [dbo].[Menu] ADD  CONSTRAINT [DF_Menu_OrderID]  DEFAULT ((1)) FOR [OrderID]
GO
/****** Object:  Default [DF_Permission_Flags]    Script Date: 07/27/2014 22:54:58 ******/
ALTER TABLE [dbo].[Permission] ADD  CONSTRAINT [DF_Permission_Flags]  DEFAULT ((0)) FOR [Flags]
GO
/****** Object:  Default [DF_Permission_GroupID]    Script Date: 07/27/2014 22:54:58 ******/
ALTER TABLE [dbo].[Permission] ADD  CONSTRAINT [DF_Permission_GroupID]  DEFAULT ((1)) FOR [GroupID]
GO
/****** Object:  Default [DF_User_LastLoginDate]    Script Date: 07/27/2014 22:54:58 ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_LastLoginDate]  DEFAULT (getdate()) FOR [LastLoginDate]
GO
/****** Object:  Default [DF_User_CreateDate]    Script Date: 07/27/2014 22:54:58 ******/
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
/****** Object:  Default [DF_UserLoginGUID_GUID]    Script Date: 07/27/2014 22:54:58 ******/
ALTER TABLE [dbo].[UserLoginGUID] ADD  CONSTRAINT [DF_UserLoginGUID_GUID]  DEFAULT (newid()) FOR [GUID]
GO
/****** Object:  Default [DF_UserLoginGUID_ExpireTime]    Script Date: 07/27/2014 22:54:58 ******/
ALTER TABLE [dbo].[UserLoginGUID] ADD  CONSTRAINT [DF_UserLoginGUID_ExpireTime]  DEFAULT (dateadd(hour,(3),getdate())) FOR [ExpireDate]
GO
/****** Object:  ForeignKey [FK_Menu_Menu]    Script Date: 07/27/2014 22:54:58 ******/
ALTER TABLE [dbo].[Menu]  WITH CHECK ADD  CONSTRAINT [FK_Menu_Menu] FOREIGN KEY([ParentID])
REFERENCES [dbo].[Menu] ([ID])
GO
ALTER TABLE [dbo].[Menu] CHECK CONSTRAINT [FK_Menu_Menu]
GO
/****** Object:  ForeignKey [FK_Permission_PermissionGroup]    Script Date: 07/27/2014 22:54:58 ******/
ALTER TABLE [dbo].[Permission]  WITH CHECK ADD  CONSTRAINT [FK_Permission_PermissionGroup] FOREIGN KEY([GroupID])
REFERENCES [dbo].[PermissionGroup] ([ID])
GO
ALTER TABLE [dbo].[Permission] CHECK CONSTRAINT [FK_Permission_PermissionGroup]
GO
/****** Object:  ForeignKey [FK_Relation_MenuPGroup_Menu]    Script Date: 07/27/2014 22:54:58 ******/
ALTER TABLE [dbo].[Relation_MenuPGroup]  WITH CHECK ADD  CONSTRAINT [FK_Relation_MenuPGroup_Menu] FOREIGN KEY([MenuID])
REFERENCES [dbo].[Menu] ([ID])
GO
ALTER TABLE [dbo].[Relation_MenuPGroup] CHECK CONSTRAINT [FK_Relation_MenuPGroup_Menu]
GO
/****** Object:  ForeignKey [FK_Relation_MenuPGroup_Permission]    Script Date: 07/27/2014 22:54:58 ******/
ALTER TABLE [dbo].[Relation_MenuPGroup]  WITH CHECK ADD  CONSTRAINT [FK_Relation_MenuPGroup_Permission] FOREIGN KEY([PermissionGroupID])
REFERENCES [dbo].[PermissionGroup] ([ID])
GO
ALTER TABLE [dbo].[Relation_MenuPGroup] CHECK CONSTRAINT [FK_Relation_MenuPGroup_Permission]
GO
/****** Object:  ForeignKey [FK_Relation_MenuPGroup_Role_Relation_MenuPGroup]    Script Date: 07/27/2014 22:54:58 ******/
ALTER TABLE [dbo].[Relation_MenuPGroup_Role]  WITH CHECK ADD  CONSTRAINT [FK_Relation_MenuPGroup_Role_Relation_MenuPGroup] FOREIGN KEY([MenuPGRelationID])
REFERENCES [dbo].[Relation_MenuPGroup] ([ID])
GO
ALTER TABLE [dbo].[Relation_MenuPGroup_Role] CHECK CONSTRAINT [FK_Relation_MenuPGroup_Role_Relation_MenuPGroup]
GO
/****** Object:  ForeignKey [FK_Relation_MenuPGroup_Role_Role]    Script Date: 07/27/2014 22:54:58 ******/
ALTER TABLE [dbo].[Relation_MenuPGroup_Role]  WITH CHECK ADD  CONSTRAINT [FK_Relation_MenuPGroup_Role_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([ID])
GO
ALTER TABLE [dbo].[Relation_MenuPGroup_Role] CHECK CONSTRAINT [FK_Relation_MenuPGroup_Role_Role]
GO
/****** Object:  ForeignKey [FK_User_Department]    Script Date: 07/27/2014 22:54:58 ******/
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Department] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Department] ([ID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Department]
GO
/****** Object:  ForeignKey [FK_UserLoginGUID_User]    Script Date: 07/27/2014 22:54:58 ******/
ALTER TABLE [dbo].[UserLoginGUID]  WITH CHECK ADD  CONSTRAINT [FK_UserLoginGUID_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[UserLoginGUID] CHECK CONSTRAINT [FK_UserLoginGUID_User]
GO
