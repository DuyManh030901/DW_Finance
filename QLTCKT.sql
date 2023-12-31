drop database HTTTQL;
GO
/****** Object:  Table [dbo].[BalanceRec]    Script Date: 4/18/2023 9:04:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BalanceRec](
	[ID] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL ,
	[Content] [varchar](255) NULL,
	[Amount] [varchar](255) NULL,
	[Term] [varchar](255) NULL,
	[UID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Branch]    Script Date: 4/18/2023 9:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Branch](
	[BraID] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Phone] [varchar](255) NULL,
	[Location] [varchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BuyBill]    Script Date: 4/18/2023 9:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BuyBill](
	[DocID] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Payment] [float] NULL,
	[BraID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 4/18/2023 9:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DPMID] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Name] [varchar](255) NULL,
	[NumOfEmployees] [varchar](255) NULL,
	[BraID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document]    Script Date: 4/18/2023 9:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document](
	[DocID] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Name] [varchar](255) NULL,
	[Type] [varchar](255) NULL,
	[Content] [varchar](255) NULL,
	[Amount] [float] NULL,
	[Time] [date] NULL,
	[UID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 4/18/2023 9:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmpID] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Name] [varchar](255) NULL,
	[Phone] [varchar](255) NULL,
	[Email] [varchar](255) NULL,
	[Address] [varchar](255) NULL,
	[Sex] [nchar](10) NULL,
	[CardID] [int] NOT NULL,
	[Bank] [varchar](255) NULL,
	[TaxID] [int] NOT NULL,
	[DPMID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvestmentRec]    Script Date: 4/18/2023 9:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvestmentRec](
	[ID] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Type] [varchar](255) NULL,
	[Time] [date] NULL,
	[Desc] [varchar](255) NULL,
	[Amount] [float] NULL,
	[UID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LendPayment]    Script Date: 4/18/2023 9:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LendPayment](
	[LendPaymentID] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[InterestAmt] [float] NULL,
	[PaymentAmt] [varchar](255) NULL,
	[Time] [date] NULL,
	[Payment] [varchar](255) NULL,
	[Account] [varchar](255) NULL,
	[AccountDR] [varchar](255) NULL,
	[AccountCR] [varchar](255) NULL,
	[LendRecID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LendRec]    Script Date: 4/18/2023 9:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LendRec](
	[LendRecID] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Desc] [varchar](255) NULL,
	[Amount] [float] NULL,
	[Time] [date] NULL,
	[InterestRate] [float] NULL,
	[Expired] [varchar](255) NULL,
	[RecentAmt] [float] NULL,
	[Account] [varchar](255) NULL,
	[AccountDR] [varchar](255) NULL,
	[AccountCR] [varchar](255) NULL,
	[UID] [int] NOT NULL,
	[PnID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoanPayment]    Script Date: 4/18/2023 9:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoanPayment](
	[LoanPaymentID] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[InterestAmt] [float] NULL,
	[PaymentAmt] [varchar](255) NULL,
	[Time] [date] NULL,
	[Payment] [varchar](255) NULL,
	[Account] [varchar](255) NULL,
	[AccountDR] [varchar](255) NULL,
	[AccountCR] [varchar](255) NULL,
	[LoanRecID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoanRec]    Script Date: 4/18/2023 9:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoanRec](
	[LoanRecID] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Desc] [varchar](255) NULL,
	[Amount] [float] NULL,
	[time] [date] NULL,
	[InterestRate] [float] NULL,
	[Expried] [varchar](255) NULL,
	[RecentAmt] [float] NULL,
	[Account] [varchar](255) NULL,
	[AccountDR] [varchar](255) NULL,
	[AccountCR] [varchar](255) NULL,
	[UID] [int] NOT NULL,
	[PnID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Log]    Script Date: 4/18/2023 9:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log](
	[ID] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Name] [varchar](255) NULL,
	[Action] [varchar](255) NULL,
	[Time] [date] NULL,
	[UID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Partner]    Script Date: 4/18/2023 9:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Partner](
	[PnID] [int] IDENTITY(1,1) PRIMARY KEY not NULL,
	[Name] [varchar](255) NULL,
	[TaxID] [int] NULL,
	[Address] [varchar](255) NULL,
	[Desc] [varchar](255) NULL,
	[Phone] [varchar](255) NULL,
	[Email] [varchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 4/18/2023 9:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProID] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Name] [varchar](255) NULL,
	[CtrPrice] [float] NULL,
	[InPrice] [float] NULL,
	[OutPrice] [float] NULL,
	[NumInBranch] [int] NULL,
	[PnID] [int] NOT NULL,
	[BraID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_BuyBill]    Script Date: 4/18/2023 9:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_BuyBill](
	[ProID] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[DocID] [int] NOT NULL,
	[Num] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_SellBill]    Script Date: 4/18/2023 9:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_SellBill](
	[ProID] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[DocID] [int] NOT NULL,
	[Num] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Receipt]    Script Date: 4/18/2023 9:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receipt](
	[DocID] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[ReceiptType] [varchar](255) NULL,
	[Desc] [varchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Salary]    Script Date: 4/18/2023 9:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salary](
	[ID] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Deduction] [float] NULL,
	[Sum] [float] NULL,
	[DayOfNum] [float] NULL,
	[Reward] [float] NULL,
	[EmpID] [int] NOT NULL,
	[STID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalaryTable]    Script Date: 4/18/2023 9:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalaryTable](
	[STID] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[total] [float] NULL,
	[Note] [varchar](255) NULL,
	[Time] [date] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SellBill]    Script Date: 4/18/2023 9:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SellBill](
	[DocID] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Customer] [varchar](255) NULL,
	[CusPhone] [varchar](255) NULL,
	[CusAddress] [varchar](255) NULL,
	[Payment] [float] NULL,
	[TaxID] [int] NOT NULL,
	[BraID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Summary]    Script Date: 4/18/2023 9:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Summary](
	[ID] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Term] [varchar](255) NULL,
	[Detail] [varchar](255) NULL,
	[Balance] [varchar](255) NULL,
	[TaxID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tax]    Script Date: 4/18/2023 9:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tax](
	[TaxID] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[TaxType] [varchar](255) NULL,
	[Percentage] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 4/18/2023 9:04:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UID] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Usename] [varchar](255) NULL,
	[password] [varchar](255) NULL,
	[Phone] [varchar](255) NULL,
	[Email] [varchar](255) NULL,
	[Address] [varchar](255) NULL,
	[Sex] [nchar](10) NULL,
	[BraID] [int] NOT NULL
) ON [PRIMARY]
GO
