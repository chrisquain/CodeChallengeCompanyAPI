IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pCompanyUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[pCompanyUpdate]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
	
CREATE PROCEDURE [dbo].[pCompanyUpdate]
	@CompanyID int,
	@Name varchar(100) NULL,
	@Exchange varchar(100) NULL,
	@ISIN varchar(255) NULL,
	@Ticker varchar(100) NULL,
	@Website varchar(255) NULL
AS

UPDATE [dbo].[Company]
SET
	[Name] = @Name ,
	[Exchange] = @Exchange,
	[ISIN] = @ISIN,
	[Ticker] = @Ticker,
	[Website] = @Website
WHERE
	CompanyID = @CompanyID
GO
