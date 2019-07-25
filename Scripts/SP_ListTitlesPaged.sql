USE [pubs]
GO

/****** Object:  StoredProcedure [dbo].[SP_ListTitlesPaged]    Script Date: 3/4/2015 4:34:22 PM ******/
DROP PROCEDURE [dbo].[SP_ListTitlesPaged]
GO

/****** Object:  StoredProcedure [dbo].[SP_ListTitlesPaged]    Script Date: 3/4/2015 4:34:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_ListTitlesPaged] 
	@startRow int,
	@numberOfRows int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT * FROM
	(
		SELECT [title_id]
			,[title]
		    ,[type]
		    ,[pub_id]
		    ,[price]
		    ,[advance]
		    ,[royalty]
		    ,[ytd_sales]
		    ,[notes]
		    ,[pubdate]
			,ROW_NUMBER() OVER(ORDER BY [title]) AS rowNum
		  FROM [dbo].[titles]
	) AS T
	WHERE rowNum BETWEEN @startRow AND (@startRow + @numberOfRows - 1)

	SELECT COUNT(1) AS NumberOfTitles
	FROM [dbo].[titles]

END

GO


