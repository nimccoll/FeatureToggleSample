USE [pubs]
GO

/****** Object:  StoredProcedure [dbo].[SP_ListPublishersPaged]    Script Date: 3/4/2015 4:34:11 PM ******/
DROP PROCEDURE [dbo].[SP_ListPublishersPaged]
GO

/****** Object:  StoredProcedure [dbo].[SP_ListPublishersPaged]    Script Date: 3/4/2015 4:34:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_ListPublishersPaged] 
	@startRow int,
	@numberOfRows int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT * FROM
	(
		SELECT [pub_id]
			,[pub_name]
			,[city]
			,[state]
			,[country]
			,ROW_NUMBER() OVER(ORDER BY [pub_name]) AS rowNum
		FROM [dbo].[publishers]
	) AS P
	WHERE rowNum BETWEEN @startRow AND (@startRow + @numberOfRows - 1)

	SELECT COUNT(1) AS NumberOfPublishers
	FROM [dbo].[publishers]

END

GO


