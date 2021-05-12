IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pCompanyInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[pCompanyInsert]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
	
CREATE PROCEDURE [dbo].[pCompanyInsert]
	@Name varchar(100),
	@Exchange varchar(100),
	@ISIN varchar(255) ,
	@Ticker varchar(100),
	@Website varchar(255) NULL
AS

INSERT INTO [dbo].[Company](
	[Name],
	[Exchange],
	[ISIN],
	[Ticker],
	[Website]
)
VALUES(
	@Name,
	@Exchange,
	@ISIN,
	@Ticker,
	@Website
)

SELECT SCOPE_IDENTITY();

GO
