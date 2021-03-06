USE [SharpReport]
GO
/****** Object:  User [SharpReportUser]    Script Date: 07/27/2014 23:40:58 ******/
CREATE USER [SharpReportUser] FOR LOGIN [SharpReportUser] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[VoyageLoad20140713]    Script Date: 07/27/2014 23:41:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VoyageLoad20140713](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LCLCatalog] [nvarchar](500) NULL,
	[LCLAmount] [float] NULL,
	[LCLPrice] [float] NULL,
	[CurrencyID] [int] NULL,
	[DelayDay] [int] NULL,
	[DelayRate] [float] NULL,
	[QuickDay] [int] NULL,
	[QuickRate] [float] NULL,
	[TEUEmpty] [int] NULL,
	[TEUHeavy] [int] NULL,
	[TEUFrost] [int] NULL,
	[FEUEmpty] [int] NULL,
	[FEUHeavy] [int] NULL,
	[FEUFrost] [int] NULL,
	[FEUDanger] [int] NULL,
	[FFEUEmpty] [int] NULL,
	[FFEUHeavy] [int] NULL,
	[FFEUFrost] [int] NULL,
	[FFEUDanger] [int] NULL,
	[Rest] [int] NULL,
	[EqualTo] [int] NULL,
	[TotalNat] [int] NULL,
	[TotalStand] [int] NULL,
	[CurrencyOtherID] [int] NOT NULL,
	[OtherFee] [float] NULL,
	[Remark] [nvarchar](2000) NULL,
	[Customer] [nvarchar](200) NULL,
	[TaxNo] [nvarchar](200) NULL,
	[LCLAmountReal] [float] NULL,
	[Amount] [float] NULL,
	[DelayAmount] [float] NULL,
	[DispatchAmount] [float] NULL,
	[User1] [nvarchar](200) NULL,
	[User2] [nvarchar](200) NULL,
	[User3] [nvarchar](200) NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[VoyageLoad20140713] ON
INSERT [dbo].[VoyageLoad20140713] ([ID], [LCLCatalog], [LCLAmount], [LCLPrice], [CurrencyID], [DelayDay], [DelayRate], [QuickDay], [QuickRate], [TEUEmpty], [TEUHeavy], [TEUFrost], [FEUEmpty], [FEUHeavy], [FEUFrost], [FEUDanger], [FFEUEmpty], [FFEUHeavy], [FFEUFrost], [FFEUDanger], [Rest], [EqualTo], [TotalNat], [TotalStand], [CurrencyOtherID], [OtherFee], [Remark], [Customer], [TaxNo], [LCLAmountReal], [Amount], [DelayAmount], [DispatchAmount], [User1], [User2], [User3]) VALUES (1, N'0', 0, 0, 1, 1, 0, 1, 0, 1, 6, 0, 2, 7, 0, 0, 3, 8, 0, 0, 4, 5, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[VoyageLoad20140713] ([ID], [LCLCatalog], [LCLAmount], [LCLPrice], [CurrencyID], [DelayDay], [DelayRate], [QuickDay], [QuickRate], [TEUEmpty], [TEUHeavy], [TEUFrost], [FEUEmpty], [FEUHeavy], [FEUFrost], [FEUDanger], [FFEUEmpty], [FFEUHeavy], [FFEUFrost], [FFEUDanger], [Rest], [EqualTo], [TotalNat], [TotalStand], [CurrencyOtherID], [OtherFee], [Remark], [Customer], [TaxNo], [LCLAmountReal], [Amount], [DelayAmount], [DispatchAmount], [User1], [User2], [User3]) VALUES (2, N'0', 1, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[VoyageLoad20140713] ([ID], [LCLCatalog], [LCLAmount], [LCLPrice], [CurrencyID], [DelayDay], [DelayRate], [QuickDay], [QuickRate], [TEUEmpty], [TEUHeavy], [TEUFrost], [FEUEmpty], [FEUHeavy], [FEUFrost], [FEUDanger], [FFEUEmpty], [FFEUHeavy], [FFEUFrost], [FFEUDanger], [Rest], [EqualTo], [TotalNat], [TotalStand], [CurrencyOtherID], [OtherFee], [Remark], [Customer], [TaxNo], [LCLAmountReal], [Amount], [DelayAmount], [DispatchAmount], [User1], [User2], [User3]) VALUES (3, N'0', 0, 0, 1, 1, 0, 1, 0, 1, 3, 0, 1, 2, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[VoyageLoad20140713] ([ID], [LCLCatalog], [LCLAmount], [LCLPrice], [CurrencyID], [DelayDay], [DelayRate], [QuickDay], [QuickRate], [TEUEmpty], [TEUHeavy], [TEUFrost], [FEUEmpty], [FEUHeavy], [FEUFrost], [FEUDanger], [FFEUEmpty], [FFEUHeavy], [FFEUFrost], [FFEUDanger], [Rest], [EqualTo], [TotalNat], [TotalStand], [CurrencyOtherID], [OtherFee], [Remark], [Customer], [TaxNo], [LCLAmountReal], [Amount], [DelayAmount], [DispatchAmount], [User1], [User2], [User3]) VALUES (4, N'0', 0, 0, 1, 1, 0, 1, 0, 1, 0, 0, 2, 0, 0, 0, 3, 4, 0, 0, 1, 5, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[VoyageLoad20140713] ([ID], [LCLCatalog], [LCLAmount], [LCLPrice], [CurrencyID], [DelayDay], [DelayRate], [QuickDay], [QuickRate], [TEUEmpty], [TEUHeavy], [TEUFrost], [FEUEmpty], [FEUHeavy], [FEUFrost], [FEUDanger], [FFEUEmpty], [FFEUHeavy], [FFEUFrost], [FFEUDanger], [Rest], [EqualTo], [TotalNat], [TotalStand], [CurrencyOtherID], [OtherFee], [Remark], [Customer], [TaxNo], [LCLAmountReal], [Amount], [DelayAmount], [DispatchAmount], [User1], [User2], [User3]) VALUES (5, N'0', 0, 0, 1, 1, 0, 1, 0, 12, 2, 0, 12, 3, 0, 0, 1, 0, 0, 0, 1, 2, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[VoyageLoad20140713] ([ID], [LCLCatalog], [LCLAmount], [LCLPrice], [CurrencyID], [DelayDay], [DelayRate], [QuickDay], [QuickRate], [TEUEmpty], [TEUHeavy], [TEUFrost], [FEUEmpty], [FEUHeavy], [FEUFrost], [FEUDanger], [FFEUEmpty], [FFEUHeavy], [FFEUFrost], [FFEUDanger], [Rest], [EqualTo], [TotalNat], [TotalStand], [CurrencyOtherID], [OtherFee], [Remark], [Customer], [TaxNo], [LCLAmountReal], [Amount], [DelayAmount], [DispatchAmount], [User1], [User2], [User3]) VALUES (6, N'0', 1212, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[VoyageLoad20140713] ([ID], [LCLCatalog], [LCLAmount], [LCLPrice], [CurrencyID], [DelayDay], [DelayRate], [QuickDay], [QuickRate], [TEUEmpty], [TEUHeavy], [TEUFrost], [FEUEmpty], [FEUHeavy], [FEUFrost], [FEUDanger], [FFEUEmpty], [FFEUHeavy], [FFEUFrost], [FFEUDanger], [Rest], [EqualTo], [TotalNat], [TotalStand], [CurrencyOtherID], [OtherFee], [Remark], [Customer], [TaxNo], [LCLAmountReal], [Amount], [DelayAmount], [DispatchAmount], [User1], [User2], [User3]) VALUES (7, N'0', 23, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[VoyageLoad20140713] ([ID], [LCLCatalog], [LCLAmount], [LCLPrice], [CurrencyID], [DelayDay], [DelayRate], [QuickDay], [QuickRate], [TEUEmpty], [TEUHeavy], [TEUFrost], [FEUEmpty], [FEUHeavy], [FEUFrost], [FEUDanger], [FFEUEmpty], [FFEUHeavy], [FFEUFrost], [FFEUDanger], [Rest], [EqualTo], [TotalNat], [TotalStand], [CurrencyOtherID], [OtherFee], [Remark], [Customer], [TaxNo], [LCLAmountReal], [Amount], [DelayAmount], [DispatchAmount], [User1], [User2], [User3]) VALUES (8, N'0', 1211, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[VoyageLoad20140713] ([ID], [LCLCatalog], [LCLAmount], [LCLPrice], [CurrencyID], [DelayDay], [DelayRate], [QuickDay], [QuickRate], [TEUEmpty], [TEUHeavy], [TEUFrost], [FEUEmpty], [FEUHeavy], [FEUFrost], [FEUDanger], [FFEUEmpty], [FFEUHeavy], [FFEUFrost], [FFEUDanger], [Rest], [EqualTo], [TotalNat], [TotalStand], [CurrencyOtherID], [OtherFee], [Remark], [Customer], [TaxNo], [LCLAmountReal], [Amount], [DelayAmount], [DispatchAmount], [User1], [User2], [User3]) VALUES (11, N'1', 5, 2, 1, 3, 5, 4, 6, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[VoyageLoad20140713] ([ID], [LCLCatalog], [LCLAmount], [LCLPrice], [CurrencyID], [DelayDay], [DelayRate], [QuickDay], [QuickRate], [TEUEmpty], [TEUHeavy], [TEUFrost], [FEUEmpty], [FEUHeavy], [FEUFrost], [FEUDanger], [FFEUEmpty], [FFEUHeavy], [FFEUFrost], [FFEUDanger], [Rest], [EqualTo], [TotalNat], [TotalStand], [CurrencyOtherID], [OtherFee], [Remark], [Customer], [TaxNo], [LCLAmountReal], [Amount], [DelayAmount], [DispatchAmount], [User1], [User2], [User3]) VALUES (12, N'货种', 12121, 12121, 1, 12, 1221, 12, 1221, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, NULL, N'', N'', 0, 0, 0, 0, NULL, NULL, NULL)
INSERT [dbo].[VoyageLoad20140713] ([ID], [LCLCatalog], [LCLAmount], [LCLPrice], [CurrencyID], [DelayDay], [DelayRate], [QuickDay], [QuickRate], [TEUEmpty], [TEUHeavy], [TEUFrost], [FEUEmpty], [FEUHeavy], [FEUFrost], [FEUDanger], [FFEUEmpty], [FFEUHeavy], [FFEUFrost], [FFEUDanger], [Rest], [EqualTo], [TotalNat], [TotalStand], [CurrencyOtherID], [OtherFee], [Remark], [Customer], [TaxNo], [LCLAmountReal], [Amount], [DelayAmount], [DispatchAmount], [User1], [User2], [User3]) VALUES (13, N'货种', 1212, 1212, 1, 12, 12, 12, 12, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, NULL, N'', N'', 0, 0, 0, 0, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[VoyageLoad20140713] OFF
/****** Object:  Table [dbo].[Route]    Script Date: 07/27/2014 23:41:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Route](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Distance] [float] NULL,
	[TotalRoute] [nvarchar](2000) NULL,
 CONSTRAINT [PK_Route] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'航线名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Route', @level2type=N'COLUMN',@level2name=N'Name'
GO
SET IDENTITY_INSERT [dbo].[Route] ON
INSERT [dbo].[Route] ([ID], [Name], [Distance], [TotalRoute]) VALUES (1, N'测试航线1', 2222, NULL)
INSERT [dbo].[Route] ([ID], [Name], [Distance], [TotalRoute]) VALUES (20, N'zjqtest3', 987, NULL)
INSERT [dbo].[Route] ([ID], [Name], [Distance], [TotalRoute]) VALUES (30, N'连云港外贸', 10000, NULL)
INSERT [dbo].[Route] ([ID], [Name], [Distance], [TotalRoute]) VALUES (31, N'01', 1000, NULL)
SET IDENTITY_INSERT [dbo].[Route] OFF
/****** Object:  Table [dbo].[ReportType]    Script Date: 07/27/2014 23:41:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ReportType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报表类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ReportType', @level2type=N'COLUMN',@level2name=N'Name'
GO
SET IDENTITY_INSERT [dbo].[ReportType] ON
INSERT [dbo].[ReportType] ([ID], [Name]) VALUES (1, N'预估录入')
INSERT [dbo].[ReportType] ([ID], [Name]) VALUES (2, N'修正录入')
INSERT [dbo].[ReportType] ([ID], [Name]) VALUES (3, N'财务确认')
SET IDENTITY_INSERT [dbo].[ReportType] OFF
/****** Object:  Table [dbo].[RentShipReport]    Script Date: 07/27/2014 23:41:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RentShipReport](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ShipID] [int] NULL,
	[RentTypeID] [int] NOT NULL,
	[Customer] [nvarchar](200) NULL,
	[TaxNo] [nvarchar](200) NULL,
	[CurrencyID] [int] NOT NULL,
	[User1] [nvarchar](200) NULL,
	[User2] [nvarchar](200) NULL,
	[User3] [nvarchar](200) NULL,
	[InputDate] [datetime] NULL,
	[CreateTime] [datetime] NULL,
	[RentFee] [float] NULL,
	[Amount] [float] NULL,
	[BeginDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[RentDays] [int] NOT NULL,
	[DiscountDays] [int] NULL,
	[RealDays] [int] NULL,
	[Price] [float] NULL,
	[CommunicateFee] [float] NULL,
	[LockFee] [float] NULL,
	[OtherFee] [float] NULL,
	[Remark] [nvarchar](2000) NULL,
 CONSTRAINT [PK_RentShipReport] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'船舶' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RentShipReport', @level2type=N'COLUMN',@level2name=N'ShipID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出租方式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RentShipReport', @level2type=N'COLUMN',@level2name=N'RentTypeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RentShipReport', @level2type=N'COLUMN',@level2name=N'Customer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'纳税识别号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RentShipReport', @level2type=N'COLUMN',@level2name=N'TaxNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'租金计费币种' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RentShipReport', @level2type=N'COLUMN',@level2name=N'CurrencyID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主管' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RentShipReport', @level2type=N'COLUMN',@level2name=N'User1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RentShipReport', @level2type=N'COLUMN',@level2name=N'User2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'制表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RentShipReport', @level2type=N'COLUMN',@level2name=N'User3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登记时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RentShipReport', @level2type=N'COLUMN',@level2name=N'InputDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登记时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RentShipReport', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'租金' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RentShipReport', @level2type=N'COLUMN',@level2name=N'RentFee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'总费用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RentShipReport', @level2type=N'COLUMN',@level2name=N'Amount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'租金计算开始时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RentShipReport', @level2type=N'COLUMN',@level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'租金计算结束时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RentShipReport', @level2type=N'COLUMN',@level2name=N'EndDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'扣租时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RentShipReport', @level2type=N'COLUMN',@level2name=N'RentDays'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'扣租时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RentShipReport', @level2type=N'COLUMN',@level2name=N'DiscountDays'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计算租金时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RentShipReport', @level2type=N'COLUMN',@level2name=N'RealDays'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日租金' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RentShipReport', @level2type=N'COLUMN',@level2name=N'Price'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'通讯费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RentShipReport', @level2type=N'COLUMN',@level2name=N'CommunicateFee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'绑扎锁具补贴' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RentShipReport', @level2type=N'COLUMN',@level2name=N'LockFee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他补贴' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RentShipReport', @level2type=N'COLUMN',@level2name=N'OtherFee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RentShipReport', @level2type=N'COLUMN',@level2name=N'Remark'
GO
SET IDENTITY_INSERT [dbo].[RentShipReport] ON
INSERT [dbo].[RentShipReport] ([ID], [ShipID], [RentTypeID], [Customer], [TaxNo], [CurrencyID], [User1], [User2], [User3], [InputDate], [CreateTime], [RentFee], [Amount], [BeginDate], [EndDate], [RentDays], [DiscountDays], [RealDays], [Price], [CommunicateFee], [LockFee], [OtherFee], [Remark]) VALUES (1, 2, 1, N'客户', N'纳税识别', 1, N'1', N'2', N'3', CAST(0x0000A32400BC29EC AS DateTime), CAST(0x0000A32400BC29EC AS DateTime), 121212, 6073, CAST(0x0000A32400000000 AS DateTime), CAST(0x0000A33300000000 AS DateTime), 15, 1, 5, 1212, 11, 1, 1, N'1212')
INSERT [dbo].[RentShipReport] ([ID], [ShipID], [RentTypeID], [Customer], [TaxNo], [CurrencyID], [User1], [User2], [User3], [InputDate], [CreateTime], [RentFee], [Amount], [BeginDate], [EndDate], [RentDays], [DiscountDays], [RealDays], [Price], [CommunicateFee], [LockFee], [OtherFee], [Remark]) VALUES (2, 4, 3, N'上海浦海航运有限公司', N'纳税识别号', 2, N'主管', N'审核', N'制表', CAST(0x0000A342010323D8 AS DateTime), CAST(0x0000A342010323D8 AS DateTime), 123000, 0, CAST(0x0000A31E00000000 AS DateTime), CAST(0x0000A32D00000000 AS DateTime), 0, 0, 15, 8200, 650, 0, -9614.39, N'第六十九期租金
租期（租金USD8400/天）至2013年6月17日0000结束
新租期，即日租金USD8200/天从2013年6月17日0001开始
因锚机故障扣租-9614.39美元')
SET IDENTITY_INSERT [dbo].[RentShipReport] OFF
/****** Object:  Synonym [dbo].[User]    Script Date: 07/27/2014 23:41:02 ******/
CREATE SYNONYM [dbo].[User] FOR [SharpMembership].[dbo].[User]
GO
/****** Object:  Table [dbo].[ShipComponent]    Script Date: 07/27/2014 23:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShipComponent](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Remark] [nvarchar](50) NULL,
 CONSTRAINT [PK_ShipComponent] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ShipComponent] ON
INSERT [dbo].[ShipComponent] ([ID], [Name], [Remark]) VALUES (1, N'主机', NULL)
INSERT [dbo].[ShipComponent] ([ID], [Name], [Remark]) VALUES (2, N'副机1', NULL)
INSERT [dbo].[ShipComponent] ([ID], [Name], [Remark]) VALUES (3, N'副机2', NULL)
INSERT [dbo].[ShipComponent] ([ID], [Name], [Remark]) VALUES (4, N'副机3', NULL)
INSERT [dbo].[ShipComponent] ([ID], [Name], [Remark]) VALUES (5, N'锅炉', NULL)
SET IDENTITY_INSERT [dbo].[ShipComponent] OFF
/****** Object:  Table [dbo].[Ship]    Script Date: 07/27/2014 23:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ship](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[ChiefEngineer] [nvarchar](50) NULL,
	[Captain] [nvarchar](50) NULL,
	[GeneralManager] [nvarchar](50) NULL,
	[LoadType] [nvarchar](50) NULL,
	[OperationType] [nvarchar](50) NULL,
	[RentDate] [date] NULL,
	[Enable] [bit] NOT NULL,
 CONSTRAINT [PK_Ship] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'船舶名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Ship', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'船舶编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Ship', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1:散货；2：集装箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Ship', @level2type=N'COLUMN',@level2name=N'LoadType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1:自营；2：租赁' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Ship', @level2type=N'COLUMN',@level2name=N'OperationType'
GO
SET IDENTITY_INSERT [dbo].[Ship] ON
INSERT [dbo].[Ship] ([ID], [Name], [Code], [ChiefEngineer], [Captain], [GeneralManager], [LoadType], [OperationType], [RentDate], [Enable]) VALUES (1, N'东方盛', N'Ship0', N'a0', N'b0', N'c0', N'1', N'2', CAST(0x00380B00 AS Date), 1)
INSERT [dbo].[Ship] ([ID], [Name], [Code], [ChiefEngineer], [Captain], [GeneralManager], [LoadType], [OperationType], [RentDate], [Enable]) VALUES (2, N'榕峰', N'Ship1', N'a1', N'b1', N'c1', N'2', N'1', CAST(0xB8370B00 AS Date), 1)
INSERT [dbo].[Ship] ([ID], [Name], [Code], [ChiefEngineer], [Captain], [GeneralManager], [LoadType], [OperationType], [RentDate], [Enable]) VALUES (3, N'东方富', N'Ship2', N'a2', N'b2', N'c2', N'2', N'1', NULL, 1)
INSERT [dbo].[Ship] ([ID], [Name], [Code], [ChiefEngineer], [Captain], [GeneralManager], [LoadType], [OperationType], [RentDate], [Enable]) VALUES (4, N'东方强', N'Ship3', N'a3', N'b3', N'c3', N'2', N'1', NULL, 1)
INSERT [dbo].[Ship] ([ID], [Name], [Code], [ChiefEngineer], [Captain], [GeneralManager], [LoadType], [OperationType], [RentDate], [Enable]) VALUES (5, N'东方兴', N'Ship4', N'a4', N'b4', N'c4', N'2', N'1', NULL, 1)
INSERT [dbo].[Ship] ([ID], [Name], [Code], [ChiefEngineer], [Captain], [GeneralManager], [LoadType], [OperationType], [RentDate], [Enable]) VALUES (6, N'东方顺', N'Ship5', N'a5', N'b5', N'c5', N'2', N'1', NULL, 1)
INSERT [dbo].[Ship] ([ID], [Name], [Code], [ChiefEngineer], [Captain], [GeneralManager], [LoadType], [OperationType], [RentDate], [Enable]) VALUES (7, N'恒辉', N'船舶编号', N'轮机长', N'船长', N'机务主管', N'2', N'1', CAST(0x9D380B00 AS Date), 1)
SET IDENTITY_INSERT [dbo].[Ship] OFF
/****** Object:  Table [dbo].[ManagerType]    Script Date: 07/27/2014 23:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ManagerType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[TaxRate] [float] NOT NULL,
 CONSTRAINT [PK_ManagerType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ManagerType] ON
INSERT [dbo].[ManagerType] ([ID], [Name], [TaxRate]) VALUES (1, N'外贸台湾线', 0)
INSERT [dbo].[ManagerType] ([ID], [Name], [TaxRate]) VALUES (2, N'外贸集装箱', 0)
INSERT [dbo].[ManagerType] ([ID], [Name], [TaxRate]) VALUES (3, N'内贸', 0.11)
INSERT [dbo].[ManagerType] ([ID], [Name], [TaxRate]) VALUES (4, N'内支线', 0.11)
INSERT [dbo].[ManagerType] ([ID], [Name], [TaxRate]) VALUES (8, N'出租', 0.17)
INSERT [dbo].[ManagerType] ([ID], [Name], [TaxRate]) VALUES (9, N'柜出租', 0.17)
INSERT [dbo].[ManagerType] ([ID], [Name], [TaxRate]) VALUES (10, N'其他', 0)
SET IDENTITY_INSERT [dbo].[ManagerType] OFF
/****** Object:  Table [dbo].[Log]    Script Date: 07/27/2014 23:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Message] [ntext] NULL,
	[Type] [int] NOT NULL,
	[SourceID] [int] NULL,
	[Time] [datetime] NOT NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OilType]    Script Date: 07/27/2014 23:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OilType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Category] [int] NOT NULL,
 CONSTRAINT [PK_OilType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1：燃料；2：润料。' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OilType', @level2type=N'COLUMN',@level2name=N'Category'
GO
SET IDENTITY_INSERT [dbo].[OilType] ON
INSERT [dbo].[OilType] ([ID], [Name], [Category]) VALUES (1, N'燃料油', 1)
INSERT [dbo].[OilType] ([ID], [Name], [Category]) VALUES (2, N'柴油', 1)
INSERT [dbo].[OilType] ([ID], [Name], [Category]) VALUES (3, N'机油', 2)
INSERT [dbo].[OilType] ([ID], [Name], [Category]) VALUES (4, N'气缸油', 2)
INSERT [dbo].[OilType] ([ID], [Name], [Category]) VALUES (5, N'透平油', 2)
INSERT [dbo].[OilType] ([ID], [Name], [Category]) VALUES (6, N'液压油', 2)
INSERT [dbo].[OilType] ([ID], [Name], [Category]) VALUES (7, N'其他', 2)
INSERT [dbo].[OilType] ([ID], [Name], [Category]) VALUES (8, N'冷冻油', 2)
INSERT [dbo].[OilType] ([ID], [Name], [Category]) VALUES (9, N'空压机油', 2)
SET IDENTITY_INSERT [dbo].[OilType] OFF
/****** Object:  Table [dbo].[PortType]    Script Date: 07/27/2014 23:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PortType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PortType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'港口类型名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PortType', @level2type=N'COLUMN',@level2name=N'Name'
GO
SET IDENTITY_INSERT [dbo].[PortType] ON
INSERT [dbo].[PortType] ([ID], [Name]) VALUES (1, N'装货港')
INSERT [dbo].[PortType] ([ID], [Name]) VALUES (2, N'始运港')
INSERT [dbo].[PortType] ([ID], [Name]) VALUES (3, N'卸货港')
INSERT [dbo].[PortType] ([ID], [Name]) VALUES (4, N'目的港')
INSERT [dbo].[PortType] ([ID], [Name]) VALUES (5, N'经停港')
SET IDENTITY_INSERT [dbo].[PortType] OFF
/****** Object:  Table [dbo].[Port]    Script Date: 07/27/2014 23:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Port](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Remark] [nvarchar](256) NULL,
 CONSTRAINT [PK_Port] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Port', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'港口名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Port', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Port', @level2type=N'COLUMN',@level2name=N'Remark'
GO
SET IDENTITY_INSERT [dbo].[Port] ON
INSERT [dbo].[Port] ([ID], [Name], [Remark]) VALUES (1, N'福州', NULL)
INSERT [dbo].[Port] ([ID], [Name], [Remark]) VALUES (2, N'厦门', NULL)
INSERT [dbo].[Port] ([ID], [Name], [Remark]) VALUES (3, N'漳州', NULL)
INSERT [dbo].[Port] ([ID], [Name], [Remark]) VALUES (4, N'泉州', NULL)
INSERT [dbo].[Port] ([ID], [Name], [Remark]) VALUES (5, N'上海', NULL)
INSERT [dbo].[Port] ([ID], [Name], [Remark]) VALUES (6, N'广州', NULL)
INSERT [dbo].[Port] ([ID], [Name], [Remark]) VALUES (7, N'天津', NULL)
INSERT [dbo].[Port] ([ID], [Name], [Remark]) VALUES (8, N'连云港', NULL)
INSERT [dbo].[Port] ([ID], [Name], [Remark]) VALUES (9, N'SAMARINDA', NULL)
INSERT [dbo].[Port] ([ID], [Name], [Remark]) VALUES (10, N'宁德', NULL)
SET IDENTITY_INSERT [dbo].[Port] OFF
/****** Object:  Table [dbo].[Currency]    Script Date: 07/27/2014 23:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Currency](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Currency] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Currency] ON
INSERT [dbo].[Currency] ([ID], [Name]) VALUES (1, N'人民币')
INSERT [dbo].[Currency] ([ID], [Name]) VALUES (2, N'美元')
INSERT [dbo].[Currency] ([ID], [Name]) VALUES (3, N'日元')
INSERT [dbo].[Currency] ([ID], [Name]) VALUES (4, N'新台币')
INSERT [dbo].[Currency] ([ID], [Name]) VALUES (5, N'港币')
INSERT [dbo].[Currency] ([ID], [Name]) VALUES (6, N'新加坡元')
SET IDENTITY_INSERT [dbo].[Currency] OFF
/****** Object:  Table [dbo].[CostProperty]    Script Date: 07/27/2014 23:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CostProperty](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CostProperty] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'费用性质' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CostProperty', @level2type=N'COLUMN',@level2name=N'Name'
GO
/****** Object:  Table [dbo].[CostCategory]    Script Date: 07/27/2014 23:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CostCategory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CostCategory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'费用类别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CostCategory', @level2type=N'COLUMN',@level2name=N'Name'
GO
/****** Object:  Table [dbo].[HangciBaseInput]    Script Date: 07/27/2014 23:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HangciBaseInput](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ShipInputDate] [datetime] NULL,
	[GeneralManagerDate] [datetime] NULL,
 CONSTRAINT [PK_HangciBaseInput] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[HangciBaseInput] ON
INSERT [dbo].[HangciBaseInput] ([ID], [ShipInputDate], [GeneralManagerDate]) VALUES (12, CAST(0x0000A1E100000000 AS DateTime), CAST(0x0000A1E900000000 AS DateTime))
INSERT [dbo].[HangciBaseInput] ([ID], [ShipInputDate], [GeneralManagerDate]) VALUES (13, CAST(0x0000A21D0125FF3F AS DateTime), CAST(0x0000A21D0125FF3F AS DateTime))
INSERT [dbo].[HangciBaseInput] ([ID], [ShipInputDate], [GeneralManagerDate]) VALUES (14, CAST(0x0000A26000000000 AS DateTime), CAST(0x0000A26000000000 AS DateTime))
INSERT [dbo].[HangciBaseInput] ([ID], [ShipInputDate], [GeneralManagerDate]) VALUES (15, CAST(0x0000A35C00000000 AS DateTime), CAST(0x0000A35C00000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[HangciBaseInput] OFF
/****** Object:  Table [dbo].[FormLibrary]    Script Date: 07/27/2014 23:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FormLibrary](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Content] [ntext] NOT NULL,
	[DocName] [varchar](50) NULL,
 CONSTRAINT [PK_FormLibrary] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标识ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FormLibrary', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'表单内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FormLibrary', @level2type=N'COLUMN',@level2name=N'Content'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文档编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FormLibrary', @level2type=N'COLUMN',@level2name=N'DocName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'表单库文档保存的数据库访问类' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FormLibrary'
GO
SET IDENTITY_INSERT [dbo].[FormLibrary] ON
INSERT [dbo].[FormLibrary] ([ID], [Content], [DocName]) VALUES (1, N'<?xml version="1.0" encoding="utf-8"?>
<WuliaoInputInfo xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <ID>7</ID>
  <DimTimeID>18</DimTimeID>
  <ShipID>5</ShipID>
  <UsageType>3</UsageType>
  <InputUserID>0</InputUserID>
  <ReportTypeID>1</ReportTypeID>
  <CreateTime>2013-05-04T15:05:52</CreateTime>
  <CurrencyID>1</CurrencyID>
  <ExchangeRateID />
  <PreestimateFormID />
  <AmendFormID />
  <总数>0</总数>
  <生产用品>0</生产用品>
  <生活用品>0</生活用品>
  <办公用品>0</办公用品>
  <油漆>0</油漆>
  <缆绳>0</缆绳>
  <锁具>0</锁具>
  <药品>0</药品>
  <其他>0</其他>
</WuliaoInputInfo>', NULL)
INSERT [dbo].[FormLibrary] ([ID], [Content], [DocName]) VALUES (2, N'<?xml version="1.0" encoding="utf-8"?>
<WuliaoInputInfo xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <ID>7</ID>
  <DimTimeID>18</DimTimeID>
  <ShipID>5</ShipID>
  <UsageType>3</UsageType>
  <InputUserID>0</InputUserID>
  <ReportTypeID>1</ReportTypeID>
  <CreateTime>2013-05-04T15:05:52</CreateTime>
  <CurrencyID>1</CurrencyID>
  <ExchangeRateID />
  <PreestimateFormID />
  <AmendFormID />
  <总数>0</总数>
  <生产用品>0</生产用品>
  <生活用品>0</生活用品>
  <办公用品>0</办公用品>
  <油漆>0</油漆>
  <缆绳>0</缆绳>
  <锁具>0</锁具>
  <药品>0</药品>
  <其他>0</其他>
</WuliaoInputInfo>', NULL)
INSERT [dbo].[FormLibrary] ([ID], [Content], [DocName]) VALUES (3, N'<?xml version="1.0" encoding="utf-8"?>
<WuliaoInputInfo xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <ID>7</ID>
  <DimTimeID>18</DimTimeID>
  <ShipID>5</ShipID>
  <UsageType>3</UsageType>
  <InputUserID>0</InputUserID>
  <ReportTypeID>1</ReportTypeID>
  <CreateTime>2013-05-04T15:05:52</CreateTime>
  <CurrencyID>1</CurrencyID>
  <ExchangeRateID />
  <PreestimateFormID />
  <AmendFormID />
  <总数>0</总数>
  <生产用品>0</生产用品>
  <生活用品>0</生活用品>
  <办公用品>0</办公用品>
  <油漆>0</油漆>
  <缆绳>0</缆绳>
  <锁具>0</锁具>
  <药品>0</药品>
  <其他>0</其他>
</WuliaoInputInfo>', NULL)
INSERT [dbo].[FormLibrary] ([ID], [Content], [DocName]) VALUES (4, N'<?xml version="1.0" encoding="utf-8"?>
<WuliaoInputInfo xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <ID>7</ID>
  <DimTimeID>18</DimTimeID>
  <ShipID>5</ShipID>
  <UsageType>3</UsageType>
  <InputUserID>0</InputUserID>
  <ReportTypeID>1</ReportTypeID>
  <CreateTime>2013-05-04T15:05:52</CreateTime>
  <CurrencyID>1</CurrencyID>
  <ExchangeRateID />
  <总数>0</总数>
  <生产用品>0</生产用品>
  <生活用品>0</生活用品>
  <办公用品>0</办公用品>
  <油漆>0</油漆>
  <缆绳>0</缆绳>
  <锁具>0</锁具>
  <药品>0</药品>
  <其他>0</其他>
</WuliaoInputInfo>', NULL)
INSERT [dbo].[FormLibrary] ([ID], [Content], [DocName]) VALUES (5, N'<?xml version="1.0" encoding="utf-8"?>
<WuliaoInputInfo xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <ID>7</ID>
  <DimTimeID>18</DimTimeID>
  <ShipID>5</ShipID>
  <UsageType>3</UsageType>
  <InputUserID>0</InputUserID>
  <ReportTypeID>1</ReportTypeID>
  <CreateTime>2013-05-04T15:05:52</CreateTime>
  <CurrencyID>1</CurrencyID>
  <ExchangeRateID />
  <总数>0</总数>
  <生产用品>0</生产用品>
  <生活用品>0</生活用品>
  <办公用品>0</办公用品>
  <油漆>0</油漆>
  <缆绳>0</缆绳>
  <锁具>0</锁具>
  <药品>0</药品>
  <其他>0</其他>
</WuliaoInputInfo>', NULL)
INSERT [dbo].[FormLibrary] ([ID], [Content], [DocName]) VALUES (6, N'<?xml version="1.0" encoding="utf-8"?>
<WuliaoInputInfo xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <ID>7</ID>
  <DimTimeID>18</DimTimeID>
  <ShipID>5</ShipID>
  <UsageType>3</UsageType>
  <InputUserID>0</InputUserID>
  <ReportTypeID>1</ReportTypeID>
  <CreateTime>2013-05-04T15:05:52</CreateTime>
  <CurrencyID>1</CurrencyID>
  <ExchangeRateID />
  <总数>0</总数>
  <生产用品>0</生产用品>
  <生活用品>0</生活用品>
  <办公用品>0</办公用品>
  <油漆>0</油漆>
  <缆绳>0</缆绳>
  <锁具>0</锁具>
  <药品>0</药品>
  <其他>0</其他>
</WuliaoInputInfo>', NULL)
INSERT [dbo].[FormLibrary] ([ID], [Content], [DocName]) VALUES (7, N'<?xml version="1.0" encoding="utf-8"?>
<WuliaoInputInfo xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <ID>8</ID>
  <DimTimeID>18</DimTimeID>
  <ShipID>4</ShipID>
  <UsageType>2</UsageType>
  <InputUserID>0</InputUserID>
  <ReportTypeID>1</ReportTypeID>
  <CreateTime>2013-05-04T15:06:20</CreateTime>
  <CurrencyID>1</CurrencyID>
  <ExchangeRateID />
  <总数>0</总数>
  <生产用品>0</生产用品>
  <生活用品>0</生活用品>
  <办公用品>0</办公用品>
  <油漆>0</油漆>
  <缆绳>0</缆绳>
  <锁具>0</锁具>
  <药品>0</药品>
  <其他>0</其他>
</WuliaoInputInfo>', NULL)
INSERT [dbo].[FormLibrary] ([ID], [Content], [DocName]) VALUES (8, N'<?xml version="1.0" encoding="utf-8"?>
<WuliaoInputInfo xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <ID>7</ID>
  <DimTimeID>18</DimTimeID>
  <ShipID>5</ShipID>
  <UsageType>3</UsageType>
  <InputUserID>0</InputUserID>
  <ApproveUserID>0</ApproveUserID>
  <ReportTypeID>2</ReportTypeID>
  <CreateTime>2013-05-04T15:05:52</CreateTime>
  <CurrencyID>1</CurrencyID>
  <ExchangeRateID>0</ExchangeRateID>
  <PreestimateFormID>6</PreestimateFormID>
  <AmendFormID>0</AmendFormID>
  <总数>238</总数>
  <生产用品>1</生产用品>
  <生活用品>1</生活用品>
  <办公用品>1</办公用品>
  <油漆>111</油漆>
  <缆绳>1</缆绳>
  <锁具>11</锁具>
  <药品>1</药品>
  <其他>111</其他>
</WuliaoInputInfo>', NULL)
SET IDENTITY_INSERT [dbo].[FormLibrary] OFF
/****** Object:  Table [dbo].[FeeCatalog]    Script Date: 07/27/2014 23:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeeCatalog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DepartmentID] [int] NOT NULL,
 CONSTRAINT [PK_FleeCatalog] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[FeeCatalog] ON
INSERT [dbo].[FeeCatalog] ([ID], [Name], [DepartmentID]) VALUES (1, N'英版图书', 4)
INSERT [dbo].[FeeCatalog] ([ID], [Name], [DepartmentID]) VALUES (2, N'英版航告', 4)
INSERT [dbo].[FeeCatalog] ([ID], [Name], [DepartmentID]) VALUES (3, N'英版海图', 4)
INSERT [dbo].[FeeCatalog] ([ID], [Name], [DepartmentID]) VALUES (4, N'中版图书', 4)
INSERT [dbo].[FeeCatalog] ([ID], [Name], [DepartmentID]) VALUES (5, N'中版航告', 4)
INSERT [dbo].[FeeCatalog] ([ID], [Name], [DepartmentID]) VALUES (6, N'中版海图', 4)
INSERT [dbo].[FeeCatalog] ([ID], [Name], [DepartmentID]) VALUES (7, N'海事局版海图', 4)
INSERT [dbo].[FeeCatalog] ([ID], [Name], [DepartmentID]) VALUES (8, N'保安体系审核和审批', 4)
INSERT [dbo].[FeeCatalog] ([ID], [Name], [DepartmentID]) VALUES (9, N'安全管理体系审核', 4)
INSERT [dbo].[FeeCatalog] ([ID], [Name], [DepartmentID]) VALUES (10, N'公司DOC审核', 4)
INSERT [dbo].[FeeCatalog] ([ID], [Name], [DepartmentID]) VALUES (11, N'能效管理计划审核和审批', 4)
INSERT [dbo].[FeeCatalog] ([ID], [Name], [DepartmentID]) VALUES (12, N'安全生产标准化审核（CCS）', 4)
INSERT [dbo].[FeeCatalog] ([ID], [Name], [DepartmentID]) VALUES (13, N'船员租金', 5)
INSERT [dbo].[FeeCatalog] ([ID], [Name], [DepartmentID]) VALUES (15, N'船员劳动保护', 5)
INSERT [dbo].[FeeCatalog] ([ID], [Name], [DepartmentID]) VALUES (16, N'船员雇主责任险', 5)
SET IDENTITY_INSERT [dbo].[FeeCatalog] OFF
/****** Object:  Table [dbo].[DimTime]    Script Date: 07/27/2014 23:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DimTime](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Year] [int] NOT NULL,
	[MonthName] [nvarchar](50) NOT NULL,
	[QuarterName] [nvarchar](50) NOT NULL,
	[MonthNumOfYear] [int] NOT NULL,
	[QuarterNumOfYear] [int] NOT NULL,
 CONSTRAINT [PK_DimTime] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DimTime] ON
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (1, 2012, N'一月', N'一季度', 1, 1)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (2, 2012, N'二月', N'一季度', 2, 1)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (3, 2012, N'三月', N'一季度', 3, 1)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (4, 2012, N'四月', N'二季度', 4, 2)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (5, 2012, N'五月', N'二季度', 5, 2)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (6, 2012, N'六月', N'二季度', 6, 2)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (7, 2012, N'七月', N'三季度', 7, 3)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (8, 2012, N'八月', N'三季度', 8, 3)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (9, 2012, N'九月', N'三季度', 9, 3)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (10, 2012, N'十月', N'四季度', 10, 4)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (11, 2012, N'十一月', N'四季度', 11, 4)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (12, 2012, N'十二月', N'四季度', 12, 4)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (13, 2013, N'一月', N'一季度', 1, 1)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (14, 2013, N'二月', N'一季度', 2, 1)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (15, 2013, N'三月', N'一季度', 3, 1)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (16, 2013, N'四月', N'二季度', 4, 2)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (17, 2013, N'五月', N'二季度', 5, 2)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (18, 2013, N'六月', N'二季度', 6, 2)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (19, 2013, N'七月', N'三季度', 7, 3)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (20, 2013, N'八月', N'三季度', 8, 3)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (21, 2013, N'九月', N'三季度', 9, 3)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (22, 2013, N'十月', N'四季度', 10, 4)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (23, 2013, N'十一月', N'四季度', 11, 4)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (24, 2013, N'十二月', N'四季度', 12, 4)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (25, 2014, N'一月', N'一季度', 1, 1)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (26, 2014, N'二月', N'一季度', 2, 1)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (27, 2014, N'三月', N'一季度', 3, 1)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (28, 2014, N'四月', N'二季度', 4, 2)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (29, 2014, N'五月', N'二季度', 5, 2)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (30, 2014, N'六月', N'二季度', 6, 2)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (31, 2014, N'七月', N'三季度', 7, 3)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (32, 2014, N'八月', N'三季度', 8, 3)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (33, 2014, N'九月', N'三季度', 9, 3)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (34, 2014, N'十月', N'四季度', 10, 4)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (35, 2014, N'十一月', N'四季度', 11, 4)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (36, 2014, N'十二月', N'四季度', 12, 4)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (37, 2015, N'一月', N'一季度', 1, 1)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (38, 2015, N'二月', N'一季度', 2, 1)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (39, 2015, N'三月', N'一季度', 3, 1)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (40, 2015, N'四月', N'二季度', 4, 2)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (41, 2015, N'五月', N'二季度', 5, 2)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (42, 2015, N'六月', N'二季度', 6, 2)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (43, 2015, N'七月', N'三季度', 7, 3)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (44, 2015, N'八月', N'三季度', 8, 3)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (45, 2015, N'九月', N'三季度', 9, 3)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (46, 2015, N'十月', N'四季度', 10, 4)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (47, 2015, N'十一月', N'四季度', 11, 4)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (48, 2015, N'十二月', N'四季度', 12, 4)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (49, 2016, N'一月', N'一季度', 1, 1)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (50, 2016, N'二月', N'一季度', 2, 1)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (51, 2016, N'三月', N'一季度', 3, 1)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (52, 2016, N'四月', N'二季度', 4, 2)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (53, 2016, N'五月', N'二季度', 5, 2)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (54, 2016, N'六月', N'二季度', 6, 2)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (55, 2016, N'七月', N'三季度', 7, 3)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (56, 2016, N'八月', N'三季度', 8, 3)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (57, 2016, N'九月', N'三季度', 9, 3)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (58, 2016, N'十月', N'四季度', 10, 4)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (59, 2016, N'十一月', N'四季度', 11, 4)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (60, 2016, N'十二月', N'四季度', 12, 4)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (61, 2016, N'一月', N'一季度', 1, 1)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (62, 2016, N'二月', N'一季度', 2, 1)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (63, 2016, N'三月', N'一季度', 3, 1)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (64, 2016, N'四月', N'二季度', 4, 2)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (65, 2016, N'五月', N'二季度', 5, 2)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (66, 2016, N'六月', N'二季度', 6, 2)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (67, 2016, N'七月', N'三季度', 7, 3)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (68, 2016, N'八月', N'三季度', 8, 3)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (69, 2016, N'九月', N'三季度', 9, 3)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (70, 2016, N'十月', N'四季度', 10, 4)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (71, 2016, N'十一月', N'四季度', 11, 4)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (72, 2016, N'十二月', N'四季度', 12, 4)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (73, 2017, N'一月', N'一季度', 1, 1)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (74, 2017, N'二月', N'一季度', 2, 1)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (75, 2017, N'三月', N'一季度', 3, 1)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (76, 2017, N'四月', N'二季度', 4, 2)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (77, 2017, N'五月', N'二季度', 5, 2)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (78, 2017, N'六月', N'二季度', 6, 2)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (79, 2017, N'七月', N'三季度', 7, 3)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (80, 2017, N'八月', N'三季度', 8, 3)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (81, 2017, N'九月', N'三季度', 9, 3)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (82, 2017, N'十月', N'四季度', 10, 4)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (83, 2017, N'十一月', N'四季度', 11, 4)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (84, 2017, N'十二月', N'四季度', 12, 4)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (85, 2018, N'一月', N'一季度', 1, 1)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (86, 2018, N'二月', N'一季度', 2, 1)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (87, 2018, N'三月', N'一季度', 3, 1)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (88, 2018, N'四月', N'二季度', 4, 2)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (89, 2018, N'五月', N'二季度', 5, 2)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (90, 2018, N'六月', N'二季度', 6, 2)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (91, 2018, N'七月', N'三季度', 7, 3)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (92, 2018, N'八月', N'三季度', 8, 3)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (93, 2018, N'九月', N'三季度', 9, 3)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (94, 2018, N'十月', N'四季度', 10, 4)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (95, 2018, N'十一月', N'四季度', 11, 4)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (96, 2018, N'十二月', N'四季度', 12, 4)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (97, 2019, N'一月', N'一季度', 1, 1)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (98, 2019, N'二月', N'一季度', 2, 1)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (99, 2019, N'三月', N'一季度', 3, 1)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (100, 2019, N'四月', N'二季度', 4, 2)
GO
print 'Processed 100 total records'
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (101, 2019, N'五月', N'二季度', 5, 2)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (102, 2019, N'六月', N'二季度', 6, 2)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (103, 2019, N'七月', N'三季度', 7, 3)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (104, 2019, N'八月', N'三季度', 8, 3)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (105, 2019, N'九月', N'三季度', 9, 3)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (106, 2019, N'十月', N'四季度', 10, 4)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (107, 2019, N'十一月', N'四季度', 11, 4)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (108, 2019, N'十二月', N'四季度', 12, 4)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (109, 2020, N'一月', N'一季度', 1, 1)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (110, 2020, N'二月', N'一季度', 2, 1)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (111, 2020, N'三月', N'一季度', 3, 1)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (112, 2020, N'四月', N'二季度', 4, 2)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (113, 2020, N'五月', N'二季度', 5, 2)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (114, 2020, N'六月', N'二季度', 6, 2)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (115, 2020, N'七月', N'三季度', 7, 3)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (116, 2020, N'八月', N'三季度', 8, 3)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (117, 2020, N'九月', N'三季度', 9, 3)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (118, 2020, N'十月', N'四季度', 10, 4)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (119, 2020, N'十一月', N'四季度', 11, 4)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (120, 2020, N'十二月', N'四季度', 12, 4)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (121, 2021, N'一月', N'一季度', 1, 1)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (122, 2021, N'二月', N'一季度', 2, 1)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (123, 2021, N'三月', N'一季度', 3, 1)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (124, 2021, N'四月', N'二季度', 4, 2)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (125, 2021, N'五月', N'二季度', 5, 2)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (126, 2021, N'六月', N'二季度', 6, 2)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (127, 2021, N'七月', N'三季度', 7, 3)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (128, 2021, N'八月', N'三季度', 8, 3)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (129, 2021, N'九月', N'三季度', 9, 3)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (130, 2021, N'十月', N'四季度', 10, 4)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (131, 2021, N'十一月', N'四季度', 11, 4)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (132, 2021, N'十二月', N'四季度', 12, 4)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (133, 2022, N'一月', N'一季度', 1, 1)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (134, 2022, N'二月', N'一季度', 2, 1)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (135, 2022, N'三月', N'一季度', 3, 1)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (136, 2022, N'四月', N'二季度', 4, 2)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (137, 2022, N'五月', N'二季度', 5, 2)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (138, 2022, N'六月', N'二季度', 6, 2)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (139, 2022, N'七月', N'三季度', 7, 3)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (140, 2022, N'八月', N'三季度', 8, 3)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (141, 2022, N'九月', N'三季度', 9, 3)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (142, 2022, N'十月', N'四季度', 10, 4)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (143, 2022, N'十一月', N'四季度', 11, 4)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (144, 2022, N'十二月', N'四季度', 12, 4)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (145, 2023, N'一月', N'一季度', 1, 1)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (146, 2023, N'二月', N'一季度', 2, 1)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (147, 2023, N'三月', N'一季度', 3, 1)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (148, 2023, N'四月', N'二季度', 4, 2)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (149, 2023, N'五月', N'二季度', 5, 2)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (150, 2023, N'六月', N'二季度', 6, 2)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (151, 2023, N'七月', N'三季度', 7, 3)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (152, 2023, N'八月', N'三季度', 8, 3)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (153, 2023, N'九月', N'三季度', 9, 3)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (154, 2023, N'十月', N'四季度', 10, 4)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (155, 2023, N'十一月', N'四季度', 11, 4)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (156, 2023, N'十二月', N'四季度', 12, 4)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (157, 2024, N'一月', N'一季度', 1, 1)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (158, 2024, N'二月', N'一季度', 2, 1)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (159, 2024, N'三月', N'一季度', 3, 1)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (160, 2024, N'四月', N'二季度', 4, 2)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (161, 2024, N'五月', N'二季度', 5, 2)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (162, 2024, N'六月', N'二季度', 6, 2)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (163, 2024, N'七月', N'三季度', 7, 3)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (164, 2024, N'八月', N'三季度', 8, 3)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (165, 2024, N'九月', N'三季度', 9, 3)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (166, 2024, N'十月', N'四季度', 10, 4)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (167, 2024, N'十一月', N'四季度', 11, 4)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (168, 2024, N'十二月', N'四季度', 12, 4)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (169, 2025, N'一月', N'一季度', 1, 1)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (170, 2025, N'二月', N'一季度', 2, 1)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (171, 2025, N'三月', N'一季度', 3, 1)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (172, 2025, N'四月', N'二季度', 4, 2)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (173, 2025, N'五月', N'二季度', 5, 2)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (174, 2025, N'六月', N'二季度', 6, 2)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (175, 2025, N'七月', N'三季度', 7, 3)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (176, 2025, N'八月', N'三季度', 8, 3)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (177, 2025, N'九月', N'三季度', 9, 3)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (178, 2025, N'十月', N'四季度', 10, 4)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (179, 2025, N'十一月', N'四季度', 11, 4)
INSERT [dbo].[DimTime] ([ID], [Year], [MonthName], [QuarterName], [MonthNumOfYear], [QuarterNumOfYear]) VALUES (180, 2025, N'十二月', N'四季度', 12, 4)
SET IDENTITY_INSERT [dbo].[DimTime] OFF
/****** Object:  Synonym [dbo].[Department]    Script Date: 07/27/2014 23:41:02 ******/
CREATE SYNONYM [dbo].[Department] FOR [SharpMembership].[dbo].[Department]
GO
/****** Object:  Table [dbo].[CommonFee]    Script Date: 07/27/2014 23:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CommonFee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DimTimeID] [int] NOT NULL,
	[ShipID] [int] NULL,
	[InputUserID] [int] NULL,
	[ApproveUserID] [int] NULL,
	[CreateTime] [datetime] NULL,
	[CurrencyID] [int] NOT NULL,
	[ExchangeRateID] [int] NULL,
	[FeeCatalogID] [int] NOT NULL,
	[Amount] [float] NULL,
	[备注] [nvarchar](500) NULL,
 CONSTRAINT [PK_CommonFlee] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CommonFee] ON
INSERT [dbo].[CommonFee] ([ID], [DimTimeID], [ShipID], [InputUserID], [ApproveUserID], [CreateTime], [CurrencyID], [ExchangeRateID], [FeeCatalogID], [Amount], [备注]) VALUES (2, 13, 6, 1, 0, CAST(0x0000A1F4010F098C AS DateTime), 2, 0, 1, 10000, N'TEST1')
INSERT [dbo].[CommonFee] ([ID], [DimTimeID], [ShipID], [InputUserID], [ApproveUserID], [CreateTime], [CurrencyID], [ExchangeRateID], [FeeCatalogID], [Amount], [备注]) VALUES (4, 13, NULL, NULL, 0, CAST(0x0000A1F800E7D3E4 AS DateTime), 1, 0, 1, 10000, N'test')
INSERT [dbo].[CommonFee] ([ID], [DimTimeID], [ShipID], [InputUserID], [ApproveUserID], [CreateTime], [CurrencyID], [ExchangeRateID], [FeeCatalogID], [Amount], [备注]) VALUES (6, 13, NULL, NULL, 1, CAST(0x0000A1F800E83DE8 AS DateTime), 1, 0, 13, 18900, N'test1')
INSERT [dbo].[CommonFee] ([ID], [DimTimeID], [ShipID], [InputUserID], [ApproveUserID], [CreateTime], [CurrencyID], [ExchangeRateID], [FeeCatalogID], [Amount], [备注]) VALUES (7, 13, NULL, NULL, 0, CAST(0x0000A1F800E846ED AS DateTime), 1, 0, 15, 12433, N'rwar2')
INSERT [dbo].[CommonFee] ([ID], [DimTimeID], [ShipID], [InputUserID], [ApproveUserID], [CreateTime], [CurrencyID], [ExchangeRateID], [FeeCatalogID], [Amount], [备注]) VALUES (8, 13, NULL, NULL, 0, CAST(0x0000A1F800E84EF6 AS DateTime), 1, 0, 16, 12121444, N'teset3')
INSERT [dbo].[CommonFee] ([ID], [DimTimeID], [ShipID], [InputUserID], [ApproveUserID], [CreateTime], [CurrencyID], [ExchangeRateID], [FeeCatalogID], [Amount], [备注]) VALUES (9, 13, 0, 0, 0, CAST(0x0000A1F800F7FAD0 AS DateTime), 4, 0, 5, 12312, N'test1')
INSERT [dbo].[CommonFee] ([ID], [DimTimeID], [ShipID], [InputUserID], [ApproveUserID], [CreateTime], [CurrencyID], [ExchangeRateID], [FeeCatalogID], [Amount], [备注]) VALUES (10, 13, NULL, NULL, 0, CAST(0x0000A1F800F80342 AS DateTime), 1, 0, 1, 1266, N'etset2')
INSERT [dbo].[CommonFee] ([ID], [DimTimeID], [ShipID], [InputUserID], [ApproveUserID], [CreateTime], [CurrencyID], [ExchangeRateID], [FeeCatalogID], [Amount], [备注]) VALUES (11, 18, NULL, NULL, 0, CAST(0x0000A1F800F81E5A AS DateTime), 1, 0, 16, 23123, N'test')
INSERT [dbo].[CommonFee] ([ID], [DimTimeID], [ShipID], [InputUserID], [ApproveUserID], [CreateTime], [CurrencyID], [ExchangeRateID], [FeeCatalogID], [Amount], [备注]) VALUES (12, 25, NULL, NULL, 1, CAST(0x0000A35C00775EAA AS DateTime), 1, 0, 1, 12212, N'')
INSERT [dbo].[CommonFee] ([ID], [DimTimeID], [ShipID], [InputUserID], [ApproveUserID], [CreateTime], [CurrencyID], [ExchangeRateID], [FeeCatalogID], [Amount], [备注]) VALUES (13, 29, NULL, NULL, 1, CAST(0x0000A35C007774EA AS DateTime), 1, 0, 13, 1212, N'12')
SET IDENTITY_INSERT [dbo].[CommonFee] OFF
/****** Object:  Table [dbo].[CertificateFlee]    Script Date: 07/27/2014 23:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CertificateFlee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DimTimeID] [int] NOT NULL,
	[InputUserID] [int] NULL,
	[ApproveUserID] [int] NULL,
	[CreateTime] [datetime] NULL,
	[CurrencyID] [int] NOT NULL,
	[ExchangeRateID] [int] NULL,
	[项目名称] [nvarchar](50) NULL,
	[证书类型] [int] NOT NULL,
	[发证日期] [datetime] NULL,
	[有效期至] [datetime] NULL,
	[年审有效日期] [datetime] NULL,
	[快递费] [float] NULL,
	[图纸复印费] [float] NULL,
	[洗照片] [float] NULL,
	[公正] [float] NULL,
	[其他] [float] NULL,
	[备注] [nvarchar](500) NULL,
 CONSTRAINT [PK_CertificateFlee] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CertificateFlee', @level2type=N'COLUMN',@level2name=N'DimTimeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登记人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CertificateFlee', @level2type=N'COLUMN',@level2name=N'InputUserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'财务部审核人员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CertificateFlee', @level2type=N'COLUMN',@level2name=N'ApproveUserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'币种主键，默认1为人民币' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CertificateFlee', @level2type=N'COLUMN',@level2name=N'CurrencyID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'汇率主键，默认NULL，不进行转换' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CertificateFlee', @level2type=N'COLUMN',@level2name=N'ExchangeRateID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1:公司证书;2:船舶证书' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CertificateFlee', @level2type=N'COLUMN',@level2name=N'证书类型'
GO
SET IDENTITY_INSERT [dbo].[CertificateFlee] ON
INSERT [dbo].[CertificateFlee] ([ID], [DimTimeID], [InputUserID], [ApproveUserID], [CreateTime], [CurrencyID], [ExchangeRateID], [项目名称], [证书类型], [发证日期], [有效期至], [年审有效日期], [快递费], [图纸复印费], [洗照片], [公正], [其他], [备注]) VALUES (1, 24, 1, 1, CAST(0x0000A1F700133C38 AS DateTime), 2, 1, N'国内水路运输许可证', 1, CAST(0x00009E9200000000 AS DateTime), CAST(0x0000A4C700000000 AS DateTime), CAST(0x0000A1B000000000 AS DateTime), 121, 11, 1212, 121211, 11, N'test')
SET IDENTITY_INSERT [dbo].[CertificateFlee] OFF
/****** Object:  Table [dbo].[BeijianInput]    Script Date: 07/27/2014 23:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BeijianInput](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DimTimeID] [int] NOT NULL,
	[UsageType] [int] NOT NULL,
	[InputUserID] [int] NOT NULL,
	[ApproveUserID] [int] NULL,
	[CreateTime] [datetime] NOT NULL,
	[ReportTypeID] [int] NOT NULL,
	[ShipID] [int] NULL,
	[CurrencyID] [int] NOT NULL,
	[ExchangeRateID] [int] NULL,
	[PreestimateFormID] [int] NULL,
	[AmendFormID] [int] NULL,
	[总数] [float] NOT NULL,
	[主机] [float] NULL,
	[副机] [float] NULL,
	[舾装] [float] NULL,
	[电器] [float] NULL,
	[辅机] [float] NULL,
	[分油机] [float] NULL,
 CONSTRAINT [PK_BeijianInput] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BeijianInput', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报告期主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BeijianInput', @level2type=N'COLUMN',@level2name=N'DimTimeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1：日常用、2：厂修用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BeijianInput', @level2type=N'COLUMN',@level2name=N'UsageType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登记人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BeijianInput', @level2type=N'COLUMN',@level2name=N'InputUserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'财务部审核人员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BeijianInput', @level2type=N'COLUMN',@level2name=N'ApproveUserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报表创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BeijianInput', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'币种主键，默认1为人民币' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BeijianInput', @level2type=N'COLUMN',@level2name=N'CurrencyID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'汇率主键，默认NULL，不进行转换' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BeijianInput', @level2type=N'COLUMN',@level2name=N'ExchangeRateID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'预估输入的XML表单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BeijianInput', @level2type=N'COLUMN',@level2name=N'PreestimateFormID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修正录入XML表单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BeijianInput', @level2type=N'COLUMN',@level2name=N'AmendFormID'
GO
SET IDENTITY_INSERT [dbo].[BeijianInput] ON
INSERT [dbo].[BeijianInput] ([ID], [DimTimeID], [UsageType], [InputUserID], [ApproveUserID], [CreateTime], [ReportTypeID], [ShipID], [CurrencyID], [ExchangeRateID], [PreestimateFormID], [AmendFormID], [总数], [主机], [副机], [舾装], [电器], [辅机], [分油机]) VALUES (1, 16, 0, 0, 0, CAST(0x0000A1A70010FA7C AS DateTime), 3, 1, 1, NULL, NULL, NULL, 66, 11, 11, 11, 11, 11, 11)
INSERT [dbo].[BeijianInput] ([ID], [DimTimeID], [UsageType], [InputUserID], [ApproveUserID], [CreateTime], [ReportTypeID], [ShipID], [CurrencyID], [ExchangeRateID], [PreestimateFormID], [AmendFormID], [总数], [主机], [副机], [舾装], [电器], [辅机], [分油机]) VALUES (3, 16, 0, 0, 0, CAST(0x0000A1B50138FA44 AS DateTime), 3, 4, 1, NULL, NULL, NULL, 132, 22, 22, 22, 22, 22, 22)
INSERT [dbo].[BeijianInput] ([ID], [DimTimeID], [UsageType], [InputUserID], [ApproveUserID], [CreateTime], [ReportTypeID], [ShipID], [CurrencyID], [ExchangeRateID], [PreestimateFormID], [AmendFormID], [总数], [主机], [副机], [舾装], [电器], [辅机], [分油机]) VALUES (5, 16, 0, 0, 0, CAST(0x0000A1B5013B8F34 AS DateTime), 3, 2, 1, NULL, NULL, NULL, 199, 35, 34, 33, 31, 32, 34)
SET IDENTITY_INSERT [dbo].[BeijianInput] OFF
/****** Object:  Table [dbo].[InsuranceOfCompensation]    Script Date: 07/27/2014 23:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InsuranceOfCompensation](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DimTimeID] [int] NOT NULL,
	[ShipID] [int] NOT NULL,
	[InputUserID] [int] NULL,
	[ApproveUserID] [int] NULL,
	[CreateTime] [datetime] NULL,
	[CurrencyID] [int] NOT NULL,
	[ExchangeRateID] [int] NULL,
	[BeginDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[船舶险保单号] [nvarchar](50) NULL,
	[主险保额] [float] NULL,
	[主险费率] [float] NULL,
	[主险保费] [float] NULL,
	[战争保赔险费率] [float] NULL,
	[战争保赔险保费] [float] NULL,
	[免赔额] [float] NULL,
	[船舶险总保费] [float] NULL,
	[保赔险保单号] [nvarchar](50) NULL,
	[保险期限自] [datetime] NULL,
	[保险期限到] [datetime] NULL,
	[保赔险费率] [float] NULL,
	[保赔险保费] [float] NULL,
	[备注] [nvarchar](500) NULL,
 CONSTRAINT [PK_InsuranceOfCompensation] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InsuranceOfCompensation', @level2type=N'COLUMN',@level2name=N'DimTimeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'船舶ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InsuranceOfCompensation', @level2type=N'COLUMN',@level2name=N'ShipID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登记人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InsuranceOfCompensation', @level2type=N'COLUMN',@level2name=N'InputUserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'财务部审核人员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InsuranceOfCompensation', @level2type=N'COLUMN',@level2name=N'ApproveUserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'币种主键，默认1为人民币' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InsuranceOfCompensation', @level2type=N'COLUMN',@level2name=N'CurrencyID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'汇率主键，默认NULL，不进行转换' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InsuranceOfCompensation', @level2type=N'COLUMN',@level2name=N'ExchangeRateID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'抵达时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InsuranceOfCompensation', @level2type=N'COLUMN',@level2name=N'EndDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'5万元20英尺货柜数目' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InsuranceOfCompensation', @level2type=N'COLUMN',@level2name=N'主险保额'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'5万元40英尺货柜数目' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InsuranceOfCompensation', @level2type=N'COLUMN',@level2name=N'主险费率'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'总保费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InsuranceOfCompensation', @level2type=N'COLUMN',@level2name=N'主险保费'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'（美元/吨）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InsuranceOfCompensation', @level2type=N'COLUMN',@level2name=N'保赔险费率'
GO
SET IDENTITY_INSERT [dbo].[InsuranceOfCompensation] ON
INSERT [dbo].[InsuranceOfCompensation] ([ID], [DimTimeID], [ShipID], [InputUserID], [ApproveUserID], [CreateTime], [CurrencyID], [ExchangeRateID], [BeginDate], [EndDate], [船舶险保单号], [主险保额], [主险费率], [主险保费], [战争保赔险费率], [战争保赔险保费], [免赔额], [船舶险总保费], [保赔险保单号], [保险期限自], [保险期限到], [保赔险费率], [保赔险保费], [备注]) VALUES (2, 19, 6, 1, 1, CAST(0x0000A1F4010F09FE AS DateTime), 1, NULL, CAST(0x0000A1870083D600 AS DateTime), CAST(0x0000A29A0083D600 AS DateTime), N'PCAE2013AP010000000055', 2800000, 0.7, 19600, 0.035, 980, 13000, 20580, N'PCAE2013AP010000000012', CAST(0x0000A16B0083D600 AS DateTime), CAST(0x00009FFD0083D600 AS DateTime), 6.05, 36868.7, NULL)
INSERT [dbo].[InsuranceOfCompensation] ([ID], [DimTimeID], [ShipID], [InputUserID], [ApproveUserID], [CreateTime], [CurrencyID], [ExchangeRateID], [BeginDate], [EndDate], [船舶险保单号], [主险保额], [主险费率], [主险保费], [战争保赔险费率], [战争保赔险保费], [免赔额], [船舶险总保费], [保赔险保单号], [保险期限自], [保险期限到], [保赔险费率], [保赔险保费], [备注]) VALUES (3, 16, 1, 0, NULL, CAST(0x0000A2AA0157DC4B AS DateTime), 1, 0, CAST(0x0000A2A600000000 AS DateTime), CAST(0x0000A41200000000 AS DateTime), N'1111', 121111, 121211, 0, 11111, 0, 1211, 0, N'1212', CAST(0x0000A2A600000000 AS DateTime), CAST(0x0000A41200000000 AS DateTime), 111122, 1111222, N'121212')
INSERT [dbo].[InsuranceOfCompensation] ([ID], [DimTimeID], [ShipID], [InputUserID], [ApproveUserID], [CreateTime], [CurrencyID], [ExchangeRateID], [BeginDate], [EndDate], [船舶险保单号], [主险保额], [主险费率], [主险保费], [战争保赔险费率], [战争保赔险保费], [免赔额], [船舶险总保费], [保赔险保单号], [保险期限自], [保险期限到], [保赔险费率], [保赔险保费], [备注]) VALUES (4, 25, 1, 0, NULL, CAST(0x0000A2AA0165BAAF AS DateTime), 1, 0, CAST(0x0000A2A600000000 AS DateTime), CAST(0x0000A2C400000000 AS DateTime), N'12121', 121212, 1212, 0, 111, 0, 121212, 0, N'121212', CAST(0x0000A2A600000000 AS DateTime), CAST(0x0000A41200000000 AS DateTime), 11, 121212, N'121212')
INSERT [dbo].[InsuranceOfCompensation] ([ID], [DimTimeID], [ShipID], [InputUserID], [ApproveUserID], [CreateTime], [CurrencyID], [ExchangeRateID], [BeginDate], [EndDate], [船舶险保单号], [主险保额], [主险费率], [主险保费], [战争保赔险费率], [战争保赔险保费], [免赔额], [船舶险总保费], [保赔险保单号], [保险期限自], [保险期限到], [保赔险费率], [保赔险保费], [备注]) VALUES (5, 31, 1, 1, NULL, CAST(0x0000A37501265D07 AS DateTime), 1, 0, CAST(0x0000A36300000000 AS DateTime), CAST(0x0000A37200000000 AS DateTime), N'12121', 1, 1, 0, 1, 0, 1, 0, N'1', CAST(0x0000A35C00000000 AS DateTime), CAST(0x0000A36400000000 AS DateTime), 11, 11, N'11')
SET IDENTITY_INSERT [dbo].[InsuranceOfCompensation] OFF
/****** Object:  Table [dbo].[OilUseBalance]    Script Date: 07/27/2014 23:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OilUseBalance](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BaseInputID] [int] NOT NULL,
	[OilTypeID] [int] NULL,
	[Remaining] [float] NULL,
	[Addition] [float] NULL,
	[Consuming] [float] NULL,
	[Balance] [float] NULL,
 CONSTRAINT [PK_OilUseBalance] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[OilUseBalance] ON
INSERT [dbo].[OilUseBalance] ([ID], [BaseInputID], [OilTypeID], [Remaining], [Addition], [Consuming], [Balance]) VALUES (49, 12, 1, 2, 2, 2, 2)
INSERT [dbo].[OilUseBalance] ([ID], [BaseInputID], [OilTypeID], [Remaining], [Addition], [Consuming], [Balance]) VALUES (50, 12, 2, 2, 2, 2, 2)
INSERT [dbo].[OilUseBalance] ([ID], [BaseInputID], [OilTypeID], [Remaining], [Addition], [Consuming], [Balance]) VALUES (51, 12, 3, 2, 2, 2, 2)
INSERT [dbo].[OilUseBalance] ([ID], [BaseInputID], [OilTypeID], [Remaining], [Addition], [Consuming], [Balance]) VALUES (52, 12, 4, 3, 3, 3, 3)
INSERT [dbo].[OilUseBalance] ([ID], [BaseInputID], [OilTypeID], [Remaining], [Addition], [Consuming], [Balance]) VALUES (53, 12, 5, 3, 3, 3, 3)
INSERT [dbo].[OilUseBalance] ([ID], [BaseInputID], [OilTypeID], [Remaining], [Addition], [Consuming], [Balance]) VALUES (54, 12, 6, 3, 3, 3, 3)
INSERT [dbo].[OilUseBalance] ([ID], [BaseInputID], [OilTypeID], [Remaining], [Addition], [Consuming], [Balance]) VALUES (55, 12, 8, 3, 3, 3, 3)
INSERT [dbo].[OilUseBalance] ([ID], [BaseInputID], [OilTypeID], [Remaining], [Addition], [Consuming], [Balance]) VALUES (56, 12, 9, 3, 3, 3, 3)
INSERT [dbo].[OilUseBalance] ([ID], [BaseInputID], [OilTypeID], [Remaining], [Addition], [Consuming], [Balance]) VALUES (57, 12, 7, 3, 3, 3, 3)
INSERT [dbo].[OilUseBalance] ([ID], [BaseInputID], [OilTypeID], [Remaining], [Addition], [Consuming], [Balance]) VALUES (58, 14, 1, 0, 0, 0, 0)
INSERT [dbo].[OilUseBalance] ([ID], [BaseInputID], [OilTypeID], [Remaining], [Addition], [Consuming], [Balance]) VALUES (59, 14, 2, 0, 0, 0, 0)
INSERT [dbo].[OilUseBalance] ([ID], [BaseInputID], [OilTypeID], [Remaining], [Addition], [Consuming], [Balance]) VALUES (60, 14, 3, 0, 0, 0, 0)
INSERT [dbo].[OilUseBalance] ([ID], [BaseInputID], [OilTypeID], [Remaining], [Addition], [Consuming], [Balance]) VALUES (61, 14, 4, 0, 0, 0, 0)
INSERT [dbo].[OilUseBalance] ([ID], [BaseInputID], [OilTypeID], [Remaining], [Addition], [Consuming], [Balance]) VALUES (62, 14, 5, 0, 0, 0, 0)
INSERT [dbo].[OilUseBalance] ([ID], [BaseInputID], [OilTypeID], [Remaining], [Addition], [Consuming], [Balance]) VALUES (63, 14, 6, 0, 0, 0, 0)
INSERT [dbo].[OilUseBalance] ([ID], [BaseInputID], [OilTypeID], [Remaining], [Addition], [Consuming], [Balance]) VALUES (64, 14, 8, 0, 0, 0, 0)
INSERT [dbo].[OilUseBalance] ([ID], [BaseInputID], [OilTypeID], [Remaining], [Addition], [Consuming], [Balance]) VALUES (65, 14, 9, 0, 0, 0, 0)
INSERT [dbo].[OilUseBalance] ([ID], [BaseInputID], [OilTypeID], [Remaining], [Addition], [Consuming], [Balance]) VALUES (66, 14, 7, 0, 0, 0, 0)
INSERT [dbo].[OilUseBalance] ([ID], [BaseInputID], [OilTypeID], [Remaining], [Addition], [Consuming], [Balance]) VALUES (67, 15, 1, 1, 2, 3, 0)
INSERT [dbo].[OilUseBalance] ([ID], [BaseInputID], [OilTypeID], [Remaining], [Addition], [Consuming], [Balance]) VALUES (68, 15, 2, 1, 2, 3, 0)
INSERT [dbo].[OilUseBalance] ([ID], [BaseInputID], [OilTypeID], [Remaining], [Addition], [Consuming], [Balance]) VALUES (69, 15, 3, 1, 2, 3, 0)
INSERT [dbo].[OilUseBalance] ([ID], [BaseInputID], [OilTypeID], [Remaining], [Addition], [Consuming], [Balance]) VALUES (70, 15, 4, 1, 2, 3, 0)
INSERT [dbo].[OilUseBalance] ([ID], [BaseInputID], [OilTypeID], [Remaining], [Addition], [Consuming], [Balance]) VALUES (71, 15, 5, 1, 2, 3, 0)
INSERT [dbo].[OilUseBalance] ([ID], [BaseInputID], [OilTypeID], [Remaining], [Addition], [Consuming], [Balance]) VALUES (72, 15, 6, 1, 2, 3, 0)
INSERT [dbo].[OilUseBalance] ([ID], [BaseInputID], [OilTypeID], [Remaining], [Addition], [Consuming], [Balance]) VALUES (73, 15, 8, 1, 2, 3, 0)
INSERT [dbo].[OilUseBalance] ([ID], [BaseInputID], [OilTypeID], [Remaining], [Addition], [Consuming], [Balance]) VALUES (74, 15, 9, 1, 2, 3, 0)
INSERT [dbo].[OilUseBalance] ([ID], [BaseInputID], [OilTypeID], [Remaining], [Addition], [Consuming], [Balance]) VALUES (75, 15, 7, 1, 2, 3, 0)
SET IDENTITY_INSERT [dbo].[OilUseBalance] OFF
/****** Object:  Table [dbo].[Relation_RoutePort]    Script Date: 07/27/2014 23:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Relation_RoutePort](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RouteID] [int] NOT NULL,
	[PortID] [int] NOT NULL,
	[PortTypeID] [int] NOT NULL,
	[OrderNum] [int] NOT NULL,
 CONSTRAINT [PK_RelationRoutePort] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Relation_RoutePort] ON
INSERT [dbo].[Relation_RoutePort] ([ID], [RouteID], [PortID], [PortTypeID], [OrderNum]) VALUES (1, 1, 1, 5, 1)
INSERT [dbo].[Relation_RoutePort] ([ID], [RouteID], [PortID], [PortTypeID], [OrderNum]) VALUES (2, 1, 2, 2, 0)
INSERT [dbo].[Relation_RoutePort] ([ID], [RouteID], [PortID], [PortTypeID], [OrderNum]) VALUES (3, 1, 3, 5, 3)
INSERT [dbo].[Relation_RoutePort] ([ID], [RouteID], [PortID], [PortTypeID], [OrderNum]) VALUES (4, 1, 4, 4, 99)
INSERT [dbo].[Relation_RoutePort] ([ID], [RouteID], [PortID], [PortTypeID], [OrderNum]) VALUES (38, 20, 3, 2, 0)
INSERT [dbo].[Relation_RoutePort] ([ID], [RouteID], [PortID], [PortTypeID], [OrderNum]) VALUES (39, 20, 2, 4, 99)
INSERT [dbo].[Relation_RoutePort] ([ID], [RouteID], [PortID], [PortTypeID], [OrderNum]) VALUES (58, 1, 4, 5, 1)
INSERT [dbo].[Relation_RoutePort] ([ID], [RouteID], [PortID], [PortTypeID], [OrderNum]) VALUES (59, 1, 3, 5, 2)
INSERT [dbo].[Relation_RoutePort] ([ID], [RouteID], [PortID], [PortTypeID], [OrderNum]) VALUES (60, 1, 5, 5, 3)
INSERT [dbo].[Relation_RoutePort] ([ID], [RouteID], [PortID], [PortTypeID], [OrderNum]) VALUES (61, 20, 1, 5, 1)
INSERT [dbo].[Relation_RoutePort] ([ID], [RouteID], [PortID], [PortTypeID], [OrderNum]) VALUES (62, 20, 3, 5, 2)
INSERT [dbo].[Relation_RoutePort] ([ID], [RouteID], [PortID], [PortTypeID], [OrderNum]) VALUES (63, 20, 6, 5, 3)
INSERT [dbo].[Relation_RoutePort] ([ID], [RouteID], [PortID], [PortTypeID], [OrderNum]) VALUES (64, 30, 8, 2, 0)
INSERT [dbo].[Relation_RoutePort] ([ID], [RouteID], [PortID], [PortTypeID], [OrderNum]) VALUES (65, 30, 10, 4, 99)
INSERT [dbo].[Relation_RoutePort] ([ID], [RouteID], [PortID], [PortTypeID], [OrderNum]) VALUES (66, 30, 9, 5, 1)
INSERT [dbo].[Relation_RoutePort] ([ID], [RouteID], [PortID], [PortTypeID], [OrderNum]) VALUES (67, 31, 5, 2, 0)
INSERT [dbo].[Relation_RoutePort] ([ID], [RouteID], [PortID], [PortTypeID], [OrderNum]) VALUES (68, 31, 1, 4, 99)
INSERT [dbo].[Relation_RoutePort] ([ID], [RouteID], [PortID], [PortTypeID], [OrderNum]) VALUES (69, 31, 10, 5, 1)
SET IDENTITY_INSERT [dbo].[Relation_RoutePort] OFF
/****** Object:  Table [dbo].[JianyanInput]    Script Date: 07/27/2014 23:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JianyanInput](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DimTimeID] [int] NOT NULL,
	[InputUserID] [int] NOT NULL,
	[ApproveUserID] [int] NULL,
	[CreateTime] [datetime] NOT NULL,
	[ReportTypeID] [int] NOT NULL,
	[CurrencyID] [int] NOT NULL,
	[ExchangeRateID] [int] NULL,
	[PreestimateFormID] [int] NULL,
	[AmendFormID] [int] NULL,
	[总数] [float] NOT NULL,
	[ShipID] [int] NULL,
 CONSTRAINT [PK_JianyanInput] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'JianyanInput', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报告期主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'JianyanInput', @level2type=N'COLUMN',@level2name=N'DimTimeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登记人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'JianyanInput', @level2type=N'COLUMN',@level2name=N'InputUserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'财务部审核人员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'JianyanInput', @level2type=N'COLUMN',@level2name=N'ApproveUserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报表创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'JianyanInput', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'币种主键，默认1为人民币' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'JianyanInput', @level2type=N'COLUMN',@level2name=N'CurrencyID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'汇率主键，默认NULL，不进行转换' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'JianyanInput', @level2type=N'COLUMN',@level2name=N'ExchangeRateID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'预估输入的XML表单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'JianyanInput', @level2type=N'COLUMN',@level2name=N'PreestimateFormID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修正录入XML表单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'JianyanInput', @level2type=N'COLUMN',@level2name=N'AmendFormID'
GO
SET IDENTITY_INSERT [dbo].[JianyanInput] ON
INSERT [dbo].[JianyanInput] ([ID], [DimTimeID], [InputUserID], [ApproveUserID], [CreateTime], [ReportTypeID], [CurrencyID], [ExchangeRateID], [PreestimateFormID], [AmendFormID], [总数], [ShipID]) VALUES (1, 16, 0, 0, CAST(0x0000A1A7001397A0 AS DateTime), 1, 1, NULL, NULL, NULL, 12223111, NULL)
INSERT [dbo].[JianyanInput] ([ID], [DimTimeID], [InputUserID], [ApproveUserID], [CreateTime], [ReportTypeID], [CurrencyID], [ExchangeRateID], [PreestimateFormID], [AmendFormID], [总数], [ShipID]) VALUES (2, 17, 0, NULL, CAST(0x0000A1B5015922B0 AS DateTime), 1, 1, NULL, NULL, NULL, 111, 1)
INSERT [dbo].[JianyanInput] ([ID], [DimTimeID], [InputUserID], [ApproveUserID], [CreateTime], [ReportTypeID], [CurrencyID], [ExchangeRateID], [PreestimateFormID], [AmendFormID], [总数], [ShipID]) VALUES (3, 17, 0, NULL, CAST(0x0000A1B50159369C AS DateTime), 2, 1, NULL, NULL, NULL, 222, 1)
INSERT [dbo].[JianyanInput] ([ID], [DimTimeID], [InputUserID], [ApproveUserID], [CreateTime], [ReportTypeID], [CurrencyID], [ExchangeRateID], [PreestimateFormID], [AmendFormID], [总数], [ShipID]) VALUES (4, 17, 0, 0, CAST(0x0000A1B501594704 AS DateTime), 3, 1, NULL, NULL, NULL, 4444, 4)
SET IDENTITY_INSERT [dbo].[JianyanInput] OFF
/****** Object:  Table [dbo].[Invoice]    Script Date: 07/27/2014 23:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Number] [nvarchar](50) NOT NULL,
	[PersonName] [nvarchar](50) NULL,
	[Amout] [float] NULL,
	[CurrencyID] [int] NOT NULL,
	[ExchangeRateID] [int] NULL,
	[Rate] [float] NULL,
	[InputDate] [datetime] NOT NULL,
	[ScanImage] [image] NULL,
	[Remark] [nvarchar](500) NULL,
	[URL] [nvarchar](250) NULL,
	[CreateTime] [datetime] NOT NULL,
	[ReportType] [nvarchar](50) NULL,
	[KeyID] [nvarchar](50) NULL,
 CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发票编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Invoice', @level2type=N'COLUMN',@level2name=N'Number'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'税率（%）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Invoice', @level2type=N'COLUMN',@level2name=N'Rate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'开票时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Invoice', @level2type=N'COLUMN',@level2name=N'InputDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'税率' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Invoice', @level2type=N'COLUMN',@level2name=N'ScanImage'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'录入日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Invoice', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报表类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Invoice', @level2type=N'COLUMN',@level2name=N'ReportType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报表主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Invoice', @level2type=N'COLUMN',@level2name=N'KeyID'
GO
SET IDENTITY_INSERT [dbo].[Invoice] ON
INSERT [dbo].[Invoice] ([ID], [Number], [PersonName], [Amout], [CurrencyID], [ExchangeRateID], [Rate], [InputDate], [ScanImage], [Remark], [URL], [CreateTime], [ReportType], [KeyID]) VALUES (1, N'1111', NULL, 1111, 1, NULL, 0, CAST(0x0000A28300F532EB AS DateTime), NULL, N'', N'View1.jpg', CAST(0x0000A1D101686DEC AS DateTime), N'1', N'7')
INSERT [dbo].[Invoice] ([ID], [Number], [PersonName], [Amout], [CurrencyID], [ExchangeRateID], [Rate], [InputDate], [ScanImage], [Remark], [URL], [CreateTime], [ReportType], [KeyID]) VALUES (2, N'11222', NULL, 221, 1, NULL, 0, CAST(0x0000A28300F532EB AS DateTime), NULL, N'', N'View1.jpg', CAST(0x0000A1D101709B81 AS DateTime), N'1', N'7')
INSERT [dbo].[Invoice] ([ID], [Number], [PersonName], [Amout], [CurrencyID], [ExchangeRateID], [Rate], [InputDate], [ScanImage], [Remark], [URL], [CreateTime], [ReportType], [KeyID]) VALUES (3, N'estset1111', N'test', 12121212, 1, 0, 0.17, CAST(0x0000A283010560E4 AS DateTime), NULL, N'', N'View1.jpg', CAST(0x0000A2830105CAB2 AS DateTime), N'1', N'12')
INSERT [dbo].[Invoice] ([ID], [Number], [PersonName], [Amout], [CurrencyID], [ExchangeRateID], [Rate], [InputDate], [ScanImage], [Remark], [URL], [CreateTime], [ReportType], [KeyID]) VALUES (4, N'1231232', N'erwer', 2333, 2, 0, 0.11, CAST(0x0000A26C00000000 AS DateTime), NULL, N'', N'View1.jpg', CAST(0x0000A2830105E09E AS DateTime), N'1', N'12')
INSERT [dbo].[Invoice] ([ID], [Number], [PersonName], [Amout], [CurrencyID], [ExchangeRateID], [Rate], [InputDate], [ScanImage], [Remark], [URL], [CreateTime], [ReportType], [KeyID]) VALUES (5, N'12312', N'test', 1123222, 2, 0, 0.17, CAST(0x0000A26C00000000 AS DateTime), NULL, N'', N'View1.jpg', CAST(0x0000A287016436D7 AS DateTime), N'12', N'4')
INSERT [dbo].[Invoice] ([ID], [Number], [PersonName], [Amout], [CurrencyID], [ExchangeRateID], [Rate], [InputDate], [ScanImage], [Remark], [URL], [CreateTime], [ReportType], [KeyID]) VALUES (6, N'21312', N'test', 112233.22, 2, 0, 0.17, CAST(0x0000A28A00EA8904 AS DateTime), NULL, N'', N'View1.jpg', CAST(0x0000A28A00EA9644 AS DateTime), N'1', N'13')
INSERT [dbo].[Invoice] ([ID], [Number], [PersonName], [Amout], [CurrencyID], [ExchangeRateID], [Rate], [InputDate], [ScanImage], [Remark], [URL], [CreateTime], [ReportType], [KeyID]) VALUES (7, N'123123', N'122', 123123123, 1, 0, 0.17, CAST(0x0000A28800000000 AS DateTime), NULL, N'', N'7_123123.jpg', CAST(0x0000A295011A86F4 AS DateTime), N'1', N'1')
INSERT [dbo].[Invoice] ([ID], [Number], [PersonName], [Amout], [CurrencyID], [ExchangeRateID], [Rate], [InputDate], [ScanImage], [Remark], [URL], [CreateTime], [ReportType], [KeyID]) VALUES (8, N'234', N'234', 2334, 2, 0, 0.17, CAST(0x0000A2950127C530 AS DateTime), NULL, N'', N'View1.jpg', CAST(0x0000A2950127CFBC AS DateTime), N'1', N'4')
INSERT [dbo].[Invoice] ([ID], [Number], [PersonName], [Amout], [CurrencyID], [ExchangeRateID], [Rate], [InputDate], [ScanImage], [Remark], [URL], [CreateTime], [ReportType], [KeyID]) VALUES (9, N'34232234', N'', 123123, 1, 0, 0.17, CAST(0x0000A2B400B95F14 AS DateTime), NULL, N'', N'', CAST(0x0000A2B400BACC6D AS DateTime), N'8', N'7')
INSERT [dbo].[Invoice] ([ID], [Number], [PersonName], [Amout], [CurrencyID], [ExchangeRateID], [Rate], [InputDate], [ScanImage], [Remark], [URL], [CreateTime], [ReportType], [KeyID]) VALUES (10, N'121212', N'test', 36, 1, 0, 0.17, CAST(0x0000A35C00771E88 AS DateTime), NULL, N'', N'', CAST(0x0000A35C00772ECD AS DateTime), N'1', N'14')
SET IDENTITY_INSERT [dbo].[Invoice] OFF
/****** Object:  Table [dbo].[SampleReport]    Script Date: 07/27/2014 23:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SampleReport](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[ReportTypeID] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[DateID] [int] NOT NULL,
	[Data1] [float] NULL,
	[Data2] [float] NULL,
	[Data3] [float] NULL,
	[ApproveDocument] [nvarchar](500) NULL,
 CONSTRAINT [PK_SampleReport] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SampleReport', @level2type=N'COLUMN',@level2name=N'UserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报表类型主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SampleReport', @level2type=N'COLUMN',@level2name=N'ReportTypeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报表生成时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SampleReport', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日期主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SampleReport', @level2type=N'COLUMN',@level2name=N'DateID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'批文编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SampleReport', @level2type=N'COLUMN',@level2name=N'ApproveDocument'
GO
/****** Object:  Table [dbo].[RentContainerReport]    Script Date: 07/27/2014 23:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RentContainerReport](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Customer] [nvarchar](200) NULL,
	[TaxNo] [nvarchar](200) NULL,
	[CurrencyID] [int] NOT NULL,
	[User1] [nvarchar](200) NULL,
	[User2] [nvarchar](200) NULL,
	[User3] [nvarchar](200) NULL,
	[InputDate] [datetime] NULL,
	[CreateTime] [datetime] NULL,
	[Amount] [float] NULL,
	[BeginDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[RentDays] [int] NOT NULL,
	[Remark] [nvarchar](2000) NULL,
 CONSTRAINT [PK_RentContainerReport] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RentContainerReport', @level2type=N'COLUMN',@level2name=N'Customer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'纳税识别号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RentContainerReport', @level2type=N'COLUMN',@level2name=N'TaxNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'租金计费币种' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RentContainerReport', @level2type=N'COLUMN',@level2name=N'CurrencyID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主管' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RentContainerReport', @level2type=N'COLUMN',@level2name=N'User1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RentContainerReport', @level2type=N'COLUMN',@level2name=N'User2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'制表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RentContainerReport', @level2type=N'COLUMN',@level2name=N'User3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登记时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RentContainerReport', @level2type=N'COLUMN',@level2name=N'InputDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登记时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RentContainerReport', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'总费用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RentContainerReport', @level2type=N'COLUMN',@level2name=N'Amount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'租金计算开始时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RentContainerReport', @level2type=N'COLUMN',@level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'租金计算结束时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RentContainerReport', @level2type=N'COLUMN',@level2name=N'EndDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RentContainerReport', @level2type=N'COLUMN',@level2name=N'Remark'
GO
SET IDENTITY_INSERT [dbo].[RentContainerReport] ON
INSERT [dbo].[RentContainerReport] ([ID], [Customer], [TaxNo], [CurrencyID], [User1], [User2], [User3], [InputDate], [CreateTime], [Amount], [BeginDate], [EndDate], [RentDays], [Remark]) VALUES (1, N'承租方', N'纳税识别', 2, N'12', N'1', N'2', CAST(0x0000A3250108C66C AS DateTime), CAST(0x0000A3250108C66C AS DateTime), 0, CAST(0x0000A31D00000000 AS DateTime), CAST(0x0000A31F00000000 AS DateTime), 1, N'1212')
SET IDENTITY_INSERT [dbo].[RentContainerReport] OFF
/****** Object:  Table [dbo].[VoyageConsume]    Script Date: 07/27/2014 23:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VoyageConsume](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BaseInputID] [int] NOT NULL,
	[ShipComponentID] [int] NOT NULL,
	[MainSlowWorkTime] [float] NULL,
	[MainCruiseWorkTime] [float] NULL,
	[VoyageWorkTime] [float] NULL,
	[FuelConsume] [float] NULL,
	[DieselConsume] [float] NULL,
	[OtherConsume] [float] NULL,
 CONSTRAINT [PK_VoyageConsume] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[VoyageConsume] ON
INSERT [dbo].[VoyageConsume] ([ID], [BaseInputID], [ShipComponentID], [MainSlowWorkTime], [MainCruiseWorkTime], [VoyageWorkTime], [FuelConsume], [DieselConsume], [OtherConsume]) VALUES (41, 12, 1, 1, 1, 1, 1, 1, 1)
INSERT [dbo].[VoyageConsume] ([ID], [BaseInputID], [ShipComponentID], [MainSlowWorkTime], [MainCruiseWorkTime], [VoyageWorkTime], [FuelConsume], [DieselConsume], [OtherConsume]) VALUES (42, 12, 2, 0, 0, 1, 1, 1, 1)
INSERT [dbo].[VoyageConsume] ([ID], [BaseInputID], [ShipComponentID], [MainSlowWorkTime], [MainCruiseWorkTime], [VoyageWorkTime], [FuelConsume], [DieselConsume], [OtherConsume]) VALUES (43, 12, 3, 0, 0, 1, 1, 1, 1)
INSERT [dbo].[VoyageConsume] ([ID], [BaseInputID], [ShipComponentID], [MainSlowWorkTime], [MainCruiseWorkTime], [VoyageWorkTime], [FuelConsume], [DieselConsume], [OtherConsume]) VALUES (44, 12, 4, 0, 0, 1, 1, 1, 1)
INSERT [dbo].[VoyageConsume] ([ID], [BaseInputID], [ShipComponentID], [MainSlowWorkTime], [MainCruiseWorkTime], [VoyageWorkTime], [FuelConsume], [DieselConsume], [OtherConsume]) VALUES (45, 12, 4, 0, 0, 1, 1, 1, 1)
INSERT [dbo].[VoyageConsume] ([ID], [BaseInputID], [ShipComponentID], [MainSlowWorkTime], [MainCruiseWorkTime], [VoyageWorkTime], [FuelConsume], [DieselConsume], [OtherConsume]) VALUES (46, 12, 5, 0, 0, 1, 1, 1, 1)
INSERT [dbo].[VoyageConsume] ([ID], [BaseInputID], [ShipComponentID], [MainSlowWorkTime], [MainCruiseWorkTime], [VoyageWorkTime], [FuelConsume], [DieselConsume], [OtherConsume]) VALUES (47, 14, 1, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[VoyageConsume] ([ID], [BaseInputID], [ShipComponentID], [MainSlowWorkTime], [MainCruiseWorkTime], [VoyageWorkTime], [FuelConsume], [DieselConsume], [OtherConsume]) VALUES (48, 14, 2, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[VoyageConsume] ([ID], [BaseInputID], [ShipComponentID], [MainSlowWorkTime], [MainCruiseWorkTime], [VoyageWorkTime], [FuelConsume], [DieselConsume], [OtherConsume]) VALUES (49, 14, 3, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[VoyageConsume] ([ID], [BaseInputID], [ShipComponentID], [MainSlowWorkTime], [MainCruiseWorkTime], [VoyageWorkTime], [FuelConsume], [DieselConsume], [OtherConsume]) VALUES (50, 14, 4, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[VoyageConsume] ([ID], [BaseInputID], [ShipComponentID], [MainSlowWorkTime], [MainCruiseWorkTime], [VoyageWorkTime], [FuelConsume], [DieselConsume], [OtherConsume]) VALUES (51, 14, 4, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[VoyageConsume] ([ID], [BaseInputID], [ShipComponentID], [MainSlowWorkTime], [MainCruiseWorkTime], [VoyageWorkTime], [FuelConsume], [DieselConsume], [OtherConsume]) VALUES (52, 14, 5, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[VoyageConsume] ([ID], [BaseInputID], [ShipComponentID], [MainSlowWorkTime], [MainCruiseWorkTime], [VoyageWorkTime], [FuelConsume], [DieselConsume], [OtherConsume]) VALUES (53, 14, 4, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[VoyageConsume] ([ID], [BaseInputID], [ShipComponentID], [MainSlowWorkTime], [MainCruiseWorkTime], [VoyageWorkTime], [FuelConsume], [DieselConsume], [OtherConsume]) VALUES (54, 14, 4, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[VoyageConsume] ([ID], [BaseInputID], [ShipComponentID], [MainSlowWorkTime], [MainCruiseWorkTime], [VoyageWorkTime], [FuelConsume], [DieselConsume], [OtherConsume]) VALUES (55, 15, 1, 1, 2, 3, 4, 5, 6)
INSERT [dbo].[VoyageConsume] ([ID], [BaseInputID], [ShipComponentID], [MainSlowWorkTime], [MainCruiseWorkTime], [VoyageWorkTime], [FuelConsume], [DieselConsume], [OtherConsume]) VALUES (56, 15, 2, 0, 0, 3, 4, 5, 6)
INSERT [dbo].[VoyageConsume] ([ID], [BaseInputID], [ShipComponentID], [MainSlowWorkTime], [MainCruiseWorkTime], [VoyageWorkTime], [FuelConsume], [DieselConsume], [OtherConsume]) VALUES (57, 15, 3, 0, 0, 3, 4, 5, 6)
INSERT [dbo].[VoyageConsume] ([ID], [BaseInputID], [ShipComponentID], [MainSlowWorkTime], [MainCruiseWorkTime], [VoyageWorkTime], [FuelConsume], [DieselConsume], [OtherConsume]) VALUES (58, 15, 4, 0, 0, 3, 4, 5, 6)
INSERT [dbo].[VoyageConsume] ([ID], [BaseInputID], [ShipComponentID], [MainSlowWorkTime], [MainCruiseWorkTime], [VoyageWorkTime], [FuelConsume], [DieselConsume], [OtherConsume]) VALUES (59, 15, 4, 0, 0, 3, 4, 5, 6)
INSERT [dbo].[VoyageConsume] ([ID], [BaseInputID], [ShipComponentID], [MainSlowWorkTime], [MainCruiseWorkTime], [VoyageWorkTime], [FuelConsume], [DieselConsume], [OtherConsume]) VALUES (60, 15, 5, 0, 0, 3, 4, 5, 6)
INSERT [dbo].[VoyageConsume] ([ID], [BaseInputID], [ShipComponentID], [MainSlowWorkTime], [MainCruiseWorkTime], [VoyageWorkTime], [FuelConsume], [DieselConsume], [OtherConsume]) VALUES (61, 15, 4, 0, 0, 3, 4, 5, 6)
INSERT [dbo].[VoyageConsume] ([ID], [BaseInputID], [ShipComponentID], [MainSlowWorkTime], [MainCruiseWorkTime], [VoyageWorkTime], [FuelConsume], [DieselConsume], [OtherConsume]) VALUES (62, 15, 4, 0, 0, 3, 4, 5, 6)
INSERT [dbo].[VoyageConsume] ([ID], [BaseInputID], [ShipComponentID], [MainSlowWorkTime], [MainCruiseWorkTime], [VoyageWorkTime], [FuelConsume], [DieselConsume], [OtherConsume]) VALUES (63, 15, 4, 0, 0, 3, 4, 5, 6)
SET IDENTITY_INSERT [dbo].[VoyageConsume] OFF
/****** Object:  Table [dbo].[Voyage]    Script Date: 07/27/2014 23:41:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Voyage](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[RouteID] [int] NOT NULL,
	[ShipID] [int] NOT NULL,
	[BeginDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[HangciBaseID] [int] NULL,
	[OrderNum] [int] NOT NULL,
	[VoyageLoadID] [int] NULL,
	[ManagerTypeID] [int] NOT NULL,
 CONSTRAINT [PK_Voyage] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'航次名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Voyage', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'航次起始时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Voyage', @level2type=N'COLUMN',@level2name=N'BeginDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'航次结束时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Voyage', @level2type=N'COLUMN',@level2name=N'EndDate'
GO
SET IDENTITY_INSERT [dbo].[Voyage] ON
INSERT [dbo].[Voyage] ([ID], [Name], [RouteID], [ShipID], [BeginDate], [EndDate], [HangciBaseID], [OrderNum], [VoyageLoadID], [ManagerTypeID]) VALUES (20, N'cs01', 1, 2, CAST(0x0000A1D0008C1360 AS DateTime), CAST(0x0000A1E90130DEE0 AS DateTime), 12, 1, 13, 1)
INSERT [dbo].[Voyage] ([ID], [Name], [RouteID], [ShipID], [BeginDate], [EndDate], [HangciBaseID], [OrderNum], [VoyageLoadID], [ManagerTypeID]) VALUES (21, N'cs02', 1, 1, CAST(0x0000A1EA00000000 AS DateTime), CAST(0x0000A1EC00000000 AS DateTime), 12, 1, NULL, 1)
INSERT [dbo].[Voyage] ([ID], [Name], [RouteID], [ShipID], [BeginDate], [EndDate], [HangciBaseID], [OrderNum], [VoyageLoadID], [ManagerTypeID]) VALUES (22, N'cs03', 1, 2, CAST(0x0000A251008C1360 AS DateTime), CAST(0x0000A2670130DEE0 AS DateTime), 13, 1, NULL, 1)
INSERT [dbo].[Voyage] ([ID], [Name], [RouteID], [ShipID], [BeginDate], [EndDate], [HangciBaseID], [OrderNum], [VoyageLoadID], [ManagerTypeID]) VALUES (23, N'cs04', 1, 1, CAST(0x0000A21A008C1360 AS DateTime), CAST(0x0000A21C0130DEE0 AS DateTime), 13, 1, NULL, 1)
INSERT [dbo].[Voyage] ([ID], [Name], [RouteID], [ShipID], [BeginDate], [EndDate], [HangciBaseID], [OrderNum], [VoyageLoadID], [ManagerTypeID]) VALUES (24, N'20130911', 1, 2, CAST(0x0000A25100000000 AS DateTime), CAST(0x0000A26700000000 AS DateTime), 15, 1, NULL, 1)
INSERT [dbo].[Voyage] ([ID], [Name], [RouteID], [ShipID], [BeginDate], [EndDate], [HangciBaseID], [OrderNum], [VoyageLoadID], [ManagerTypeID]) VALUES (25, N'20131002', 1, 1, CAST(0x0000A24A00000000 AS DateTime), CAST(0x0000A25F00000000 AS DateTime), NULL, 1, NULL, 1)
INSERT [dbo].[Voyage] ([ID], [Name], [RouteID], [ShipID], [BeginDate], [EndDate], [HangciBaseID], [OrderNum], [VoyageLoadID], [ManagerTypeID]) VALUES (26, N'20130501', 1, 1, CAST(0x0000A23500000000 AS DateTime), CAST(0x0000A24400000000 AS DateTime), 14, 1, NULL, 1)
INSERT [dbo].[Voyage] ([ID], [Name], [RouteID], [ShipID], [BeginDate], [EndDate], [HangciBaseID], [OrderNum], [VoyageLoadID], [ManagerTypeID]) VALUES (28, N'20130122', 1, 1, CAST(0x0000A24A00000000 AS DateTime), CAST(0x0000A25F00000000 AS DateTime), 14, 12, NULL, 1)
INSERT [dbo].[Voyage] ([ID], [Name], [RouteID], [ShipID], [BeginDate], [EndDate], [HangciBaseID], [OrderNum], [VoyageLoadID], [ManagerTypeID]) VALUES (29, N'20131126', 1, 2, CAST(0x0000A28200000000 AS DateTime), CAST(0x0000A28500000000 AS DateTime), NULL, 1, NULL, 1)
INSERT [dbo].[Voyage] ([ID], [Name], [RouteID], [ShipID], [BeginDate], [EndDate], [HangciBaseID], [OrderNum], [VoyageLoadID], [ManagerTypeID]) VALUES (31, N'1401', 1, 7, CAST(0x0000A31E00000000 AS DateTime), CAST(0x0000A32D00000000 AS DateTime), NULL, 1, NULL, 3)
INSERT [dbo].[Voyage] ([ID], [Name], [RouteID], [ShipID], [BeginDate], [EndDate], [HangciBaseID], [OrderNum], [VoyageLoadID], [ManagerTypeID]) VALUES (32, N'1343', 1, 7, CAST(0x0000A31E00000000 AS DateTime), CAST(0x0000A32B00000000 AS DateTime), NULL, 1343, NULL, 1)
INSERT [dbo].[Voyage] ([ID], [Name], [RouteID], [ShipID], [BeginDate], [EndDate], [HangciBaseID], [OrderNum], [VoyageLoadID], [ManagerTypeID]) VALUES (33, N'1401', 30, 1, CAST(0x0000A2DA00000000 AS DateTime), CAST(0x0000A2F000000000 AS DateTime), NULL, 2, NULL, 2)
INSERT [dbo].[Voyage] ([ID], [Name], [RouteID], [ShipID], [BeginDate], [EndDate], [HangciBaseID], [OrderNum], [VoyageLoadID], [ManagerTypeID]) VALUES (34, N'1344', 1, 7, CAST(0x0000A33F00350250 AS DateTime), CAST(0x0000A354014FA1E0 AS DateTime), NULL, 1344, NULL, 3)
INSERT [dbo].[Voyage] ([ID], [Name], [RouteID], [ShipID], [BeginDate], [EndDate], [HangciBaseID], [OrderNum], [VoyageLoadID], [ManagerTypeID]) VALUES (35, N'1345', 1, 7, CAST(0x0000A35400000000 AS DateTime), CAST(0x0000A35400000000 AS DateTime), NULL, 1345, NULL, 1)
INSERT [dbo].[Voyage] ([ID], [Name], [RouteID], [ShipID], [BeginDate], [EndDate], [HangciBaseID], [OrderNum], [VoyageLoadID], [ManagerTypeID]) VALUES (36, N'1346', 1, 7, CAST(0x0000A35400000000 AS DateTime), CAST(0x0000A35400000000 AS DateTime), NULL, 1346, NULL, 4)
INSERT [dbo].[Voyage] ([ID], [Name], [RouteID], [ShipID], [BeginDate], [EndDate], [HangciBaseID], [OrderNum], [VoyageLoadID], [ManagerTypeID]) VALUES (37, N'1347', 1, 7, CAST(0x0000A35400000000 AS DateTime), CAST(0x0000A35400000000 AS DateTime), NULL, 1347, NULL, 1)
SET IDENTITY_INSERT [dbo].[Voyage] OFF
/****** Object:  View [dbo].[V_RentShipReport]    Script Date: 07/27/2014 23:41:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_RentShipReport]
AS
SELECT     dbo.RentShipReport.ID, dbo.RentShipReport.ShipID, dbo.RentShipReport.Customer, dbo.RentShipReport.TaxNo, dbo.RentShipReport.BeginDate, 
                      dbo.RentShipReport.EndDate, dbo.RentShipReport.DiscountDays, dbo.RentShipReport.RealDays, dbo.RentShipReport.Price, dbo.RentShipReport.CommunicateFee, 
                      dbo.RentShipReport.LockFee, dbo.RentShipReport.OtherFee, dbo.RentShipReport.Remark, dbo.RentShipReport.User1, dbo.RentShipReport.User2, 
                      dbo.RentShipReport.User3, dbo.Ship.Name AS ShipName, dbo.RentShipReport.CurrencyID, dbo.Currency.Name AS CurrencyName, dbo.RentShipReport.CreateTime, 
                      dbo.RentShipReport.InputDate, dbo.RentShipReport.RentDays, dbo.RentShipReport.Amount, dbo.RentShipReport.RentTypeID, dbo.RentShipReport.RentFee
FROM         dbo.RentShipReport INNER JOIN
                      dbo.Currency ON dbo.RentShipReport.CurrencyID = dbo.Currency.ID INNER JOIN
                      dbo.Ship ON dbo.RentShipReport.ShipID = dbo.Ship.ID
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
         Begin Table = "RentShipReport"
            Begin Extent = 
               Top = 35
               Left = 497
               Bottom = 263
               Right = 662
            End
            DisplayFlags = 280
            TopColumn = 12
         End
         Begin Table = "Currency"
            Begin Extent = 
               Top = 142
               Left = 243
               Bottom = 231
               Right = 385
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Ship"
            Begin Extent = 
               Top = 6
               Left = 247
               Bottom = 125
               Right = 415
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
      Begin ColumnWidths = 22
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
         Column = 2040
         Alias = 1770
         Table = 1635
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
      ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_RentShipReport'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'   Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_RentShipReport'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_RentShipReport'
GO
/****** Object:  Table [dbo].[ExchangeRate]    Script Date: 07/27/2014 23:41:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExchangeRate](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DimTimeID] [int] NOT NULL,
	[Rate] [float] NOT NULL,
	[CurrencyID] [int] NOT NULL,
 CONSTRAINT [PK_ExchangeRate] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'汇率转换：人民币=外币/汇率' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ExchangeRate', @level2type=N'COLUMN',@level2name=N'Rate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'币种主键，默认1为人民币' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ExchangeRate', @level2type=N'COLUMN',@level2name=N'CurrencyID'
GO
SET IDENTITY_INSERT [dbo].[ExchangeRate] ON
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (1, 1, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (2, 2, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (3, 3, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (4, 4, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (5, 5, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (6, 6, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (7, 7, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (8, 8, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (9, 9, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (10, 10, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (11, 11, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (12, 12, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (14, 13, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (15, 14, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (16, 15, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (17, 16, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (18, 17, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (20, 18, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (21, 19, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (22, 20, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (23, 21, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (24, 22, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (25, 23, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (26, 24, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (27, 25, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (28, 26, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (29, 27, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (30, 28, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (31, 29, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (32, 30, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (33, 31, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (34, 32, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (35, 33, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (36, 34, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (37, 35, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (38, 36, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (39, 37, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (40, 38, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (41, 39, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (42, 40, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (43, 41, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (44, 42, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (45, 43, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (46, 44, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (47, 45, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (48, 46, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (49, 47, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (50, 48, 0.1641, 2)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (51, 1, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (52, 2, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (53, 3, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (54, 4, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (55, 5, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (56, 6, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (57, 7, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (58, 8, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (59, 9, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (60, 10, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (61, 11, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (62, 12, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (63, 13, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (64, 14, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (65, 15, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (66, 16, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (67, 17, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (68, 18, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (69, 19, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (70, 20, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (71, 21, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (72, 22, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (73, 23, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (74, 24, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (75, 25, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (76, 26, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (77, 27, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (78, 28, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (79, 29, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (80, 30, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (81, 31, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (82, 32, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (83, 33, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (84, 34, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (85, 35, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (86, 36, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (87, 37, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (88, 38, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (89, 39, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (90, 40, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (91, 41, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (92, 42, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (93, 43, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (94, 44, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (95, 45, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (96, 46, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (97, 47, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (98, 48, 16.8439, 3)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (195, 1, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (196, 2, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (197, 3, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (198, 4, 4.8495, 4)
GO
print 'Processed 100 total records'
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (199, 5, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (200, 6, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (201, 7, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (202, 8, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (203, 9, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (204, 10, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (205, 11, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (206, 12, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (207, 13, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (208, 14, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (209, 15, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (210, 16, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (211, 17, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (212, 18, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (213, 19, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (214, 20, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (215, 21, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (216, 22, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (217, 23, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (218, 24, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (219, 25, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (220, 26, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (221, 27, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (222, 28, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (223, 29, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (224, 30, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (225, 31, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (226, 32, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (227, 33, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (228, 34, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (229, 35, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (230, 36, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (231, 37, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (232, 38, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (233, 39, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (234, 40, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (235, 41, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (236, 42, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (237, 43, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (238, 44, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (239, 45, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (240, 46, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (241, 47, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (242, 48, 4.8495, 4)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (243, 1, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (244, 2, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (245, 3, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (246, 4, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (247, 5, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (248, 6, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (249, 7, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (250, 8, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (251, 9, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (252, 10, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (253, 11, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (254, 12, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (255, 13, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (256, 14, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (257, 15, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (258, 16, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (259, 17, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (260, 18, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (261, 19, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (262, 20, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (263, 21, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (264, 22, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (265, 23, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (266, 24, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (267, 25, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (268, 26, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (269, 27, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (270, 28, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (271, 29, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (272, 30, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (273, 31, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (274, 32, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (275, 33, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (276, 34, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (277, 35, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (278, 36, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (279, 37, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (280, 38, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (281, 39, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (282, 40, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (283, 41, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (284, 42, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (285, 43, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (286, 44, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (287, 45, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (288, 46, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (289, 47, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (290, 48, 0.2058, 6)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (291, 1, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (292, 2, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (293, 3, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (294, 4, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (295, 5, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (296, 6, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (297, 7, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (298, 8, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (299, 9, 1.2725, 5)
GO
print 'Processed 200 total records'
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (300, 10, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (301, 11, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (302, 12, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (303, 13, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (304, 14, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (305, 15, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (306, 16, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (307, 17, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (308, 18, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (309, 19, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (310, 20, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (311, 21, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (312, 22, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (313, 23, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (314, 24, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (315, 25, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (316, 26, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (317, 27, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (318, 28, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (319, 29, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (320, 30, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (321, 31, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (322, 32, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (323, 33, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (324, 34, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (325, 35, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (326, 36, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (327, 37, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (328, 38, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (329, 39, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (330, 40, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (331, 41, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (332, 42, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (333, 43, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (334, 44, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (335, 45, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (336, 46, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (337, 47, 1.2725, 5)
INSERT [dbo].[ExchangeRate] ([ID], [DimTimeID], [Rate], [CurrencyID]) VALUES (338, 48, 1.2725, 5)
SET IDENTITY_INSERT [dbo].[ExchangeRate] OFF
/****** Object:  Table [dbo].[XiuliInput]    Script Date: 07/27/2014 23:41:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XiuliInput](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DimTimeID] [int] NOT NULL,
	[UsageType] [int] NOT NULL,
	[InputUserID] [int] NOT NULL,
	[ApproveUserID] [int] NULL,
	[CreateTime] [datetime] NOT NULL,
	[ReportTypeID] [int] NOT NULL,
	[ShipID] [int] NULL,
	[CurrencyID] [int] NOT NULL,
	[ExchangeRateID] [int] NULL,
	[PreestimateFormID] [int] NULL,
	[AmendFormID] [int] NULL,
	[总数] [float] NOT NULL,
	[自购物料] [float] NULL,
	[备件] [float] NULL,
	[其他] [float] NULL,
	[修理费用] [float] NULL,
	[服务工程] [float] NULL,
	[甲板工程] [float] NULL,
	[轮机工程] [float] NULL,
	[电气工程] [float] NULL,
 CONSTRAINT [PK_XiuliInput] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XiuliInput', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报告期主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XiuliInput', @level2type=N'COLUMN',@level2name=N'DimTimeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1.临时厂修;2.计划厂修、3.航修、4.扩大自修、5.事故性修理、6.通导' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XiuliInput', @level2type=N'COLUMN',@level2name=N'UsageType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登记人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XiuliInput', @level2type=N'COLUMN',@level2name=N'InputUserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'财务部审核人员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XiuliInput', @level2type=N'COLUMN',@level2name=N'ApproveUserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报表创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XiuliInput', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'币种主键，默认1为人民币' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XiuliInput', @level2type=N'COLUMN',@level2name=N'CurrencyID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'汇率主键，默认NULL，不进行转换' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XiuliInput', @level2type=N'COLUMN',@level2name=N'ExchangeRateID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'预估输入的XML表单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XiuliInput', @level2type=N'COLUMN',@level2name=N'PreestimateFormID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修正录入XML表单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XiuliInput', @level2type=N'COLUMN',@level2name=N'AmendFormID'
GO
SET IDENTITY_INSERT [dbo].[XiuliInput] ON
INSERT [dbo].[XiuliInput] ([ID], [DimTimeID], [UsageType], [InputUserID], [ApproveUserID], [CreateTime], [ReportTypeID], [ShipID], [CurrencyID], [ExchangeRateID], [PreestimateFormID], [AmendFormID], [总数], [自购物料], [备件], [其他], [修理费用], [服务工程], [甲板工程], [轮机工程], [电气工程]) VALUES (1, 16, 1, 0, 0, CAST(0x0000A1A700140820 AS DateTime), 2, 1, 1, NULL, NULL, NULL, 22435, 21212, 1212, 11, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[XiuliInput] ([ID], [DimTimeID], [UsageType], [InputUserID], [ApproveUserID], [CreateTime], [ReportTypeID], [ShipID], [CurrencyID], [ExchangeRateID], [PreestimateFormID], [AmendFormID], [总数], [自购物料], [备件], [其他], [修理费用], [服务工程], [甲板工程], [轮机工程], [电气工程]) VALUES (2, 16, 3, 0, 0, CAST(0x0000A1A700141E64 AS DateTime), 2, 2, 1, NULL, NULL, NULL, 244, 111, 122, 11, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[XiuliInput] OFF
/****** Object:  Table [dbo].[WuliaoInput]    Script Date: 07/27/2014 23:41:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WuliaoInput](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DimTimeID] [int] NOT NULL,
	[UsageType] [int] NOT NULL,
	[InputUserID] [int] NOT NULL,
	[ApproveUserID] [int] NULL,
	[CreateTime] [datetime] NOT NULL,
	[ShipID] [int] NULL,
	[CheckState] [int] NULL,
	[ReportTypeID] [int] NOT NULL,
	[CurrencyID] [int] NOT NULL,
	[ExchangeRateID] [int] NULL,
	[PreestimateFormID] [int] NULL,
	[AmendFormID] [int] NULL,
	[总数] [float] NOT NULL,
	[生产用品] [float] NULL,
	[生活用品] [float] NULL,
	[办公用品] [float] NULL,
	[油漆] [float] NULL,
	[缆绳] [float] NULL,
	[锁具] [float] NULL,
	[药品] [float] NULL,
	[其他] [float] NULL,
 CONSTRAINT [PK_WuliaoInput] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WuliaoInput', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报告期主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WuliaoInput', @level2type=N'COLUMN',@level2name=N'DimTimeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1：日常用、2：厂修用和3：航修用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WuliaoInput', @level2type=N'COLUMN',@level2name=N'UsageType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登记人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WuliaoInput', @level2type=N'COLUMN',@level2name=N'InputUserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'财务部审核人员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WuliaoInput', @level2type=N'COLUMN',@level2name=N'ApproveUserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报表创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WuliaoInput', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1：预估录入/2：修正录入/3：财务确认' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WuliaoInput', @level2type=N'COLUMN',@level2name=N'CheckState'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'币种主键，默认1为人民币' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WuliaoInput', @level2type=N'COLUMN',@level2name=N'CurrencyID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'汇率主键，默认NULL，不进行转换' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WuliaoInput', @level2type=N'COLUMN',@level2name=N'ExchangeRateID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'预估输入的XML表单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WuliaoInput', @level2type=N'COLUMN',@level2name=N'PreestimateFormID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修正录入XML表单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WuliaoInput', @level2type=N'COLUMN',@level2name=N'AmendFormID'
GO
SET IDENTITY_INSERT [dbo].[WuliaoInput] ON
INSERT [dbo].[WuliaoInput] ([ID], [DimTimeID], [UsageType], [InputUserID], [ApproveUserID], [CreateTime], [ShipID], [CheckState], [ReportTypeID], [CurrencyID], [ExchangeRateID], [PreestimateFormID], [AmendFormID], [总数], [生产用品], [生活用品], [办公用品], [油漆], [缆绳], [锁具], [药品], [其他]) VALUES (1, 16, 1, 1, 1, CAST(0x0000A1A6016ECE19 AS DateTime), 1, 1, 1, 1, NULL, NULL, NULL, 100, 1, 2, 3, 4, 5, 6, 7, 56)
INSERT [dbo].[WuliaoInput] ([ID], [DimTimeID], [UsageType], [InputUserID], [ApproveUserID], [CreateTime], [ShipID], [CheckState], [ReportTypeID], [CurrencyID], [ExchangeRateID], [PreestimateFormID], [AmendFormID], [总数], [生产用品], [生活用品], [办公用品], [油漆], [缆绳], [锁具], [药品], [其他]) VALUES (4, 16, 1, 0, 0, CAST(0x0000A1A7000080E8 AS DateTime), 5, 1, 1, 1, 0, NULL, NULL, 119, 5, 4, 6, 8, 6, 6, 7, 77)
INSERT [dbo].[WuliaoInput] ([ID], [DimTimeID], [UsageType], [InputUserID], [ApproveUserID], [CreateTime], [ShipID], [CheckState], [ReportTypeID], [CurrencyID], [ExchangeRateID], [PreestimateFormID], [AmendFormID], [总数], [生产用品], [生活用品], [办公用品], [油漆], [缆绳], [锁具], [药品], [其他]) VALUES (5, 16, 1, 0, NULL, CAST(0x0000A1A700033EDC AS DateTime), 1, 1, 1, 1, NULL, NULL, NULL, 44, 2, 1, 3, 6, 4, 3, 5, 4)
INSERT [dbo].[WuliaoInput] ([ID], [DimTimeID], [UsageType], [InputUserID], [ApproveUserID], [CreateTime], [ShipID], [CheckState], [ReportTypeID], [CurrencyID], [ExchangeRateID], [PreestimateFormID], [AmendFormID], [总数], [生产用品], [生活用品], [办公用品], [油漆], [缆绳], [锁具], [药品], [其他]) VALUES (6, 17, 2, 0, 0, CAST(0x0000A1B400F8A264 AS DateTime), 2, 1, 1, 1, NULL, NULL, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[WuliaoInput] ([ID], [DimTimeID], [UsageType], [InputUserID], [ApproveUserID], [CreateTime], [ShipID], [CheckState], [ReportTypeID], [CurrencyID], [ExchangeRateID], [PreestimateFormID], [AmendFormID], [总数], [生产用品], [生活用品], [办公用品], [油漆], [缆绳], [锁具], [药品], [其他]) VALUES (7, 18, 3, 0, 0, CAST(0x0000A1B400F8CDC0 AS DateTime), 5, 1, 3, 1, 0, 6, 8, 251, 2, 2, 1, 111, 1, 22, 1, 111)
INSERT [dbo].[WuliaoInput] ([ID], [DimTimeID], [UsageType], [InputUserID], [ApproveUserID], [CreateTime], [ShipID], [CheckState], [ReportTypeID], [CurrencyID], [ExchangeRateID], [PreestimateFormID], [AmendFormID], [总数], [生产用品], [生活用品], [办公用品], [油漆], [缆绳], [锁具], [药品], [其他]) VALUES (8, 18, 2, 0, 0, CAST(0x0000A1B400F8EE90 AS DateTime), 4, 1, 2, 1, 0, 7, 0, 248, 11, 111, 1, 111, 1, 1, 1, 11)
INSERT [dbo].[WuliaoInput] ([ID], [DimTimeID], [UsageType], [InputUserID], [ApproveUserID], [CreateTime], [ShipID], [CheckState], [ReportTypeID], [CurrencyID], [ExchangeRateID], [PreestimateFormID], [AmendFormID], [总数], [生产用品], [生活用品], [办公用品], [油漆], [缆绳], [锁具], [药品], [其他]) VALUES (9, 17, 2, 0, 0, CAST(0x0000A1B400F91B18 AS DateTime), 3, 1, 1, 1, NULL, NULL, NULL, 0, 0, 0, 0, 0, 23, 0, 0, 0)
INSERT [dbo].[WuliaoInput] ([ID], [DimTimeID], [UsageType], [InputUserID], [ApproveUserID], [CreateTime], [ShipID], [CheckState], [ReportTypeID], [CurrencyID], [ExchangeRateID], [PreestimateFormID], [AmendFormID], [总数], [生产用品], [生活用品], [办公用品], [油漆], [缆绳], [锁具], [药品], [其他]) VALUES (10, 17, 3, 0, 0, CAST(0x0000A1B40100C728 AS DateTime), 1, 1, 2, 1, NULL, NULL, NULL, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[WuliaoInput] ([ID], [DimTimeID], [UsageType], [InputUserID], [ApproveUserID], [CreateTime], [ShipID], [CheckState], [ReportTypeID], [CurrencyID], [ExchangeRateID], [PreestimateFormID], [AmendFormID], [总数], [生产用品], [生活用品], [办公用品], [油漆], [缆绳], [锁具], [药品], [其他]) VALUES (12, 23, 0, 0, NULL, CAST(0x0000A283010561A5 AS DateTime), 1, 1, 1, 1, 0, NULL, NULL, 19, 2, 1, 1, 3, 2, 3, 3, 4)
INSERT [dbo].[WuliaoInput] ([ID], [DimTimeID], [UsageType], [InputUserID], [ApproveUserID], [CreateTime], [ShipID], [CheckState], [ReportTypeID], [CurrencyID], [ExchangeRateID], [PreestimateFormID], [AmendFormID], [总数], [生产用品], [生活用品], [办公用品], [油漆], [缆绳], [锁具], [药品], [其他]) VALUES (13, 24, 0, 0, NULL, CAST(0x0000A28A00EA893F AS DateTime), 1, 1, 1, 1, 0, NULL, NULL, 25, 11, 12, 0, 0, 0, 1, 1, 0)
INSERT [dbo].[WuliaoInput] ([ID], [DimTimeID], [UsageType], [InputUserID], [ApproveUserID], [CreateTime], [ShipID], [CheckState], [ReportTypeID], [CurrencyID], [ExchangeRateID], [PreestimateFormID], [AmendFormID], [总数], [生产用品], [生活用品], [办公用品], [油漆], [缆绳], [锁具], [药品], [其他]) VALUES (14, 31, 0, 1, NULL, CAST(0x0000A35C00771F28 AS DateTime), 1, 1, 1, 1, 0, NULL, NULL, 36, 2, 1, 5, 8, 6, 3, 7, 4)
SET IDENTITY_INSERT [dbo].[WuliaoInput] OFF
/****** Object:  Table [dbo].[VoyageRent_todel]    Script Date: 07/27/2014 23:41:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VoyageRent_todel](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LCLCatalog] [nvarchar](500) NULL,
	[LCLAmount] [float] NULL,
	[LCLPrice] [float] NULL,
	[CurrencyID] [int] NULL,
	[DelayDay] [int] NULL,
	[DelayRate] [float] NULL,
	[QuickDay] [int] NULL,
	[QuickRate] [float] NULL,
	[TEUEmpty] [int] NULL,
	[TEUHeavy] [int] NULL,
	[TEUFrost] [int] NULL,
	[FEUEmpty] [int] NULL,
	[FEUHeavy] [int] NULL,
	[FEUFrost] [int] NULL,
	[FEUDanger] [int] NULL,
	[FFEUEmpty] [int] NULL,
	[FFEUHeavy] [int] NULL,
	[FFEUFrost] [int] NULL,
	[FFEUDanger] [int] NULL,
	[Rest] [int] NULL,
	[EqualTo] [int] NULL,
	[TotalNat] [int] NULL,
	[TotalStand] [int] NULL,
	[CurrencyOtherID] [int] NOT NULL,
	[OtherFee] [float] NULL,
	[Remark] [nvarchar](2000) NULL,
	[Customer] [nvarchar](200) NULL,
	[TaxNo] [nvarchar](200) NULL,
	[LCLAmountReal] [float] NULL,
	[Amount] [float] NULL,
	[DelayAmount] [float] NULL,
	[DispatchAmount] [float] NULL,
	[User1] [nvarchar](200) NULL,
	[User2] [nvarchar](200) NULL,
	[User3] [nvarchar](200) NULL,
 CONSTRAINT [PK_VoyageRent] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'散货载货量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageRent_todel', @level2type=N'COLUMN',@level2name=N'LCLCatalog'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'散货种类' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageRent_todel', @level2type=N'COLUMN',@level2name=N'LCLAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'运价（元/吨）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageRent_todel', @level2type=N'COLUMN',@level2name=N'LCLPrice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'币种主键，默认1为人民币' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageRent_todel', @level2type=N'COLUMN',@level2name=N'CurrencyID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'散货载货量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageRent_todel', @level2type=N'COLUMN',@level2name=N'DelayDay'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'滞期率（元/天）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageRent_todel', @level2type=N'COLUMN',@level2name=N'DelayRate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'速遣率' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageRent_todel', @level2type=N'COLUMN',@level2name=N'QuickDay'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'速遣率（元/天） ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageRent_todel', @level2type=N'COLUMN',@level2name=N'QuickRate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'20空' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageRent_todel', @level2type=N'COLUMN',@level2name=N'TEUEmpty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N' 20重' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageRent_todel', @level2type=N'COLUMN',@level2name=N'TEUHeavy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'20冰冻' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageRent_todel', @level2type=N'COLUMN',@level2name=N'TEUFrost'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'40空' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageRent_todel', @level2type=N'COLUMN',@level2name=N'FEUEmpty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'40重' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageRent_todel', @level2type=N'COLUMN',@level2name=N'FEUHeavy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'40冰冻' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageRent_todel', @level2type=N'COLUMN',@level2name=N'FEUFrost'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'40冰冻' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageRent_todel', @level2type=N'COLUMN',@level2name=N'FEUDanger'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'40危险' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageRent_todel', @level2type=N'COLUMN',@level2name=N'FFEUEmpty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'45重' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageRent_todel', @level2type=N'COLUMN',@level2name=N'FFEUHeavy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'45冰冻' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageRent_todel', @level2type=N'COLUMN',@level2name=N'FFEUFrost'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'45冰冻' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageRent_todel', @level2type=N'COLUMN',@level2name=N'FFEUDanger'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'特殊的柜' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageRent_todel', @level2type=N'COLUMN',@level2name=N'Rest'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'相当于多少个标准箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageRent_todel', @level2type=N'COLUMN',@level2name=N'EqualTo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自然柜总数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageRent_todel', @level2type=N'COLUMN',@level2name=N'TotalNat'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'相当于多少个标准箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageRent_todel', @level2type=N'COLUMN',@level2name=N'TotalStand'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他收入币种' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageRent_todel', @level2type=N'COLUMN',@level2name=N'CurrencyOtherID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他收入金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageRent_todel', @level2type=N'COLUMN',@level2name=N'OtherFee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他收入说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageRent_todel', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客户名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageRent_todel', @level2type=N'COLUMN',@level2name=N'Customer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'纳税识别号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageRent_todel', @level2type=N'COLUMN',@level2name=N'TaxNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计费货运量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageRent_todel', @level2type=N'COLUMN',@level2name=N'LCLAmountReal'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'运费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageRent_todel', @level2type=N'COLUMN',@level2name=N'Amount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'滞期费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageRent_todel', @level2type=N'COLUMN',@level2name=N'DelayAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'速遣费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageRent_todel', @level2type=N'COLUMN',@level2name=N'DispatchAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主管' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageRent_todel', @level2type=N'COLUMN',@level2name=N'User1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageRent_todel', @level2type=N'COLUMN',@level2name=N'User2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'制表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageRent_todel', @level2type=N'COLUMN',@level2name=N'User3'
GO
/****** Object:  Table [dbo].[VoyageLoad]    Script Date: 07/27/2014 23:41:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VoyageLoad](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TEUEmpty] [int] NULL,
	[TEUHeavy] [int] NULL,
	[TEUFrost] [int] NULL,
	[FEUEmpty] [int] NULL,
	[FEUHeavy] [int] NULL,
	[FEUFrost] [int] NULL,
	[FEUDanger] [int] NULL,
	[FFEUEmpty] [int] NULL,
	[FFEUHeavy] [int] NULL,
	[FFEUFrost] [int] NULL,
	[FFEUDanger] [int] NULL,
	[Rest] [int] NULL,
	[EqualTo] [int] NULL,
	[TotalNat] [int] NULL,
	[TotalStand] [int] NULL,
	[Remark] [nvarchar](2000) NULL,
	[User1] [nvarchar](200) NULL,
	[User2] [nvarchar](200) NULL,
	[User3] [nvarchar](200) NULL,
	[VoyageID] [int] NULL,
 CONSTRAINT [PK_VoyageLoad] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'20空' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageLoad', @level2type=N'COLUMN',@level2name=N'TEUEmpty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N' 20重' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageLoad', @level2type=N'COLUMN',@level2name=N'TEUHeavy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'20冰冻' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageLoad', @level2type=N'COLUMN',@level2name=N'TEUFrost'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'40空' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageLoad', @level2type=N'COLUMN',@level2name=N'FEUEmpty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'40重' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageLoad', @level2type=N'COLUMN',@level2name=N'FEUHeavy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'40冰冻' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageLoad', @level2type=N'COLUMN',@level2name=N'FEUFrost'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'40冰冻' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageLoad', @level2type=N'COLUMN',@level2name=N'FEUDanger'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'40危险' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageLoad', @level2type=N'COLUMN',@level2name=N'FFEUEmpty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'45重' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageLoad', @level2type=N'COLUMN',@level2name=N'FFEUHeavy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'45冰冻' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageLoad', @level2type=N'COLUMN',@level2name=N'FFEUFrost'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'45冰冻' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageLoad', @level2type=N'COLUMN',@level2name=N'FFEUDanger'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'特殊的柜' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageLoad', @level2type=N'COLUMN',@level2name=N'Rest'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'相当于多少个标准箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageLoad', @level2type=N'COLUMN',@level2name=N'EqualTo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自然柜总数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageLoad', @level2type=N'COLUMN',@level2name=N'TotalNat'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'相当于多少个标准箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageLoad', @level2type=N'COLUMN',@level2name=N'TotalStand'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他收入说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageLoad', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主管' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageLoad', @level2type=N'COLUMN',@level2name=N'User1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageLoad', @level2type=N'COLUMN',@level2name=N'User2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'制表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageLoad', @level2type=N'COLUMN',@level2name=N'User3'
GO
SET IDENTITY_INSERT [dbo].[VoyageLoad] ON
INSERT [dbo].[VoyageLoad] ([ID], [TEUEmpty], [TEUHeavy], [TEUFrost], [FEUEmpty], [FEUHeavy], [FEUFrost], [FEUDanger], [FFEUEmpty], [FFEUHeavy], [FFEUFrost], [FFEUDanger], [Rest], [EqualTo], [TotalNat], [TotalStand], [Remark], [User1], [User2], [User3], [VoyageID]) VALUES (13, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, 20)
INSERT [dbo].[VoyageLoad] ([ID], [TEUEmpty], [TEUHeavy], [TEUFrost], [FEUEmpty], [FEUHeavy], [FEUFrost], [FEUDanger], [FFEUEmpty], [FFEUHeavy], [FFEUFrost], [FFEUDanger], [Rest], [EqualTo], [TotalNat], [TotalStand], [Remark], [User1], [User2], [User3], [VoyageID]) VALUES (21, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, 37)
INSERT [dbo].[VoyageLoad] ([ID], [TEUEmpty], [TEUHeavy], [TEUFrost], [FEUEmpty], [FEUHeavy], [FEUFrost], [FEUDanger], [FFEUEmpty], [FFEUHeavy], [FFEUFrost], [FFEUDanger], [Rest], [EqualTo], [TotalNat], [TotalStand], [Remark], [User1], [User2], [User3], [VoyageID]) VALUES (22, 1, 2, 3, 0, 0, 33, 0, 0, 0, 22, 0, 0, 0, 22, 0, NULL, NULL, NULL, NULL, 34)
INSERT [dbo].[VoyageLoad] ([ID], [TEUEmpty], [TEUHeavy], [TEUFrost], [FEUEmpty], [FEUHeavy], [FEUFrost], [FEUDanger], [FFEUEmpty], [FFEUHeavy], [FFEUFrost], [FFEUDanger], [Rest], [EqualTo], [TotalNat], [TotalStand], [Remark], [User1], [User2], [User3], [VoyageID]) VALUES (23, 2, 3, 1, 0, 2, 3, 0, 0, 1, 1, 0, 0, 0, 22, 111, NULL, NULL, NULL, NULL, 32)
INSERT [dbo].[VoyageLoad] ([ID], [TEUEmpty], [TEUHeavy], [TEUFrost], [FEUEmpty], [FEUHeavy], [FEUFrost], [FEUDanger], [FFEUEmpty], [FFEUHeavy], [FFEUFrost], [FFEUDanger], [Rest], [EqualTo], [TotalNat], [TotalStand], [Remark], [User1], [User2], [User3], [VoyageID]) VALUES (24, 121, 1, 1, 12, 3, 0, 0, 3, 3, 3, 0, 11, 11, 211, 211, NULL, NULL, NULL, NULL, 36)
SET IDENTITY_INSERT [dbo].[VoyageLoad] OFF
/****** Object:  Table [dbo].[VoyageLCL]    Script Date: 07/27/2014 23:41:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VoyageLCL](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LCLCatalog] [nvarchar](500) NULL,
	[LCLAmount] [float] NULL,
	[LCLPrice] [float] NULL,
	[CurrencyID] [int] NULL,
	[DelayDay] [float] NULL,
	[DelayRate] [float] NULL,
	[QuickDay] [float] NULL,
	[QuickRate] [float] NULL,
	[Customer] [nvarchar](200) NULL,
	[TaxNo] [nvarchar](200) NULL,
	[LCLAmountReal] [float] NULL,
	[DelayAmount] [float] NULL,
	[DispatchAmount] [float] NULL,
	[Amount] [float] NULL,
	[User1] [nvarchar](200) NULL,
	[User2] [nvarchar](200) NULL,
	[User3] [nvarchar](200) NULL,
	[VoyageID] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[InputDate] [datetime] NULL,
 CONSTRAINT [PK_VoyageLCL] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'散货载货量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageLCL', @level2type=N'COLUMN',@level2name=N'LCLCatalog'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'散货种类' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageLCL', @level2type=N'COLUMN',@level2name=N'LCLAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'运价（元/吨）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageLCL', @level2type=N'COLUMN',@level2name=N'LCLPrice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'币种主键，默认1为人民币' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageLCL', @level2type=N'COLUMN',@level2name=N'CurrencyID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'散货载货量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageLCL', @level2type=N'COLUMN',@level2name=N'DelayDay'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'滞期率（元/天）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageLCL', @level2type=N'COLUMN',@level2name=N'DelayRate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'速遣率' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageLCL', @level2type=N'COLUMN',@level2name=N'QuickDay'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'速遣率（元/天） ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageLCL', @level2type=N'COLUMN',@level2name=N'QuickRate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客户名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageLCL', @level2type=N'COLUMN',@level2name=N'Customer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'纳税识别号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageLCL', @level2type=N'COLUMN',@level2name=N'TaxNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计费货运量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageLCL', @level2type=N'COLUMN',@level2name=N'LCLAmountReal'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'滞期费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageLCL', @level2type=N'COLUMN',@level2name=N'DelayAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'速遣费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageLCL', @level2type=N'COLUMN',@level2name=N'DispatchAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'运费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageLCL', @level2type=N'COLUMN',@level2name=N'Amount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主管' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageLCL', @level2type=N'COLUMN',@level2name=N'User1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageLCL', @level2type=N'COLUMN',@level2name=N'User2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'制表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageLCL', @level2type=N'COLUMN',@level2name=N'User3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'开票日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageLCL', @level2type=N'COLUMN',@level2name=N'InputDate'
GO
SET IDENTITY_INSERT [dbo].[VoyageLCL] ON
INSERT [dbo].[VoyageLCL] ([ID], [LCLCatalog], [LCLAmount], [LCLPrice], [CurrencyID], [DelayDay], [DelayRate], [QuickDay], [QuickRate], [Customer], [TaxNo], [LCLAmountReal], [DelayAmount], [DispatchAmount], [Amount], [User1], [User2], [User3], [VoyageID], [CreateTime], [InputDate]) VALUES (4, N'货种', 212, 121212, 1, 12, 12, 12, 12, N'客户名称', N'纳税识别号', 121, 0, 0, 0, N'主管', N'审核', N'制表', 20, CAST(0x0000A31B011AF198 AS DateTime), CAST(0x0000A31B011AF198 AS DateTime))
INSERT [dbo].[VoyageLCL] ([ID], [LCLCatalog], [LCLAmount], [LCLPrice], [CurrencyID], [DelayDay], [DelayRate], [QuickDay], [QuickRate], [Customer], [TaxNo], [LCLAmountReal], [DelayAmount], [DispatchAmount], [Amount], [User1], [User2], [User3], [VoyageID], [CreateTime], [InputDate]) VALUES (5, N'货种', 12, 112, 1, 1, 1, 1, 1, N'2323', N'2323', 121, 0, 0, 13552, N'1', N'2', N'3', 21, CAST(0x0000A321011028A8 AS DateTime), CAST(0x0000A321011028A8 AS DateTime))
INSERT [dbo].[VoyageLCL] ([ID], [LCLCatalog], [LCLAmount], [LCLPrice], [CurrencyID], [DelayDay], [DelayRate], [QuickDay], [QuickRate], [Customer], [TaxNo], [LCLAmountReal], [DelayAmount], [DispatchAmount], [Amount], [User1], [User2], [User3], [VoyageID], [CreateTime], [InputDate]) VALUES (6, N'货种', 67523, 55, 1, 12.2233, 1, 12.2222, 2, N'绿地能源集团广东煤业科技有限公司', N'纳税识别号：   ', 67523, 0, 0, 3713801.6677, N'主管', N'审核', N'制表', 28, CAST(0x0000A354008BB0F0 AS DateTime), CAST(0x0000A354008BB0F0 AS DateTime))
INSERT [dbo].[VoyageLCL] ([ID], [LCLCatalog], [LCLAmount], [LCLPrice], [CurrencyID], [DelayDay], [DelayRate], [QuickDay], [QuickRate], [Customer], [TaxNo], [LCLAmountReal], [DelayAmount], [DispatchAmount], [Amount], [User1], [User2], [User3], [VoyageID], [CreateTime], [InputDate]) VALUES (8, N'货种', 68029, 7.3, 2, 0, 0, 0, 0, N'', N'', 68029, 0, 0, 496611.7, N'主管', N'审核', N'制表', 33, CAST(0x0000A354009B0B68 AS DateTime), CAST(0x0000A354009B0B68 AS DateTime))
SET IDENTITY_INSERT [dbo].[VoyageLCL] OFF
/****** Object:  Table [dbo].[VoyageFCL]    Script Date: 07/27/2014 23:41:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VoyageFCL](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CurrencyID] [int] NULL,
	[Customer] [nvarchar](200) NULL,
	[TaxNo] [nvarchar](200) NULL,
	[Amount] [float] NULL,
	[User1] [nvarchar](200) NULL,
	[User2] [nvarchar](200) NULL,
	[User3] [nvarchar](200) NULL,
	[VoyageID] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[InputDate] [datetime] NULL,
	[Fee] [float] NULL,
	[BeginFee] [float] NULL,
	[EndFee] [float] NULL,
	[OilFee] [float] NULL,
	[Tally] [float] NULL,
	[Box] [float] NULL,
	[Other] [float] NULL,
	[Remark] [ntext] NULL,
	[Subsidize] [float] NULL,
	[BookFee] [float] NULL,
	[BranchOther] [float] NULL,
 CONSTRAINT [PK_VoyageFCL] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'币种主键，默认1为人民币' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageFCL', @level2type=N'COLUMN',@level2name=N'CurrencyID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客户名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageFCL', @level2type=N'COLUMN',@level2name=N'Customer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'纳税识别号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageFCL', @level2type=N'COLUMN',@level2name=N'TaxNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'运费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageFCL', @level2type=N'COLUMN',@level2name=N'Amount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主管' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageFCL', @level2type=N'COLUMN',@level2name=N'User1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageFCL', @level2type=N'COLUMN',@level2name=N'User2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'制表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageFCL', @level2type=N'COLUMN',@level2name=N'User3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'开票日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageFCL', @level2type=N'COLUMN',@level2name=N'InputDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'运费金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageFCL', @level2type=N'COLUMN',@level2name=N'Fee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'始运港装卸费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageFCL', @level2type=N'COLUMN',@level2name=N'BeginFee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'目的港装卸费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageFCL', @level2type=N'COLUMN',@level2name=N'EndFee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'油款' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageFCL', @level2type=N'COLUMN',@level2name=N'OilFee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'理货费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageFCL', @level2type=N'COLUMN',@level2name=N'Tally'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'箱费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageFCL', @level2type=N'COLUMN',@level2name=N'Box'
GO
SET IDENTITY_INSERT [dbo].[VoyageFCL] ON
INSERT [dbo].[VoyageFCL] ([ID], [CurrencyID], [Customer], [TaxNo], [Amount], [User1], [User2], [User3], [VoyageID], [CreateTime], [InputDate], [Fee], [BeginFee], [EndFee], [OilFee], [Tally], [Box], [Other], [Remark], [Subsidize], [BookFee], [BranchOther]) VALUES (1, 1, N'客户', N'纳税识别号', 11, N'主管', N'主管', N'制表', 20, CAST(0x0000A320015BA2E3 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[VoyageFCL] ([ID], [CurrencyID], [Customer], [TaxNo], [Amount], [User1], [User2], [User3], [VoyageID], [CreateTime], [InputDate], [Fee], [BeginFee], [EndFee], [OilFee], [Tally], [Box], [Other], [Remark], [Subsidize], [BookFee], [BranchOther]) VALUES (2, 1, N'客户', N'纳税识别号', 573575, N'主管', N'审核', N'制表', 32, CAST(0x0000A3420121752C AS DateTime), CAST(0x0000A3420121752C AS DateTime), 153000, 100331, 82744, 185000, 5010, 52500, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[VoyageFCL] ([ID], [CurrencyID], [Customer], [TaxNo], [Amount], [User1], [User2], [User3], [VoyageID], [CreateTime], [InputDate], [Fee], [BeginFee], [EndFee], [OilFee], [Tally], [Box], [Other], [Remark], [Subsidize], [BookFee], [BranchOther]) VALUES (3, 1, N'客户名', N'纳税识别号', 512312, N'主管', N'审核', N'制表', 34, CAST(0x0000A354009FBA3C AS DateTime), CAST(0x0000A354009FBA3C AS DateTime), 153000, 48105, 73707, 185000, 4114, 52500, 0, N'', NULL, NULL, NULL)
INSERT [dbo].[VoyageFCL] ([ID], [CurrencyID], [Customer], [TaxNo], [Amount], [User1], [User2], [User3], [VoyageID], [CreateTime], [InputDate], [Fee], [BeginFee], [EndFee], [OilFee], [Tally], [Box], [Other], [Remark], [Subsidize], [BookFee], [BranchOther]) VALUES (4, 1, N'客户名称', N'纳税识别号', 461242, N'管', N'审核', N'制表', 35, CAST(0x0000A35400A0682C AS DateTime), CAST(0x0000A35400A0682C AS DateTime), 140000, 52921, 30821, 185000, 3783, 52500, 0, N'', NULL, NULL, NULL)
INSERT [dbo].[VoyageFCL] ([ID], [CurrencyID], [Customer], [TaxNo], [Amount], [User1], [User2], [User3], [VoyageID], [CreateTime], [InputDate], [Fee], [BeginFee], [EndFee], [OilFee], [Tally], [Box], [Other], [Remark], [Subsidize], [BookFee], [BranchOther]) VALUES (5, 1, N'客户名称', N'纳税识别号', 488214.02, N'主管', N'审核', N'制表', 36, CAST(0x0000A35400A0F8FC AS DateTime), CAST(0x0000A35400A0F8FC AS DateTime), 140000, 37321, 67962, 185000, 4086, 52500, 0, N'', 12.02, 1111, 222)
INSERT [dbo].[VoyageFCL] ([ID], [CurrencyID], [Customer], [TaxNo], [Amount], [User1], [User2], [User3], [VoyageID], [CreateTime], [InputDate], [Fee], [BeginFee], [EndFee], [OilFee], [Tally], [Box], [Other], [Remark], [Subsidize], [BookFee], [BranchOther]) VALUES (6, 1, N'', N'', 1085900, N'', N'', N'', 22, CAST(0x0000A36400F3EBC1 AS DateTime), CAST(0x0000A36400F3EBC1 AS DateTime), 456456, 56777, 110000, 456456, 4566, 5656, 555, N'', NULL, NULL, NULL)
INSERT [dbo].[VoyageFCL] ([ID], [CurrencyID], [Customer], [TaxNo], [Amount], [User1], [User2], [User3], [VoyageID], [CreateTime], [InputDate], [Fee], [BeginFee], [EndFee], [OilFee], [Tally], [Box], [Other], [Remark], [Subsidize], [BookFee], [BranchOther]) VALUES (7, 1, N'', N'', 3470000, N'', N'', N'', 31, CAST(0x0000A36400FBB731 AS DateTime), CAST(0x0000A36400FBB731 AS DateTime), 150000, 280000, 3000000, 20000, 6000, 20000, 0, N'', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[VoyageFCL] OFF
/****** Object:  Table [dbo].[VoyageOther]    Script Date: 07/27/2014 23:41:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VoyageOther](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CurrencyID] [int] NULL,
	[Amount] [float] NULL,
	[OtherName] [nvarchar](200) NULL,
	[Remark] [nvarchar](2000) NULL,
	[Customer] [nvarchar](200) NULL,
	[User1] [nvarchar](200) NULL,
	[User2] [nvarchar](200) NULL,
	[User3] [nvarchar](200) NULL,
	[VoyageID] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[InputDate] [datetime] NULL,
 CONSTRAINT [PK_VoyageOther] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'币种主键，默认1为人民币' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageOther', @level2type=N'COLUMN',@level2name=N'CurrencyID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他收入金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageOther', @level2type=N'COLUMN',@level2name=N'Amount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他收入项目' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageOther', @level2type=N'COLUMN',@level2name=N'OtherName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他收入说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageOther', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客户名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageOther', @level2type=N'COLUMN',@level2name=N'Customer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主管' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageOther', @level2type=N'COLUMN',@level2name=N'User1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageOther', @level2type=N'COLUMN',@level2name=N'User2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'制表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageOther', @level2type=N'COLUMN',@level2name=N'User3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'hangci' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageOther', @level2type=N'COLUMN',@level2name=N'VoyageID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'开票日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VoyageOther', @level2type=N'COLUMN',@level2name=N'InputDate'
GO
SET IDENTITY_INSERT [dbo].[VoyageOther] ON
INSERT [dbo].[VoyageOther] ([ID], [CurrencyID], [Amount], [OtherName], [Remark], [Customer], [User1], [User2], [User3], [VoyageID], [CreateTime], [InputDate]) VALUES (1, 1, 1, N'12', N'121', N'客户', N'1', N'2', N'3', 20, CAST(0x0000A321010B0BAC AS DateTime), CAST(0x0000A321010B0BAC AS DateTime))
INSERT [dbo].[VoyageOther] ([ID], [CurrencyID], [Amount], [OtherName], [Remark], [Customer], [User1], [User2], [User3], [VoyageID], [CreateTime], [InputDate]) VALUES (2, 1, 212, N'1212', N'1212', N'', N'12', N'1212', N'1212', 21, CAST(0x0000A3210110345B AS DateTime), CAST(0x0000A3210110345B AS DateTime))
INSERT [dbo].[VoyageOther] ([ID], [CurrencyID], [Amount], [OtherName], [Remark], [Customer], [User1], [User2], [User3], [VoyageID], [CreateTime], [InputDate]) VALUES (3, 1, -10230, N'项目', N'单价录入错误，合同总额修正', N'客户名称', N'主管', N'审核', N'制表', 37, CAST(0x0000A35400A92425 AS DateTime), CAST(0x0000A35400A92425 AS DateTime))
SET IDENTITY_INSERT [dbo].[VoyageOther] OFF
/****** Object:  View [dbo].[V_Voyage]    Script Date: 07/27/2014 23:41:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_Voyage]
AS
SELECT     TOP (100) PERCENT v.BeginDate, v.EndDate, r.Distance, ps.Name AS sName, pe.Name AS eName, s.Name AS ShipName, s.Captain, s.ChiefEngineer, 
                      s.GeneralManager, DATEDIFF(hh, v.BeginDate, v.EndDate) AS DiffHours, v.ID, v.Name, v.RouteID, v.ShipID, v.HangciBaseID, v.OrderNum, v.VoyageLoadID, 
                      ps.ID AS sPortID, pe.ID AS ePortID, r.Name AS RouteName, v.ManagerTypeID
FROM         dbo.Voyage AS v INNER JOIN
                      dbo.Route AS r ON v.RouteID = r.ID INNER JOIN
                      dbo.Relation_RoutePort AS rrpe ON r.ID = rrpe.RouteID INNER JOIN
                      dbo.Relation_RoutePort AS rrps ON r.ID = rrps.RouteID INNER JOIN
                      dbo.Port AS ps ON rrps.PortID = ps.ID INNER JOIN
                      dbo.Port AS pe ON rrpe.PortID = pe.ID INNER JOIN
                      dbo.Ship AS s ON v.ShipID = s.ID
WHERE     (rrps.PortTypeID = '2') AND (rrpe.PortTypeID = '4')
ORDER BY v.BeginDate
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
         Begin Table = "v"
            Begin Extent = 
               Top = 7
               Left = 258
               Bottom = 133
               Right = 433
            End
            DisplayFlags = 280
            TopColumn = 6
         End
         Begin Table = "r"
            Begin Extent = 
               Top = 25
               Left = 497
               Bottom = 129
               Right = 639
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "rrpe"
            Begin Extent = 
               Top = 6
               Left = 737
               Bottom = 125
               Right = 881
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "rrps"
            Begin Extent = 
               Top = 137
               Left = 257
               Bottom = 256
               Right = 401
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ps"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 230
               Right = 180
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "pe"
            Begin Extent = 
               Top = 176
               Left = 486
               Bottom = 280
               Right = 628
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "s"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 206
            End
            DisplayFlags = 280
            TopColumn = 0
        ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Voyage'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N' End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 18
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1935
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
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 1170
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Voyage'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Voyage'
GO
/****** Object:  View [dbo].[V_RoutePort]    Script Date: 07/27/2014 23:41:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_RoutePort]
AS
SELECT     dbo.Port.ID, dbo.Port.Name, dbo.Port.Remark, dbo.Relation_RoutePort.RouteID, dbo.Relation_RoutePort.PortTypeID, dbo.Relation_RoutePort.OrderNum
FROM         dbo.Port INNER JOIN
                      dbo.Relation_RoutePort ON dbo.Port.ID = dbo.Relation_RoutePort.PortID INNER JOIN
                      dbo.PortType ON dbo.Relation_RoutePort.PortTypeID = dbo.PortType.ID
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
         Begin Table = "Port"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 110
               Right = 180
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PortType"
            Begin Extent = 
               Top = 131
               Left = 234
               Bottom = 220
               Right = 376
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Relation_RoutePort"
            Begin Extent = 
               Top = 23
               Left = 454
               Bottom = 142
               Right = 598
            End
            DisplayFlags = 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_RoutePort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_RoutePort'
GO
/****** Object:  View [dbo].[V_InsuranceOfCompensation]    Script Date: 07/27/2014 23:41:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_InsuranceOfCompensation]
AS
SELECT     dbo.InsuranceOfCompensation.ID, dbo.InsuranceOfCompensation.DimTimeID, dbo.InsuranceOfCompensation.ShipID, dbo.InsuranceOfCompensation.InputUserID, 
                      dbo.InsuranceOfCompensation.ApproveUserID, dbo.InsuranceOfCompensation.CreateTime, dbo.InsuranceOfCompensation.CurrencyID, 
                      dbo.InsuranceOfCompensation.ExchangeRateID, dbo.InsuranceOfCompensation.BeginDate, dbo.InsuranceOfCompensation.EndDate, 
                      dbo.InsuranceOfCompensation.主险保额, dbo.InsuranceOfCompensation.主险费率, dbo.InsuranceOfCompensation.主险保费, 
                      dbo.InsuranceOfCompensation.战争保赔险费率, dbo.InsuranceOfCompensation.战争保赔险保费, dbo.InsuranceOfCompensation.免赔额, 
                      dbo.InsuranceOfCompensation.船舶险总保费, dbo.InsuranceOfCompensation.保赔险保单号, dbo.InsuranceOfCompensation.保险期限自, 
                      dbo.InsuranceOfCompensation.保险期限到, dbo.InsuranceOfCompensation.保赔险费率, dbo.InsuranceOfCompensation.保赔险保费, 
                      dbo.InsuranceOfCompensation.备注, dbo.Ship.Name AS ShipName, dbo.DimTime.Year, dbo.DimTime.MonthNumOfYear, dbo.Currency.Name AS CurrencyName
FROM         dbo.InsuranceOfCompensation INNER JOIN
                      dbo.Ship ON dbo.InsuranceOfCompensation.ShipID = dbo.Ship.ID INNER JOIN
                      dbo.DimTime ON dbo.InsuranceOfCompensation.DimTimeID = dbo.DimTime.ID INNER JOIN
                      dbo.Currency ON dbo.InsuranceOfCompensation.CurrencyID = dbo.Currency.ID
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
         Begin Table = "InsuranceOfCompensation"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 211
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Ship"
            Begin Extent = 
               Top = 203
               Left = 397
               Bottom = 322
               Right = 565
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DimTime"
            Begin Extent = 
               Top = 22
               Left = 426
               Bottom = 141
               Right = 608
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "Currency"
            Begin Extent = 
               Top = 225
               Left = 104
               Bottom = 314
               Right = 246
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
         Or =' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_InsuranceOfCompensation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N' 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_InsuranceOfCompensation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_InsuranceOfCompensation'
GO
/****** Object:  View [dbo].[V_ExchangeRate]    Script Date: 07/27/2014 23:41:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_ExchangeRate]
AS
SELECT     dbo.ExchangeRate.ID, dbo.ExchangeRate.DimTimeID, dbo.ExchangeRate.CurrencyID, dbo.ExchangeRate.Rate, dbo.Currency.Name, dbo.DimTime.Year, 
                      dbo.DimTime.MonthName, dbo.DimTime.QuarterName, dbo.DimTime.MonthNumOfYear, dbo.DimTime.QuarterNumOfYear
FROM         dbo.Currency INNER JOIN
                      dbo.ExchangeRate ON dbo.Currency.ID = dbo.ExchangeRate.CurrencyID INNER JOIN
                      dbo.DimTime ON dbo.ExchangeRate.DimTimeID = dbo.DimTime.ID
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[31] 4[22] 2[17] 3) )"
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
         Begin Table = "Currency"
            Begin Extent = 
               Top = 71
               Left = 24
               Bottom = 160
               Right = 166
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ExchangeRate"
            Begin Extent = 
               Top = 27
               Left = 261
               Bottom = 146
               Right = 405
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DimTime"
            Begin Extent = 
               Top = 79
               Left = 553
               Bottom = 198
               Right = 735
            End
            DisplayFlags = 280
            TopColumn = 2
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_ExchangeRate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_ExchangeRate'
GO
/****** Object:  View [dbo].[V_CommonFee]    Script Date: 07/27/2014 23:41:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_CommonFee]
AS
SELECT     dbo.CommonFee.ID, dbo.CommonFee.DimTimeID, dbo.CommonFee.ShipID, dbo.CommonFee.InputUserID, dbo.CommonFee.ApproveUserID, 
                      dbo.CommonFee.CreateTime, dbo.CommonFee.CurrencyID, dbo.CommonFee.ExchangeRateID, dbo.CommonFee.FeeCatalogID, dbo.CommonFee.Amount, 
                      dbo.CommonFee.备注, dbo.Currency.Name AS CurrencyName, dbo.DimTime.Year, dbo.DimTime.MonthNumOfYear, dbo.FeeCatalog.Name, 
                      dbo.FeeCatalog.DepartmentID
FROM         dbo.CommonFee INNER JOIN
                      dbo.Currency ON dbo.CommonFee.CurrencyID = dbo.Currency.ID INNER JOIN
                      dbo.DimTime ON dbo.CommonFee.DimTimeID = dbo.DimTime.ID INNER JOIN
                      dbo.FeeCatalog ON dbo.CommonFee.FeeCatalogID = dbo.FeeCatalog.ID
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
         Begin Table = "CommonFee"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Currency"
            Begin Extent = 
               Top = 241
               Left = 101
               Bottom = 330
               Right = 243
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DimTime"
            Begin Extent = 
               Top = 37
               Left = 420
               Bottom = 156
               Right = 602
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "FeeCatalog"
            Begin Extent = 
               Top = 214
               Left = 326
               Bottom = 318
               Right = 483
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
      Begin ColumnWidths = 15
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
  ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_CommonFee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'       SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_CommonFee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_CommonFee'
GO
/****** Object:  View [dbo].[V_CertificateFlee]    Script Date: 07/27/2014 23:41:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_CertificateFlee]
AS
SELECT     dbo.CertificateFlee.*, dbo.DimTime.Year, dbo.Currency.Name AS CurrencyName
FROM         dbo.CertificateFlee INNER JOIN
                      dbo.Currency ON dbo.CertificateFlee.CurrencyID = dbo.Currency.ID INNER JOIN
                      dbo.DimTime ON dbo.CertificateFlee.DimTimeID = dbo.DimTime.ID
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
         Begin Table = "CertificateFlee"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Currency"
            Begin Extent = 
               Top = 232
               Left = 423
               Bottom = 321
               Right = 565
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DimTime"
            Begin Extent = 
               Top = 6
               Left = 426
               Bottom = 125
               Right = 608
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_CertificateFlee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_CertificateFlee'
GO
/****** Object:  View [dbo].[V_Beijian]    Script Date: 07/27/2014 23:41:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_Beijian]
AS
SELECT     dbo.DimTime.Year, dbo.DimTime.MonthName, dbo.DimTime.QuarterName, dbo.DimTime.MonthNumOfYear, dbo.DimTime.QuarterNumOfYear, dbo.BeijianInput.ID, 
                      dbo.BeijianInput.DimTimeID, dbo.BeijianInput.UsageType, dbo.BeijianInput.InputUserID, dbo.BeijianInput.ApproveUserID, dbo.BeijianInput.CreateTime, 
                      dbo.BeijianInput.ReportTypeID, dbo.BeijianInput.总数, dbo.BeijianInput.主机, dbo.BeijianInput.副机, dbo.BeijianInput.舾装, dbo.BeijianInput.电器, 
                      dbo.BeijianInput.辅机, dbo.BeijianInput.分油机, dbo.BeijianInput.ShipID, dbo.Ship.Name, dbo.Ship.Code
FROM         dbo.BeijianInput INNER JOIN
                      dbo.DimTime ON dbo.BeijianInput.DimTimeID = dbo.DimTime.ID LEFT OUTER JOIN
                      dbo.Ship ON dbo.BeijianInput.ShipID = dbo.Ship.ID
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
         Begin Table = "BeijianInput"
            Begin Extent = 
               Top = 96
               Left = 263
               Bottom = 215
               Right = 426
            End
            DisplayFlags = 280
            TopColumn = 12
         End
         Begin Table = "DimTime"
            Begin Extent = 
               Top = 25
               Left = 61
               Bottom = 144
               Right = 243
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "Ship"
            Begin Extent = 
               Top = 6
               Left = 459
               Bottom = 125
               Right = 627
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Beijian'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Beijian'
GO
/****** Object:  View [dbo].[V_FeeCatalog]    Script Date: 07/27/2014 23:41:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_FeeCatalog]
AS
SELECT     dbo.FeeCatalog.ID, dbo.FeeCatalog.Name, dbo.FeeCatalog.DepartmentID, dbo.Department.FullName AS DepartmentName
FROM         dbo.FeeCatalog INNER JOIN
                      dbo.Department ON dbo.FeeCatalog.DepartmentID = dbo.Department.ID
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
         Begin Table = "FeeCatalog"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 110
               Right = 195
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Department"
            Begin Extent = 
               Top = 6
               Left = 233
               Bottom = 114
               Right = 366
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_FeeCatalog'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_FeeCatalog'
GO
/****** Object:  View [dbo].[V_RentContainerReport]    Script Date: 07/27/2014 23:41:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_RentContainerReport]
AS
SELECT     dbo.RentContainerReport.ID, dbo.RentContainerReport.Customer, dbo.RentContainerReport.TaxNo, dbo.RentContainerReport.User1, dbo.RentContainerReport.User2, 
                      dbo.RentContainerReport.User3, dbo.RentContainerReport.InputDate, dbo.RentContainerReport.CreateTime, dbo.RentContainerReport.Amount, 
                      dbo.RentContainerReport.BeginDate, dbo.RentContainerReport.EndDate, dbo.RentContainerReport.RentDays, dbo.RentContainerReport.Remark, 
                      dbo.Currency.Name AS CurrencyName, dbo.RentContainerReport.CurrencyID
FROM         dbo.RentContainerReport INNER JOIN
                      dbo.Currency ON dbo.RentContainerReport.CurrencyID = dbo.Currency.ID
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
         Begin Table = "RentContainerReport"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 240
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Currency"
            Begin Extent = 
               Top = 34
               Left = 385
               Bottom = 216
               Right = 597
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
         Table = 1395
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_RentContainerReport'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_RentContainerReport'
GO
/****** Object:  View [dbo].[V_Jianyan]    Script Date: 07/27/2014 23:41:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_Jianyan]
AS
SELECT     dbo.DimTime.Year, dbo.DimTime.MonthName, dbo.DimTime.QuarterName, dbo.DimTime.MonthNumOfYear, dbo.DimTime.QuarterNumOfYear, dbo.JianyanInput.ID, 
                      dbo.JianyanInput.DimTimeID, dbo.JianyanInput.InputUserID, dbo.JianyanInput.ApproveUserID, dbo.JianyanInput.CreateTime, dbo.JianyanInput.ReportTypeID, 
                      dbo.JianyanInput.总数, dbo.JianyanInput.ShipID, dbo.Ship.Name, dbo.Ship.Code
FROM         dbo.DimTime INNER JOIN
                      dbo.JianyanInput ON dbo.DimTime.ID = dbo.JianyanInput.DimTimeID LEFT OUTER JOIN
                      dbo.Ship ON dbo.JianyanInput.ShipID = dbo.Ship.ID
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
         Begin Table = "DimTime"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 220
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "JianyanInput"
            Begin Extent = 
               Top = 6
               Left = 258
               Bottom = 125
               Right = 421
            End
            DisplayFlags = 280
            TopColumn = 5
         End
         Begin Table = "Ship"
            Begin Extent = 
               Top = 6
               Left = 459
               Bottom = 125
               Right = 627
            End
            DisplayFlags = 280
            TopColumn = 2
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Jianyan'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Jianyan'
GO
/****** Object:  View [dbo].[V_Invoice]    Script Date: 07/27/2014 23:41:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_Invoice]
AS
SELECT     dbo.Invoice.*
FROM         dbo.Invoice
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
         Begin Table = "Invoice"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 188
               Right = 377
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Invoice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_Invoice'
GO
/****** Object:  View [dbo].[V_XiuliInput]    Script Date: 07/27/2014 23:41:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_XiuliInput]
AS
SELECT     dbo.DimTime.Year, dbo.DimTime.MonthName, dbo.DimTime.QuarterName, dbo.DimTime.MonthNumOfYear, dbo.DimTime.QuarterNumOfYear, dbo.XiuliInput.ID, 
                      dbo.XiuliInput.DimTimeID, dbo.XiuliInput.UsageType, dbo.XiuliInput.InputUserID, dbo.XiuliInput.ApproveUserID, dbo.XiuliInput.CreateTime, 
                      dbo.XiuliInput.ReportTypeID, dbo.XiuliInput.总数, dbo.XiuliInput.自购物料, dbo.XiuliInput.备件, dbo.XiuliInput.其他, dbo.XiuliInput.ShipID, dbo.Ship.Name, 
                      dbo.Ship.Code, dbo.XiuliInput.修理费用, dbo.XiuliInput.服务工程, dbo.XiuliInput.甲板工程, dbo.XiuliInput.轮机工程, dbo.XiuliInput.电气工程
FROM         dbo.DimTime INNER JOIN
                      dbo.XiuliInput ON dbo.DimTime.ID = dbo.XiuliInput.DimTimeID LEFT OUTER JOIN
                      dbo.Ship ON dbo.XiuliInput.ShipID = dbo.Ship.ID
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
         Begin Table = "DimTime"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 220
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "XiuliInput"
            Begin Extent = 
               Top = 6
               Left = 258
               Bottom = 125
               Right = 421
            End
            DisplayFlags = 280
            TopColumn = 17
         End
         Begin Table = "Ship"
            Begin Extent = 
               Top = 6
               Left = 459
               Bottom = 125
               Right = 627
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_XiuliInput'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_XiuliInput'
GO
/****** Object:  View [dbo].[V_WuliaoInput]    Script Date: 07/27/2014 23:41:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_WuliaoInput]
AS
SELECT     dbo.WuliaoInput.ID, dbo.WuliaoInput.DimTimeID, dbo.WuliaoInput.InputUserID, dbo.WuliaoInput.UsageType, dbo.WuliaoInput.ApproveUserID, 
                      dbo.WuliaoInput.CreateTime, dbo.WuliaoInput.总数, dbo.WuliaoInput.生产用品, dbo.WuliaoInput.生活用品, dbo.WuliaoInput.办公用品, dbo.WuliaoInput.油漆, 
                      dbo.WuliaoInput.缆绳, dbo.WuliaoInput.锁具, dbo.WuliaoInput.药品, dbo.WuliaoInput.其他, dbo.DimTime.MonthName, dbo.DimTime.QuarterName, dbo.DimTime.Year, 
                      dbo.DimTime.MonthNumOfYear, dbo.DimTime.QuarterNumOfYear, dbo.WuliaoInput.ShipID, dbo.Ship.Name, dbo.Ship.Code, dbo.WuliaoInput.CheckState, 
                      dbo.WuliaoInput.ReportTypeID
FROM         dbo.DimTime INNER JOIN
                      dbo.WuliaoInput ON dbo.DimTime.ID = dbo.WuliaoInput.DimTimeID LEFT OUTER JOIN
                      dbo.Ship ON dbo.WuliaoInput.ShipID = dbo.Ship.ID
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
         Begin Table = "DimTime"
            Begin Extent = 
               Top = 5
               Left = 13
               Bottom = 124
               Right = 195
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "WuliaoInput"
            Begin Extent = 
               Top = 4
               Left = 344
               Bottom = 229
               Right = 520
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "Ship"
            Begin Extent = 
               Top = 6
               Left = 558
               Bottom = 125
               Right = 726
            End
            DisplayFlags = 280
            TopColumn = 2
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_WuliaoInput'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_WuliaoInput'
GO
/****** Object:  Table [dbo].[RentContainer]    Script Date: 07/27/2014 23:41:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RentContainer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ReportID] [int] NOT NULL,
	[ContainerTypeID] [int] NOT NULL,
	[Amount] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[RentFee] [float] NOT NULL,
	[CreateTime] [datetime] NULL,
	[Remark] [nvarchar](2000) NULL,
 CONSTRAINT [PK_RentContainer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登记时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RentContainer', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
SET IDENTITY_INSERT [dbo].[RentContainer] ON
INSERT [dbo].[RentContainer] ([ID], [ReportID], [ContainerTypeID], [Amount], [Price], [RentFee], [CreateTime], [Remark]) VALUES (2, 1, 1, 121, 1, 1111, CAST(0x0000A325010A9550 AS DateTime), N'0211')
INSERT [dbo].[RentContainer] ([ID], [ReportID], [ContainerTypeID], [Amount], [Price], [RentFee], [CreateTime], [Remark]) VALUES (3, 1, 2, 12, 11, 122, CAST(0x0000A325010AA1AC AS DateTime), N'1112')
INSERT [dbo].[RentContainer] ([ID], [ReportID], [ContainerTypeID], [Amount], [Price], [RentFee], [CreateTime], [Remark]) VALUES (4, 1, 4, 1112, 11, 4344, CAST(0x0000A325010BE34A AS DateTime), N'0')
SET IDENTITY_INSERT [dbo].[RentContainer] OFF
/****** Object:  Table [dbo].[InsuranceOfFreightTransport]    Script Date: 07/27/2014 23:41:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InsuranceOfFreightTransport](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DimTimeID] [int] NOT NULL,
	[VoyageID] [int] NOT NULL,
	[InputUserID] [int] NULL,
	[ApproveUserID] [int] NULL,
	[CreateTime] [datetime] NULL,
	[CurrencyID] [int] NOT NULL,
	[ExchangeRateID] [int] NULL,
	[Departure] [datetime] NULL,
	[Arrival] [datetime] NULL,
	[Amount50kilo20feet] [int] NULL,
	[Amount50kilo40feet] [int] NULL,
	[总保费] [float] NULL,
	[备注] [nvarchar](500) NULL,
 CONSTRAINT [PK_InsuranceOfFreightTransport] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InsuranceOfFreightTransport', @level2type=N'COLUMN',@level2name=N'DimTimeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'航次ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InsuranceOfFreightTransport', @level2type=N'COLUMN',@level2name=N'VoyageID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登记人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InsuranceOfFreightTransport', @level2type=N'COLUMN',@level2name=N'InputUserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'财务部审核人员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InsuranceOfFreightTransport', @level2type=N'COLUMN',@level2name=N'ApproveUserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'币种主键，默认1为人民币' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InsuranceOfFreightTransport', @level2type=N'COLUMN',@level2name=N'CurrencyID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'汇率主键，默认NULL，不进行转换' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InsuranceOfFreightTransport', @level2type=N'COLUMN',@level2name=N'ExchangeRateID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出发时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InsuranceOfFreightTransport', @level2type=N'COLUMN',@level2name=N'Departure'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'抵达时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InsuranceOfFreightTransport', @level2type=N'COLUMN',@level2name=N'Arrival'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'5万元20英尺货柜数目' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InsuranceOfFreightTransport', @level2type=N'COLUMN',@level2name=N'Amount50kilo20feet'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'5万元40英尺货柜数目' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InsuranceOfFreightTransport', @level2type=N'COLUMN',@level2name=N'Amount50kilo40feet'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'总保费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InsuranceOfFreightTransport', @level2type=N'COLUMN',@level2name=N'总保费'
GO
SET IDENTITY_INSERT [dbo].[InsuranceOfFreightTransport] ON
INSERT [dbo].[InsuranceOfFreightTransport] ([ID], [DimTimeID], [VoyageID], [InputUserID], [ApproveUserID], [CreateTime], [CurrencyID], [ExchangeRateID], [Departure], [Arrival], [Amount50kilo20feet], [Amount50kilo40feet], [总保费], [备注]) VALUES (1, 19, 20, 1, 1, CAST(0x0000A1ED01135061 AS DateTime), 1, NULL, NULL, NULL, 10, 20, 0, N'test')
INSERT [dbo].[InsuranceOfFreightTransport] ([ID], [DimTimeID], [VoyageID], [InputUserID], [ApproveUserID], [CreateTime], [CurrencyID], [ExchangeRateID], [Departure], [Arrival], [Amount50kilo20feet], [Amount50kilo40feet], [总保费], [备注]) VALUES (2, 25, 20, 0, NULL, CAST(0x0000A2AA0164B0A6 AS DateTime), 1, 0, CAST(0x0000000000000000 AS DateTime), CAST(0x0000000000000000 AS DateTime), 1212, 222, 0, N'12121')
SET IDENTITY_INSERT [dbo].[InsuranceOfFreightTransport] OFF
/****** Object:  Table [dbo].[InsuranceOfContainer]    Script Date: 07/27/2014 23:41:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InsuranceOfContainer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DimTimeID] [int] NOT NULL,
	[InputUserID] [int] NULL,
	[ApproveUserID] [int] NULL,
	[CreateTime] [datetime] NULL,
	[CurrencyID] [int] NOT NULL,
	[ExchangeRateID] [int] NULL,
	[柜号起始字母] [nvarchar](50) NULL,
	[集装箱数量20] [int] NULL,
	[集装箱数量40] [int] NULL,
	[单价20] [float] NULL,
	[单价40] [float] NULL,
	[保额] [float] NULL,
	[基本险保险费率] [float] NULL,
	[保险期限自] [datetime] NULL,
	[保险期限到] [datetime] NULL,
	[保费] [float] NULL,
	[备注] [nvarchar](500) NULL,
 CONSTRAINT [PK_InsuranceOfContainer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[InsuranceOfContainer] ON
INSERT [dbo].[InsuranceOfContainer] ([ID], [DimTimeID], [InputUserID], [ApproveUserID], [CreateTime], [CurrencyID], [ExchangeRateID], [柜号起始字母], [集装箱数量20], [集装箱数量40], [单价20], [单价40], [保额], [基本险保险费率], [保险期限自], [保险期限到], [保费], [备注]) VALUES (2, 19, 1, 1, CAST(0x0000A1F4010F09FE AS DateTime), 2, 1, N'FOSU', 1450, 180, 2375, 3800, 4127750, 0.22, CAST(0x0000A13900000000 AS DateTime), CAST(0x0000A2A500000000 AS DateTime), 12345678, N'875332')
INSERT [dbo].[InsuranceOfContainer] ([ID], [DimTimeID], [InputUserID], [ApproveUserID], [CreateTime], [CurrencyID], [ExchangeRateID], [柜号起始字母], [集装箱数量20], [集装箱数量40], [单价20], [单价40], [保额], [基本险保险费率], [保险期限自], [保险期限到], [保费], [备注]) VALUES (7, 36, 1, NULL, CAST(0x0000A2B400B95F2D AS DateTime), 1, 0, N'tg', 1212, 12, 1212, 12, 11122222, 0.22, CAST(0x0000A2A600000000 AS DateTime), CAST(0x0000A41200000000 AS DateTime), 0, N'121212')
SET IDENTITY_INSERT [dbo].[InsuranceOfContainer] OFF
/****** Object:  Table [dbo].[OilFeeReport]    Script Date: 07/27/2014 23:41:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OilFeeReport](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VoyageID] [int] NOT NULL,
	[InputUserID] [int] NOT NULL,
	[ApproveUserID] [int] NULL,
	[CreateTime] [datetime] NOT NULL,
	[ReportTypeID] [int] NULL,
 CONSTRAINT [PK_OilFee_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'航次主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OilFeeReport', @level2type=N'COLUMN',@level2name=N'VoyageID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登记人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OilFeeReport', @level2type=N'COLUMN',@level2name=N'InputUserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'财务部审核人员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OilFeeReport', @level2type=N'COLUMN',@level2name=N'ApproveUserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报表创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OilFeeReport', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1：预估录入/2：修正录入/3：财务确认' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OilFeeReport', @level2type=N'COLUMN',@level2name=N'ReportTypeID'
GO
SET IDENTITY_INSERT [dbo].[OilFeeReport] ON
INSERT [dbo].[OilFeeReport] ([ID], [VoyageID], [InputUserID], [ApproveUserID], [CreateTime], [ReportTypeID]) VALUES (2, 28, 0, NULL, CAST(0x0000A27B0100FE3C AS DateTime), 1)
INSERT [dbo].[OilFeeReport] ([ID], [VoyageID], [InputUserID], [ApproveUserID], [CreateTime], [ReportTypeID]) VALUES (3, 20, 0, NULL, CAST(0x0000A28401656D73 AS DateTime), 1)
INSERT [dbo].[OilFeeReport] ([ID], [VoyageID], [InputUserID], [ApproveUserID], [CreateTime], [ReportTypeID]) VALUES (4, 26, 1, NULL, CAST(0x0000A287015DFEA8 AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[OilFeeReport] OFF
/****** Object:  Table [dbo].[OilTypeFee]    Script Date: 07/27/2014 23:41:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OilTypeFee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OilTypeID] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[Quantity] [float] NOT NULL,
	[PortID] [int] NOT NULL,
	[CurrencyID] [int] NOT NULL,
	[OilFeeReportID] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_OilTypeFee] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'油类型ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OilTypeFee', @level2type=N'COLUMN',@level2name=N'OilTypeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单价' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OilTypeFee', @level2type=N'COLUMN',@level2name=N'Price'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OilTypeFee', @level2type=N'COLUMN',@level2name=N'Quantity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'港口ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OilTypeFee', @level2type=N'COLUMN',@level2name=N'PortID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'币种主键，默认1为人民币' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OilTypeFee', @level2type=N'COLUMN',@level2name=N'CurrencyID'
GO
SET IDENTITY_INSERT [dbo].[OilTypeFee] ON
INSERT [dbo].[OilTypeFee] ([ID], [OilTypeID], [Price], [Quantity], [PortID], [CurrencyID], [OilFeeReportID], [CreateTime]) VALUES (1, 1, 2000.6, 12.5, 1, 1, 2, CAST(0x0000A27C00000000 AS DateTime))
INSERT [dbo].[OilTypeFee] ([ID], [OilTypeID], [Price], [Quantity], [PortID], [CurrencyID], [OilFeeReportID], [CreateTime]) VALUES (6, 6, 121212, 12, 1, 1, 4, CAST(0x0000A22E00000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[OilTypeFee] OFF
/****** Object:  Table [dbo].[InstalmentOfCompensation]    Script Date: 07/27/2014 23:41:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InstalmentOfCompensation](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CompensationID] [int] NOT NULL,
	[ReportType] [int] NOT NULL,
	[CurrencyID] [int] NOT NULL,
	[Amount] [float] NOT NULL,
	[PayDate] [datetime] NOT NULL,
	[Remark] [nvarchar](500) NULL,
 CONSTRAINT [PK_InstalmentOfCompensation] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[InstalmentOfCompensation] ON
INSERT [dbo].[InstalmentOfCompensation] ([ID], [CompensationID], [ReportType], [CurrencyID], [Amount], [PayDate], [Remark]) VALUES (2, 2, 6, 1, 6860, CAST(0x0000A14500000000 AS DateTime), NULL)
INSERT [dbo].[InstalmentOfCompensation] ([ID], [CompensationID], [ReportType], [CurrencyID], [Amount], [PayDate], [Remark]) VALUES (4, 2, 6, 1, 6860, CAST(0x0000A1C700000000 AS DateTime), NULL)
INSERT [dbo].[InstalmentOfCompensation] ([ID], [CompensationID], [ReportType], [CurrencyID], [Amount], [PayDate], [Remark]) VALUES (5, 2, 6, 1, 6860, CAST(0x0000A23F00000000 AS DateTime), NULL)
INSERT [dbo].[InstalmentOfCompensation] ([ID], [CompensationID], [ReportType], [CurrencyID], [Amount], [PayDate], [Remark]) VALUES (7, 2, 7, 1, 9300, CAST(0x0000A16B00000000 AS DateTime), NULL)
INSERT [dbo].[InstalmentOfCompensation] ([ID], [CompensationID], [ReportType], [CurrencyID], [Amount], [PayDate], [Remark]) VALUES (8, 2, 7, 1, 9300, CAST(0x0000A1D900000000 AS DateTime), NULL)
INSERT [dbo].[InstalmentOfCompensation] ([ID], [CompensationID], [ReportType], [CurrencyID], [Amount], [PayDate], [Remark]) VALUES (9, 2, 7, 1, 9300, CAST(0x0000A25300000000 AS DateTime), NULL)
INSERT [dbo].[InstalmentOfCompensation] ([ID], [CompensationID], [ReportType], [CurrencyID], [Amount], [PayDate], [Remark]) VALUES (11, 2, 7, 1, 8968.7, CAST(0x0000A27200000000 AS DateTime), NULL)
INSERT [dbo].[InstalmentOfCompensation] ([ID], [CompensationID], [ReportType], [CurrencyID], [Amount], [PayDate], [Remark]) VALUES (12, 2, 8, 2, 1212, CAST(0x0000A1F700000000 AS DateTime), N'12')
INSERT [dbo].[InstalmentOfCompensation] ([ID], [CompensationID], [ReportType], [CurrencyID], [Amount], [PayDate], [Remark]) VALUES (16, 7, 8, 1, 123123, CAST(0x0000A2B400B95F14 AS DateTime), N'111')
SET IDENTITY_INSERT [dbo].[InstalmentOfCompensation] OFF
/****** Object:  Table [dbo].[FCLCustomer]    Script Date: 07/27/2014 23:41:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FCLCustomer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Fee] [float] NOT NULL,
	[gp20] [int] NOT NULL,
	[gp40] [int] NOT NULL,
	[dp20] [int] NOT NULL,
	[dp40] [int] NOT NULL,
	[FCLID] [int] NOT NULL,
 CONSTRAINT [PK_FCLCustomer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[FCLCustomer] ON
INSERT [dbo].[FCLCustomer] ([ID], [Name], [Fee], [gp20], [gp40], [dp20], [dp40], [FCLID]) VALUES (1, N'12', 121, 1, 2, 3, 4, 2)
INSERT [dbo].[FCLCustomer] ([ID], [Name], [Fee], [gp20], [gp40], [dp20], [dp40], [FCLID]) VALUES (3, N'22', 3, 3, 2, 2, 1, 2)
SET IDENTITY_INSERT [dbo].[FCLCustomer] OFF
/****** Object:  Table [dbo].[Container]    Script Date: 07/27/2014 23:41:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Container](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[InsuranceID] [int] NOT NULL,
	[编号] [nvarchar](100) NOT NULL,
	[投保金额] [float] NOT NULL,
	[货柜类型] [int] NOT NULL,
	[备注] [nvarchar](200) NULL,
 CONSTRAINT [PK_Container] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属的保险报表编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Container', @level2type=N'COLUMN',@level2name=N'InsuranceID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0：20英寸柜；1：40英寸柜' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Container', @level2type=N'COLUMN',@level2name=N'货柜类型'
GO
SET IDENTITY_INSERT [dbo].[Container] ON
INSERT [dbo].[Container] ([ID], [InsuranceID], [编号], [投保金额], [货柜类型], [备注]) VALUES (1, 1, N'no1', 10, 1, N'test')
INSERT [dbo].[Container] ([ID], [InsuranceID], [编号], [投保金额], [货柜类型], [备注]) VALUES (6, 1, N'', 0, 2, N'')
INSERT [dbo].[Container] ([ID], [InsuranceID], [编号], [投保金额], [货柜类型], [备注]) VALUES (9, 2, N'121212', 12121212, 1, N'121212')
SET IDENTITY_INSERT [dbo].[Container] OFF
/****** Object:  View [dbo].[V_VoyageOther]    Script Date: 07/27/2014 23:41:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_VoyageOther]
AS
SELECT     dbo.Ship.Name AS ShipName, dbo.Voyage.Name, dbo.Voyage.RouteID, dbo.Voyage.ShipID, dbo.Voyage.BeginDate, dbo.Voyage.EndDate, 
                      dbo.Voyage.ManagerTypeID, dbo.ManagerType.Name AS ManagerTypeName, dbo.Voyage.ID AS VoyageID, dbo.VoyageOther.CurrencyID, dbo.VoyageOther.Amount, 
                      dbo.VoyageOther.Remark, dbo.VoyageOther.Customer, dbo.VoyageOther.User1, dbo.VoyageOther.User2, dbo.VoyageOther.User3, dbo.VoyageOther.CreateTime, 
                      dbo.VoyageOther.InputDate, dbo.VoyageOther.ID, dbo.VoyageOther.OtherName
FROM         dbo.Ship INNER JOIN
                      dbo.Voyage ON dbo.Ship.ID = dbo.Voyage.ShipID INNER JOIN
                      dbo.ManagerType ON dbo.Voyage.ManagerTypeID = dbo.ManagerType.ID LEFT OUTER JOIN
                      dbo.VoyageOther ON dbo.Voyage.ID = dbo.VoyageOther.VoyageID
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[20] 2[16] 3) )"
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
         Begin Table = "Ship"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 206
            End
            DisplayFlags = 280
            TopColumn = 6
         End
         Begin Table = "Voyage"
            Begin Extent = 
               Top = 6
               Left = 244
               Bottom = 125
               Right = 410
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ManagerType"
            Begin Extent = 
               Top = 166
               Left = 468
               Bottom = 270
               Right = 610
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "VoyageOther"
            Begin Extent = 
               Top = 4
               Left = 649
               Bottom = 178
               Right = 822
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
      Begin ColumnWidths = 21
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
         Alia' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_VoyageOther'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N's = 1830
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_VoyageOther'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_VoyageOther'
GO
/****** Object:  View [dbo].[V_VoyageLoad]    Script Date: 07/27/2014 23:41:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_VoyageLoad]
AS
SELECT     dbo.Ship.Name AS ShipName, dbo.VoyageLoad.ID, dbo.VoyageLoad.TEUEmpty, dbo.VoyageLoad.TEUHeavy, dbo.VoyageLoad.FEUEmpty, 
                      dbo.VoyageLoad.FEUHeavy, dbo.VoyageLoad.FFEUEmpty, dbo.VoyageLoad.FFEUHeavy, dbo.VoyageLoad.EqualTo, dbo.VoyageLoad.Rest, 
                      dbo.Voyage.ID AS VoyageID, dbo.Voyage.Name, dbo.Voyage.RouteID, dbo.Voyage.ShipID, dbo.Voyage.BeginDate, dbo.Voyage.EndDate, dbo.VoyageLoad.TEUFrost, 
                      dbo.VoyageLoad.FEUFrost, dbo.VoyageLoad.FEUDanger, dbo.VoyageLoad.FFEUFrost, dbo.VoyageLoad.FFEUDanger, dbo.VoyageLoad.TotalNat, 
                      dbo.VoyageLoad.TotalStand, dbo.VoyageLoad.User1, dbo.VoyageLoad.Remark, dbo.VoyageLoad.User2, dbo.VoyageLoad.User3
FROM         dbo.Ship INNER JOIN
                      dbo.Voyage ON dbo.Ship.ID = dbo.Voyage.ShipID INNER JOIN
                      dbo.VoyageLoad ON dbo.Voyage.ID = dbo.VoyageLoad.VoyageID
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
         Begin Table = "Ship"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 206
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Voyage"
            Begin Extent = 
               Top = 6
               Left = 244
               Bottom = 216
               Right = 427
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "VoyageLoad"
            Begin Extent = 
               Top = 13
               Left = 470
               Bottom = 255
               Right = 774
            End
            DisplayFlags = 280
            TopColumn = 9
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 29
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
    ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_VoyageLoad'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'     NewValue = 1170
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_VoyageLoad'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_VoyageLoad'
GO
/****** Object:  View [dbo].[V_VoyageLCL]    Script Date: 07/27/2014 23:41:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_VoyageLCL]
AS
SELECT     dbo.Ship.Name AS ShipName, dbo.Voyage.Name, dbo.Voyage.RouteID, dbo.Voyage.ShipID, dbo.Voyage.BeginDate, dbo.Voyage.EndDate, dbo.VoyageLCL.LCLAmount, 
                      dbo.VoyageLCL.LCLCatalog, dbo.VoyageLCL.CurrencyID, dbo.VoyageLCL.LCLPrice, dbo.VoyageLCL.DelayDay, dbo.VoyageLCL.QuickDay, dbo.VoyageLCL.DelayRate, 
                      dbo.VoyageLCL.Customer, dbo.VoyageLCL.QuickRate, dbo.VoyageLCL.TaxNo, dbo.VoyageLCL.LCLAmountReal, dbo.VoyageLCL.DelayAmount, 
                      dbo.VoyageLCL.DispatchAmount, dbo.VoyageLCL.Amount, dbo.VoyageLCL.User1, dbo.VoyageLCL.User2, dbo.VoyageLCL.User3, dbo.VoyageLCL.ID, 
                      dbo.Voyage.ManagerTypeID, dbo.ManagerType.Name AS ManagerTypeName, dbo.VoyageLCL.CreateTime, dbo.VoyageLCL.InputDate, 
                      dbo.Voyage.ID AS VoyageID
FROM         dbo.Ship INNER JOIN
                      dbo.Voyage ON dbo.Ship.ID = dbo.Voyage.ShipID INNER JOIN
                      dbo.ManagerType ON dbo.Voyage.ManagerTypeID = dbo.ManagerType.ID LEFT OUTER JOIN
                      dbo.VoyageLCL ON dbo.Voyage.ID = dbo.VoyageLCL.VoyageID
WHERE     (dbo.Ship.LoadType = N'1')
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[34] 4[23] 2[17] 3) )"
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
         Begin Table = "ManagerType"
            Begin Extent = 
               Top = 136
               Left = 474
               Bottom = 240
               Right = 616
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "VoyageLCL"
            Begin Extent = 
               Top = 6
               Left = 522
               Bottom = 118
               Right = 757
            End
            DisplayFlags = 280
            TopColumn = 18
         End
         Begin Table = "Ship"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 126
               Right = 206
            End
            DisplayFlags = 280
            TopColumn = 5
         End
         Begin Table = "Voyage"
            Begin Extent = 
               Top = 6
               Left = 244
               Bottom = 194
               Right = 411
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
      Begin ColumnWidths = 31
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
         Width = 1500
         Width = 1500
         Width = 1500' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_VoyageLCL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'
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
         Table = 1815
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_VoyageLCL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_VoyageLCL'
GO
/****** Object:  View [dbo].[V_VoyageFCL]    Script Date: 07/27/2014 23:41:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_VoyageFCL]
AS
SELECT     dbo.Ship.Name AS ShipName, dbo.Voyage.Name, dbo.Voyage.RouteID, dbo.Voyage.ShipID, dbo.Voyage.BeginDate, dbo.Voyage.EndDate, dbo.VoyageFCL.CurrencyID, 
                      dbo.VoyageFCL.Customer, dbo.VoyageFCL.TaxNo, dbo.VoyageFCL.Amount, dbo.VoyageFCL.User1, dbo.VoyageFCL.User3, dbo.VoyageFCL.User2, dbo.VoyageFCL.ID, 
                      dbo.VoyageFCL.CreateTime, dbo.Voyage.ManagerTypeID, dbo.ManagerType.Name AS ManagerTypeName, dbo.VoyageFCL.InputDate, dbo.Voyage.ID AS VoyageID, 
                      dbo.VoyageFCL.Fee, dbo.VoyageFCL.BeginFee, dbo.VoyageFCL.EndFee, dbo.VoyageFCL.OilFee, dbo.VoyageFCL.Tally, dbo.VoyageFCL.Box, dbo.VoyageFCL.Other, 
                      dbo.VoyageFCL.Remark, dbo.VoyageLoad.TEUEmpty, dbo.VoyageLoad.TEUHeavy, dbo.VoyageLoad.TEUFrost, dbo.VoyageLoad.FEUHeavy, 
                      dbo.VoyageLoad.FEUEmpty, dbo.VoyageLoad.FEUFrost, dbo.VoyageLoad.FEUDanger, dbo.VoyageLoad.FFEUEmpty, dbo.VoyageLoad.FFEUHeavy, 
                      dbo.VoyageLoad.FFEUFrost, dbo.VoyageLoad.FFEUDanger, dbo.VoyageLoad.Rest, dbo.VoyageLoad.EqualTo, dbo.VoyageLoad.TotalNat, dbo.VoyageLoad.TotalStand, 
                      dbo.VoyageFCL.Subsidize, dbo.VoyageFCL.BookFee, dbo.VoyageFCL.BranchOther
FROM         dbo.Ship INNER JOIN
                      dbo.Voyage ON dbo.Ship.ID = dbo.Voyage.ShipID INNER JOIN
                      dbo.ManagerType ON dbo.Voyage.ManagerTypeID = dbo.ManagerType.ID LEFT OUTER JOIN
                      dbo.VoyageLoad ON dbo.Voyage.ID = dbo.VoyageLoad.VoyageID LEFT OUTER JOIN
                      dbo.VoyageFCL ON dbo.Voyage.ID = dbo.VoyageFCL.VoyageID
WHERE     (dbo.Ship.LoadType = N'2')
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[28] 4[33] 2[17] 3) )"
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
         Begin Table = "Ship"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 126
               Right = 206
            End
            DisplayFlags = 280
            TopColumn = 6
         End
         Begin Table = "Voyage"
            Begin Extent = 
               Top = 6
               Left = 244
               Bottom = 142
               Right = 417
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ManagerType"
            Begin Extent = 
               Top = 159
               Left = 428
               Bottom = 263
               Right = 570
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "VoyageLoad"
            Begin Extent = 
               Top = 167
               Left = 786
               Bottom = 382
               Right = 1004
            End
            DisplayFlags = 280
            TopColumn = 11
         End
         Begin Table = "VoyageFCL"
            Begin Extent = 
               Top = 3
               Left = 502
               Bottom = 168
               Right = 686
            End
            DisplayFlags = 280
            TopColumn = 15
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 35
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
         Width = 1500
         Width = 1500
       ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_VoyageFCL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'  Width = 1500
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
         Column = 3105
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_VoyageFCL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_VoyageFCL'
GO
/****** Object:  View [dbo].[V_InsuranceOfFreightTransport]    Script Date: 07/27/2014 23:41:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_InsuranceOfFreightTransport]
AS
SELECT     dbo.Ship.Name AS ShipName, dbo.Voyage.Name, dbo.Voyage.BeginDate, dbo.Voyage.EndDate, dbo.InsuranceOfFreightTransport.ID, 
                      dbo.InsuranceOfFreightTransport.DimTimeID, dbo.InsuranceOfFreightTransport.Amount50kilo20feet, dbo.InsuranceOfFreightTransport.Amount50kilo40feet, 
                      dbo.Port.Name AS Port1, Port_1.Name AS Port2, dbo.Ship.ID AS ShipID, dbo.DimTime.Year, dbo.DimTime.MonthNumOfYear, dbo.InsuranceOfFreightTransport.总保费, 
                      dbo.Currency.Name AS CurrencyName
FROM         dbo.DimTime INNER JOIN
                      dbo.InsuranceOfFreightTransport ON dbo.DimTime.ID = dbo.InsuranceOfFreightTransport.DimTimeID INNER JOIN
                      dbo.Currency ON dbo.InsuranceOfFreightTransport.CurrencyID = dbo.Currency.ID RIGHT OUTER JOIN
                      dbo.Relation_RoutePort INNER JOIN
                      dbo.Route ON dbo.Relation_RoutePort.RouteID = dbo.Route.ID INNER JOIN
                      dbo.Port ON dbo.Relation_RoutePort.PortID = dbo.Port.ID INNER JOIN
                      dbo.Relation_RoutePort AS Relation_RoutePort_1 ON dbo.Route.ID = Relation_RoutePort_1.RouteID INNER JOIN
                      dbo.Port AS Port_1 ON Relation_RoutePort_1.PortID = Port_1.ID RIGHT OUTER JOIN
                      dbo.Ship RIGHT OUTER JOIN
                      dbo.Voyage ON dbo.Ship.ID = dbo.Voyage.ShipID ON dbo.Route.ID = dbo.Voyage.RouteID ON dbo.InsuranceOfFreightTransport.VoyageID = dbo.Voyage.ID
WHERE     (dbo.Relation_RoutePort.PortTypeID = 1) AND (Relation_RoutePort_1.PortTypeID = 4)
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[33] 4[33] 2[21] 3) )"
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
         Top = -96
         Left = -11
      End
      Begin Tables = 
         Begin Table = "DimTime"
            Begin Extent = 
               Top = 408
               Left = 795
               Bottom = 527
               Right = 977
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Currency"
            Begin Extent = 
               Top = 198
               Left = 788
               Bottom = 287
               Right = 930
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Relation_RoutePort"
            Begin Extent = 
               Top = 7
               Left = 278
               Bottom = 126
               Right = 422
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "Route"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 117
               Right = 188
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Port"
            Begin Extent = 
               Top = 0
               Left = 502
               Bottom = 104
               Right = 644
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Relation_RoutePort_1"
            Begin Extent = 
               Top = 130
               Left = 275
               Bottom = 249
               Right = 419
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Port_1"
            Begin Extent = 
               Top = 127
               Left = 510
               Bottom = 231
               Right = 652
            End
        ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_InsuranceOfFreightTransport'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'    DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Ship"
            Begin Extent = 
               Top = 143
               Left = 14
               Bottom = 262
               Right = 182
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Voyage"
            Begin Extent = 
               Top = 268
               Left = 276
               Bottom = 387
               Right = 431
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "InsuranceOfFreightTransport"
            Begin Extent = 
               Top = 286
               Left = 492
               Bottom = 434
               Right = 750
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
      Begin ColumnWidths = 15
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
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 2070
         Alias = 900
         Table = 1845
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_InsuranceOfFreightTransport'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_InsuranceOfFreightTransport'
GO
/****** Object:  View [dbo].[V_InsuranceOfContainer]    Script Date: 07/27/2014 23:41:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_InsuranceOfContainer]
AS
SELECT     dbo.InsuranceOfContainer.ID, dbo.InsuranceOfContainer.DimTimeID, dbo.InsuranceOfContainer.InputUserID, dbo.InsuranceOfContainer.ApproveUserID, 
                      dbo.InsuranceOfContainer.CreateTime, dbo.InsuranceOfContainer.CurrencyID, dbo.InsuranceOfContainer.ExchangeRateID, dbo.InsuranceOfContainer.柜号起始字母, 
                      dbo.InsuranceOfContainer.集装箱数量20, dbo.InsuranceOfContainer.集装箱数量40, dbo.InsuranceOfContainer.单价20, dbo.InsuranceOfContainer.单价40, 
                      dbo.InsuranceOfContainer.保额, dbo.InsuranceOfContainer.基本险保险费率, dbo.InsuranceOfContainer.保险期限自, dbo.InsuranceOfContainer.保险期限到, 
                      dbo.InsuranceOfContainer.保费, dbo.InsuranceOfContainer.备注, dbo.Currency.Name AS CurrencyName, dbo.DimTime.Year
FROM         dbo.Currency INNER JOIN
                      dbo.InsuranceOfContainer ON dbo.Currency.ID = dbo.InsuranceOfContainer.CurrencyID INNER JOIN
                      dbo.DimTime ON dbo.InsuranceOfContainer.DimTimeID = dbo.DimTime.ID
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
         Begin Table = "Currency"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 95
               Right = 180
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "InsuranceOfContainer"
            Begin Extent = 
               Top = 4
               Left = 339
               Bottom = 123
               Right = 512
            End
            DisplayFlags = 280
            TopColumn = 7
         End
         Begin Table = "DimTime"
            Begin Extent = 
               Top = 0
               Left = 774
               Bottom = 119
               Right = 956
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
      Begin ColumnWidths = 23
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
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_InsuranceOfContainer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'        Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_InsuranceOfContainer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_InsuranceOfContainer'
GO
/****** Object:  View [dbo].[V_RentContainer]    Script Date: 07/27/2014 23:41:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_RentContainer]
AS
SELECT     dbo.RentContainer.ID, dbo.RentContainer.ReportID, dbo.RentContainer.ContainerTypeID, dbo.RentContainer.Amount, dbo.RentContainer.Price, 
                      dbo.RentContainer.RentFee, dbo.RentContainer.Remark, dbo.RentContainer.CreateTime, dbo.Currency.Name AS CurrencyName, dbo.RentContainerReport.CurrencyID, 
                      dbo.RentContainerReport.EndDate, dbo.RentContainerReport.BeginDate, dbo.RentContainerReport.Customer, dbo.RentContainerReport.TaxNo, 
                      dbo.RentContainerReport.User1, dbo.RentContainerReport.User2, dbo.RentContainerReport.User3, dbo.RentContainerReport.InputDate, 
                      dbo.RentContainerReport.RentDays
FROM         dbo.RentContainer INNER JOIN
                      dbo.RentContainerReport ON dbo.RentContainer.ReportID = dbo.RentContainerReport.ID INNER JOIN
                      dbo.Currency ON dbo.RentContainerReport.CurrencyID = dbo.Currency.ID
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[32] 2[9] 3) )"
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
         Begin Table = "RentContainer"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 190
               Right = 224
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "RentContainerReport"
            Begin Extent = 
               Top = 10
               Left = 278
               Bottom = 195
               Right = 471
            End
            DisplayFlags = 280
            TopColumn = 6
         End
         Begin Table = "Currency"
            Begin Extent = 
               Top = 6
               Left = 509
               Bottom = 95
               Right = 651
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
      Begin ColumnWidths = 23
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
         Alias = 1305
         Table = 2040
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_RentContainer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_RentContainer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_RentContainer'
GO
/****** Object:  View [dbo].[V_OilFeeReport]    Script Date: 07/27/2014 23:41:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_OilFeeReport]
AS
SELECT     dbo.OilFeeReport.ID, dbo.OilFeeReport.ApproveUserID, dbo.OilFeeReport.CreateTime, dbo.OilFeeReport.ReportTypeID, User_1.Name AS InputUserName, 
                      dbo.OilFeeReport.InputUserID, dbo.[User].Name AS ApproveUserName, dbo.OilFeeReport.VoyageID, dbo.Voyage.Name AS VoyageName
FROM         dbo.Voyage INNER JOIN
                      dbo.OilFeeReport ON dbo.Voyage.ID = dbo.OilFeeReport.VoyageID LEFT OUTER JOIN
                      dbo.[User] ON dbo.OilFeeReport.ApproveUserID = dbo.[User].ID LEFT OUTER JOIN
                      dbo.[User] AS User_1 ON dbo.OilFeeReport.InputUserID = User_1.ID
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
         Begin Table = "User_1"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 114
               Right = 186
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "OilFeeReport"
            Begin Extent = 
               Top = 16
               Left = 255
               Bottom = 124
               Right = 409
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "Voyage"
            Begin Extent = 
               Top = 9
               Left = 455
               Bottom = 117
               Right = 605
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "User"
            Begin Extent = 
               Top = 161
               Left = 45
               Bottom = 269
               Right = 193
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
         O' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_OilFeeReport'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'r = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_OilFeeReport'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_OilFeeReport'
GO
/****** Object:  View [dbo].[V_InstalmentOfCompensation]    Script Date: 07/27/2014 23:41:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_InstalmentOfCompensation]
AS
SELECT     dbo.InstalmentOfCompensation.*, dbo.Currency.Name AS CurrencyName
FROM         dbo.InstalmentOfCompensation INNER JOIN
                      dbo.Currency ON dbo.InstalmentOfCompensation.CurrencyID = dbo.Currency.ID
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
         Begin Table = "InstalmentOfCompensation"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 206
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Currency"
            Begin Extent = 
               Top = 73
               Left = 372
               Bottom = 162
               Right = 514
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_InstalmentOfCompensation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_InstalmentOfCompensation'
GO
/****** Object:  View [dbo].[V_OilTypeFee]    Script Date: 07/27/2014 23:41:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_OilTypeFee]
AS
SELECT     dbo.OilType.Name AS OilTypeName, dbo.OilType.Category, dbo.Port.Name AS PortName, dbo.Currency.Name AS CurrencyName, dbo.OilTypeFee.ID, 
                      dbo.OilTypeFee.OilTypeID, dbo.OilTypeFee.Price, dbo.OilTypeFee.Quantity, dbo.OilTypeFee.PortID, dbo.OilTypeFee.CurrencyID, dbo.OilTypeFee.OilFeeReportID, 
                      dbo.OilTypeFee.CreateTime
FROM         dbo.OilType INNER JOIN
                      dbo.Currency INNER JOIN
                      dbo.OilTypeFee ON dbo.Currency.ID = dbo.OilTypeFee.CurrencyID ON dbo.OilType.ID = dbo.OilTypeFee.OilTypeID INNER JOIN
                      dbo.Port ON dbo.OilTypeFee.PortID = dbo.Port.ID
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
         Begin Table = "OilType"
            Begin Extent = 
               Top = 12
               Left = 53
               Bottom = 105
               Right = 186
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Currency"
            Begin Extent = 
               Top = 208
               Left = 69
               Bottom = 286
               Right = 202
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "OilTypeFee"
            Begin Extent = 
               Top = 116
               Left = 274
               Bottom = 224
               Right = 428
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Port"
            Begin Extent = 
               Top = 109
               Left = 27
               Bottom = 202
               Right = 160
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
      Begin ColumnWidths = 14
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
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 1500
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
  ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_OilTypeFee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'       GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_OilTypeFee'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_OilTypeFee'
GO
/****** Object:  View [dbo].[V_FCLCustomer]    Script Date: 07/27/2014 23:41:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_FCLCustomer]
AS
SELECT     dbo.FCLCustomer.ID, dbo.FCLCustomer.Name, dbo.FCLCustomer.Fee, dbo.FCLCustomer.gp20, dbo.FCLCustomer.gp40, dbo.FCLCustomer.dp20, 
                      dbo.FCLCustomer.dp40, dbo.FCLCustomer.FCLID
FROM         dbo.FCLCustomer INNER JOIN
                      dbo.VoyageFCL ON dbo.FCLCustomer.FCLID = dbo.VoyageFCL.ID
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
         Begin Table = "VoyageFCL"
            Begin Extent = 
               Top = 6
               Left = 230
               Bottom = 125
               Right = 374
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "FCLCustomer"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 192
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_FCLCustomer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'V_FCLCustomer'
GO
/****** Object:  Default [DF_RentShipReport_RentType]    Script Date: 07/27/2014 23:41:01 ******/
ALTER TABLE [dbo].[RentShipReport] ADD  CONSTRAINT [DF_RentShipReport_RentType]  DEFAULT ((1)) FOR [RentTypeID]
GO
/****** Object:  Default [DF_RentShipReport_CurrencyID]    Script Date: 07/27/2014 23:41:01 ******/
ALTER TABLE [dbo].[RentShipReport] ADD  CONSTRAINT [DF_RentShipReport_CurrencyID]  DEFAULT ((1)) FOR [CurrencyID]
GO
/****** Object:  Default [DF_RentShipReport_BeginDate1]    Script Date: 07/27/2014 23:41:01 ******/
ALTER TABLE [dbo].[RentShipReport] ADD  CONSTRAINT [DF_RentShipReport_BeginDate1]  DEFAULT (getdate()) FOR [InputDate]
GO
/****** Object:  Default [DF_RentShipReport_InputDate1]    Script Date: 07/27/2014 23:41:01 ******/
ALTER TABLE [dbo].[RentShipReport] ADD  CONSTRAINT [DF_RentShipReport_InputDate1]  DEFAULT (getdate()) FOR [CreateTime]
GO
/****** Object:  Default [DF_RentShipReport_Amount1]    Script Date: 07/27/2014 23:41:01 ******/
ALTER TABLE [dbo].[RentShipReport] ADD  CONSTRAINT [DF_RentShipReport_Amount1]  DEFAULT ((0)) FOR [RentFee]
GO
/****** Object:  Default [DF_RentShipReport_Price1]    Script Date: 07/27/2014 23:41:01 ******/
ALTER TABLE [dbo].[RentShipReport] ADD  CONSTRAINT [DF_RentShipReport_Price1]  DEFAULT ((0)) FOR [Amount]
GO
/****** Object:  Default [DF_RentShipReport_BeginDate]    Script Date: 07/27/2014 23:41:01 ******/
ALTER TABLE [dbo].[RentShipReport] ADD  CONSTRAINT [DF_RentShipReport_BeginDate]  DEFAULT (getdate()) FOR [BeginDate]
GO
/****** Object:  Default [DF_RentShipReport_EndDate]    Script Date: 07/27/2014 23:41:01 ******/
ALTER TABLE [dbo].[RentShipReport] ADD  CONSTRAINT [DF_RentShipReport_EndDate]  DEFAULT (getdate()) FOR [EndDate]
GO
/****** Object:  Default [DF_RentShipReport_DiscountDays1]    Script Date: 07/27/2014 23:41:01 ******/
ALTER TABLE [dbo].[RentShipReport] ADD  CONSTRAINT [DF_RentShipReport_DiscountDays1]  DEFAULT ((0)) FOR [RentDays]
GO
/****** Object:  Default [DF_RentShipReport_DiscountDays]    Script Date: 07/27/2014 23:41:01 ******/
ALTER TABLE [dbo].[RentShipReport] ADD  CONSTRAINT [DF_RentShipReport_DiscountDays]  DEFAULT ((0)) FOR [DiscountDays]
GO
/****** Object:  Default [DF_RentShipReport_Price]    Script Date: 07/27/2014 23:41:01 ******/
ALTER TABLE [dbo].[RentShipReport] ADD  CONSTRAINT [DF_RentShipReport_Price]  DEFAULT ((0)) FOR [Price]
GO
/****** Object:  Default [DF_RentShipReport_CommunicateFee]    Script Date: 07/27/2014 23:41:01 ******/
ALTER TABLE [dbo].[RentShipReport] ADD  CONSTRAINT [DF_RentShipReport_CommunicateFee]  DEFAULT ((0)) FOR [CommunicateFee]
GO
/****** Object:  Default [DF_RentShipReport_LockFee]    Script Date: 07/27/2014 23:41:01 ******/
ALTER TABLE [dbo].[RentShipReport] ADD  CONSTRAINT [DF_RentShipReport_LockFee]  DEFAULT ((0)) FOR [LockFee]
GO
/****** Object:  Default [DF_RentShipReport_OtherFee]    Script Date: 07/27/2014 23:41:01 ******/
ALTER TABLE [dbo].[RentShipReport] ADD  CONSTRAINT [DF_RentShipReport_OtherFee]  DEFAULT ((0)) FOR [OtherFee]
GO
/****** Object:  Default [DF_Ship_LoadType]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[Ship] ADD  CONSTRAINT [DF_Ship_LoadType]  DEFAULT ((2)) FOR [LoadType]
GO
/****** Object:  Default [DF_Ship_OperationType]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[Ship] ADD  CONSTRAINT [DF_Ship_OperationType]  DEFAULT ((1)) FOR [OperationType]
GO
/****** Object:  Default [DF_Ship_RentDate]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[Ship] ADD  CONSTRAINT [DF_Ship_RentDate]  DEFAULT (getdate()) FOR [RentDate]
GO
/****** Object:  Default [DF_Ship_Enable]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[Ship] ADD  CONSTRAINT [DF_Ship_Enable]  DEFAULT ((1)) FOR [Enable]
GO
/****** Object:  Default [DF_ManagerType_TaxRate]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[ManagerType] ADD  CONSTRAINT [DF_ManagerType_TaxRate]  DEFAULT ((0)) FOR [TaxRate]
GO
/****** Object:  Default [DF_Log_Time]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[Log] ADD  CONSTRAINT [DF_Log_Time]  DEFAULT (getdate()) FOR [Time]
GO
/****** Object:  Default [DF_OilType_Type]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[OilType] ADD  CONSTRAINT [DF_OilType_Type]  DEFAULT ((1)) FOR [Category]
GO
/****** Object:  Default [DF_HangciBaseInput_ShipInputDate]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[HangciBaseInput] ADD  CONSTRAINT [DF_HangciBaseInput_ShipInputDate]  DEFAULT (getdate()) FOR [ShipInputDate]
GO
/****** Object:  Default [DF_HangciBaseInput_GeneralManagerDate]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[HangciBaseInput] ADD  CONSTRAINT [DF_HangciBaseInput_GeneralManagerDate]  DEFAULT (getdate()) FOR [GeneralManagerDate]
GO
/****** Object:  Default [DF_FleeCatalog_DepartmentID]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[FeeCatalog] ADD  CONSTRAINT [DF_FleeCatalog_DepartmentID]  DEFAULT ((4)) FOR [DepartmentID]
GO
/****** Object:  Default [DF_CommonFlee_Amount]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[CommonFee] ADD  CONSTRAINT [DF_CommonFlee_Amount]  DEFAULT ((0)) FOR [Amount]
GO
/****** Object:  Default [DF_CertificateFlee_CreateTime]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[CertificateFlee] ADD  CONSTRAINT [DF_CertificateFlee_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
/****** Object:  Default [DF_CertificateFlee_CurrencyID]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[CertificateFlee] ADD  CONSTRAINT [DF_CertificateFlee_CurrencyID]  DEFAULT ((1)) FOR [CurrencyID]
GO
/****** Object:  Default [DF_CertificateFlee_证书类型]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[CertificateFlee] ADD  CONSTRAINT [DF_CertificateFlee_证书类型]  DEFAULT ((1)) FOR [证书类型]
GO
/****** Object:  Default [DF_CertificateFlee_快递费]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[CertificateFlee] ADD  CONSTRAINT [DF_CertificateFlee_快递费]  DEFAULT ((0)) FOR [快递费]
GO
/****** Object:  Default [DF_CertificateFlee_图纸复印费]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[CertificateFlee] ADD  CONSTRAINT [DF_CertificateFlee_图纸复印费]  DEFAULT ((0)) FOR [图纸复印费]
GO
/****** Object:  Default [DF_CertificateFlee_图纸复印费3]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[CertificateFlee] ADD  CONSTRAINT [DF_CertificateFlee_图纸复印费3]  DEFAULT ((0)) FOR [洗照片]
GO
/****** Object:  Default [DF_CertificateFlee_图纸复印费2]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[CertificateFlee] ADD  CONSTRAINT [DF_CertificateFlee_图纸复印费2]  DEFAULT ((0)) FOR [公正]
GO
/****** Object:  Default [DF_CertificateFlee_图纸复印费1]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[CertificateFlee] ADD  CONSTRAINT [DF_CertificateFlee_图纸复印费1]  DEFAULT ((0)) FOR [其他]
GO
/****** Object:  Default [DF_BeijianInput_CreateTime]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[BeijianInput] ADD  CONSTRAINT [DF_BeijianInput_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
/****** Object:  Default [DF_BeijianInput_ReportTypeID]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[BeijianInput] ADD  CONSTRAINT [DF_BeijianInput_ReportTypeID]  DEFAULT ((1)) FOR [ReportTypeID]
GO
/****** Object:  Default [DF_BeijianInput_CurrencyID]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[BeijianInput] ADD  CONSTRAINT [DF_BeijianInput_CurrencyID]  DEFAULT ((1)) FOR [CurrencyID]
GO
/****** Object:  Default [DF_BeijianInput_总数]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[BeijianInput] ADD  CONSTRAINT [DF_BeijianInput_总数]  DEFAULT ((0)) FOR [总数]
GO
/****** Object:  Default [DF_InsuranceOfCompensation_CreateTime]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[InsuranceOfCompensation] ADD  CONSTRAINT [DF_InsuranceOfCompensation_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
/****** Object:  Default [DF_InsuranceOfCompensation_CurrencyID]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[InsuranceOfCompensation] ADD  CONSTRAINT [DF_InsuranceOfCompensation_CurrencyID]  DEFAULT ((1)) FOR [CurrencyID]
GO
/****** Object:  Default [DF_InsuranceOfCompensation_Amount50kilo20feet]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[InsuranceOfCompensation] ADD  CONSTRAINT [DF_InsuranceOfCompensation_Amount50kilo20feet]  DEFAULT ((0)) FOR [主险保额]
GO
/****** Object:  Default [DF_InsuranceOfCompensation_Amount50kilo40feet]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[InsuranceOfCompensation] ADD  CONSTRAINT [DF_InsuranceOfCompensation_Amount50kilo40feet]  DEFAULT ((0)) FOR [主险费率]
GO
/****** Object:  Default [DF_InsuranceOfCompensation_总数]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[InsuranceOfCompensation] ADD  CONSTRAINT [DF_InsuranceOfCompensation_总数]  DEFAULT ((0)) FOR [主险保费]
GO
/****** Object:  Default [DF_InsuranceOfCompensation_战争保赔险费率]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[InsuranceOfCompensation] ADD  CONSTRAINT [DF_InsuranceOfCompensation_战争保赔险费率]  DEFAULT ((0)) FOR [战争保赔险费率]
GO
/****** Object:  Default [DF_InsuranceOfCompensation_战争保赔险费率1]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[InsuranceOfCompensation] ADD  CONSTRAINT [DF_InsuranceOfCompensation_战争保赔险费率1]  DEFAULT ((0)) FOR [战争保赔险保费]
GO
/****** Object:  Default [DF_InsuranceOfCompensation_免赔额]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[InsuranceOfCompensation] ADD  CONSTRAINT [DF_InsuranceOfCompensation_免赔额]  DEFAULT ((0)) FOR [免赔额]
GO
/****** Object:  Default [DF_InsuranceOfCompensation_船舶险总保费]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[InsuranceOfCompensation] ADD  CONSTRAINT [DF_InsuranceOfCompensation_船舶险总保费]  DEFAULT ((0)) FOR [船舶险总保费]
GO
/****** Object:  Default [DF_InsuranceOfCompensation_保赔险费率]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[InsuranceOfCompensation] ADD  CONSTRAINT [DF_InsuranceOfCompensation_保赔险费率]  DEFAULT ((0)) FOR [保赔险费率]
GO
/****** Object:  Default [DF_InsuranceOfCompensation_保赔险保费]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[InsuranceOfCompensation] ADD  CONSTRAINT [DF_InsuranceOfCompensation_保赔险保费]  DEFAULT ((0)) FOR [保赔险保费]
GO
/****** Object:  Default [DF_Relation_RoutePort_OrderNum]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[Relation_RoutePort] ADD  CONSTRAINT [DF_Relation_RoutePort_OrderNum]  DEFAULT ((0)) FOR [OrderNum]
GO
/****** Object:  Default [DF_JianyanInput_CreateTime]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[JianyanInput] ADD  CONSTRAINT [DF_JianyanInput_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
/****** Object:  Default [DF_JianyanInput_ReportTypeID]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[JianyanInput] ADD  CONSTRAINT [DF_JianyanInput_ReportTypeID]  DEFAULT ((1)) FOR [ReportTypeID]
GO
/****** Object:  Default [DF_JianyanInput_CurrencyID]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[JianyanInput] ADD  CONSTRAINT [DF_JianyanInput_CurrencyID]  DEFAULT ((1)) FOR [CurrencyID]
GO
/****** Object:  Default [DF_JianyanInput_总数]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[JianyanInput] ADD  CONSTRAINT [DF_JianyanInput_总数]  DEFAULT ((0)) FOR [总数]
GO
/****** Object:  Default [DF_Invoice_Amout]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[Invoice] ADD  CONSTRAINT [DF_Invoice_Amout]  DEFAULT ((0)) FOR [Amout]
GO
/****** Object:  Default [DF_Invoice_CurrencyID]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[Invoice] ADD  CONSTRAINT [DF_Invoice_CurrencyID]  DEFAULT ((1)) FOR [CurrencyID]
GO
/****** Object:  Default [DF_Invoice_Amout1]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[Invoice] ADD  CONSTRAINT [DF_Invoice_Amout1]  DEFAULT ((0)) FOR [Rate]
GO
/****** Object:  Default [DF_Invoice_CreateTime1]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[Invoice] ADD  CONSTRAINT [DF_Invoice_CreateTime1]  DEFAULT (getdate()) FOR [InputDate]
GO
/****** Object:  Default [DF_Invoice_CreateTime]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[Invoice] ADD  CONSTRAINT [DF_Invoice_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
/****** Object:  Default [DF_SampleReport_CreateTime]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[SampleReport] ADD  CONSTRAINT [DF_SampleReport_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
/****** Object:  Default [DF_SampleReport_Data1]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[SampleReport] ADD  CONSTRAINT [DF_SampleReport_Data1]  DEFAULT ((0)) FOR [Data1]
GO
/****** Object:  Default [DF_SampleReport_Data2]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[SampleReport] ADD  CONSTRAINT [DF_SampleReport_Data2]  DEFAULT ((0)) FOR [Data2]
GO
/****** Object:  Default [DF_SampleReport_Data3]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[SampleReport] ADD  CONSTRAINT [DF_SampleReport_Data3]  DEFAULT ((0)) FOR [Data3]
GO
/****** Object:  Default [DF_RentContainerReport_CurrencyID]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[RentContainerReport] ADD  CONSTRAINT [DF_RentContainerReport_CurrencyID]  DEFAULT ((1)) FOR [CurrencyID]
GO
/****** Object:  Default [DF_RentContainerReport_BeginDate1]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[RentContainerReport] ADD  CONSTRAINT [DF_RentContainerReport_BeginDate1]  DEFAULT (getdate()) FOR [InputDate]
GO
/****** Object:  Default [DF_RentContainerReport_InputDate1]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[RentContainerReport] ADD  CONSTRAINT [DF_RentContainerReport_InputDate1]  DEFAULT (getdate()) FOR [CreateTime]
GO
/****** Object:  Default [DF_RentContainerReport_Price1]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[RentContainerReport] ADD  CONSTRAINT [DF_RentContainerReport_Price1]  DEFAULT ((0)) FOR [Amount]
GO
/****** Object:  Default [DF_RentContainerReport_BeginDate]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[RentContainerReport] ADD  CONSTRAINT [DF_RentContainerReport_BeginDate]  DEFAULT (getdate()) FOR [BeginDate]
GO
/****** Object:  Default [DF_RentContainerReport_EndDate]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[RentContainerReport] ADD  CONSTRAINT [DF_RentContainerReport_EndDate]  DEFAULT (getdate()) FOR [EndDate]
GO
/****** Object:  Default [DF_RentContainerReport_DiscountDays1]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[RentContainerReport] ADD  CONSTRAINT [DF_RentContainerReport_DiscountDays1]  DEFAULT ((0)) FOR [RentDays]
GO
/****** Object:  Default [DF_Voyage_BeginDate]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[Voyage] ADD  CONSTRAINT [DF_Voyage_BeginDate]  DEFAULT (getdate()) FOR [BeginDate]
GO
/****** Object:  Default [DF_Voyage_EndDate]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[Voyage] ADD  CONSTRAINT [DF_Voyage_EndDate]  DEFAULT (getdate()) FOR [EndDate]
GO
/****** Object:  Default [DF_Voyage_Order]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[Voyage] ADD  CONSTRAINT [DF_Voyage_Order]  DEFAULT ((1)) FOR [OrderNum]
GO
/****** Object:  Default [DF_Voyage_ManagerTypeID]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[Voyage] ADD  CONSTRAINT [DF_Voyage_ManagerTypeID]  DEFAULT ((1)) FOR [ManagerTypeID]
GO
/****** Object:  Default [DF_ExchangeRate_CurrencyID]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[ExchangeRate] ADD  CONSTRAINT [DF_ExchangeRate_CurrencyID]  DEFAULT ((1)) FOR [CurrencyID]
GO
/****** Object:  Default [DF_XiuliInput_CreateTime]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[XiuliInput] ADD  CONSTRAINT [DF_XiuliInput_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
/****** Object:  Default [DF_XiuliInput_ReportTypeID]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[XiuliInput] ADD  CONSTRAINT [DF_XiuliInput_ReportTypeID]  DEFAULT ((1)) FOR [ReportTypeID]
GO
/****** Object:  Default [DF_XiuliInput_CurrencyID]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[XiuliInput] ADD  CONSTRAINT [DF_XiuliInput_CurrencyID]  DEFAULT ((1)) FOR [CurrencyID]
GO
/****** Object:  Default [DF_XiuliInput_总数]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[XiuliInput] ADD  CONSTRAINT [DF_XiuliInput_总数]  DEFAULT ((0)) FOR [总数]
GO
/****** Object:  Default [DF_WuliaoInput_UsageType]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[WuliaoInput] ADD  CONSTRAINT [DF_WuliaoInput_UsageType]  DEFAULT ((1)) FOR [UsageType]
GO
/****** Object:  Default [DF_WuliaoInput_CreateTime]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[WuliaoInput] ADD  CONSTRAINT [DF_WuliaoInput_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
/****** Object:  Default [DF_WuliaoInput_State]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[WuliaoInput] ADD  CONSTRAINT [DF_WuliaoInput_State]  DEFAULT ((1)) FOR [CheckState]
GO
/****** Object:  Default [DF_WuliaoInput_ReportTypeID]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[WuliaoInput] ADD  CONSTRAINT [DF_WuliaoInput_ReportTypeID]  DEFAULT ((1)) FOR [ReportTypeID]
GO
/****** Object:  Default [DF_WuliaoInput_CurrencyID]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[WuliaoInput] ADD  CONSTRAINT [DF_WuliaoInput_CurrencyID]  DEFAULT ((1)) FOR [CurrencyID]
GO
/****** Object:  Default [DF_WuliaoInput_ExchangeRateID]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[WuliaoInput] ADD  CONSTRAINT [DF_WuliaoInput_ExchangeRateID]  DEFAULT ('') FOR [ExchangeRateID]
GO
/****** Object:  Default [DF_WuliaoInput_总数]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[WuliaoInput] ADD  CONSTRAINT [DF_WuliaoInput_总数]  DEFAULT ((0)) FOR [总数]
GO
/****** Object:  Default [DF_VoyageRent_LCLAmount1]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageRent_todel] ADD  CONSTRAINT [DF_VoyageRent_LCLAmount1]  DEFAULT ((0)) FOR [LCLCatalog]
GO
/****** Object:  Default [DF_VoyageRent_LCLAmount]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageRent_todel] ADD  CONSTRAINT [DF_VoyageRent_LCLAmount]  DEFAULT ((0)) FOR [LCLAmount]
GO
/****** Object:  Default [DF_VoyageRent_LCLAmount11]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageRent_todel] ADD  CONSTRAINT [DF_VoyageRent_LCLAmount11]  DEFAULT ((0)) FOR [LCLPrice]
GO
/****** Object:  Default [DF_VoyageRent_LCLAmount11_1]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageRent_todel] ADD  CONSTRAINT [DF_VoyageRent_LCLAmount11_1]  DEFAULT ((1)) FOR [CurrencyID]
GO
/****** Object:  Default [DF_VoyageRent_LCLAmount11_2]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageRent_todel] ADD  CONSTRAINT [DF_VoyageRent_LCLAmount11_2]  DEFAULT ((1)) FOR [DelayDay]
GO
/****** Object:  Default [DF_VoyageRent_LCLAmount11_3]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageRent_todel] ADD  CONSTRAINT [DF_VoyageRent_LCLAmount11_3]  DEFAULT ((0)) FOR [DelayRate]
GO
/****** Object:  Default [DF_VoyageRent_DelayDay1]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageRent_todel] ADD  CONSTRAINT [DF_VoyageRent_DelayDay1]  DEFAULT ((1)) FOR [QuickDay]
GO
/****** Object:  Default [DF_VoyageRent_DelayRate1]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageRent_todel] ADD  CONSTRAINT [DF_VoyageRent_DelayRate1]  DEFAULT ((0)) FOR [QuickRate]
GO
/****** Object:  Default [DF_VoyageRent_TEUEmpty]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageRent_todel] ADD  CONSTRAINT [DF_VoyageRent_TEUEmpty]  DEFAULT ((0)) FOR [TEUEmpty]
GO
/****** Object:  Default [DF_VoyageRent_TEUHeavy]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageRent_todel] ADD  CONSTRAINT [DF_VoyageRent_TEUHeavy]  DEFAULT ((0)) FOR [TEUHeavy]
GO
/****** Object:  Default [DF_VoyageRent_TEUHeavy1_1]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageRent_todel] ADD  CONSTRAINT [DF_VoyageRent_TEUHeavy1_1]  DEFAULT ((0)) FOR [TEUFrost]
GO
/****** Object:  Default [DF_VoyageRent_TEUEmpty1]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageRent_todel] ADD  CONSTRAINT [DF_VoyageRent_TEUEmpty1]  DEFAULT ((0)) FOR [FEUEmpty]
GO
/****** Object:  Default [DF_VoyageRent_TEUHeavy1]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageRent_todel] ADD  CONSTRAINT [DF_VoyageRent_TEUHeavy1]  DEFAULT ((0)) FOR [FEUHeavy]
GO
/****** Object:  Default [DF_VoyageRent_FEUHeavy1_1]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageRent_todel] ADD  CONSTRAINT [DF_VoyageRent_FEUHeavy1_1]  DEFAULT ((0)) FOR [FEUFrost]
GO
/****** Object:  Default [DF_VoyageRent_FEUFrost1]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageRent_todel] ADD  CONSTRAINT [DF_VoyageRent_FEUFrost1]  DEFAULT ((0)) FOR [FEUDanger]
GO
/****** Object:  Default [DF_VoyageRent_FEUEmpty1]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageRent_todel] ADD  CONSTRAINT [DF_VoyageRent_FEUEmpty1]  DEFAULT ((0)) FOR [FFEUEmpty]
GO
/****** Object:  Default [DF_VoyageRent_FEUHeavy1]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageRent_todel] ADD  CONSTRAINT [DF_VoyageRent_FEUHeavy1]  DEFAULT ((0)) FOR [FFEUHeavy]
GO
/****** Object:  Default [DF_VoyageRent_FEUFrost1_1]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageRent_todel] ADD  CONSTRAINT [DF_VoyageRent_FEUFrost1_1]  DEFAULT ((0)) FOR [FFEUFrost]
GO
/****** Object:  Default [DF_VoyageRent_FEUDanger1]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageRent_todel] ADD  CONSTRAINT [DF_VoyageRent_FEUDanger1]  DEFAULT ((0)) FOR [FFEUDanger]
GO
/****** Object:  Default [DF_VoyageRent_FFEUHeavy1]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageRent_todel] ADD  CONSTRAINT [DF_VoyageRent_FFEUHeavy1]  DEFAULT ((0)) FOR [Rest]
GO
/****** Object:  Default [DF_VoyageRent_FFEUHeavy2]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageRent_todel] ADD  CONSTRAINT [DF_VoyageRent_FFEUHeavy2]  DEFAULT ((0)) FOR [EqualTo]
GO
/****** Object:  Default [DF_VoyageRent_Rest1]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageRent_todel] ADD  CONSTRAINT [DF_VoyageRent_Rest1]  DEFAULT ((0)) FOR [TotalNat]
GO
/****** Object:  Default [DF_VoyageRent_EqualTo1]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageRent_todel] ADD  CONSTRAINT [DF_VoyageRent_EqualTo1]  DEFAULT ((0)) FOR [TotalStand]
GO
/****** Object:  Default [DF_VoyageRent_CurrencyOtherID]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageRent_todel] ADD  CONSTRAINT [DF_VoyageRent_CurrencyOtherID]  DEFAULT ((1)) FOR [CurrencyOtherID]
GO
/****** Object:  Default [DF_VoyageRent_OtherFee]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageRent_todel] ADD  CONSTRAINT [DF_VoyageRent_OtherFee]  DEFAULT ((0)) FOR [OtherFee]
GO
/****** Object:  Default [DF_VoyageRent_LCLAmountReal]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageRent_todel] ADD  CONSTRAINT [DF_VoyageRent_LCLAmountReal]  DEFAULT ((0)) FOR [LCLAmountReal]
GO
/****** Object:  Default [DF_VoyageRent_Amount]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageRent_todel] ADD  CONSTRAINT [DF_VoyageRent_Amount]  DEFAULT ((0)) FOR [Amount]
GO
/****** Object:  Default [DF_VoyageRent_Amount1]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageRent_todel] ADD  CONSTRAINT [DF_VoyageRent_Amount1]  DEFAULT ((0)) FOR [DelayAmount]
GO
/****** Object:  Default [DF_VoyageRent_DelayAmount1]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageRent_todel] ADD  CONSTRAINT [DF_VoyageRent_DelayAmount1]  DEFAULT ((0)) FOR [DispatchAmount]
GO
/****** Object:  Default [DF_VoyageLoad_TEUEmpty]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageLoad] ADD  CONSTRAINT [DF_VoyageLoad_TEUEmpty]  DEFAULT ((0)) FOR [TEUEmpty]
GO
/****** Object:  Default [DF_VoyageLoad_TEUHeavy]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageLoad] ADD  CONSTRAINT [DF_VoyageLoad_TEUHeavy]  DEFAULT ((0)) FOR [TEUHeavy]
GO
/****** Object:  Default [DF_VoyageLoad_TEUHeavy1_1]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageLoad] ADD  CONSTRAINT [DF_VoyageLoad_TEUHeavy1_1]  DEFAULT ((0)) FOR [TEUFrost]
GO
/****** Object:  Default [DF_VoyageLoad_TEUEmpty1]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageLoad] ADD  CONSTRAINT [DF_VoyageLoad_TEUEmpty1]  DEFAULT ((0)) FOR [FEUEmpty]
GO
/****** Object:  Default [DF_VoyageLoad_TEUHeavy1]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageLoad] ADD  CONSTRAINT [DF_VoyageLoad_TEUHeavy1]  DEFAULT ((0)) FOR [FEUHeavy]
GO
/****** Object:  Default [DF_VoyageLoad_FEUHeavy1_1]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageLoad] ADD  CONSTRAINT [DF_VoyageLoad_FEUHeavy1_1]  DEFAULT ((0)) FOR [FEUFrost]
GO
/****** Object:  Default [DF_VoyageLoad_FEUFrost1]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageLoad] ADD  CONSTRAINT [DF_VoyageLoad_FEUFrost1]  DEFAULT ((0)) FOR [FEUDanger]
GO
/****** Object:  Default [DF_VoyageLoad_FEUEmpty1]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageLoad] ADD  CONSTRAINT [DF_VoyageLoad_FEUEmpty1]  DEFAULT ((0)) FOR [FFEUEmpty]
GO
/****** Object:  Default [DF_VoyageLoad_FEUHeavy1]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageLoad] ADD  CONSTRAINT [DF_VoyageLoad_FEUHeavy1]  DEFAULT ((0)) FOR [FFEUHeavy]
GO
/****** Object:  Default [DF_VoyageLoad_FEUFrost1_1]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageLoad] ADD  CONSTRAINT [DF_VoyageLoad_FEUFrost1_1]  DEFAULT ((0)) FOR [FFEUFrost]
GO
/****** Object:  Default [DF_VoyageLoad_FEUDanger1]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageLoad] ADD  CONSTRAINT [DF_VoyageLoad_FEUDanger1]  DEFAULT ((0)) FOR [FFEUDanger]
GO
/****** Object:  Default [DF_VoyageLoad_FFEUHeavy1]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageLoad] ADD  CONSTRAINT [DF_VoyageLoad_FFEUHeavy1]  DEFAULT ((0)) FOR [Rest]
GO
/****** Object:  Default [DF_VoyageLoad_FFEUHeavy2]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageLoad] ADD  CONSTRAINT [DF_VoyageLoad_FFEUHeavy2]  DEFAULT ((0)) FOR [EqualTo]
GO
/****** Object:  Default [DF_VoyageLoad_Rest1]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageLoad] ADD  CONSTRAINT [DF_VoyageLoad_Rest1]  DEFAULT ((0)) FOR [TotalNat]
GO
/****** Object:  Default [DF_VoyageLoad_EqualTo1]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageLoad] ADD  CONSTRAINT [DF_VoyageLoad_EqualTo1]  DEFAULT ((0)) FOR [TotalStand]
GO
/****** Object:  Default [DF_VoyageLCL_LCLAmount1]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageLCL] ADD  CONSTRAINT [DF_VoyageLCL_LCLAmount1]  DEFAULT ((0)) FOR [LCLCatalog]
GO
/****** Object:  Default [DF_VoyageLCL_LCLAmount]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageLCL] ADD  CONSTRAINT [DF_VoyageLCL_LCLAmount]  DEFAULT ((0)) FOR [LCLAmount]
GO
/****** Object:  Default [DF_VoyageLCL_LCLAmount11]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageLCL] ADD  CONSTRAINT [DF_VoyageLCL_LCLAmount11]  DEFAULT ((0)) FOR [LCLPrice]
GO
/****** Object:  Default [DF_VoyageLCL_LCLAmount11_1]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageLCL] ADD  CONSTRAINT [DF_VoyageLCL_LCLAmount11_1]  DEFAULT ((1)) FOR [CurrencyID]
GO
/****** Object:  Default [DF_VoyageLCL_LCLAmount11_2]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageLCL] ADD  CONSTRAINT [DF_VoyageLCL_LCLAmount11_2]  DEFAULT ((1)) FOR [DelayDay]
GO
/****** Object:  Default [DF_VoyageLCL_LCLAmount11_3]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageLCL] ADD  CONSTRAINT [DF_VoyageLCL_LCLAmount11_3]  DEFAULT ((0)) FOR [DelayRate]
GO
/****** Object:  Default [DF_VoyageLCL_DelayDay1]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageLCL] ADD  CONSTRAINT [DF_VoyageLCL_DelayDay1]  DEFAULT ((1)) FOR [QuickDay]
GO
/****** Object:  Default [DF_VoyageLCL_DelayRate1]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageLCL] ADD  CONSTRAINT [DF_VoyageLCL_DelayRate1]  DEFAULT ((0)) FOR [QuickRate]
GO
/****** Object:  Default [DF_VoyageLCL_LCLAmountReal]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageLCL] ADD  CONSTRAINT [DF_VoyageLCL_LCLAmountReal]  DEFAULT ((0)) FOR [LCLAmountReal]
GO
/****** Object:  Default [DF_VoyageLCL_Amount1]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageLCL] ADD  CONSTRAINT [DF_VoyageLCL_Amount1]  DEFAULT ((0)) FOR [DelayAmount]
GO
/****** Object:  Default [DF_VoyageLCL_DelayAmount1]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageLCL] ADD  CONSTRAINT [DF_VoyageLCL_DelayAmount1]  DEFAULT ((0)) FOR [DispatchAmount]
GO
/****** Object:  Default [DF_VoyageLCL_Amount]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageLCL] ADD  CONSTRAINT [DF_VoyageLCL_Amount]  DEFAULT ((0)) FOR [Amount]
GO
/****** Object:  Default [DF_VoyageLCL_CreateTime]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageLCL] ADD  CONSTRAINT [DF_VoyageLCL_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
/****** Object:  Default [DF_VoyageFCL_LCLAmount11_1]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageFCL] ADD  CONSTRAINT [DF_VoyageFCL_LCLAmount11_1]  DEFAULT ((1)) FOR [CurrencyID]
GO
/****** Object:  Default [DF_VoyageFCL_Amount]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageFCL] ADD  CONSTRAINT [DF_VoyageFCL_Amount]  DEFAULT ((0)) FOR [Amount]
GO
/****** Object:  Default [DF_VoyageFCL_CreateTime]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageFCL] ADD  CONSTRAINT [DF_VoyageFCL_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
/****** Object:  Default [DF_VoyageFCL_Fee]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageFCL] ADD  CONSTRAINT [DF_VoyageFCL_Fee]  DEFAULT ((0)) FOR [Fee]
GO
/****** Object:  Default [DF_VoyageFCL_Fee1]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageFCL] ADD  CONSTRAINT [DF_VoyageFCL_Fee1]  DEFAULT ((0)) FOR [BeginFee]
GO
/****** Object:  Default [DF_VoyageFCL_BeginFee1]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageFCL] ADD  CONSTRAINT [DF_VoyageFCL_BeginFee1]  DEFAULT ((0)) FOR [EndFee]
GO
/****** Object:  Default [DF_VoyageFCL_EndFee1]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageFCL] ADD  CONSTRAINT [DF_VoyageFCL_EndFee1]  DEFAULT ((0)) FOR [OilFee]
GO
/****** Object:  Default [DF_VoyageFCL_OilFee1]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageFCL] ADD  CONSTRAINT [DF_VoyageFCL_OilFee1]  DEFAULT ((0)) FOR [Tally]
GO
/****** Object:  Default [DF_VoyageFCL_Tally1]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageFCL] ADD  CONSTRAINT [DF_VoyageFCL_Tally1]  DEFAULT ((0)) FOR [Box]
GO
/****** Object:  Default [DF_VoyageFCL_Other]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageFCL] ADD  CONSTRAINT [DF_VoyageFCL_Other]  DEFAULT ((0)) FOR [Other]
GO
/****** Object:  Default [DF_VoyageFCL_Subsidize]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageFCL] ADD  CONSTRAINT [DF_VoyageFCL_Subsidize]  DEFAULT ((0)) FOR [Subsidize]
GO
/****** Object:  Default [DF_VoyageFCL_Subsidize2]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageFCL] ADD  CONSTRAINT [DF_VoyageFCL_Subsidize2]  DEFAULT ((0)) FOR [BookFee]
GO
/****** Object:  Default [DF_VoyageFCL_Subsidize1]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageFCL] ADD  CONSTRAINT [DF_VoyageFCL_Subsidize1]  DEFAULT ((0)) FOR [BranchOther]
GO
/****** Object:  Default [DF_VoyageOther_LCLAmount11_1]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageOther] ADD  CONSTRAINT [DF_VoyageOther_LCLAmount11_1]  DEFAULT ((1)) FOR [CurrencyID]
GO
/****** Object:  Default [DF_VoyageOther_OtherFee]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageOther] ADD  CONSTRAINT [DF_VoyageOther_OtherFee]  DEFAULT ((0)) FOR [Amount]
GO
/****** Object:  Default [DF_VoyageOther_CreateTime]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageOther] ADD  CONSTRAINT [DF_VoyageOther_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
/****** Object:  Default [DF_RentContainer_Amount]    Script Date: 07/27/2014 23:41:05 ******/
ALTER TABLE [dbo].[RentContainer] ADD  CONSTRAINT [DF_RentContainer_Amount]  DEFAULT ((0)) FOR [Amount]
GO
/****** Object:  Default [DF_RentContainer_Price]    Script Date: 07/27/2014 23:41:05 ******/
ALTER TABLE [dbo].[RentContainer] ADD  CONSTRAINT [DF_RentContainer_Price]  DEFAULT ((0)) FOR [Price]
GO
/****** Object:  Default [DF_RentContainer_CreateTime]    Script Date: 07/27/2014 23:41:05 ******/
ALTER TABLE [dbo].[RentContainer] ADD  CONSTRAINT [DF_RentContainer_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
/****** Object:  Default [DF_InsuranceOfFreightTransport_CreateTime]    Script Date: 07/27/2014 23:41:05 ******/
ALTER TABLE [dbo].[InsuranceOfFreightTransport] ADD  CONSTRAINT [DF_InsuranceOfFreightTransport_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
/****** Object:  Default [DF_InsuranceOfFreightTransport_CurrencyID]    Script Date: 07/27/2014 23:41:05 ******/
ALTER TABLE [dbo].[InsuranceOfFreightTransport] ADD  CONSTRAINT [DF_InsuranceOfFreightTransport_CurrencyID]  DEFAULT ((1)) FOR [CurrencyID]
GO
/****** Object:  Default [DF_InsuranceOfFreightTransport_Amount50kilo20feet]    Script Date: 07/27/2014 23:41:05 ******/
ALTER TABLE [dbo].[InsuranceOfFreightTransport] ADD  CONSTRAINT [DF_InsuranceOfFreightTransport_Amount50kilo20feet]  DEFAULT ((0)) FOR [Amount50kilo20feet]
GO
/****** Object:  Default [DF_InsuranceOfFreightTransport_Amount50kilo40feet]    Script Date: 07/27/2014 23:41:05 ******/
ALTER TABLE [dbo].[InsuranceOfFreightTransport] ADD  CONSTRAINT [DF_InsuranceOfFreightTransport_Amount50kilo40feet]  DEFAULT ((0)) FOR [Amount50kilo40feet]
GO
/****** Object:  Default [DF_InsuranceOfFreightTransport_总数]    Script Date: 07/27/2014 23:41:05 ******/
ALTER TABLE [dbo].[InsuranceOfFreightTransport] ADD  CONSTRAINT [DF_InsuranceOfFreightTransport_总数]  DEFAULT ((0)) FOR [总保费]
GO
/****** Object:  Default [DF_InsuranceOfContainer_集装箱数量20]    Script Date: 07/27/2014 23:41:05 ******/
ALTER TABLE [dbo].[InsuranceOfContainer] ADD  CONSTRAINT [DF_InsuranceOfContainer_集装箱数量20]  DEFAULT ((0)) FOR [集装箱数量20]
GO
/****** Object:  Default [DF_InsuranceOfContainer_集装箱数量40]    Script Date: 07/27/2014 23:41:05 ******/
ALTER TABLE [dbo].[InsuranceOfContainer] ADD  CONSTRAINT [DF_InsuranceOfContainer_集装箱数量40]  DEFAULT ((0)) FOR [集装箱数量40]
GO
/****** Object:  Default [DF_InsuranceOfContainer_单价20]    Script Date: 07/27/2014 23:41:05 ******/
ALTER TABLE [dbo].[InsuranceOfContainer] ADD  CONSTRAINT [DF_InsuranceOfContainer_单价20]  DEFAULT ((0)) FOR [单价20]
GO
/****** Object:  Default [DF_InsuranceOfContainer_单价40]    Script Date: 07/27/2014 23:41:05 ******/
ALTER TABLE [dbo].[InsuranceOfContainer] ADD  CONSTRAINT [DF_InsuranceOfContainer_单价40]  DEFAULT ((0)) FOR [单价40]
GO
/****** Object:  Default [DF_InsuranceOfContainer_保额]    Script Date: 07/27/2014 23:41:05 ******/
ALTER TABLE [dbo].[InsuranceOfContainer] ADD  CONSTRAINT [DF_InsuranceOfContainer_保额]  DEFAULT ((0)) FOR [保额]
GO
/****** Object:  Default [DF_InsuranceOfContainer_基本险保险费率]    Script Date: 07/27/2014 23:41:05 ******/
ALTER TABLE [dbo].[InsuranceOfContainer] ADD  CONSTRAINT [DF_InsuranceOfContainer_基本险保险费率]  DEFAULT ((0)) FOR [基本险保险费率]
GO
/****** Object:  Default [DF_InsuranceOfContainer_保费]    Script Date: 07/27/2014 23:41:05 ******/
ALTER TABLE [dbo].[InsuranceOfContainer] ADD  CONSTRAINT [DF_InsuranceOfContainer_保费]  DEFAULT ((0)) FOR [保费]
GO
/****** Object:  Default [DF_OilFee_CreateTime]    Script Date: 07/27/2014 23:41:05 ******/
ALTER TABLE [dbo].[OilFeeReport] ADD  CONSTRAINT [DF_OilFee_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
/****** Object:  Default [DF_OilFee_CheckState]    Script Date: 07/27/2014 23:41:05 ******/
ALTER TABLE [dbo].[OilFeeReport] ADD  CONSTRAINT [DF_OilFee_CheckState]  DEFAULT ((1)) FOR [ReportTypeID]
GO
/****** Object:  Default [DF_OilTypeFee_CurrencyID]    Script Date: 07/27/2014 23:41:05 ******/
ALTER TABLE [dbo].[OilTypeFee] ADD  CONSTRAINT [DF_OilTypeFee_CurrencyID]  DEFAULT ((1)) FOR [CurrencyID]
GO
/****** Object:  Default [DF_OilTypeFee_CreateTime]    Script Date: 07/27/2014 23:41:05 ******/
ALTER TABLE [dbo].[OilTypeFee] ADD  CONSTRAINT [DF_OilTypeFee_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
/****** Object:  Default [DF_InstalmentOfCompensation_ReportType]    Script Date: 07/27/2014 23:41:05 ******/
ALTER TABLE [dbo].[InstalmentOfCompensation] ADD  CONSTRAINT [DF_InstalmentOfCompensation_ReportType]  DEFAULT ((5)) FOR [ReportType]
GO
/****** Object:  Default [DF_FCLCustomer_Fee]    Script Date: 07/27/2014 23:41:05 ******/
ALTER TABLE [dbo].[FCLCustomer] ADD  CONSTRAINT [DF_FCLCustomer_Fee]  DEFAULT ((0)) FOR [Fee]
GO
/****** Object:  Default [DF_FCLCustomer_20gp]    Script Date: 07/27/2014 23:41:05 ******/
ALTER TABLE [dbo].[FCLCustomer] ADD  CONSTRAINT [DF_FCLCustomer_20gp]  DEFAULT ((0)) FOR [gp20]
GO
/****** Object:  Default [DF_FCLCustomer_40gp]    Script Date: 07/27/2014 23:41:05 ******/
ALTER TABLE [dbo].[FCLCustomer] ADD  CONSTRAINT [DF_FCLCustomer_40gp]  DEFAULT ((0)) FOR [gp40]
GO
/****** Object:  Default [DF_FCLCustomer_20gp1]    Script Date: 07/27/2014 23:41:05 ******/
ALTER TABLE [dbo].[FCLCustomer] ADD  CONSTRAINT [DF_FCLCustomer_20gp1]  DEFAULT ((0)) FOR [dp20]
GO
/****** Object:  Default [DF_FCLCustomer_40gp1]    Script Date: 07/27/2014 23:41:05 ******/
ALTER TABLE [dbo].[FCLCustomer] ADD  CONSTRAINT [DF_FCLCustomer_40gp1]  DEFAULT ((0)) FOR [dp40]
GO
/****** Object:  ForeignKey [FK_CommonFee_Currency]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[CommonFee]  WITH CHECK ADD  CONSTRAINT [FK_CommonFee_Currency] FOREIGN KEY([CurrencyID])
REFERENCES [dbo].[Currency] ([ID])
GO
ALTER TABLE [dbo].[CommonFee] CHECK CONSTRAINT [FK_CommonFee_Currency]
GO
/****** Object:  ForeignKey [FK_CommonFee_DimTime]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[CommonFee]  WITH CHECK ADD  CONSTRAINT [FK_CommonFee_DimTime] FOREIGN KEY([DimTimeID])
REFERENCES [dbo].[DimTime] ([ID])
GO
ALTER TABLE [dbo].[CommonFee] CHECK CONSTRAINT [FK_CommonFee_DimTime]
GO
/****** Object:  ForeignKey [FK_CommonFee_FeeCatalog]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[CommonFee]  WITH CHECK ADD  CONSTRAINT [FK_CommonFee_FeeCatalog] FOREIGN KEY([FeeCatalogID])
REFERENCES [dbo].[FeeCatalog] ([ID])
GO
ALTER TABLE [dbo].[CommonFee] CHECK CONSTRAINT [FK_CommonFee_FeeCatalog]
GO
/****** Object:  ForeignKey [FK_CertificateFlee_Currency]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[CertificateFlee]  WITH CHECK ADD  CONSTRAINT [FK_CertificateFlee_Currency] FOREIGN KEY([CurrencyID])
REFERENCES [dbo].[Currency] ([ID])
GO
ALTER TABLE [dbo].[CertificateFlee] CHECK CONSTRAINT [FK_CertificateFlee_Currency]
GO
/****** Object:  ForeignKey [FK_CertificateFlee_DimTime]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[CertificateFlee]  WITH CHECK ADD  CONSTRAINT [FK_CertificateFlee_DimTime] FOREIGN KEY([DimTimeID])
REFERENCES [dbo].[DimTime] ([ID])
GO
ALTER TABLE [dbo].[CertificateFlee] CHECK CONSTRAINT [FK_CertificateFlee_DimTime]
GO
/****** Object:  ForeignKey [FK_BeijianInput_Currency]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[BeijianInput]  WITH CHECK ADD  CONSTRAINT [FK_BeijianInput_Currency] FOREIGN KEY([CurrencyID])
REFERENCES [dbo].[Currency] ([ID])
GO
ALTER TABLE [dbo].[BeijianInput] CHECK CONSTRAINT [FK_BeijianInput_Currency]
GO
/****** Object:  ForeignKey [FK_BeijianInput_DimTime]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[BeijianInput]  WITH CHECK ADD  CONSTRAINT [FK_BeijianInput_DimTime] FOREIGN KEY([DimTimeID])
REFERENCES [dbo].[DimTime] ([ID])
GO
ALTER TABLE [dbo].[BeijianInput] CHECK CONSTRAINT [FK_BeijianInput_DimTime]
GO
/****** Object:  ForeignKey [FK_BeijianInput_ReportType]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[BeijianInput]  WITH CHECK ADD  CONSTRAINT [FK_BeijianInput_ReportType] FOREIGN KEY([ReportTypeID])
REFERENCES [dbo].[ReportType] ([ID])
GO
ALTER TABLE [dbo].[BeijianInput] CHECK CONSTRAINT [FK_BeijianInput_ReportType]
GO
/****** Object:  ForeignKey [FK_InsuranceOfCompensation_Currency]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[InsuranceOfCompensation]  WITH CHECK ADD  CONSTRAINT [FK_InsuranceOfCompensation_Currency] FOREIGN KEY([CurrencyID])
REFERENCES [dbo].[Currency] ([ID])
GO
ALTER TABLE [dbo].[InsuranceOfCompensation] CHECK CONSTRAINT [FK_InsuranceOfCompensation_Currency]
GO
/****** Object:  ForeignKey [FK_InsuranceOfCompensation_DimTime]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[InsuranceOfCompensation]  WITH CHECK ADD  CONSTRAINT [FK_InsuranceOfCompensation_DimTime] FOREIGN KEY([DimTimeID])
REFERENCES [dbo].[DimTime] ([ID])
GO
ALTER TABLE [dbo].[InsuranceOfCompensation] CHECK CONSTRAINT [FK_InsuranceOfCompensation_DimTime]
GO
/****** Object:  ForeignKey [FK_InsuranceOfCompensation_Voyage]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[InsuranceOfCompensation]  WITH CHECK ADD  CONSTRAINT [FK_InsuranceOfCompensation_Voyage] FOREIGN KEY([ShipID])
REFERENCES [dbo].[Ship] ([ID])
GO
ALTER TABLE [dbo].[InsuranceOfCompensation] CHECK CONSTRAINT [FK_InsuranceOfCompensation_Voyage]
GO
/****** Object:  ForeignKey [FK_OilUseBalance_HangciBaseInput]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[OilUseBalance]  WITH CHECK ADD  CONSTRAINT [FK_OilUseBalance_HangciBaseInput] FOREIGN KEY([BaseInputID])
REFERENCES [dbo].[HangciBaseInput] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OilUseBalance] CHECK CONSTRAINT [FK_OilUseBalance_HangciBaseInput]
GO
/****** Object:  ForeignKey [FK_Relation_RoutePort_Port]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[Relation_RoutePort]  WITH CHECK ADD  CONSTRAINT [FK_Relation_RoutePort_Port] FOREIGN KEY([PortID])
REFERENCES [dbo].[Port] ([ID])
GO
ALTER TABLE [dbo].[Relation_RoutePort] CHECK CONSTRAINT [FK_Relation_RoutePort_Port]
GO
/****** Object:  ForeignKey [FK_Relation_RoutePort_PortType]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[Relation_RoutePort]  WITH CHECK ADD  CONSTRAINT [FK_Relation_RoutePort_PortType] FOREIGN KEY([PortTypeID])
REFERENCES [dbo].[PortType] ([ID])
GO
ALTER TABLE [dbo].[Relation_RoutePort] CHECK CONSTRAINT [FK_Relation_RoutePort_PortType]
GO
/****** Object:  ForeignKey [FK_Relation_RoutePort_Route]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[Relation_RoutePort]  WITH CHECK ADD  CONSTRAINT [FK_Relation_RoutePort_Route] FOREIGN KEY([RouteID])
REFERENCES [dbo].[Route] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Relation_RoutePort] CHECK CONSTRAINT [FK_Relation_RoutePort_Route]
GO
/****** Object:  ForeignKey [FK_JianyanInput_Currency]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[JianyanInput]  WITH CHECK ADD  CONSTRAINT [FK_JianyanInput_Currency] FOREIGN KEY([CurrencyID])
REFERENCES [dbo].[Currency] ([ID])
GO
ALTER TABLE [dbo].[JianyanInput] CHECK CONSTRAINT [FK_JianyanInput_Currency]
GO
/****** Object:  ForeignKey [FK_JianyanInput_DimTime]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[JianyanInput]  WITH CHECK ADD  CONSTRAINT [FK_JianyanInput_DimTime] FOREIGN KEY([DimTimeID])
REFERENCES [dbo].[DimTime] ([ID])
GO
ALTER TABLE [dbo].[JianyanInput] CHECK CONSTRAINT [FK_JianyanInput_DimTime]
GO
/****** Object:  ForeignKey [FK_JianyanInput_JianyanInput]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[JianyanInput]  WITH CHECK ADD  CONSTRAINT [FK_JianyanInput_JianyanInput] FOREIGN KEY([ReportTypeID])
REFERENCES [dbo].[ReportType] ([ID])
GO
ALTER TABLE [dbo].[JianyanInput] CHECK CONSTRAINT [FK_JianyanInput_JianyanInput]
GO
/****** Object:  ForeignKey [FK_Invoice_Currency]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Currency] FOREIGN KEY([CurrencyID])
REFERENCES [dbo].[Currency] ([ID])
GO
ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Currency]
GO
/****** Object:  ForeignKey [FK_SampleReport_DimTime]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[SampleReport]  WITH CHECK ADD  CONSTRAINT [FK_SampleReport_DimTime] FOREIGN KEY([DateID])
REFERENCES [dbo].[DimTime] ([ID])
GO
ALTER TABLE [dbo].[SampleReport] CHECK CONSTRAINT [FK_SampleReport_DimTime]
GO
/****** Object:  ForeignKey [FK_SampleReport_ReportType]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[SampleReport]  WITH CHECK ADD  CONSTRAINT [FK_SampleReport_ReportType] FOREIGN KEY([ReportTypeID])
REFERENCES [dbo].[ReportType] ([ID])
GO
ALTER TABLE [dbo].[SampleReport] CHECK CONSTRAINT [FK_SampleReport_ReportType]
GO
/****** Object:  ForeignKey [FK_RentContainerReport_Currency]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[RentContainerReport]  WITH CHECK ADD  CONSTRAINT [FK_RentContainerReport_Currency] FOREIGN KEY([CurrencyID])
REFERENCES [dbo].[Currency] ([ID])
GO
ALTER TABLE [dbo].[RentContainerReport] CHECK CONSTRAINT [FK_RentContainerReport_Currency]
GO
/****** Object:  ForeignKey [FK_VoyageConsume_HangciBaseInput]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[VoyageConsume]  WITH CHECK ADD  CONSTRAINT [FK_VoyageConsume_HangciBaseInput] FOREIGN KEY([BaseInputID])
REFERENCES [dbo].[HangciBaseInput] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VoyageConsume] CHECK CONSTRAINT [FK_VoyageConsume_HangciBaseInput]
GO
/****** Object:  ForeignKey [FK_Voyage_HangciBaseInput]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[Voyage]  WITH NOCHECK ADD  CONSTRAINT [FK_Voyage_HangciBaseInput] FOREIGN KEY([HangciBaseID])
REFERENCES [dbo].[HangciBaseInput] ([ID])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Voyage] NOCHECK CONSTRAINT [FK_Voyage_HangciBaseInput]
GO
/****** Object:  ForeignKey [FK_Voyage_ManagerType]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[Voyage]  WITH CHECK ADD  CONSTRAINT [FK_Voyage_ManagerType] FOREIGN KEY([ManagerTypeID])
REFERENCES [dbo].[ManagerType] ([ID])
GO
ALTER TABLE [dbo].[Voyage] CHECK CONSTRAINT [FK_Voyage_ManagerType]
GO
/****** Object:  ForeignKey [FK_Voyage_Route]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[Voyage]  WITH CHECK ADD  CONSTRAINT [FK_Voyage_Route] FOREIGN KEY([RouteID])
REFERENCES [dbo].[Route] ([ID])
GO
ALTER TABLE [dbo].[Voyage] CHECK CONSTRAINT [FK_Voyage_Route]
GO
/****** Object:  ForeignKey [FK_Voyage_Ship]    Script Date: 07/27/2014 23:41:02 ******/
ALTER TABLE [dbo].[Voyage]  WITH CHECK ADD  CONSTRAINT [FK_Voyage_Ship] FOREIGN KEY([ShipID])
REFERENCES [dbo].[Ship] ([ID])
GO
ALTER TABLE [dbo].[Voyage] CHECK CONSTRAINT [FK_Voyage_Ship]
GO
/****** Object:  ForeignKey [FK_ExchangeRate_Currency]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[ExchangeRate]  WITH CHECK ADD  CONSTRAINT [FK_ExchangeRate_Currency] FOREIGN KEY([CurrencyID])
REFERENCES [dbo].[Currency] ([ID])
GO
ALTER TABLE [dbo].[ExchangeRate] CHECK CONSTRAINT [FK_ExchangeRate_Currency]
GO
/****** Object:  ForeignKey [FK_ExchangeRate_DimTime]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[ExchangeRate]  WITH CHECK ADD  CONSTRAINT [FK_ExchangeRate_DimTime] FOREIGN KEY([DimTimeID])
REFERENCES [dbo].[DimTime] ([ID])
GO
ALTER TABLE [dbo].[ExchangeRate] CHECK CONSTRAINT [FK_ExchangeRate_DimTime]
GO
/****** Object:  ForeignKey [FK_XiuliInput_Currency]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[XiuliInput]  WITH CHECK ADD  CONSTRAINT [FK_XiuliInput_Currency] FOREIGN KEY([CurrencyID])
REFERENCES [dbo].[Currency] ([ID])
GO
ALTER TABLE [dbo].[XiuliInput] CHECK CONSTRAINT [FK_XiuliInput_Currency]
GO
/****** Object:  ForeignKey [FK_XiuliInput_DimTime]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[XiuliInput]  WITH CHECK ADD  CONSTRAINT [FK_XiuliInput_DimTime] FOREIGN KEY([DimTimeID])
REFERENCES [dbo].[DimTime] ([ID])
GO
ALTER TABLE [dbo].[XiuliInput] CHECK CONSTRAINT [FK_XiuliInput_DimTime]
GO
/****** Object:  ForeignKey [FK_XiuliInput_XiuliInput]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[XiuliInput]  WITH CHECK ADD  CONSTRAINT [FK_XiuliInput_XiuliInput] FOREIGN KEY([ReportTypeID])
REFERENCES [dbo].[ReportType] ([ID])
GO
ALTER TABLE [dbo].[XiuliInput] CHECK CONSTRAINT [FK_XiuliInput_XiuliInput]
GO
/****** Object:  ForeignKey [FK_WuliaoInput_Currency]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[WuliaoInput]  WITH CHECK ADD  CONSTRAINT [FK_WuliaoInput_Currency] FOREIGN KEY([CurrencyID])
REFERENCES [dbo].[Currency] ([ID])
GO
ALTER TABLE [dbo].[WuliaoInput] CHECK CONSTRAINT [FK_WuliaoInput_Currency]
GO
/****** Object:  ForeignKey [FK_WuliaoInput_DimTime]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[WuliaoInput]  WITH CHECK ADD  CONSTRAINT [FK_WuliaoInput_DimTime] FOREIGN KEY([DimTimeID])
REFERENCES [dbo].[DimTime] ([ID])
GO
ALTER TABLE [dbo].[WuliaoInput] CHECK CONSTRAINT [FK_WuliaoInput_DimTime]
GO
/****** Object:  ForeignKey [FK_WuliaoInput_ReportType]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[WuliaoInput]  WITH CHECK ADD  CONSTRAINT [FK_WuliaoInput_ReportType] FOREIGN KEY([ReportTypeID])
REFERENCES [dbo].[ReportType] ([ID])
GO
ALTER TABLE [dbo].[WuliaoInput] CHECK CONSTRAINT [FK_WuliaoInput_ReportType]
GO
/****** Object:  ForeignKey [FK_VoyageRent_Currency]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageRent_todel]  WITH CHECK ADD  CONSTRAINT [FK_VoyageRent_Currency] FOREIGN KEY([CurrencyID])
REFERENCES [dbo].[Currency] ([ID])
GO
ALTER TABLE [dbo].[VoyageRent_todel] CHECK CONSTRAINT [FK_VoyageRent_Currency]
GO
/****** Object:  ForeignKey [FK_VoyageLoad_Voyage]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageLoad]  WITH CHECK ADD  CONSTRAINT [FK_VoyageLoad_Voyage] FOREIGN KEY([VoyageID])
REFERENCES [dbo].[Voyage] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VoyageLoad] CHECK CONSTRAINT [FK_VoyageLoad_Voyage]
GO
/****** Object:  ForeignKey [FK_VoyageLCL_Currency]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageLCL]  WITH CHECK ADD  CONSTRAINT [FK_VoyageLCL_Currency] FOREIGN KEY([CurrencyID])
REFERENCES [dbo].[Currency] ([ID])
GO
ALTER TABLE [dbo].[VoyageLCL] CHECK CONSTRAINT [FK_VoyageLCL_Currency]
GO
/****** Object:  ForeignKey [FK_VoyageLCL_Voyage]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageLCL]  WITH CHECK ADD  CONSTRAINT [FK_VoyageLCL_Voyage] FOREIGN KEY([VoyageID])
REFERENCES [dbo].[Voyage] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VoyageLCL] CHECK CONSTRAINT [FK_VoyageLCL_Voyage]
GO
/****** Object:  ForeignKey [FK_VoyageFCL_Currency]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageFCL]  WITH CHECK ADD  CONSTRAINT [FK_VoyageFCL_Currency] FOREIGN KEY([CurrencyID])
REFERENCES [dbo].[Currency] ([ID])
GO
ALTER TABLE [dbo].[VoyageFCL] CHECK CONSTRAINT [FK_VoyageFCL_Currency]
GO
/****** Object:  ForeignKey [FK_VoyageFCL_Voyage]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageFCL]  WITH CHECK ADD  CONSTRAINT [FK_VoyageFCL_Voyage] FOREIGN KEY([VoyageID])
REFERENCES [dbo].[Voyage] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[VoyageFCL] CHECK CONSTRAINT [FK_VoyageFCL_Voyage]
GO
/****** Object:  ForeignKey [FK_VoyageOther_Currency]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageOther]  WITH CHECK ADD  CONSTRAINT [FK_VoyageOther_Currency] FOREIGN KEY([CurrencyID])
REFERENCES [dbo].[Currency] ([ID])
GO
ALTER TABLE [dbo].[VoyageOther] CHECK CONSTRAINT [FK_VoyageOther_Currency]
GO
/****** Object:  ForeignKey [FK_VoyageOther_Voyage]    Script Date: 07/27/2014 23:41:04 ******/
ALTER TABLE [dbo].[VoyageOther]  WITH CHECK ADD  CONSTRAINT [FK_VoyageOther_Voyage] FOREIGN KEY([VoyageID])
REFERENCES [dbo].[Voyage] ([ID])
GO
ALTER TABLE [dbo].[VoyageOther] CHECK CONSTRAINT [FK_VoyageOther_Voyage]
GO
/****** Object:  ForeignKey [FK_RentContainer_RentContainerReport]    Script Date: 07/27/2014 23:41:05 ******/
ALTER TABLE [dbo].[RentContainer]  WITH CHECK ADD  CONSTRAINT [FK_RentContainer_RentContainerReport] FOREIGN KEY([ReportID])
REFERENCES [dbo].[RentContainerReport] ([ID])
GO
ALTER TABLE [dbo].[RentContainer] CHECK CONSTRAINT [FK_RentContainer_RentContainerReport]
GO
/****** Object:  ForeignKey [FK_InsuranceOfFreightTransport_Currency]    Script Date: 07/27/2014 23:41:05 ******/
ALTER TABLE [dbo].[InsuranceOfFreightTransport]  WITH CHECK ADD  CONSTRAINT [FK_InsuranceOfFreightTransport_Currency] FOREIGN KEY([CurrencyID])
REFERENCES [dbo].[Currency] ([ID])
GO
ALTER TABLE [dbo].[InsuranceOfFreightTransport] CHECK CONSTRAINT [FK_InsuranceOfFreightTransport_Currency]
GO
/****** Object:  ForeignKey [FK_InsuranceOfFreightTransport_DimTime]    Script Date: 07/27/2014 23:41:05 ******/
ALTER TABLE [dbo].[InsuranceOfFreightTransport]  WITH CHECK ADD  CONSTRAINT [FK_InsuranceOfFreightTransport_DimTime] FOREIGN KEY([DimTimeID])
REFERENCES [dbo].[DimTime] ([ID])
GO
ALTER TABLE [dbo].[InsuranceOfFreightTransport] CHECK CONSTRAINT [FK_InsuranceOfFreightTransport_DimTime]
GO
/****** Object:  ForeignKey [FK_InsuranceOfFreightTransport_Voyage]    Script Date: 07/27/2014 23:41:05 ******/
ALTER TABLE [dbo].[InsuranceOfFreightTransport]  WITH CHECK ADD  CONSTRAINT [FK_InsuranceOfFreightTransport_Voyage] FOREIGN KEY([VoyageID])
REFERENCES [dbo].[Voyage] ([ID])
GO
ALTER TABLE [dbo].[InsuranceOfFreightTransport] CHECK CONSTRAINT [FK_InsuranceOfFreightTransport_Voyage]
GO
/****** Object:  ForeignKey [FK_InsuranceOfContainer_Currency]    Script Date: 07/27/2014 23:41:05 ******/
ALTER TABLE [dbo].[InsuranceOfContainer]  WITH CHECK ADD  CONSTRAINT [FK_InsuranceOfContainer_Currency] FOREIGN KEY([CurrencyID])
REFERENCES [dbo].[Currency] ([ID])
GO
ALTER TABLE [dbo].[InsuranceOfContainer] CHECK CONSTRAINT [FK_InsuranceOfContainer_Currency]
GO
/****** Object:  ForeignKey [FK_InsuranceOfContainer_DimTime]    Script Date: 07/27/2014 23:41:05 ******/
ALTER TABLE [dbo].[InsuranceOfContainer]  WITH CHECK ADD  CONSTRAINT [FK_InsuranceOfContainer_DimTime] FOREIGN KEY([DimTimeID])
REFERENCES [dbo].[DimTime] ([ID])
GO
ALTER TABLE [dbo].[InsuranceOfContainer] CHECK CONSTRAINT [FK_InsuranceOfContainer_DimTime]
GO
/****** Object:  ForeignKey [FK_InsuranceOfContainer_ExchangeRate]    Script Date: 07/27/2014 23:41:05 ******/
ALTER TABLE [dbo].[InsuranceOfContainer]  WITH NOCHECK ADD  CONSTRAINT [FK_InsuranceOfContainer_ExchangeRate] FOREIGN KEY([ExchangeRateID])
REFERENCES [dbo].[ExchangeRate] ([ID])
NOT FOR REPLICATION
GO
ALTER TABLE [dbo].[InsuranceOfContainer] NOCHECK CONSTRAINT [FK_InsuranceOfContainer_ExchangeRate]
GO
/****** Object:  ForeignKey [FK_OilFeeReport_Voyage]    Script Date: 07/27/2014 23:41:05 ******/
ALTER TABLE [dbo].[OilFeeReport]  WITH CHECK ADD  CONSTRAINT [FK_OilFeeReport_Voyage] FOREIGN KEY([VoyageID])
REFERENCES [dbo].[Voyage] ([ID])
GO
ALTER TABLE [dbo].[OilFeeReport] CHECK CONSTRAINT [FK_OilFeeReport_Voyage]
GO
/****** Object:  ForeignKey [FK_OilTypeFee_Currency]    Script Date: 07/27/2014 23:41:05 ******/
ALTER TABLE [dbo].[OilTypeFee]  WITH CHECK ADD  CONSTRAINT [FK_OilTypeFee_Currency] FOREIGN KEY([CurrencyID])
REFERENCES [dbo].[Currency] ([ID])
GO
ALTER TABLE [dbo].[OilTypeFee] CHECK CONSTRAINT [FK_OilTypeFee_Currency]
GO
/****** Object:  ForeignKey [FK_OilTypeFee_OilFeeReport]    Script Date: 07/27/2014 23:41:05 ******/
ALTER TABLE [dbo].[OilTypeFee]  WITH CHECK ADD  CONSTRAINT [FK_OilTypeFee_OilFeeReport] FOREIGN KEY([OilFeeReportID])
REFERENCES [dbo].[OilFeeReport] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OilTypeFee] CHECK CONSTRAINT [FK_OilTypeFee_OilFeeReport]
GO
/****** Object:  ForeignKey [FK_OilTypeFee_OilType]    Script Date: 07/27/2014 23:41:05 ******/
ALTER TABLE [dbo].[OilTypeFee]  WITH CHECK ADD  CONSTRAINT [FK_OilTypeFee_OilType] FOREIGN KEY([OilTypeID])
REFERENCES [dbo].[OilType] ([ID])
GO
ALTER TABLE [dbo].[OilTypeFee] CHECK CONSTRAINT [FK_OilTypeFee_OilType]
GO
/****** Object:  ForeignKey [FK_OilTypeFee_Port]    Script Date: 07/27/2014 23:41:05 ******/
ALTER TABLE [dbo].[OilTypeFee]  WITH CHECK ADD  CONSTRAINT [FK_OilTypeFee_Port] FOREIGN KEY([PortID])
REFERENCES [dbo].[Port] ([ID])
GO
ALTER TABLE [dbo].[OilTypeFee] CHECK CONSTRAINT [FK_OilTypeFee_Port]
GO
/****** Object:  ForeignKey [FK_InstalmentOfCompensation_Currency]    Script Date: 07/27/2014 23:41:05 ******/
ALTER TABLE [dbo].[InstalmentOfCompensation]  WITH CHECK ADD  CONSTRAINT [FK_InstalmentOfCompensation_Currency] FOREIGN KEY([CurrencyID])
REFERENCES [dbo].[Currency] ([ID])
GO
ALTER TABLE [dbo].[InstalmentOfCompensation] CHECK CONSTRAINT [FK_InstalmentOfCompensation_Currency]
GO
/****** Object:  ForeignKey [FK_InstalmentOfCompensation_InsuranceOfCompensation]    Script Date: 07/27/2014 23:41:05 ******/
ALTER TABLE [dbo].[InstalmentOfCompensation]  WITH CHECK ADD  CONSTRAINT [FK_InstalmentOfCompensation_InsuranceOfCompensation] FOREIGN KEY([CompensationID])
REFERENCES [dbo].[InsuranceOfContainer] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InstalmentOfCompensation] CHECK CONSTRAINT [FK_InstalmentOfCompensation_InsuranceOfCompensation]
GO
/****** Object:  ForeignKey [FK_FCLCustomer_FCL]    Script Date: 07/27/2014 23:41:05 ******/
ALTER TABLE [dbo].[FCLCustomer]  WITH CHECK ADD  CONSTRAINT [FK_FCLCustomer_FCL] FOREIGN KEY([FCLID])
REFERENCES [dbo].[VoyageFCL] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FCLCustomer] CHECK CONSTRAINT [FK_FCLCustomer_FCL]
GO
/****** Object:  ForeignKey [FK_Container_InsuranceOfFreightTransport]    Script Date: 07/27/2014 23:41:05 ******/
ALTER TABLE [dbo].[Container]  WITH CHECK ADD  CONSTRAINT [FK_Container_InsuranceOfFreightTransport] FOREIGN KEY([InsuranceID])
REFERENCES [dbo].[InsuranceOfFreightTransport] ([ID])
GO
ALTER TABLE [dbo].[Container] CHECK CONSTRAINT [FK_Container_InsuranceOfFreightTransport]
GO
