IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pCompanySelectByISIN]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[pCompanySelectByISIN]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
	
CREATE PROCEDURE [dbo].[pCompanySelectByISIN]
	@ISIN varchar(255)
AS

SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

SELECT
	[CompanyID],
	[Name],
	[Exchange],
	[ISIN],
	[Ticker],
	[Website]
FROM
	[dbo].[Company]
WHERE
	ISIN = @ISIN
GO
