CREATE DATABASE [CardValidator]
GO

USE [CardValidator]
GO
/****** Object:  Table [dbo].[Cards]    Script Date: 6/20/2018 2:30:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cards](
	[CardId] [int] IDENTITY(1,1) NOT NULL,
	[CardNumber] [numeric](16, 0) NOT NULL,
 CONSTRAINT [PK_Cards] PRIMARY KEY CLUSTERED 
(
	[CardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CardTypes]    Script Date: 6/20/2018 2:30:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CardTypes](
	[CardTypeId] [int] IDENTITY(1,1) NOT NULL,
	[CardTypeName] [nvarchar](255) NOT NULL,
	[ValidateRegex] [nvarchar](255) NULL,
	[ExpiryYearCheckMethod] [nvarchar](255) NULL,
	[ExpiryYearCheckType] [nvarchar](255) NULL,
	[RuleOrder] [int] NOT NULL,
 CONSTRAINT [PK_CardTypes] PRIMARY KEY CLUSTERED 
(
	[CardTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Cards] ON 

GO
INSERT [dbo].[Cards] ([CardId], [CardNumber]) VALUES (2, CAST(4848123456789123 AS Numeric(16, 0)))
GO
INSERT [dbo].[Cards] ([CardId], [CardNumber]) VALUES (3, CAST(5858123456789123 AS Numeric(16, 0)))
GO
INSERT [dbo].[Cards] ([CardId], [CardNumber]) VALUES (4, CAST(312345678912345 AS Numeric(16, 0)))
GO
INSERT [dbo].[Cards] ([CardId], [CardNumber]) VALUES (5, CAST(4123456789123456 AS Numeric(16, 0)))
GO
SET IDENTITY_INSERT [dbo].[Cards] OFF
GO
SET IDENTITY_INSERT [dbo].[CardTypes] ON 

GO
INSERT [dbo].[CardTypes] ([CardTypeId], [CardTypeName], [ValidateRegex], [ExpiryYearCheckMethod], [ExpiryYearCheckType], [RuleOrder]) VALUES (1, N'Visa', N'^4[0-9]{15}$', N'IsLeapYear', N'System.DateTime', 1)
GO
INSERT [dbo].[CardTypes] ([CardTypeId], [CardTypeName], [ValidateRegex], [ExpiryYearCheckMethod], [ExpiryYearCheckType], [RuleOrder]) VALUES (2, N'MasterCard', N'^5[0-9]{15}$', N'IsPrime', N'CardValidator2.Business.Utilities.MathUtility', 2)
GO
INSERT [dbo].[CardTypes] ([CardTypeId], [CardTypeName], [ValidateRegex], [ExpiryYearCheckMethod], [ExpiryYearCheckType], [RuleOrder]) VALUES (3, N'Amex', N'^3[0-9]{14}$', N'SKIP', NULL, 3)
GO
INSERT [dbo].[CardTypes] ([CardTypeId], [CardTypeName], [ValidateRegex], [ExpiryYearCheckMethod], [ExpiryYearCheckType], [RuleOrder]) VALUES (4, N'JCB', N'^3[0-9]{15}$', N'SKIP', NULL, 4)
GO
INSERT [dbo].[CardTypes] ([CardTypeId], [CardTypeName], [ValidateRegex], [ExpiryYearCheckMethod], [ExpiryYearCheckType], [RuleOrder]) VALUES (5, N'Unkown', NULL, NULL, NULL, 5)
GO
SET IDENTITY_INSERT [dbo].[CardTypes] OFF
GO
/****** Object:  StoredProcedure [dbo].[CardExists]    Script Date: 6/20/2018 2:30:12 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Anh Truong - hoanganh727018@gmail.com
-- Create date: 2018-06-19
-- Description:	Check existence of card number
-- =============================================
CREATE PROCEDURE [dbo].[CardExists] 
	-- Add the parameters for the stored procedure here
	@CardNumber NUMERIC(16,0)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	SELECT TOP 1 CardId FROM [Cards] WHERE CardNumber = @CardNumber
	RETURN 
END

GO
