USE [pubs]
GO

/****** Object:  StoredProcedure [dbo].[SP_ListAuthorsPaged]    Script Date: 3/4/2015 1:39:34 PM ******/
DROP PROCEDURE [dbo].[SP_ListAuthorsPaged]
GO

/****** Object:  StoredProcedure [dbo].[SP_ListAuthorsPaged]    Script Date: 3/4/2015 1:39:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[SP_ListAuthorsPaged]
	@startRow int,
	@numberOfRows int,
	@sortBy varchar(30),
	@sortDirection varchar(4)
AS
BEGIN

	SET NOCOUNT ON;

	SELECT * FROM
	(
		SELECT [au_id]
		      ,[au_lname]
		      ,[au_fname]
		      ,[phone]
		      ,[address]
		      ,[city]
		      ,[state]
		      ,[zip]
		      ,[contract]
			  ,ROW_NUMBER() OVER(ORDER BY CASE WHEN @sortBy = 'Name' AND @sortDirection = 'ASC' THEN ([au_lname] + ' ' + [au_fname]) END,
				CASE WHEN @sortBy = 'Name' AND @sortDirection = 'DESC' THEN ([au_lname] + ' ' + [au_fname]) END DESC,
				CASE WHEN @sortBy = 'AuthorID' AND @sortDirection = 'ASC' THEN [au_id] END,
				CASE WHEN @sortBy = 'AuthorID' AND @sortDirection = 'DESC' THEN [au_id] END DESC,
				CASE WHEN @sortBy = 'City' AND @sortDirection = 'ASC' THEN [city] END,
				CASE WHEN @sortBy = 'City' AND @sortDirection = 'DESC' THEN [city] END DESC,
				CASE WHEN @sortBy = 'State' AND @sortDirection = 'ASC' THEN [state] END,
				CASE WHEN @sortBy = 'State' AND @sortDirection = 'DESC' THEN [state] END DESC,
				CASE WHEN @sortBy = 'HasContract' AND @sortDirection = 'ASC' THEN [contract] END,
				CASE WHEN @sortBy = 'HasContract' AND @sortDirection = 'ASC' THEN [contract] END DESC) AS rowNum
		  FROM [dbo].[authors]
	  ) AS A
	  WHERE rowNum BETWEEN @startRow AND (@startRow + @numberOfRows - 1)

	 SELECT COUNT(1) AS NumberOfAuthors
		FROM [dbo].[authors]

END


GO


