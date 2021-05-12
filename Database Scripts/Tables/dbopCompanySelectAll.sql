IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pCompanySelectAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[pCompanySelectAll]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
	
CREATE PROCEDURE [dbo].[pCompanySelectAll]

AS

SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

SELECT
	[Name],
	[Exchange],
	[ISIN],
	[Ticker],
	[Website]
FROM
	[dbo].[Company]

GO
